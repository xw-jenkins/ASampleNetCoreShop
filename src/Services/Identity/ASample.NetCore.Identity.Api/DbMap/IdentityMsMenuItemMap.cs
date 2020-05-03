using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityMsMenuItemMap : IEntityTypeConfiguration<MsMenuItem>
    {
        public void Configure(EntityTypeBuilder<MsMenuItem> builder)
        {
            builder.ToTable("ums_identity_ms_menu_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MsId);
            builder.Property(c => c.MenuId);

            builder.Property(c => c.CreateTime);
        }
    }
}
