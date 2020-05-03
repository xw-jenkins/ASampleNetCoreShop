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
    public class RoleRepository:Repository<IdentityApiContext,Role>,IRoleRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public RoleRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRoleDbSet = _unitOfWork.GetDbContext().Set<UserRoleItem>();
            _roleMenuDbSet = _unitOfWork.GetDbContext().Set<RoleMenuItem>();
        }
        private DbSet<UserRoleItem> _userRoleDbSet;
        private DbSet<RoleMenuItem> _roleMenuDbSet;

        public async Task<List<Role>> QueryRoleAsync(Guid userId)
        {
            var userRoles = await _userRoleDbSet.Where(c => c.UserId == userId).ToListAsync();
            var roleList = new List<Role>();
            foreach (var item in userRoles)
            {
                var role = await GetAsync(item.RoleId);
                roleList.Add(role);
            }
            return roleList;
        }

        public async Task AddUserRoleAsync(UserRoleDto dto)
        {
            foreach (var item in dto.RoleIds)
            {
                var userRole = new UserRoleItem
                {
                    UserId = dto.UserId,
                    RoleId = item,
                };
                await _userRoleDbSet.AddAsync(userRole);
            }
        }

        public async Task AddRoleMenuAsync(RoleMenuDto dto)
        {
            try
            {
                var existMenus =  _roleMenuDbSet.Where(c => c.RoleId == dto.RoleId);
                _roleMenuDbSet.RemoveRange(existMenus);

                foreach (var item in dto.MenuIds)
                {
                    if (!existMenus.Any(c => c.RoleId == dto.RoleId && c.MenuId == item))
                    {
                        var roleMenu = new RoleMenuItem
                        {
                            RoleId = dto.RoleId,
                            MenuId = item,
                        };
                        await _roleMenuDbSet.AddAsync(roleMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        


    }
}
