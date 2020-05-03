using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using ASample.NetCore.Order.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Order.Api.Controllers
{
    [Route("api/oms/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _ordersRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] OrderParam param)
        {
            var filter = param.SearchLambda<Orders, OrderParam>();
            var result = await _ordersRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<Orders>
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
        /// 订单发货
        /// </summary>
        /// <returns></returns>
        [HttpPut("deliver/{id}")]
        public async Task<ApiRequestResult> DeveliverOrder([FromRoute]Guid id,string deliveryCompany,string deliverySn)
        {
            var entity = await _ordersRepository.GetAsync(id);
            entity.DeliveryCompany = deliveryCompany;    
            entity.DeliverySn = deliverySn;    
            await _ordersRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _ordersRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}