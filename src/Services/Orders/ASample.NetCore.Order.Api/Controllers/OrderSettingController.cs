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
    [Route("api/oms/order/setting")]
    [ApiController]
    public class OrderSettingController : ControllerBase
    {
        private readonly IOrderSettingRepository _orderSettingRepository;

        public OrderSettingController(IOrderSettingRepository orderSettingRepository)
        {
            _orderSettingRepository = orderSettingRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _orderSettingRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("get")]
        public async Task<ApiRequestResult> QueryFirstAsync()
        {
            var result = await _orderSettingRepository.QueryAsync();
            return ApiRequestResult.Success(result.FirstOrDefault()??new OrderSetting(), "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] OrderSettingParam param)
        {
            var filter = param.SearchLambda<OrderSetting, OrderSettingParam>();
            var result = await _orderSettingRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<OrderSetting>
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
        public async Task<ApiRequestResult> AddAsync(OrderSettingDto dto)
        {
            var command = dto.EntityMap<OrderSettingDto, OrderSetting>();
            await _orderSettingRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改订单设置信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(OrderSettingDto dto)
        {
            var entity = await _orderSettingRepository.GetAsync(dto.Id.Value);
            
            if (entity == null)
            {
                var newEntity = dto.EntityMap<OrderSettingDto, OrderSetting>();
                await _orderSettingRepository.AddAsync(newEntity);
            }
            else
            {
                var updateEntity = dto.EntityMap(entity);
                await _orderSettingRepository.UpdateAsync(updateEntity);
            }
                
            return ApiRequestResult.Success("修改成功");
        }
        

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _orderSettingRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}