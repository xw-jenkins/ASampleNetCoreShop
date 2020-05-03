using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.Marketing.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Marketing.Api.Controllers
{
    [Route("api/sms/home/new/product")]
    [ApiController]
    public class HomeNewProductController : ControllerBase
    {
        private readonly IHomeNewProductRepository _homeNewProductRepository;

        public HomeNewProductController(IHomeNewProductRepository homeNewProductRepository)
        {
            _homeNewProductRepository = homeNewProductRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _homeNewProductRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] HomeNewProductParam param)
        {
            var filter = param.SearchLambda<HomeNewProduct, HomeNewProductParam>();
            var result = await _homeNewProductRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<HomeNewProduct>
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
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(List<HomeNewProductDto> dtos)
        {
            var newProductList = new List<HomeNewProduct>();
            foreach (var dto in dtos)
            {
                var exist = await _homeNewProductRepository.GetAsync(c => c.ProductId == dto.ProductId);
                if (exist != null)
                    continue;
                var command = dto.EntityMap<HomeNewProductDto, HomeNewProduct>();
                newProductList.Add(command);
            }
            await _homeNewProductRepository.MultiAddAsync(newProductList);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(HomeNewProductDto dto)
        {
            var entity = await _homeNewProductRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _homeNewProductRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _homeNewProductRepository.GetAsync(id);
            entity.RecommendStatus = status;
            await _homeNewProductRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("sort")]
        public async Task<ApiRequestResult> UpdateSortAsync([FromQuery] HomeNewProductDto dto)
        {
            var entity = await _homeNewProductRepository.GetAsync(dto.Id.Value);
            entity.Sort = dto.Sort;
            await _homeNewProductRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _homeNewProductRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}