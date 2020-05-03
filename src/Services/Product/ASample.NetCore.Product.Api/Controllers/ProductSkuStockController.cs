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
    [Route("api/pms/product/sku/stock/")]
    [ApiController]
    public class ProductSkuStockController : ControllerBase
    {
        private readonly IProductSkuStockRepository _productSkuStockRepository;

        public ProductSkuStockController(IProductSkuStockRepository productSkuStockRepository)
        {
            _productSkuStockRepository = productSkuStockRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _productSkuStockRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("query/{productId}")]
        public async Task<ApiRequestResult> QueryByProductIdAsync(Guid productId)
        {
            var result = await _productSkuStockRepository.QueryAsync(c => c.ProductId == productId);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] ProductSkuStockParam param)
        {
            var filter = param.SearchLambda<ProductSkuStock, ProductSkuStockParam>();
            var result = await _productSkuStockRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<ProductSkuStock>
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

        /// <summary>
        /// 新增品牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(ProductSkuStockDto dto)
        {
            var command = dto.EntityMap<ProductSkuStockDto, ProductSkuStock>();
            await _productSkuStockRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改库存信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("{productId}")]
        public async Task<ApiRequestResult> UpdateAsync([FromRoute]Guid productId, List<ProductSkuStockDto> dtos)
        {
            var list = new List<ProductSkuStock>();
            dtos.ForEach(c =>
            {
                var entity = c.EntityMap<ProductSkuStockDto, ProductSkuStock>();
                list.Add(entity);
            });
            await _productSkuStockRepository.DeleteAsync(c => c.ProductId == productId, false);
            await _productSkuStockRepository.MultiAddAsync(list);
            
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _productSkuStockRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}