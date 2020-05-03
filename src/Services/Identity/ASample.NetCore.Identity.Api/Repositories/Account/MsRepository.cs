using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public class MsRepository:Repository<IdentityApiContext,Ms>,IMsRepository
    {
        private readonly IUnitOfWork<IdentityApiContext> _unitOfWork;
        public MsRepository(IUnitOfWork<IdentityApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
