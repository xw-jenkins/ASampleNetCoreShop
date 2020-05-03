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
    [Route("api/cms/subject/category")]
    [ApiController]
    public class SubjectCategoryController : ControllerBase
    {
        private readonly ISubjectCategoryRepository _subjectCategoryRepository;

        public SubjectCategoryController(ISubjectCategoryRepository subjectCategoryRepository)
        {
            _subjectCategoryRepository = subjectCategoryRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _subjectCategoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] SubjectCategoryParam param)
        {
            var filter = param.SearchLambda<SubjectCategory, SubjectCategoryParam>();
            var result = await _subjectCategoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<SubjectCategory>
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
        public async Task<ApiRequestResult> AddAsync(SubjectCategoryDto dto)
        {
            var command = dto.EntityMap<SubjectCategoryDto, SubjectCategory>();
            await _subjectCategoryRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(SubjectCategoryDto dto)
        {
            var entity = await _subjectCategoryRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _subjectCategoryRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _subjectCategoryRepository.GetAsync(id);
            entity.ShowStatus = status;
            await _subjectCategoryRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _subjectCategoryRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}