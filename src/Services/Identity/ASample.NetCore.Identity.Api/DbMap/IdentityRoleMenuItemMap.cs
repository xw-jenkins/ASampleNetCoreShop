using ASample.NetCore.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Identity.Api.DbMap
{
    public class IdentityRoleMenuItemMap : IEntityTypeConfiguration<RoleMenuItem>
    {
        public void Configure(EntityTypeBuilder<RoleMenuItem> builder)
        {
            builder.ToTable("ums_identity_role_menu_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RoleId);
            builder.Property(c => c.MenuId);

            builder.Property(c => c.CreateTime);
        }
    }
}
