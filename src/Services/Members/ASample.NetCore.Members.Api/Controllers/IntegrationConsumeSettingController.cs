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
    [Route("api/ums/member/integration/consume/setting")]
    [ApiController]
    public class IntegrationConsumeSettingController : ControllerBase
    {
        private readonly IIntegrationConsumeSettingRepository _integrationConsumeSettingRepository;

        public IntegrationConsumeSettingController(IIntegrationConsumeSettingRepository integrationConsumeSettingRepository)
        {
            _integrationConsumeSettingRepository = integrationConsumeSettingRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _integrationConsumeSettingRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] IntegrationConsumeSettingParam param)
        {
            var filter = param.SearchLambda<IntegrationConsumeSetting, IntegrationConsumeSettingParam>();
            var result = await _integrationConsumeSettingRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<IntegrationConsumeSetting>
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
        public async Task<ApiRequestResult> AddAsync(IntegrationConsumeSettingDto dto)
        {
            var command = dto.EntityMap<IntegrationConsumeSettingDto, IntegrationConsumeSetting>();
            await _integrationConsumeSettingRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(IntegrationConsumeSettingDto dto)
        {
            var entity = await _integrationConsumeSettingRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _integrationConsumeSettingRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _integrationConsumeSettingRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _integrationConsumeSettingRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _integrationConsumeSettingRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}