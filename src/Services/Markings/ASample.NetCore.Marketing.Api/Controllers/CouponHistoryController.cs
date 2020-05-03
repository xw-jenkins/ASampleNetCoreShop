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
    [Route("api/sms/coupon/history")]
    [ApiController]
    public class CouponHistoryController : ControllerBase
    {
        private readonly ICouponHistoryRepository _couponHistoryRepository;
        private readonly ICouponProductCategoryRelationRepository _couponProductCategoryRelationRepository;
        private readonly ICouponProductRelationRepository _couponProductRelationRepository;

        public CouponHistoryController(ICouponHistoryRepository couponHistoryRepository, ICouponProductCategoryRelationRepository couponProductCategoryRelationRepository = null, ICouponProductRelationRepository couponProductRelationRepository = null)
        {
            _couponHistoryRepository = couponHistoryRepository;
            _couponProductCategoryRelationRepository = couponProductCategoryRelationRepository;
            _couponProductRelationRepository = couponProductRelationRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _couponHistoryRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] CouponHistoryParam param)
        {
            var filter = param.SearchLambda<CouponHistory, CouponHistoryParam>();
            var result = await _couponHistoryRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var dtos = new List<CouponHistoryDto>();
            foreach (var coupon in result.Items)
            {
                var productCategoryRelationList = await _couponProductCategoryRelationRepository.QueryAsync(c => c.CouponId == coupon.Id);
                var productRelationList = await _couponProductRelationRepository.QueryAsync(c => c.CouponId == coupon.Id);
                
                var dto = coupon.EntityMap<CouponHistory, CouponHistoryDto>();
                dto.ProductCategoryRelationList = productCategoryRelationList.ToList();
                dto.ProductRelationList = productRelationList.ToList();
                dtos.Add(dto);
            }
            var pageData = new PagedDto<CouponHistoryDto>
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
    }
}