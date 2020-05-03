using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        /// <summary>
        /// 获取系统所有的菜单
        /// </summary>
        /// <param name="msId"></param>
        /// <returns></returns>
        Task<List<Menu>> QueryMsMenuAsync(Guid msId);

        /// <summary>
        /// 获取角色拥有的菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<Menu>> QueryMenuAsync(Guid roleId);

    }
}
