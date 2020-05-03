using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Order.Api.Repositories
{
    public class OrderSettingRepository : Repository<OrderApiContext, OrderSetting>, IOrderSettingRepository
    {
        public OrderSettingRepository(IUnitOfWork<OrderApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
