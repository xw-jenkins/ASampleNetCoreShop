using ASample.NetCore.Identity.Api.DbMap;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ASample.NetCore.Identity.Api
{
    public class IdentityApiContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRoleItem, UserLogin, RoleClaim, UserToken>
    {
        private readonly IOptions<DbOptions> _sqlOptions;

        public IdentityApiContext(IOptions<DbOptions> sqlOptions) : base()
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

            modelBuilder.ApplyConfiguration(new IdentityMsMap());
            modelBuilder.ApplyConfiguration(new IdentityMenuMap());
            modelBuilder.ApplyConfiguration(new IdentityMsMenuItemMap());
            modelBuilder.ApplyConfiguration(new IdentityUserMap());
            modelBuilder.ApplyConfiguration(new IdentityRoleMap());
            modelBuilder.ApplyConfiguration(new IdentityRoleClaimMap());
            modelBuilder.ApplyConfiguration(new IdentityUserClaimMap());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleMap());
            modelBuilder.ApplyConfiguration(new IdentityRoleMenuItemMap());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenMap());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginMap());
            modelBuilder.ApplyConfiguration(new RefreshTokenMap());
            //modelBuilder.ApplyConfiguration(new ProductsReportConfiguration(_jsonSerializer));
        }
    }
}
