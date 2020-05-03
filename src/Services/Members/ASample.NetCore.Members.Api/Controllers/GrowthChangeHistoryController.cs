using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.Members.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Members.Api.Controllers
{
    [Route("api/ums/member/growth/change/history")]
    [ApiController]
    public class GrowthChangeHistoryController : ControllerBase
    {
        private readonly IGrowthChangeHistoryRepository _growthChangeHistoryRepository;

        public GrowthChangeHistoryController(IGrowthChangeHistoryRepository growthChangeHistoryRepository)
        {
            _growthChangeHistoryRepository = growthChangeHistoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _growthChangeHistoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] GrowthChangeHistoryParam param)
        {
            var filter = param.SearchLambda<GrowthChangeHistory, GrowthChangeHistoryParam>();
            var result = await _growthChangeHistoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<GrowthChangeHistory>
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
        public async Task<ApiRequestResult> AddAsync(GrowthChangeHistoryDto dto)
        {
            var command = dto.EntityMap<GrowthChangeHistoryDto, GrowthChangeHistory>();
            await _growthChangeHistoryRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(GrowthChangeHistoryDto dto)
        {
            var entity = await _growthChangeHistoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _growthChangeHistoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _growthChangeHistoryRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _growthChangeHistoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _growthChangeHistoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}