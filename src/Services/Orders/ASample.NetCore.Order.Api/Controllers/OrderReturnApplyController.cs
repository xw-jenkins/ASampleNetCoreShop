using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Order.Api.Domain;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.Order.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Order.Api.Controllers
{
    [Route("api/oms/order/returnApply")]
    [ApiController]
    public class OrderReturnApplyController : ControllerBase
    {
        private readonly IOrderReturnApplyRepository _orderReturnApplyRepository;

        public OrderReturnApplyController(IOrderReturnApplyRepository ordersReturnApplyRepository)
        {
            _orderReturnApplyRepository = ordersReturnApplyRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _orderReturnApplyRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] OrderReturnApplyParam param)
        {
            var filter = param.SearchLambda<OrderReturnApply, OrderReturnApplyParam>();
            var result = await _orderReturnApplyRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<OrderReturnApply>
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
        /// 审核退货申请
        /// </summary>
        /// <returns></returns>
        [HttpPut("check/{id}")]
        public async Task<ApiRequestResult> DeveliverOrder([FromRoute]Guid id,ApplyStatus status)
        {
            var entity = await _orderReturnApplyRepository.GetAsync(id);
            entity.Status = status;    
            await _orderReturnApplyRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("审核成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _orderReturnApplyRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}