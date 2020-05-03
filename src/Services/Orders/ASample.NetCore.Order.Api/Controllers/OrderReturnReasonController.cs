using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.Order.Api.Repositories;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Order.Api.Controllers
{
    [Route("api/oms/order/returnReason")]
    [ApiController]
    public class OrderReturnReasonController : ControllerBase
    {
        private readonly IOrderReturnReasonRepository _orderReturnReasonRepository;

        public OrderReturnReasonController(IOrderReturnReasonRepository orderReturnReasonRepository)
        {
            _orderReturnReasonRepository = orderReturnReasonRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _orderReturnReasonRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] OrderReturnReasonParam param)
        {
            var filter = param.SearchLambda<OrderReturnReason, OrderReturnReasonParam>();
            var result = await _orderReturnReasonRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<OrderReturnReason>
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
        /// 新增订单设置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(OrderReturnReasonDto dto)
        {
            var command = dto.EntityMap<OrderReturnReasonDto, OrderReturnReason>();
            await _orderReturnReasonRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改订单设置信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(OrderReturnReasonDto dto)
        {
            var entity = await _orderReturnReasonRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _orderReturnReasonRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }
        

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _orderReturnReasonRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync([FromRoute]Guid id,bool status)
        {
            var entity = await _orderReturnReasonRepository.GetAsync(id);
            entity.Status = status;
            await _orderReturnReasonRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }
    }
}