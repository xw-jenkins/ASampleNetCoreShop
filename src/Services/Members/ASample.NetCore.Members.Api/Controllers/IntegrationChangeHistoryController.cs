using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.Members.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Members.Api.Controllers
{
    [Route("api/ums/member/integration/change/history")]
    [ApiController]
    public class IntegrationChangeHistoryController : ControllerBase
    {
        private readonly IIntegrationChangeHistoryRepository _integrationChangeHistoryRepository;

        public IntegrationChangeHistoryController(IIntegrationChangeHistoryRepository integrationChangeHistoryRepository)
        {
            _integrationChangeHistoryRepository = integrationChangeHistoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _integrationChangeHistoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] IntegrationChangeHistoryParam param)
        {
            var filter = param.SearchLambda<IntegrationChangeHistory, IntegrationChangeHistoryParam>();
            var result = await _integrationChangeHistoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<IntegrationChangeHistory>
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
        public async Task<ApiRequestResult> AddAsync(IntegrationChangeHistoryDto dto)
        {
            var command = dto.EntityMap<IntegrationChangeHistoryDto, IntegrationChangeHistory>();
            await _integrationChangeHistoryRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(IntegrationChangeHistoryDto dto)
        {
            var entity = await _integrationChangeHistoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _integrationChangeHistoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _integrationChangeHistoryRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _integrationChangeHistoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _integrationChangeHistoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}