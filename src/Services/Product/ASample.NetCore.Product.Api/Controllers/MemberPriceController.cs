using System;
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
    [Route("api/pms/memberprice")]
    [ApiController]
    public class MemberPriceController : ControllerBase
    {
        private readonly IProductMemberPriceRepository _memberPriceRepository;

        public MemberPriceController(IProductMemberPriceRepository memberPriceRepository)
        {
            _memberPriceRepository = memberPriceRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _memberPriceRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MemberPriceParam param)
        {
            var filter = param.SearchLambda<ProductMemberPrice, MemberPriceParam>();
            var result = await _memberPriceRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<ProductMemberPrice>
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
        /// 新增信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(ProductMemberPriceDto dto)
        {
            var command = dto.EntityMap<ProductMemberPriceDto, ProductMemberPrice>();
            await _memberPriceRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(ProductMemberPriceDto dto)
        {
            var entity = await _memberPriceRepository.GetAsync(dto.Id.Value);
            var newEntity = dto.EntityMap(entity);
            await _memberPriceRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _memberPriceRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}