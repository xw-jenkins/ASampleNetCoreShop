using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberLoginLogMap : IEntityTypeConfiguration<MemberLoginLog>
    {
        public void Configure(EntityTypeBuilder<MemberLoginLog> builder)
        {
            builder.ToTable("ums_member_login_log");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.Ip).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.Province).HasMaxLength(50);
            builder.Property(c => c.LoginType);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
