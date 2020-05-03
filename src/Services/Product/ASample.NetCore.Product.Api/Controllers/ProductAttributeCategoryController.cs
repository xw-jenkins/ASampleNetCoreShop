using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Repositories;
using ASample.NetCore;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Product.Api.Controllers
{
    [Route("api/pms/product/attribute/category")]
    [ApiController]
    public class ProductAttributeCategoryController : ControllerBase
    {
        private readonly IProductAttributeCategoryRepository _productAttributeCategoryRepository;
        private readonly IProductAttributeRepository _productAttributeRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductAttributeCategoryController(IProductAttributeCategoryRepository productAttributeCategoryRepository, IProductAttributeRepository productAttributeRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productAttributeCategoryRepository = productAttributeCategoryRepository;
            _productAttributeRepository = productAttributeRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _productAttributeCategoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] ProductAttributeCategoryParam param)
        {
            var filter = param.SearchLambda<ProductAttributeCategory, ProductAttributeCategoryParam>();
            var result = await _productAttributeCategoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<ProductAttributeCategory>
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

        [HttpGet("getattributes/{id}")]
        public async Task<ApiRequestResult> QueryProductAttributeAsync(Guid categoryAttributeId)
        {
            var productCategoryAttr = await _productAttributeRepository.QueryAsync(c => c.ProductAttributeCategoryId == categoryAttributeId);
            return ApiRequestResult.Success(productCategoryAttr, "");
        }
        

        [HttpGet("list/withattr")]
        public async Task<ApiRequestResult> QueryProductCateWithAttrAsync()
        {
            try
            {
                var productAttrCates = await _productAttributeCategoryRepository.QueryAsync(c => true);
                var list = new List<ProductAttrCateWithAttrDto>();
                foreach (var item in productAttrCates.ToList())
                {
                    var productAttrCateDto = new ProductAttrCateWithAttrDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                    };
                    var productCategoryAttr = await _productAttributeRepository.QueryAsync(c => c.ProductAttributeCategoryId == item.Id);
                    productAttrCateDto.ProductAttributes = productCategoryAttr.Select(c => c.EntityMap<ProductAttribute, ProductAttributeDto>()).ToList();
                    list.Add(productAttrCateDto);
                }
                return ApiRequestResult.Success(list, "");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(ProductAttributeCategoryDto dto)
        {
            var command = dto.EntityMap<ProductAttributeCategoryDto, ProductAttributeCategory>();
            await _productAttributeCategoryRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(ProductAttributeCategoryDto dto)
        {
            var entity = await _productAttributeCategoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _productAttributeCategoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _productAttributeCategoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}