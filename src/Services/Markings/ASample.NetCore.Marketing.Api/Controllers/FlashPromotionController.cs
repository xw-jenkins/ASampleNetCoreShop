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
    [Route("api/sms/flash/promotion")]
    [ApiController]
    public class FlashPromotionController : ControllerBase
    {
        private readonly IFlashPromotionRepository _flashPromotionRepository;

        public FlashPromotionController(IFlashPromotionRepository flashPromotionRepository)
        {
            _flashPromotionRepository = flashPromotionRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _flashPromotionRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("selectList/{flashPromotionId}")]
        public async Task<ApiRequestResult> QueryByIdAsync(Guid flashPromotionId)
        {
            var result = await _flashPromotionRepository.QueryAsync(c => c.Id == flashPromotionId);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] FlashPromotionParam param)
        {
            var filter = param.SearchLambda<FlashPromotion, FlashPromotionParam>();
            var result = await _flashPromotionRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<FlashPromotion>
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
        public async Task<ApiRequestResult> AddAsync(FlashPromotionDto dto)
        {
            var command = dto.EntityMap<FlashPromotionDto, FlashPromotion>();
            await _flashPromotionRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(FlashPromotionDto dto)
        {
            var entity = await _flashPromotionRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _flashPromotionRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _flashPromotionRepository.GetAsync(id);
            entity.Status = status;
            await _flashPromotionRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _flashPromotionRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}