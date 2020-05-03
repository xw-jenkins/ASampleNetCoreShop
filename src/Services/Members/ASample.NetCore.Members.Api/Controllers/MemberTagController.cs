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
    [Route("api/ums/member/tag")]
    [ApiController]
    public class MemberTagController : ControllerBase
    {
        private readonly IMemberTagRepository _memberTagRepository;

        public MemberTagController(IMemberTagRepository memberTagRepository)
        {
            _memberTagRepository = memberTagRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _memberTagRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MemberTagParam param)
        {
            var filter = param.SearchLambda<MemberTag, MemberTagParam>();
            var result = await _memberTagRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<MemberTag>
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
        public async Task<ApiRequestResult> AddAsync(MemberTagDto dto)
        {
            var command = dto.EntityMap<MemberTagDto, MemberTag>();
            await _memberTagRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(MemberTagDto dto)
        {
            var entity = await _memberTagRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _memberTagRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _memberTagRepository.GetAsync(id);
            //entity.ShowStatus = showStatus;
            await _memberTagRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }


        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _memberTagRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}