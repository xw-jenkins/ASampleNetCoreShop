using ASample.NetCore.Marketing.Api.DbMap;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASample.NetCore.Marketing.Api
{
    public class MarketingApiContext : DbContext
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public MarketingApiContext(IOptions<DbOptions> sqlOptions) : base()
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

            modelBuilder.ApplyConfiguration(new CouponMap());
            modelBuilder.ApplyConfiguration(new CouponHistoryMap());
            modelBuilder.ApplyConfiguration(new CouponProductRelationMap());
            modelBuilder.ApplyConfiguration(new CouponProductCategoryRelationMap());
            modelBuilder.ApplyConfiguration(new FlashPromotionMap());
            modelBuilder.ApplyConfiguration(new FlashPromotionLogMap());
            modelBuilder.ApplyConfiguration(new FlashPromotionProductRelationMap());
            modelBuilder.ApplyConfiguration(new FlashPromotionSessionMap());
            modelBuilder.ApplyConfiguration(new HomeAdvertiseMap());
            modelBuilder.ApplyConfiguration(new HomeBrandMap());
            modelBuilder.ApplyConfiguration(new HomeNewProductMap());
            modelBuilder.ApplyConfiguration(new HomeRecommendProductMap());
            modelBuilder.ApplyConfiguration(new HomeRecommendSubjectMap());

            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }
}
