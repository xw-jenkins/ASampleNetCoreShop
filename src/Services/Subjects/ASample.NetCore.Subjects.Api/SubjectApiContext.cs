using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.DbMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASample.NetCore.Subjects.Api
{
    public class SubjectApiContext : DbContext
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public SubjectApiContext(IOptions<DbOptions> sqlOptions) : base()
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

            modelBuilder.ApplyConfiguration(new HelpMap());
            modelBuilder.ApplyConfiguration(new HelpCategoryMap());
            modelBuilder.ApplyConfiguration(new TopicMap());
            modelBuilder.ApplyConfiguration(new TopicCommentMap());
            modelBuilder.ApplyConfiguration(new TopicCategoryMap());
            modelBuilder.ApplyConfiguration(new SubjectMap());
            modelBuilder.ApplyConfiguration(new SubjectCommentMap());
            modelBuilder.ApplyConfiguration(new SubjectCategoryMap());
            modelBuilder.ApplyConfiguration(new MemberReportMap());
            modelBuilder.ApplyConfiguration(new PrefrenceAreaMap());
            modelBuilder.ApplyConfiguration(new PrefrenceAreaProductRelationMap());
            modelBuilder.ApplyConfiguration(new SubjectProductRelationMap());

            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }
}
