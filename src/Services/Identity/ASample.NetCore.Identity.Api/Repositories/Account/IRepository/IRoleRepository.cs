using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public interface IRoleRepository:IRepository<Role>
    {
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Role>> QueryRoleAsync(Guid userId);

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddUserRoleAsync(UserRoleDto dto);

        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddRoleMenuAsync(RoleMenuDto dto);
    }
}
