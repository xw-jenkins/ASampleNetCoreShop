using ASample.NetCore.Order.Api.DbMap;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASample.NetCore.Order.Api
{
    public class OrderApiContext : DbContext
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public OrderApiContext(IOptions<DbOptions> sqlOptions) : base()
        {
            _sqlOptions = sqlOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            if (_sqlOptions.Value.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase(_sqlOptions.Value.Database);

                return;
            }

            optionsBuilder.UseSqlServer(_sqlOptions.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new CartItemMap());
            modelBuilder.ApplyConfiguration(new CompanyAddressMap());
            modelBuilder.ApplyConfiguration(new OrderOperateHistoryMap());
            modelBuilder.ApplyConfiguration(new OrderReturnApplyMap());
            modelBuilder.ApplyConfiguration(new OrderReturnReasonMap());
            modelBuilder.ApplyConfiguration(new OrderSettingMap());

            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }
}
