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
    [Route("api/sms/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponProductCategoryRelationRepository _couponProductCategoryRelationRepository;
        private readonly ICouponProductRelationRepository _couponProductRelationRepository;

        public CouponController(ICouponRepository couponRepository, ICouponProductCategoryRelationRepository couponProductCategoryRelationRepository = null, ICouponProductRelationRepository couponProductRelationRepository = null)
        {
            _couponRepository = couponRepository;
            _couponProductCategoryRelationRepository = couponProductCategoryRelationRepository;
            _couponProductRelationRepository = couponProductRelationRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _couponRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("{id}")]
        public async Task<ApiRequestResult> GetAsync(Guid id)
        {
            var result = await _couponRepository.GetAsync(id);
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] CouponParam param)
        {
            var filter = param.SearchLambda<Coupon, CouponParam>();
            var result = await _couponRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var dtos = new List<CouponDto>();
            foreach (var coupon in result.Items)
            {
                var productCategoryRelationList = await _couponProductCategoryRelationRepository.QueryAsync(c => c.CouponId == coupon.Id);
                var productRelationList = await _couponProductRelationRepository.QueryAsync(c => c.CouponId == coupon.Id);
                
                var dto = coupon.EntityMap<Coupon, CouponDto>();
                dto.ProductCategoryRelationList = productCategoryRelationList.ToList();
                dto.ProductRelationList = productRelationList.ToList();
                dtos.Add(dto);
            }
            var pageData = new PagedDto<CouponDto>
            {
                Code = 200,
                Msg = "获取数据成功",
                Total = result.TotalResults,
                PageSize = param.PageSize,
                Data = dtos
            };
            var json = pageData.ToString();
            return json;
        }

        /// <summary>
        /// 新增品牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(CouponDto dto)
        {
            var command = dto.EntityMap<CouponDto, Coupon>();
            command.Id = Guid.NewGuid();
            if (dto.ProductRelationList.Count > 0)
            {
                var newEntitys = dto.ProductRelationList.Select(c => new CouponProductRelation
                {
                    CouponId = command.Id,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ProductSn = c.ProductSn,
                }).ToList();
                await _couponProductRelationRepository.MultiAddAsync(newEntitys);
            }

            if (dto.ProductCategoryRelationList.Count > 0)
            {
                var newEntitys = dto.ProductCategoryRelationList.Select(c => new CouponProductCategoryRelation
                {
                    CouponId = command.Id,
                    ProductCategoryId = c.ProductCategoryId,
                    ProductCategoryName = c.ProductCategoryName,
                    ParentCategoryName = c.ParentCategoryName,
                }).ToList();
                await _couponProductCategoryRelationRepository.MultiAddAsync(newEntitys);
            }
            await _couponRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        /// <summary>
        /// 修改牌信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(CouponDto dto)
        {
            var entity = await _couponRepository.GetAsync(dto.Id.Value);
            if(dto.ProductRelationList.Count > 0)
            {
                var newEntitys = dto.ProductRelationList.Select(c => new CouponProductRelation
                {
                    CouponId = dto.Id.Value,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ProductSn = c.ProductSn,
                }).ToList();
                await _couponProductCategoryRelationRepository.DeleteAsync(c => c.CouponId == dto.Id.Value);
                await _couponProductRelationRepository.MultiAddAsync(newEntitys);
            }

            if (dto.ProductCategoryRelationList.Count > 0)
            {
                var newEntitys = dto.ProductCategoryRelationList.Select(c => new CouponProductCategoryRelation
                {
                    CouponId = dto.Id.Value,
                    ProductCategoryId = c.ProductCategoryId,
                    ProductCategoryName = c.ProductCategoryName,
                    ParentCategoryName = c.ParentCategoryName,
                }).ToList();
                await _couponProductRelationRepository.DeleteAsync(c => c.CouponId == dto.Id.Value);
                await _couponProductCategoryRelationRepository.MultiAddAsync(newEntitys);
            }
            var newEntity = dto.EntityMap(entity);
            await _couponRepository.UpdateAsync(newEntity);
            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete("{id}")]
        public async Task<ApiRequestResult> DeleteAsync([FromRoute]Guid id)
        {
            await _couponRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}