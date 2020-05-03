using ASample.NetCore.Marketing.Api.Domain;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using System;
using System.Collections.Generic;

namespace ASample.NetCore.Marketing.Api
{
    public class CouponDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 优惠卷类型；0->全场赠券；1->会员赠券；2->购物赠券；3->注册赠券
        /// </summary>
        public CouponType CouponType { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 使用平台：0->全部；1->移动；2->PC
        /// </summary>
        public PlatformType PlatformType { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 每人限领张数
        /// </summary>
        public int PerLimit { get; set; }

        /// <summary>
        /// 使用门槛；0表示无门槛
        /// </summary>
        public int MinPoint { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 使用类型：0->全场通用；1->指定分类；2->指定商品
        /// </summary>
        public UseType UseType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 发行数量
        /// </summary>
        public int PublishCount { get; set; }

        /// <summary>
        /// 已使用数量
        /// </summary>
        public int UseCcount { get; set; }

        /// <summary>
        /// 领取数量
        /// </summary>
        public int ReceiveCount { get; set; }

        /// <summary>
        /// 可以领取的日期
        /// </summary>
        public DateTime EnableTime { get; set; }

        /// <summary>
        /// 优惠码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 可领取的会员类型：0->无限时
        /// </summary>
        public int MemberLevel { get; set; }

        public List<CouponProductCategoryRelation> ProductCategoryRelationList { get; set; }
        public List<CouponProductRelation> ProductRelationList { get; set; }
    }
}
