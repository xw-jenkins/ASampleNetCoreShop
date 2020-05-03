using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Queries;
using ASample.NetCore.Identity.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/role")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _roleRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] RoleParam param)
        {
            var filter = param.SearchLambda<Role, RoleParam>();
            var result = await _roleRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<Role>
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

        [HttpGet("msroles/{msid}")]
        public async Task<ApiRequestResult> GetMsRoleAsync(Guid msid)
        {
            var result = await _roleRepository.QueryAsync(c => c.MsId == msid);
            return ApiRequestResult.Success(result, "");
        }


        [HttpGet("adminroles/{userId}")]
        public async Task<ApiRequestResult> GetUserRolesAsync(Guid userId)
        {
            var result = await _roleRepository.QueryRoleAsync(userId);
            return ApiRequestResult.Success(result, "");
        }

        [HttpPost("adminroles")]
        public async Task<ApiRequestResult> AddUserRoleAsync(UserRoleDto dto)
        {
            await _roleRepository.AddUserRoleAsync(dto);
            return ApiRequestResult.Success("角色设置成功");
        }

        [HttpPost("rolemenus")]
        public async Task<ApiRequestResult> AddRoleMenuAsync(RoleMenuDto dto)
        {
            await _roleRepository.AddRoleMenuAsync(dto);
            return ApiRequestResult.Success("权限设置成功");
        }

        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(RoleDto dto)
        {
            var command = dto.EntityMap<RoleDto, Role>();
            await _roleRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(RoleDto dto)
        {
            var entity = await _roleRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _roleRepository.UpdateAsync(newEntity);

            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _roleRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}