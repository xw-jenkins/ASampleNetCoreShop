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
    [Route("api/cms/topic/category")]
    [ApiController]
    public class TopicCategoryController : ControllerBase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public TopicCategoryController(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _topicCategoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] TopicCategoryParam param)
        {
            var filter = param.SearchLambda<TopicCategory, TopicCategoryParam>();
            var result = await _topicCategoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<TopicCategory>
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
        public async Task<ApiRequestResult> AddAsync(TopicCategoryDto dto)
        {
            var command = dto.EntityMap<TopicCategoryDto, TopicCategory>();
            await _topicCategoryRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(TopicCategoryDto dto)
        {
            var entity = await _topicCategoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _topicCategoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _topicCategoryRepository.GetAsync(id);
            await _topicCategoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _topicCategoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}