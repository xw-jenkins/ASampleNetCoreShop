using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Domain.Entities;
using ASample.NetCore.Subjects.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Subjects.Api.Controllers
{
    [Route("api/cms/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectCommentRepository _subjectCommentRepository;

        public SubjectController(ISubjectRepository subjectRepository, ISubjectCommentRepository subjectCommentRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectCommentRepository = subjectCommentRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _subjectRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] SubjectParam param)
        {
            var filter = param.SearchLambda<Subject, SubjectParam>();
            var result = await _subjectRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            foreach (var item in result.Items)
            {
                //关联产品数
                var subjectProduct = await _subjectRepository.GetSubjectProductsAsync(item.Id);
                item.ProductCount = subjectProduct.Count();

                //评论数
                var subjectComment = await _subjectCommentRepository.QueryAsync(c => c.SubjectId == item.Id);
                item.CommentCount = subjectComment.Count();
            }

            var pageData = new PagedDto<Subject>
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
        public async Task<ApiRequestResult> AddAsync(SubjectDto dto)
        {
            var command = dto.EntityMap<SubjectDto, Subject>();
            await _subjectRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(SubjectDto dto)
        {
            var entity = await _subjectRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _subjectRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _subjectRepository.GetAsync(id);
            entity.ShowStatus = status;
            await _subjectRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _subjectRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }

        [HttpGet("product/{subjectId}")]
        public async Task<ApiRequestResult> QuerySubjectProductAsync([FromRoute] Guid subjectId)
        {
            var subjectProducts = await _subjectRepository.GetSubjectProductsAsync(subjectId);
            var productIds = new List<Guid>();
            foreach (var item in subjectProducts)
            {
                productIds.Add(item.ProductId);
            }
            return ApiRequestResult.Success(productIds, "");
        }

        [HttpPost("product")]
        public async Task<ApiRequestResult> AddSubjectProductAsync(SubjectProductDto dto)
        {
            var subjectProducts = new List<SubjectProductRelation>();
            foreach (var item in dto.ProductIds)
            {
                var subjectProduct = new SubjectProductRelation
                {
                    ProductId = item,
                    SubjectId = dto.SubjectId
                };
                subjectProducts.Add(subjectProduct);
            }
            await _subjectRepository.MutilAddSubjectProductAsync(subjectProducts);
            return ApiRequestResult.Success("添加成功");
        }
    }
}