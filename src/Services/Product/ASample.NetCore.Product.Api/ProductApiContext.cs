using ASample.NetCore.Product.Api.DbMap;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASample.NetCore.Product.Api
{
    public class ProductApiContext:DbContext
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public ProductApiContext(IOptions<DbOptions> sqlOptions) : base()
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

            modelBuilder.ApplyConfiguration(new AlbumMap());
            modelBuilder.ApplyConfiguration(new AlbumPicMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CommentReplayMap());
            modelBuilder.ApplyConfiguration(new FeightTemplateMap());
            modelBuilder.ApplyConfiguration(new ProductMemberPriceMap());
            modelBuilder.ApplyConfiguration(new ProductAttributeCategoryMap());
            modelBuilder.ApplyConfiguration(new ProductAttributeMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryAttributeRelationMap());
            modelBuilder.ApplyConfiguration(new ProductFullReductionMap());
            modelBuilder.ApplyConfiguration(new ProductAttributeCategoryMap());
            modelBuilder.ApplyConfiguration(new ProductAttributeValueMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());
            modelBuilder.ApplyConfiguration(new ProductOperateLogMap());
            modelBuilder.ApplyConfiguration(new ProductSkuStockMap());
            modelBuilder.ApplyConfiguration(new ProductVerifyRecordMap());
            modelBuilder.ApplyConfiguration(new ProductLadderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            
            
            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }


}
