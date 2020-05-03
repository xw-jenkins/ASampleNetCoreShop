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
    [Route("api/pms/product/attribute")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeRepository _productAttributeRepository;
        private readonly IProductAttributeCategoryRepository _productAttributeCategoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductAttributeController(IProductAttributeRepository productAttributeRepository, IProductAttributeCategoryRepository productAttributeCategoryRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productAttributeRepository = productAttributeRepository;
            _productAttributeCategoryRepository = productAttributeCategoryRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _productAttributeRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        } 
        
        [HttpGet("attrinfos")]
        public async Task<ApiRequestResult> QueryAsync([FromQuery] ProductAttributeParam param)
        {
            var result = await _productAttributeRepository.QueryAsync(c => c.ProductAttributeCategoryId == param.ProductAttributeCategoryId && c.Type == param.Type);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list/{id}")]
        public async Task<string> QueryPagedAsync(Guid id,[FromQuery] ProductAttributeParam param)
        {
            param.ProductAttributeCategoryId = id;
            var filter = param.SearchLambda<ProductAttribute, ProductAttributeParam>();
            var result = await _productAttributeRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<ProductAttribute>
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

        [HttpGet("{id}")]
        public async Task<ApiRequestResult> GetAsync(Guid id)
        {
            var result = await _productAttributeRepository.QueryAsync(c => c.Id == id);
            return ApiRequestResult.Success(result, "");
        }

        //[HttpGet("attrinfos/{productCateId}")]
        //public async Task<ApiRequestResult> QueryAttrsAsync(Guid productCateId)
        //{
        //    var productCateAttrRelations = await _productCategoryRepository.QueryProductAttributeAsync(productCateId);
        //    var list = new List<ProductAttribute>();
        //    foreach (var item in productCateAttrRelations)
        //    {
        //        var productAttrs = await _productAttributeRepository.QueryAsync(c => c.Id == item.ProductAttributeId);
        //        list.AddRange(productAttrs);
        //    }
            
        //    return ApiRequestResult.Success(list, "");
        //}


        /// <summary>
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(ProductAttributeDto dto)
        {
            var command = dto.EntityMap<ProductAttributeDto, ProductAttribute>();

            var proAttrCate = await _productAttributeCategoryRepository.GetAsync(c => c.Id == dto.ProductAttributeCategoryId);
            if (dto.Type == 0)
                proAttrCate.AttributeCount += 1;
            if(dto.Type == 1)
                proAttrCate.ParamCount += 1;
            await _productAttributeCategoryRepository.UpdateAsync(proAttrCate);
            await _productAttributeRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(ProductAttributeDto dto)
        {
            var entity = await _productAttributeRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _productAttributeRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("showStatus/{id}/{showStatus}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id,bool showStatus)
        {
            var entity = await _productAttributeRepository.GetAsync(id);
            await _productAttributeRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _productAttributeRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}