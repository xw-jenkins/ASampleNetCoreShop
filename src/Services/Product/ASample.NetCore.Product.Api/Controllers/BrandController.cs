using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Repositories;
using ASample.NetCore;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ASample.NetCore.Product.Api.Controllers
{
    [Route("api/pms/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _brandRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] BrandParam param)
        {
            var filter = param.SearchLambda<Brand, BrandParam>();
            var result = await _brandRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<Brand>
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
        public async Task<ApiRequestResult> AddAsync(BrandDto dto)
        {
            var command = dto.EntityMap<BrandDto, Brand>();
            await _brandRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(BrandDto dto)
        {
            var entity = await _brandRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _brandRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改牌状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("showStatus/{id}/{showStatus}")]
        public async Task<ApiRequestResult> UpdateStatusAsync(Guid id,bool showStatus)
        {
            var entity = await _brandRepository.GetAsync(id);
            entity.ShowStatus = showStatus;
            await _brandRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        /// <summary>
        /// 修改牌状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("factoryStatus/{id}/{factoryStatus}")]
        public async Task<ApiRequestResult> UpdateFactoryAsync(Guid id, bool factoryStatus)
        {
            var entity = await _brandRepository.GetAsync(id);
            entity.FactoryStatus = factoryStatus;
            await _brandRepository.UpdateAsync(entity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _brandRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}