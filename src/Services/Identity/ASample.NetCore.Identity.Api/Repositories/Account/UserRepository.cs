using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public class UserRepository:Repository<IdentityApiContext,User>,IUserRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public UserRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRoleSet = unitOfWork.GetDbContext().Set<UserRoleItem>();
        }
        public DbSet<UserRoleItem> _userRoleSet;
    }
}
