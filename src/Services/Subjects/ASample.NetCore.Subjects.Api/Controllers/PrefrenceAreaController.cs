using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Domain.Entities;
using ASample.NetCore.Subjects.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Subjects.Api.Controllers
{
    [Route("api/cms/prfrence/area")]
    [ApiController]
    public class PrefrenceAreaController : ControllerBase
    {
        private readonly IPrefrenceAreaRepository _prefrenceAreaRepository;

        public PrefrenceAreaController(IPrefrenceAreaRepository prefrenceAreaRepository)
        {
            _prefrenceAreaRepository = prefrenceAreaRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _prefrenceAreaRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] PrefrenceAreaParam param)
        {
            var filter = param.SearchLambda<PrefrenceArea, PrefrenceAreaParam>();
            var result = await _prefrenceAreaRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<PrefrenceArea>
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
        public async Task<ApiRequestResult> AddAsync(PrefrenceAreaDto dto)
        {
            var command = dto.EntityMap<PrefrenceAreaDto, PrefrenceArea>();
            await _prefrenceAreaRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(PrefrenceAreaDto dto)
        {
            var entity = await _prefrenceAreaRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _prefrenceAreaRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _prefrenceAreaRepository.GetAsync(id);
            entity.ShowStatus = status;
            await _prefrenceAreaRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _prefrenceAreaRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpGet("product/{prefrenceAreaId}")]
        public async Task<ApiRequestResult> QueryPrefrenceAreaProductAsync([FromRoute] Guid prefrenceAreaId)
        {
            var prefrenceAreaProducts = await _prefrenceAreaRepository.GetPrefrenceAreaProductsAsync(prefrenceAreaId);
            var productIds = new List<Guid>();
            foreach (var item in prefrenceAreaProducts)
            {
                productIds.Add(item.ProductId);
            }
            return ApiRequestResult.Success(productIds, "");
        }

        [HttpPost("product")]
        public async Task<ApiRequestResult> AddPrefrenceAreaProductAsync(PrefrenceAreaProductDto dto)
        {
            var prefrenceAreaProducts = new List<PrefrenceAreaProductRelation>();
            foreach (var item in dto.ProductIds)
            {
                var prefrenceAreaProduct = new PrefrenceAreaProductRelation
                {
                    ProductId = item,
                    PrefrenceAreaId = dto.PrefrenceAreaId
                };
                prefrenceAreaProducts.Add(prefrenceAreaProduct);
            }
            await _prefrenceAreaRepository.MutilAddPrefrenceAreaProductAsync(prefrenceAreaProducts);
            return ApiRequestResult.Success("添加成功");
        }
    }
}