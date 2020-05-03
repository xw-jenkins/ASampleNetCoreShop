using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public class MenuRepository:Repository<IdentityApiContext,Menu>,IMenuRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public MenuRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.GetDbContext().Set<RoleMenuItem>();
            _msdbSet = _unitOfWork.GetDbContext().Set<MsMenuItem>();
        }
        private DbSet<RoleMenuItem> _dbSet;
        private DbSet<MsMenuItem> _msdbSet;

        public async Task<List<Menu>> QueryMenuAsync(Guid roleId)
        {
            var roleMenus = await _dbSet.Where(c => c.RoleId == roleId).ToListAsync();
            var menuList = new List<Menu>();
            foreach (var item in roleMenus)
            {
                var menu = await GetAsync(item.MenuId);
                menuList.Add(menu);
            }
            return menuList;
        }

        public async Task<List<Menu>> QueryMsMenuAsync(Guid msId)
        {
            var msMenus = await _msdbSet.Where(c => c.MsId == msId).ToListAsync();
            var menuList = new List<Menu>();
            foreach (var item in msMenus)
            {
                var menu = await GetAsync(item.MenuId);
                menuList.Add(menu);
            }
            return menuList;
        }
    }
}
