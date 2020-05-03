using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.Product.Api
{
    public class ProductDto
    {
        #region ProductInfo
        public Guid? Id { get; set; }
        public Guid BrandId { get; set; }

        public string BrandName { get; set; }

        public Guid ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }

        public string Name { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string ProductSN { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Stock { get; set; }

        public string Unit { get; set; }
        public string Pic { get; set; }

        public double Weight { get; set; }

        public int Sort { get; set; }
        #endregion

        #region ProductSale
        public int GiftPoint { get; set; }

        public int GiftGrowth { get; set; }

        public int UsePointLimit { get; set; }

        public bool PreviewStatus { get; set; }

        public bool PublishStatus { get; set; }

        public bool NewStatus { get; set; }

        public bool RecommendStatus { get; set; }

        public string ServiceIds { get; set; }

        public string DetailTitle { get; set; }

        public string DetailDesc { get; set; }

        public string KeyWords { get; set; }

        public string Note { get; set; }

        public List<ProductMemberPriceDto> MemberPriceList { get; set; }
        public List<ProductFullReductionDto> ProductFullReductionList { get; set; }
        public List<ProductLadderDto> ProductLadderList { get; set; }
        public DateTime? PromotionStartTime { get; set; }
        public DateTime? PromotionEndTime { get; set; }
        public decimal? PromotionPrice { get; set; } = 0;
        #endregion

        #region ProductAttribute
        public Guid ProductAttributeCategoryId { get; set; }
        public List<ProductAttributeValueDto> ProductAttributeValueList { get; set; }
        public List<ProductSkuStockDto> SkuStockList { get; set; }

        public string AlbumPics { get; set; }
        public string DetailHtml { get; set; }
        public string DetailMobileHtml { get; set; }

        #endregion

        //public Guid FeightTemplateId { get; set; }
    }
}
