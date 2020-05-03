using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using ASample.NetCore.Authentications;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Dtos;
using ASample.NetCore.Identity.Api.Messages;
using ASample.NetCore.Identity.Api.Queries;
using ASample.NetCore.Identity.Api.Repositories;
using ASample.NetCore.Identity.Api.Services;
using ASample.NetCore.Redis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/admin")]
    [ApiController]
    [JwtAuth]
    public class AdminController : ControllerBase
    {
        private readonly IIdentityServices _identityServices;
        private readonly IMenuRepository _menuRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IASampleRedisCache _cache;
        private readonly IRefreshTokenServices _refreshTokenServices;
        private readonly UserManager<User> _userManager;


        public AdminController(IIdentityServices identityServices,
            IRefreshTokenServices refreshTokenServices,
            IMenuRepository menuRepository,
            IRoleRepository roleRepository, 
            UserManager<User> userManager,
            IASampleRedisCache cache, 
            IUserRepository userRepository, 
            IUserLoginRepository userLoginRepository)
        {
            _identityServices = identityServices;
            _refreshTokenServices = refreshTokenServices;
            _menuRepository = menuRepository;
            _roleRepository = roleRepository;
            _userManager = userManager;
            _cache = cache;
            _userRepository = userRepository;
            _userLoginRepository = userLoginRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _userManager.Users.ToListAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] UserParam param)
        {
            var filter = param.SearchLambda<User, UserParam>();
            var result = await _userRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var userList = new List<User>();
            foreach (var item in result.Items)
            {
                var userLogins = await _userLoginRepository.QueryAsync(c => c.UserId == item.Id);
                item.LoginTimes = userLogins.Count();
                var userlogin = userLogins.OrderByDescending(c => c.CreateTime).Skip(1).FirstOrDefault();
                if (userlogin == null)
                    continue;
                item.LastLoginTime = userlogin.CreateTime;
                item.LastLoginIp = userlogin.LoginIp;
            }
            var pageData = new PagedDto<User>
            {
                Code = 200,
                Msg = "获取数据成功",
                Total = result.TotalResults,
                PageSize = param.PageSize,
                Data = result.Items.ToList()
            };
            var json = pageData.ToString();
            return json;
        }

        [HttpGet("get")]
        public async Task<ApiRequestResult> GetAsync(Guid id)
        {
            var result = await _userRepository.GetAsync(id);
            return ApiRequestResult.Success(result, "查询成功");
        }

        [HttpPost]
        public async Task<ApiRequestResult> AddAsync([FromBody]SignUpCommand command)
        {
            await _identityServices.SignUpAsync(command.Email, command.PhoneNumber,
                command.UserName, command.Password);
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

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpGet("auth-menu/{userId}")]
        public async Task<MsMenuJsonDto> QueryMsMenuAsync(Guid userId)
        {       
            var user = await  _identityServices.GetAsync(userId);
            if (user == null)
                return new MsMenuJsonDto();
            var menuList = new List<Menu>();

            //获取系统菜单
            var msMenus = await _menuRepository.QueryMsMenuAsync(user.MsId == null?Guid.Empty: user.MsId.Value);

            //获取用户角色
            var userRoles = await _roleRepository.QueryRoleAsync(userId);
            foreach (var item in userRoles)
            {
                //获取角色菜单
                var menus = msMenus.Where(c => c.Id == item.Id);
                menuList = menuList.Intersect(menus.ToList(), new MenuComparer()).ToList();
            }

            var parentMenus = menuList.Where(c => c.ParentId == null).ToList();
            var menuDtos = new List<LayUiMenuDto>();
            foreach (var menu in parentMenus)
            {
                var menuDto = new LayUiMenuDto
                {
                    Name = menu.MenuName,
                    Title = menu.MenuName,
                    Jump = menu.MenuUri,
                    Icon = menu.Icon,
                    List = GetSubMenuAsync(parentMenus, menuList),
                };
                menuDtos.Add(menuDto);
            }
            return new MsMenuJsonDto
            {
                Code = 0,
                Msg = "",
                Data = menuDtos,
            };
        }

        private List<LayUiMenuDto> GetSubMenuAsync(List<Menu> parentMenus,List<Menu> allMenu)
        {
            var menuDtoList = new List<LayUiMenuDto>();
            foreach (var menu in parentMenus)
            {
                var menuDto = new LayUiMenuDto
                {
                    Name = menu.MenuName,
                    Title = menu.MenuName,
                    Jump = menu.MenuUri,
                    Icon = menu.Icon,
                };
                var subMenus = allMenu.Where(c => c.ParentId == menu.Id).ToList();
                var subMenuDtos = subMenus.Select(
                    c => new LayUiMenuDto {
                        Name = c.MenuName,
                        Title = c.MenuName,
                        Jump = c.MenuUri,
                        Icon = c.Icon,
                    }).ToList();
                menuDto.List = subMenuDtos;
                GetSubMenuAsync(subMenus, allMenu);
            }
            return menuDtoList;
        }
    }
}