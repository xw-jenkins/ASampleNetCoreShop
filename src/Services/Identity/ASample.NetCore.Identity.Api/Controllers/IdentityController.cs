using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ASample.NetCore.Authentications;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Dtos;
using ASample.NetCore.Identity.Api.Messages;
using ASample.NetCore.Identity.Api.Repositories;
using ASample.NetCore.Identity.Api.Services;
using ASample.NetCore.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IASampleRedisCache _cache;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IIdentityServices _identityServices;
        private IHttpContextAccessor _accessor;
        private IConfiguration _configuration;

        public IdentityController(IIdentityServices identityServices, IASampleRedisCache cache, IUserLoginRepository userLoginRepository = null, IHttpContextAccessor accessor = null, IConfiguration configuration = null)
        {
            _identityServices = identityServices;
            _cache = cache;
            _userLoginRepository = userLoginRepository;
            _accessor = accessor;
            _configuration = configuration;
        }

        [HttpPost("sign-in")]
        public async Task<ApiRequestResult> SignIn([FromBody]SignInCommand command)
        {
            try
            {
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var result = await _identityServices.SignInAsync(command.UserName, command.Password, UserType.Member);
                var redisExpireTime = _configuration.GetSection("redis:expiryMinutes").Value.ToString();
                var expirtime = new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(Convert.ToInt32(redisExpireTime))
                };
                await _cache.SetStringAsync(result.AccessToken, JsonConvert.SerializeObject(result), expirtime);
                var data = new { tokenHead = "Bearer", token = result.AccessToken };
                //添加登录记录
                await _userLoginRepository.AddAsync(new UserLogin
                {
                    UserId = Guid.Parse(result.Id),
                    LoginProvider = "ManageSystem",
                    ProviderDisplayName = "管理系统",
                    ProviderKey = Guid.NewGuid().ToString(),
                    LoginIp = ip
                });
                return ApiRequestResult.Success(data, "登录成功");
            }
            catch (Exception ex)
            {
                return ApiRequestResult.Error("账号密码错误,请重新输入");
                throw ex;
            }
        }


        [HttpPost("sign-out")]
        public async Task<ApiRequestResult> SignOut()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            await _cache.RemoveAsync(token);
            await _identityServices.SignOutAsync();
            return ApiRequestResult.Success("退出登录成功");
        }
        

        [HttpPost("sign-up")]
        public async Task <ApiRequestResult> SignUpAsync(SignUpCommand command)
        {
            await _identityServices.SignUpAsync(command.Email, command.PhoneNumber,
                command.UserName, command.Password, UserType.Member);
            return ApiRequestResult.Success("注册成功");
        }

        [HttpGet("info")]
        [JwtAuth]
        public async Task<ApiRequestResult> GetAsync()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var key = token.Replace("Bearer", "").Trim();
            var jsonRedis = await _cache.GetStringAsync(key);
            if(jsonRedis.IsNullOrEmpty())
                return ApiRequestResult.Error("登录已过期",HttpStatusCode.Unauthorized);
            var jsonWebToken = JsonConvert.DeserializeObject<JsonWebToken>(jsonRedis);
            var accountUser = await _identityServices.GetAsync(Guid.Parse(jsonWebToken.Id));
            var roles = new List<string>
            {
                "TEST"
            };
            var userInfo = new UserInfoDto
            {
                UserName = accountUser.UserName,
                Roles = roles,
            };
            return ApiRequestResult.Success(userInfo, "");
        }

        [HttpPost("me/password")]
        [JwtAuth]
        public async Task<ApiRequestResult> ChangePasswordAsync(ChangePasswordCommand command)
        {
            await _identityServices.ChangPassword(command.UserId, command.CurrentPwd, command.NewPwd);
            return ApiRequestResult.Success("密码修改成功");
        }
    }
}