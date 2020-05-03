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
    [Route("api/ums/member/rule/setting")]
    [ApiController]
    public class MemberRuleSettingController : ControllerBase
    {
        private readonly IMemberRuleSettingRepository _memberRuleSettingRepository;

        public MemberRuleSettingController(IMemberRuleSettingRepository memberRuleSettingRepository)
        {
            _memberRuleSettingRepository = memberRuleSettingRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _memberRuleSettingRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MemberRuleSettingParam param)
        {
            var filter = param.SearchLambda<MemberRuleSetting, MemberRuleSettingParam>();
            var result = await _memberRuleSettingRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<MemberRuleSetting>
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
        public async Task<ApiRequestResult> AddAsync(MemberRuleSettingDto dto)
        {
            var command = dto.EntityMap<MemberRuleSettingDto, MemberRuleSetting>();
            await _memberRuleSettingRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(MemberRuleSettingDto dto)
        {
            var entity = await _memberRuleSettingRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _memberRuleSettingRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _memberRuleSettingRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _memberRuleSettingRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _memberRuleSettingRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}