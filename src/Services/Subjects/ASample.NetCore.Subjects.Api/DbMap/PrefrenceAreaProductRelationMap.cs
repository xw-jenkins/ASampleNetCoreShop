using ASample.NetCore.Subjects.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class PrefrenceAreaProductRelationMap : IEntityTypeConfiguration<PrefrenceAreaProductRelation>
    {
        public void Configure(EntityTypeBuilder<PrefrenceAreaProductRelation> builder)
        {
            builder.ToTable("cms_prefrence_area_product_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PrefrenceAreaId);
            builder.Property(c => c.ProductId);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
