using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class MemberReportMap : IEntityTypeConfiguration<MemberReport>
    {
        public void Configure(EntityTypeBuilder<MemberReport> builder)
        {
            builder.ToTable("cms_member_report");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ReportType);
            builder.Property(c => c.ReportStatus);
            builder.Property(c => c.HandleStatus);
            builder.Property(c => c.ReportMemberName).HasMaxLength(50);
            builder.Property(c => c.ReportObject).HasMaxLength(200);
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
