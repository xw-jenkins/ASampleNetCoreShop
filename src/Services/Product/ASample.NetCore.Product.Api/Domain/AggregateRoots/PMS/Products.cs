using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class Products:AggregateRoot
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        public Guid BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商品类别编号
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? FeightTemplateId { get; set; }

        /// <summary>
        /// 商品属性类别编号
        /// </summary>
        public Guid ProductAttributeCategoryId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 商品介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品货号
        /// </summary>
        public string ProductSN { get; set; }

        /// <summary>
        /// 商品售价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 商品重量 
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 赠送成长值
        /// </summary>
        public int GiftGrowth { get; set; }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public int GiftPoint { get; set; }

        /// <summary>
        /// 积分购买限制
        /// </summary>
        public int UsePointLimit { get; set; }

        /// <summary>
        /// 预告商品
        /// </summary>
        public bool PreviewStatus { get; set; }

        /// <summary>
        /// 上架
        /// </summary>
        public bool PublishStatus { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int Sale { get; set; }

        /// <summary>
        /// 是否新品
        /// </summary>
        public bool NewStatus { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool RecommendStatus { get; set; }

        public string Pic { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool DeleteStatus { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public bool VerifyStatus { get; set; }

        
        /// <summary>
        /// 库存预警
        /// </summary>
        public int LowStock { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceIds { get; set; }

        /// <summary>
        /// 商品关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 画册图片，连产品图片限制为5张，以逗号分割
        /// </summary>
        public string AlbumPics { get; set; }

        /// <summary>
        /// 产品详情网页内容
        /// </summary>
        public string DetailTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DetailDesc { get; set; }
        public string DetailHtml { get; set; }

        /// <summary>
        /// 移动端网页详情
        /// </summary>
        public string DetailMobileHtml { get; set; }

        /// <summary>
        /// 促销开始时间
        /// </summary>
        public DateTime? PromotionStartTime { get; set; }

        /// <summary>
        /// 促销结束时间
        /// </summary>
        public DateTime? PromotionEndTime { get; set; }

        /// <summary>
        /// 活动限购数量
        /// </summary>
        public int PromotionPerLimit { get; set; }
        
        /// <summary>
        /// 促销价格
        /// </summary>
        public decimal PromotionPrice { get; set; }

    }
}
