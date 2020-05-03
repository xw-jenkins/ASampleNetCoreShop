using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberStatisticsInfoMap : IEntityTypeConfiguration<MemberStatisticsInfo>
    {
        public void Configure(EntityTypeBuilder<MemberStatisticsInfo> builder)
        {
            builder.ToTable("ums_member_statistics_info");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.ConsumeAmount);
            builder.Property(c => c.OrderCount);
            builder.Property(c => c.CouponCount);
            builder.Property(c => c.CommentCount);
            builder.Property(c => c.ReturnOrderCount);
            builder.Property(c => c.LoginCount);
            builder.Property(c => c.AttendCount);
            builder.Property(c => c.FansCount);
            builder.Property(c => c.CollectProductCount);
            builder.Property(c => c.CollectSubjectCount);
            builder.Property(c => c.CollectTopicCount);
            builder.Property(c => c.CollectCommentCount);
            builder.Property(c => c.InviteFriendCount);
            builder.Property(c => c.RecentOrderTime);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
