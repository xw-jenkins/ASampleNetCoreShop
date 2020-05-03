using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{

    public class IdentityMenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("ums_identity_menu");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MsId);
            builder.Property(c => c.ParentId);
            builder.Property(c => c.MenuName).HasMaxLength(50);
            builder.Property(c => c.MenuDescription).HasMaxLength(500);
            builder.Property(c => c.MenuUri).HasMaxLength(500);
            builder.Property(c => c.IsShow);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
