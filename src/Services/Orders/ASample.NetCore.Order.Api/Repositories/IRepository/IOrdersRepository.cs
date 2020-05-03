using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Order.Api.Repositories
{
    public interface IOrderSettingRepository : IRepository<OrderSetting>
    {
    }
}
