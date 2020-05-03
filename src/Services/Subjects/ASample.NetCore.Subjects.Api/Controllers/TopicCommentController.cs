using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Subjects.Api.Controllers
{
    [Route("api/cms/topic/comment")]
    [ApiController]
    public class TopicCommentController : ControllerBase
    {
        private readonly ITopicCommentRepository _topicCommentRepository;

        public TopicCommentController(ITopicCommentRepository topicCommentRepository)
        {
            _topicCommentRepository = topicCommentRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _topicCommentRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] TopicCommentParam param)
        {
            var filter = param.SearchLambda<TopicComment, TopicCommentParam>();
            var result = await _topicCommentRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<TopicComment>
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
        public async Task<ApiRequestResult> AddAsync(TopicCommentDto dto)
        {
            var command = dto.EntityMap<TopicCommentDto, TopicComment>();
            await _topicCommentRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(TopicCommentDto dto)
        {
            var entity = await _topicCommentRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _topicCommentRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _topicCommentRepository.GetAsync(id);
            entity.ShowStatus = status;
            await _topicCommentRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _topicCommentRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}