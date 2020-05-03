using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public class UserLoginRepository:Repository<IdentityApiContext,UserLogin>,IUserLoginRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public UserLoginRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
