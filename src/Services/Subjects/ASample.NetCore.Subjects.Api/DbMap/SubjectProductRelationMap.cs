using ASample.NetCore.Subjects.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class SubjectProductRelationMap : IEntityTypeConfiguration<SubjectProductRelation>
    {
        public void Configure(EntityTypeBuilder<SubjectProductRelation> builder)
        {
            builder.ToTable("cms_subject_product_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.SubjectId);
            builder.Property(c => c.ProductId);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
