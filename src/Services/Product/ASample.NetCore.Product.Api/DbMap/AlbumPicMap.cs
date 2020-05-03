using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class AlbumPicMap : IEntityTypeConfiguration<AlbumPic>
    {
        public void Configure(EntityTypeBuilder<AlbumPic> builder)
        {
            builder.ToTable("pms_album_pic");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AlbumId);
            builder.Property(c => c.Pic).HasMaxLength(1500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
