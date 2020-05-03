using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityRoleClaimMap : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("ums_identity_role_claim");
            //builder.HasKey(c => c.Id);
            builder.Property(c => c.RoleId);
            builder.Property(c => c.ClaimType).HasMaxLength(50);
            builder.Property(c => c.ClaimValue).HasMaxLength(50);

            builder.Property(c => c.CreateTime);
        }
    }
}
