using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Domain.Entities;
using ASample.NetCore.Product.Api.Repositories;
using ASample.NetCore;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Product.Api.Controllers
{
    [Route("api/pms/product/category")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _productCategoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] ProductCategoryParam param)
        {
            try
            {
                var result = await _productCategoryRepository.QueryPagedAsync(c => c.ParentId == null, param);
                var list = new List<ProductCategoryDto>();
                if (result.Items != null)
                {
                    foreach (var item in result.Items)
                    {
                        var menuDto = item.EntityMap<ProductCategory, ProductCategoryDto>();
                        menuDto.HasChildren = true;
                        list.Add(menuDto);
                    }
                }

                var pageData = new PagedDto<ProductCategoryDto>
                {
                    Code = 200,
                    Msg = "获取数据成功",
                    Total = result.TotalResults,
                    //PageSize = param.P,
                    Data = list
                };
                var json = pageData.ToString();
                return json;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("childs/{id}")]
        public async Task<ApiRequestResult> QueryChildMenuAsync([FromRoute] Guid id)
        {
            var result = await _productCategoryRepository.QueryAsync(c => c.ParentId != null && c.ParentId == id);
            return ApiRequestResult.Success(result.ToList(), "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ApiRequestResult> GetAsync(Guid id)
        {
            var result = await _productCategoryRepository.GetAsync(c => c.Id == id);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("attribute/{productCateId}")]
        public async Task<ApiRequestResult> QueryAttrsAsync(Guid productCateId)
        {
            var result = await _productCategoryRepository.QueryProductAttributeAsync(productCateId);
            return ApiRequestResult.Success(result, "");
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(ProductCategoryDto dto)
        {
            var command = dto.EntityMap<ProductCategoryDto, ProductCategory>();
            command.Id = Guid.NewGuid();
            await _productCategoryRepository.AddAsync(command);
            foreach (var item in dto.ProductAttributeIdList)
            {
                var productAttrCateR = new ProductCategoryAttributeRelation
                {
                    ProductCategoryId = command.Id,
                    ProductAttributeId = item,
                };
                await _productCategoryRepository.AddProductCateAttrAsync(productAttrCateR);
            }
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(ProductCategoryDto dto)
        {
            var entity = await _productCategoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _productCategoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("showStatus/{id}/{showStatus}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id,bool showStatus)
        {
            var entity = await _productCategoryRepository.GetAsync(id);
            entity.ShowStatus = showStatus;
            await _productCategoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("showStatus/{id}/{navShowStatus}")]
        public async Task<ApiRequestResult> UpdateNavStatusAsync(Guid id, bool showStatus)
        {
            var entity = await _productCategoryRepository.GetAsync(id);
            entity.NavStatus = showStatus;
            await _productCategoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _productCategoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}