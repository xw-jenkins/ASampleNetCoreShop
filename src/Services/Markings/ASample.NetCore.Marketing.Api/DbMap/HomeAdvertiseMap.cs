using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class HomeAdvertiseMap : IEntityTypeConfiguration<HomeAdvertise>
    {
        public void Configure(EntityTypeBuilder<HomeAdvertise> builder)
        {
            builder.ToTable("sms_home_advertise");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Type);
            builder.Property(c => c.Pic).HasMaxLength(500);
            builder.Property(c => c.StartTime);
            builder.Property(c => c.EndTime);
            builder.Property(c => c.Status);
            builder.Property(c => c.ClickCount);
            builder.Property(c => c.OrderCount);
            builder.Property(c => c.Url).HasMaxLength(250);
            builder.Property(c => c.Note).HasMaxLength(250);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
