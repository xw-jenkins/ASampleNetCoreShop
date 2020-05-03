using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.Marketing.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Marketing.Api.Controllers
{
    [Route("api/sms/home/brand")]
    [ApiController]
    public class HomeBrandController : ControllerBase
    {
        private readonly IHomeBrandRepository _homeBrandRepository;

        public HomeBrandController(IHomeBrandRepository homeBrandRepository)
        {
            _homeBrandRepository = homeBrandRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _homeBrandRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] HomeBrandParam param)
        {
            var filter = param.SearchLambda<HomeBrand, HomeBrandParam>();
            var result = await _homeBrandRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<HomeBrand>
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
        public async Task<ApiRequestResult> AddAsync(List<HomeBrandDto> dtos)
        {
            var dtoList = new List<HomeBrand>();
            foreach (var dto in dtos)
            {
                var command = dto.EntityMap<HomeBrandDto, HomeBrand>();
                var exist = await _homeBrandRepository.GetAsync(c => c.BrandId == dto.BrandId);
                if (exist != null)
                    continue;
                dtoList.Add(command);
            }
            await _homeBrandRepository.MultiAddAsync(dtoList);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(HomeBrandDto dto)
        {
            var entity = await _homeBrandRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _homeBrandRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("status/{id}/{status}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id, bool status)
        {
            var entity = await _homeBrandRepository.GetAsync(id);
            entity.RecommendStatus = status;
            await _homeBrandRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("sort")]
        public async Task<ApiRequestResult> UpdateSortAsync([FromQuery] HomeBrandDto dto)
        {
            var entity = await _homeBrandRepository.GetAsync(dto.Id.Value);
            entity.Sort = dto.Sort;
            await _homeBrandRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _homeBrandRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}