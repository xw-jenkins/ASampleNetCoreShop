using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.Marketing.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Marketing.Api.Controllers
{
    [Route("api/sms/flash/session")]
    [ApiController]
    public class FlashPromotionSessionController : ControllerBase
    {
        private readonly IFlashPromotionSessionRepository _flashPromotionSessionRepository;

        public FlashPromotionSessionController(IFlashPromotionSessionRepository flashPromotionSessionRepository)
        {
            _flashPromotionSessionRepository = flashPromotionSessionRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _flashPromotionSessionRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("selectList/{flashPromotionId}")]
        public async Task<ApiRequestResult> QueryByIdAsync(Guid flashPromotionId)
        {
            var result = await _flashPromotionSessionRepository.QueryAsync(c => c.Status);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] FlashPromotionSessionParam param)
        {
            var filter = param.SearchLambda<FlashPromotionSession, FlashPromotionSessionParam>();
            var result = await _flashPromotionSessionRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<FlashPromotionSession>
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
        public async Task<ApiRequestResult> AddAsync(FlashPromotionSessionDto dto)
        {
            var command = dto.EntityMap<FlashPromotionSessionDto, FlashPromotionSession>();
            await _flashPromotionSessionRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(FlashPromotionSessionDto dto)
        {
            var entity = await _flashPromotionSessionRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _flashPromotionSessionRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _flashPromotionSessionRepository.GetAsync(id);
            entity.Status = status;
            await _flashPromotionSessionRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _flashPromotionSessionRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}