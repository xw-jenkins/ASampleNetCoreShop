using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Dtos;
using ASample.NetCore.Identity.Api.Queries;
using ASample.NetCore.Identity.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _userRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("paged")]
        public async Task<string> QueryPagedAsync([FromQuery] UserParam param)
        {
            var filter = param.SearchLambda<User, UserParam>();
            var result = await _userRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new LayuiTableDto<User>
            {
                Code = "0",
                Msg = "获取数据成功",
                Count = result.TotalResults,
                Data = result.Items.ToList()
            };
            var json = pageData.ToString();
            return json;
        }

        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(User command)
        {
            await _userRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(UserDto dto)
        {
            var entity = await _userRepository.GetAsync(dto.Id);
            var newEntity = dto.EntityMap(entity);
            await _userRepository.UpdateAsync(newEntity);

            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete]
        public async Task<ApiRequestResult> DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}