using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberLevelMap : IEntityTypeConfiguration<MemberLevel>
    {
        public void Configure(EntityTypeBuilder<MemberLevel> builder)
        {
            builder.ToTable("ums_member_level");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MsId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.Property(c => c.GrowthPoint);
            builder.Property(c => c.DefaultStatus);
            builder.Property(c => c.FreeFreightPoint);
            builder.Property(c => c.PriviledgeFreeFreight);
            builder.Property(c => c.PriviledgeSignIn);
            builder.Property(c => c.PriviledgeComment);
            builder.Property(c => c.PriviledgePromotion);
            builder.Property(c => c.PriviledgeMemberPrice);
            builder.Property(c => c.PriviledgeBirthday);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
