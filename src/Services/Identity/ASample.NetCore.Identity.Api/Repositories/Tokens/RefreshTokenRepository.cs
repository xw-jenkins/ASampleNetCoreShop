using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public class RefreshTokenRepository:Repository<IdentityApiContext, RefreshToken>, IRefreshTokenRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public RefreshTokenRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
