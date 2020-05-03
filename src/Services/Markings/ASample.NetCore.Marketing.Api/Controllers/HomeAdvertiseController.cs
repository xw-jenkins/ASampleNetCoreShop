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
    [Route("api/sms/home/advertise")]
    [ApiController]
    public class HomeAdvertiseController : ControllerBase
    {
        private readonly IHomeAdvertiseRepository _homeAdvertiseRepository;

        public HomeAdvertiseController(IHomeAdvertiseRepository homeAdvertiseRepository)
        {
            _homeAdvertiseRepository = homeAdvertiseRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _homeAdvertiseRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] HomeAdvertiseParam param)
        {
            var filter = param.SearchLambda<HomeAdvertise, HomeAdvertiseParam>();
            var result = await _homeAdvertiseRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<HomeAdvertise>
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
        public async Task<ApiRequestResult> AddAsync(HomeAdvertiseDto dto)
        {
            var command = dto.EntityMap<HomeAdvertiseDto, HomeAdvertise>();
            await _homeAdvertiseRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(HomeAdvertiseDto dto)
        {
            var entity = await _homeAdvertiseRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _homeAdvertiseRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _homeAdvertiseRepository.GetAsync(id);
            entity.Status = status;
            await _homeAdvertiseRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _homeAdvertiseRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}