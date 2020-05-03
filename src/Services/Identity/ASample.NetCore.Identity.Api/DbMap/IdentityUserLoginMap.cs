using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{

    public class IdentityUserLoginMap : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("ums_identity_user_login");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.LoginIp).HasMaxLength(50);
            builder.Property(c => c.UserId);
            builder.Property(c => c.LoginProvider).HasMaxLength(50);
            builder.Property(c => c.ProviderDisplayName).HasMaxLength(500);
            builder.Property(c => c.ProviderKey).HasMaxLength(500);

            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
