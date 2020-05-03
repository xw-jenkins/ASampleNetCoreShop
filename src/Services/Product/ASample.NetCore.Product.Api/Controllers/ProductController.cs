using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Repositories;
using ASample.NetCore;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Product.Api.Controllers
{
    [Route("api/pms/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductLadderRepository _productLadderRepository;
        private readonly IProductMemberPriceRepository _productMemberPriceRepository;
        private readonly IProductFullReductionRepository _productFullReductionRepository;
        private readonly IProductSkuStockRepository _productSkuStockRepository;
        private readonly IProductAttributeValueRepository _productAttributeValueRepository;
        public ProductController(IProductRepository productRepository,
            IProductLadderRepository productLadderRepository,
            IProductMemberPriceRepository productMemberPriceRepository,
            IProductFullReductionRepository productFullReductionRepository,
            IProductSkuStockRepository productSkuStockRepository, 
            IProductAttributeValueRepository productAttributeValueRepository)
        {
            _productRepository = productRepository;
            _productLadderRepository = productLadderRepository;
            _productMemberPriceRepository = productMemberPriceRepository;
            _productFullReductionRepository = productFullReductionRepository;
            _productSkuStockRepository = productSkuStockRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] ProductsParam param)
        {
            var filter = param.SearchLambda<Products, ProductsParam>();
            var result = await _productRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var list = new List<ProductDto>();
            foreach (var item in result.Items)
            {
                var dto = item.EntityMap<Products, ProductDto>();
                //
                var memberList = await _productMemberPriceRepository.QueryAsync(c => c.ProductId == item.Id);
                dto.MemberPriceList = memberList.Select(c => c.EntityMap<ProductMemberPrice,ProductMemberPriceDto>()).ToList();

                //
                var fullReductionList = await _productFullReductionRepository.QueryAsync(c => c.ProductId == item.Id);
                dto.ProductFullReductionList = fullReductionList.Select(c => c.EntityMap<ProductFullReduction, ProductFullReductionDto>()).ToList();

                //
                var ladderList = await _productLadderRepository.QueryAsync(c => c.ProductId == item.Id);
                dto.ProductLadderList = ladderList.Select(c => c.EntityMap<ProductLadder, ProductLadderDto>()).ToList();

                //
                var attributeValueList = await _productAttributeValueRepository.QueryAsync(c => c.ProductId == item.Id);
                dto.ProductAttributeValueList = attributeValueList.Select(c => c.EntityMap<ProductAttributeValue, ProductAttributeValueDto>()).ToList();

                //
                var skuStockList = await _productSkuStockRepository.QueryAsync(c => c.ProductId == item.Id);
                dto.SkuStockList = skuStockList.Select(c => c.EntityMap<ProductSkuStock, ProductSkuStockDto>()).ToList();

                list.Add(dto);
            }
            var pageData = new PagedDto<ProductDto>
            {
                Code = 200,
                Msg = "获取数据成功",
                Total = result.TotalResults,
                PageSize = param.PageSize,
                Data = list
            };
            var json = pageData.ToString();
            return json;
        }

        [HttpGet("queryProduct")]
        public async Task<ApiRequestResult> GetProductByFeature([FromQuery] ProductsParam param)
        {
            var filter = param.SearchLambda<Products, ProductsParam>();
            var result = await _productRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            return ApiRequestResult.Success(result, "");
        }


        [HttpGet("simpleList")]
        public async Task<string> QuerySimpleAsync([FromQuery] ProductsParam param)
        {
            var filter = param.SearchLambda<Products, ProductsParam>();
            var result = await _productRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<Products>
            {
                Code = 200,
                Msg = "获取数据成功",
                Total = result.TotalResults,
                PageSize = param.PageSize,
                Data = result.Items.ToList()
            };
            var json = pageData.ToString();
            return json;
        }

        [HttpGet("keywordSearch/{keyword}")]
        public async Task<ApiRequestResult> QueryByKeyWordAsync(string keyword)
        {
            var result = await _productRepository.QueryAsync(c => c.Name.Contains(keyword) || c.ProductSN.Contains(keyword));
            return ApiRequestResult.Success(result,"查询成功");
        }

        [HttpGet("getProductByIds")]
        public async Task<ApiRequestResult> QueryAsync(string ids = null)
        {
            if (ids.IsNullOrEmpty())
                return ApiRequestResult.Success("","参数为空");
            var idArr = ids.Split("|").ToList();
            var result = await _productRepository.QueryAsync(c => idArr.Contains(c.Id.ToString()));
            return ApiRequestResult.Success(result.ToList(), "");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _productRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpPost]
        public async Task AddAsync(ProductDto dto)
        {
            var productInfo = dto.EntityMap<ProductDto, Products>();
            productInfo.Id = Guid.NewGuid();
            await _productRepository.AddAsync(productInfo);


            //会员价格信息
            var memberPriceList = new List<ProductMemberPrice>();
            foreach (var memberPrice in dto.MemberPriceList)
            {
                var memberPriceEntity = memberPrice.EntityMap<ProductMemberPriceDto, ProductMemberPrice>();
                memberPriceEntity.ProductId = productInfo.Id;
                memberPriceList.Add(memberPriceEntity);
            }
            await _productMemberPriceRepository.MultiAddAsync(memberPriceList);

            //满减信息
            var fullReductionList = new List<ProductFullReduction>();
            foreach (var fullReduction in dto.ProductFullReductionList)
            {
                var fullReductionEntity = fullReduction.EntityMap<ProductFullReductionDto, ProductFullReduction>();
                fullReductionEntity.ProductId = productInfo.Id;
                fullReductionList.Add(fullReductionEntity);
            }
            await _productFullReductionRepository.MultiAddAsync(fullReductionList);

            //梯级价格
            var productLadderList = new List<ProductLadder>();
            foreach (var productLadder in dto.ProductLadderList)
            {
                var ladderEntity = productLadder.EntityMap<ProductLadderDto, ProductLadder>();
                ladderEntity.ProductId = productInfo.Id;
                productLadderList.Add(ladderEntity);
            }
            await _productLadderRepository.MultiAddAsync(productLadderList);
            
            //属性值
            var attributeValueList = new List<ProductAttributeValue>();
            foreach (var attributeValue in dto.ProductAttributeValueList)
            {
                var attributeValueEntity = attributeValue.EntityMap<ProductAttributeValueDto, ProductAttributeValue>();
                attributeValueEntity.ProductId = productInfo.Id;
                attributeValueList.Add(attributeValueEntity);
            }
            await _productAttributeValueRepository.MultiAddAsync(attributeValueList);


            //库存信息
            var skuStockList = new List<ProductSkuStock>();
            foreach (var skuStock in dto.SkuStockList)
            {
                var skuStockEntity = skuStock.EntityMap<ProductSkuStockDto, ProductSkuStock>();
                skuStockEntity.ProductId = productInfo.Id;
                skuStockList.Add(skuStockEntity);
            }
            await _productSkuStockRepository.MultiAddAsync(skuStockList);
        }

        [HttpPut]
        public async Task UpdateAsync(ProductDto dto)
        {
            try
            {
                //var productInfo = await _productRepository.GetAsync(dto.Id.Value);
                var productInfo = dto.EntityMap<ProductDto, Products>();
                await _productRepository.UpdateAsync(productInfo);


                //会员价格信息
                var memberPriceList = new List<ProductMemberPrice>();

                foreach (var memberPrice in dto.MemberPriceList)
                {
                    var memberPriceEntity = memberPrice.EntityMap<ProductMemberPriceDto, ProductMemberPrice>();
                    memberPriceEntity.ProductId = dto.Id.Value;
                    memberPriceList.Add(memberPriceEntity);
                }
                await _productMemberPriceRepository.DeleteAsync(c => c.ProductId == dto.Id.Value,false);
                await _productMemberPriceRepository.MultiAddAsync(memberPriceList);
                //await _productMemberPriceRepository.MultiUpdateAsync(memberPriceList);

                //满减信息
                var fullReductionList = new List<ProductFullReduction>();
                foreach (var fullReduction in dto.ProductFullReductionList)
                {
                    var fullReductionEntity = fullReduction.EntityMap<ProductFullReductionDto, ProductFullReduction>();
                    fullReductionEntity.ProductId = dto.Id.Value;
                    fullReductionList.Add(fullReductionEntity);
                }
                await _productFullReductionRepository.DeleteAsync(c => c.ProductId == dto.Id.Value, false);
                await _productFullReductionRepository.MultiAddAsync(fullReductionList);

                //梯级价格
                var productLadderList = new List<ProductLadder>();
                foreach (var productLadder in dto.ProductLadderList)
                {
                    var ladderEntity = productLadder.EntityMap<ProductLadderDto, ProductLadder>();
                    ladderEntity.ProductId = dto.Id.Value;
                    productLadderList.Add(ladderEntity);
                }
                await _productLadderRepository.DeleteAsync(c => c.ProductId == dto.Id.Value, false);
                await _productLadderRepository.MultiAddAsync(productLadderList);

                //属性值
                var attributeValueList = new List<ProductAttributeValue>();
                foreach (var attributeValue in dto.ProductAttributeValueList)
                {
                    var attributeValueEntity = attributeValue.EntityMap<ProductAttributeValueDto, ProductAttributeValue>();
                    attributeValueEntity.ProductId = dto.Id.Value;
                    attributeValueList.Add(attributeValueEntity);
                }
                await _productAttributeValueRepository.DeleteAsync(c => c.ProductId == dto.Id.Value, false);
                await _productAttributeValueRepository.MultiAddAsync(attributeValueList);


                //库存信息
                var skuStockList = new List<ProductSkuStock>();
                foreach (var skuStock in dto.SkuStockList)
                {
                    var skuStockEntity = skuStock.EntityMap<ProductSkuStockDto, ProductSkuStock>();
                    skuStockEntity.ProductId = dto.Id.Value;
                    skuStockList.Add(skuStockEntity);
                }
                await _productSkuStockRepository.DeleteAsync(c => c.ProductId == dto.Id.Value, false);
                await _productSkuStockRepository.MultiAddAsync(skuStockList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("newStatus")]
        public async Task UpdateNewStatusAsync(Guid id, bool newStatus)
        {
            var entity = await _productRepository.GetAsync(id);
            entity.NewStatus = newStatus;
            await _productRepository.UpdateAsync(entity);
        }


        [HttpPost("publishStatus")]
        public async Task UpdatePublishStatus(Guid id,bool publishStatus)
        {
            var entity = await _productRepository.GetAsync(id);
            entity.PublishStatus = publishStatus;
            await _productRepository.UpdateAsync(entity);
        }


        [HttpPost("recommendStatus")]
        public async Task UpdateRecommendStatus(Guid id, bool recommendStatus)
        {
            var entity = await _productRepository.GetAsync(id);
            entity.RecommendStatus = recommendStatus;
            await _productRepository.UpdateAsync(entity);
        }
    }
}