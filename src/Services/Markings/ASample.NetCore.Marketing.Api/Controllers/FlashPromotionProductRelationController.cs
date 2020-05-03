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
    [Route("api/sms/flash/product")]
    [ApiController]
    public class FlashPromotionProductRelationController : ControllerBase
    {
        private readonly IFlashPromotionProductRelationRepository _flashPromotionProductRelationRepository;

        public FlashPromotionProductRelationController(IFlashPromotionProductRelationRepository flashPromotionProductRelationRepository)
        {
            _flashPromotionProductRelationRepository = flashPromotionProductRelationRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _flashPromotionProductRelationRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }
        
        [HttpGet("getproduct/{flashPromotionId}/{flashPromotionSessionId}")]
        public async Task<ApiRequestResult> QueryFlashProductRelationAsync([FromRoute]Guid flashPromotionId, Guid flashPromotionSessionId)
        {
            var result = await _flashPromotionProductRelationRepository.QueryAsync(c => c.FlashPromotionId == flashPromotionId && c.FlashPromotionSessionId == flashPromotionSessionId);
            return ApiRequestResult.Success(result, "");
        }


        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] FlashPromotionProductRelationParam param)
        {
            var filter = param.SearchLambda<FlashPromotionProductRelation, FlashPromotionProductRelationParam>();
            var result = await _flashPromotionProductRelationRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<FlashPromotionProductRelation>
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
        public async Task<ApiRequestResult> AddAsync(FlashPromotionProductRelationDto dto)
        {
            var command = dto.EntityMap<FlashPromotionProductRelationDto, FlashPromotionProductRelation>();
            await _flashPromotionProductRelationRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("addList")]
        public async Task<ApiRequestResult> AddListAsync(List<FlashPromotionProductRelationDto> dtos)
        {
            var list = new List<FlashPromotionProductRelation>();
            foreach (var dto in dtos)
            {
                var command = dto.EntityMap<FlashPromotionProductRelationDto, FlashPromotionProductRelation>();
                list.Add(command);
            }
            await _flashPromotionProductRelationRepository.MultiAddAsync(list);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(FlashPromotionProductRelationDto dto)
        {
            try
            {
                var entity = await _flashPromotionProductRelationRepository.GetAsync(dto.Id.Value);
                var newEntity = dto.EntityMap(entity);
                await _flashPromotionProductRelationRepository.UpdateAsync(newEntity);
                return ApiRequestResult.Success("修改成功");
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _flashPromotionProductRelationRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}