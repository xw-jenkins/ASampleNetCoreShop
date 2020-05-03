using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityUserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("ums_identity_user");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MsId);
            builder.Property(c => c.UserName).HasMaxLength(50);
            builder.Property(c => c.NormalizedUserName).HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.NormalizedEmail).HasMaxLength(100);
            builder.Property(c => c.EmailConfirmed);
            builder.Property(c => c.PhoneNumber).HasMaxLength(50);
            builder.Property(c => c.PhoneNumberConfirmed);
            builder.Property(c => c.PasswordHash).HasMaxLength(500);
            builder.Property(c => c.ConcurrencyStamp).HasMaxLength(500);
            builder.Property(c => c.SecurityStamp).HasMaxLength(500);


            builder.Property(c => c.LastLoginTime);
            builder.Property(c => c.LastLoginIp).HasMaxLength(50);
            builder.Property(c => c.LoginTimes);
            builder.Property(c => c.UserType);
            builder.Property(c => c.UserSource);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
