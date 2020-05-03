using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Order.Api.Repositories
{
    public class OrderReturnApplyRepository : Repository<OrderApiContext, OrderReturnApply>, IOrderReturnApplyRepository
    {
        public OrderReturnApplyRepository(IUnitOfWork<OrderApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
