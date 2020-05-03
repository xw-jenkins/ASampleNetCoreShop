using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityUserRoleMap : IEntityTypeConfiguration<UserRoleItem>
    {
        public void Configure(EntityTypeBuilder<UserRoleItem> builder)
        {
            builder.ToTable("ums_identity_user_role");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RoleId);
            builder.Property(c => c.UserId);

            builder.Property(c => c.CreateTime);
        }
    }
}
