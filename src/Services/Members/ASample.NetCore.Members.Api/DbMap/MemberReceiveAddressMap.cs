using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberReceiveAddressMap : IEntityTypeConfiguration<MemberReceiveAddress>
    {
        public void Configure(EntityTypeBuilder<MemberReceiveAddress> builder)
        {
            builder.ToTable("ums_member_receive_address");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.PostCode).HasMaxLength(20);
            builder.Property(c => c.Province).HasMaxLength(20);
            builder.Property(c => c.City).HasMaxLength(20);
            builder.Property(c => c.Region).HasMaxLength(20);
            builder.Property(c => c.DetailAddress).HasMaxLength(500);
            builder.Property(c => c.DefaultStatus);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
