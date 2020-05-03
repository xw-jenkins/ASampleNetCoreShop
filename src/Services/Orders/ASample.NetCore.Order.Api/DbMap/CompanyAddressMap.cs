using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class CompanyAddressMap : IEntityTypeConfiguration<CompanyAddress>
    {
        public void Configure(EntityTypeBuilder<CompanyAddress> builder)
        {
            builder.ToTable("oms_company_address");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AddressName).HasMaxLength(50);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Phone).HasMaxLength(50);
            builder.Property(c => c.Province).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.Region).HasMaxLength(50);
            builder.Property(c => c.DetailAddress).HasMaxLength(500);
            builder.Property(c => c.ReceiveStatus);
            builder.Property(c => c.SendStatus);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
