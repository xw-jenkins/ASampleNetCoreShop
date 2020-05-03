using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityMsMap : IEntityTypeConfiguration<Ms>
    {
        public void Configure(EntityTypeBuilder<Ms> builder)
        {
            builder.ToTable("ums_identity_ms");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MsName);
            builder.Property(c => c.MsDomain).HasMaxLength(50);
            builder.Property(c => c.MsDescription).HasMaxLength(500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
