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
    [Route("api/sms/home/recommend/product")]
    [ApiController]
    public class HomeRecommendProductController : ControllerBase
    {
        private readonly IHomeRecommendProductRepository _homeRecommendProductRepository;

        public HomeRecommendProductController(IHomeRecommendProductRepository homeRecommendProductRepository)
        {
            _homeRecommendProductRepository = homeRecommendProductRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _homeRecommendProductRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] HomeRecommendProductParam param)
        {
            var filter = param.SearchLambda<HomeRecommendProduct, HomeRecommendProductParam>();
            var result = await _homeRecommendProductRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<HomeRecommendProduct>
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
        public async Task<ApiRequestResult> AddAsync(List<HomeRecommendProductDto> dtos)
        {
            var recommandProductList = new List<HomeRecommendProduct>();
            foreach (var dto in dtos)
            {
                var exist = await _homeRecommendProductRepository.GetAsync(c => c.ProductId == dto.ProductId);
                if (exist != null)
                    continue;
                var command = dto.EntityMap<HomeRecommendProductDto, HomeRecommendProduct>();
                recommandProductList.Add(command);
            }
            
            await _homeRecommendProductRepository.MultiAddAsync(recommandProductList);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(HomeRecommendProductDto dto)
        {
            var entity = await _homeRecommendProductRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _homeRecommendProductRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _homeRecommendProductRepository.GetAsync(id);
            entity.RecommendStatus = status;
            await _homeRecommendProductRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("sort")]
        public async Task<ApiRequestResult> UpdateSortAsync([FromQuery] HomeRecommendProductDto dto)
        {
            var entity = await _homeRecommendProductRepository.GetAsync(dto.Id.Value);
            entity.Sort = dto.Sort;
            await _homeRecommendProductRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _homeRecommendProductRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}