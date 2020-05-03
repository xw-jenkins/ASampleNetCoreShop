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
    [Route("api/ums/member/statistics/")]
    [ApiController]
    public class MemberStatisticsInfoController : ControllerBase
    {
        private readonly IMemberStatisticsInfoRepository _memberStatisticsInfoRepository;

        public MemberStatisticsInfoController(IMemberStatisticsInfoRepository memberStatisticsInfoRepository)
        {
            _memberStatisticsInfoRepository = memberStatisticsInfoRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _memberStatisticsInfoRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MemberStatisticsInfoParam param)
        {
            var filter = param.SearchLambda<MemberStatisticsInfo, MemberStatisticsInfoParam>();
            var result = await _memberStatisticsInfoRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<MemberStatisticsInfo>
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
        public async Task<ApiRequestResult> AddAsync(MemberStatisticsInfoDto dto)
        {
            var command = dto.EntityMap<MemberStatisticsInfoDto, MemberStatisticsInfo>();
            await _memberStatisticsInfoRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(MemberStatisticsInfoDto dto)
        {
            var entity = await _memberStatisticsInfoRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _memberStatisticsInfoRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _memberStatisticsInfoRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _memberStatisticsInfoRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _memberStatisticsInfoRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}