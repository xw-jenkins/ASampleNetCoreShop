using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Order.Api.Repositories
{
    public class OrderReturnReasonRepository : Repository<OrderApiContext, OrderReturnReason>, IOrderReturnReasonRepository
    {
        public OrderReturnReasonRepository(IUnitOfWork<OrderApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
