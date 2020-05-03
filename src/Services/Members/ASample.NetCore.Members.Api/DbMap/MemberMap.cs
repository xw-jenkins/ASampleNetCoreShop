using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("ums_member");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberLevelId);
            builder.Property(c => c.UserName).HasMaxLength(50);
            builder.Property(c => c.Password).HasMaxLength(500);
            builder.Property(c => c.NickName).HasMaxLength(50);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Icon).HasMaxLength(20);
            builder.Property(c => c.City).HasMaxLength(20);
            builder.Property(c => c.Job).HasMaxLength(20);
            builder.Property(c => c.PersonalizedSignature).HasMaxLength(200);
            builder.Property(c => c.Status);
            builder.Property(c => c.Gender);
            builder.Property(c => c.Birthday);
            builder.Property(c => c.SourceType);
            builder.Property(c => c.Integration);
            builder.Property(c => c.Growth);
            builder.Property(c => c.LuckeyCount);
            builder.Property(c => c.HistoryIntegration);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
