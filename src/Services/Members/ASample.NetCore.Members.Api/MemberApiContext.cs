using ASample.NetCore.Members.Api.DbMap;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASample.NetCore.Members.Api
{
    public class MemberApiContext:DbContext
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public MemberApiContext(IOptions<DbOptions> sqlOptions) : base()
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

            modelBuilder.ApplyConfiguration(new MemberLevelMap());
            modelBuilder.ApplyConfiguration(new MemberMap());
            modelBuilder.ApplyConfiguration(new MemberRuleSettingMap());
            modelBuilder.ApplyConfiguration(new MemberReceiveAddressMap());
            modelBuilder.ApplyConfiguration(new MemberTagMap());
            modelBuilder.ApplyConfiguration(new MemberTaskMap());
            modelBuilder.ApplyConfiguration(new MemberStatisticsInfoMap());
            modelBuilder.ApplyConfiguration(new MemberLoginLogMap());
            modelBuilder.ApplyConfiguration(new MemberMemberTagRelationMap());
            modelBuilder.ApplyConfiguration(new MemberProductCategoryRelationMap());
            modelBuilder.ApplyConfiguration(new GrowthChangeHistoryMap());
            modelBuilder.ApplyConfiguration(new IntegrationChangeHistoryMap());
            modelBuilder.ApplyConfiguration(new IntegrationConsumeSettingMap());
            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }


}
