using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{

    public class IdentityUserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("ums_identity_user_token");
            //builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Value).HasMaxLength(500);
            builder.Property(c => c.LoginProvider).HasMaxLength(500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
