using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityUserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("ums_identity_user_claim");
            //builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId);
            builder.Property(c => c.ClaimType).HasMaxLength(50);
            builder.Property(c => c.ClaimValue).HasMaxLength(50);

            builder.Property(c => c.CreateTime);
        }
    }
}
