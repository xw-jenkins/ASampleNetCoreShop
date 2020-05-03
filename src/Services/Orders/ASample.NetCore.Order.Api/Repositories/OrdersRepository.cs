using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Order.Api.Repositories
{
    public class OrdersRepository : Repository<OrderApiContext, Orders>, IOrdersRepository
    {
        public OrdersRepository(IUnitOfWork<OrderApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
