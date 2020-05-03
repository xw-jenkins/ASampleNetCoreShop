using ASample.NetCore.Members.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberMemberTagRelationMap : IEntityTypeConfiguration<MemberMemberTagRelation>
    {
        public void Configure(EntityTypeBuilder<MemberMemberTagRelation> builder)
        {
            builder.ToTable("ums_member_member_tag_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.TagId);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
