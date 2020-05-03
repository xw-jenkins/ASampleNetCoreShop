using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.EntityFramwork.Domain;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Queries;
using ASample.NetCore.Identity.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository authMsMenuRepository)
        {
            _menuRepository = authMsMenuRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _menuRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MenuParam param)
        {
            var result = await _menuRepository.QueryPagedAsync(c => c.ParentId == null, param);
            //var allSubMenu = await _menuRepository.QueryAsync(c => c.ParentId != null);
            var list = new List<MenuDto>();
            if (result.Items != null)
            {
                foreach (var item in result.Items)
                {
                    var menuDto = item.EntityMap<Menu, MenuDto>();
                    menuDto.HasChildren = true;
                    list.Add(menuDto);
                }
            }
            
            var pageData = new PagedDto<MenuDto>
            {
                Code = 200,
                Msg = "获取数据成功",
                Total = result.TotalResults,
                //PageSize = param.P,
                Data = list
            };
            var json = pageData.ToString();
            return json;
        }

        [HttpGet("childs/{id}")]
        public async Task<ApiRequestResult> QueryChildMenuAsync([FromRoute] Guid id)
        {
            var result = await _menuRepository.QueryAsync(c => c.ParentId != null && c.ParentId == id );
            return ApiRequestResult.Success(result.ToList(), "");
        }

        [HttpGet("parents")]
        public async Task<ApiRequestResult> QueryParentAsync()
        {
            var result = await _menuRepository.QueryAsync(c => c.ParentId == null);
            return ApiRequestResult.Success(result,"");
        }

        [HttpGet("msmenus/{msId}")]
        public async Task<ApiRequestResult> QueryMsMenusAsync(Guid msId)
        {
            var result = await _menuRepository.QueryAsync(c => c.MsId  == msId);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("rolemenus/{roleId}")]
        public async Task<ApiRequestResult> QueryRoleMenusAsync(Guid roleId)
        {
            var result = await _menuRepository.QueryMenuAsync(roleId);
            return ApiRequestResult.Success(result, "");
        }

        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(MenuDto dto)
        {
            var menu = dto.EntityMap<MenuDto, Menu>();
            await _menuRepository.AddAsync(menu);
            return ApiRequestResult.Success("添加成功");
        }

        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(MenuDto dto)
        {
            try
            {
                var entity = await _menuRepository.GetAsync(dto.Id.Value);
                var newEntity = dto.EntityMap(entity);
                await _menuRepository.UpdateAsync(newEntity);
            }
            catch (Exception ex)
            {
                throw;
            }

            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _menuRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpPut("isshow/{id}/{isShow}")]
        public async Task<ApiRequestResult> UpdateIsShow(Guid id,bool isShow)
        {
            try
            {
                var entity = await _menuRepository.GetAsync(id);
                entity.IsShow = isShow;
                await _menuRepository.UpdateAsync(entity);
                return ApiRequestResult.Success("修改成功");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}