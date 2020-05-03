using System;
using System.Linq;
using System.Threading.Tasks;
using ASample.NetCore.Common;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Queries;
using ASample.NetCore.Identity.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASample.NetCore.Identity.Api.Controllers
{
    [Route("api/rbac/msystem")]
    [ApiController]
    public class MsController : ControllerBase
    {
        private readonly IMsRepository _authMsRepository;

        public MsController(IMsRepository authMsRepository)
        {
            _authMsRepository = authMsRepository;
        }

        [HttpGet("query")]
        public async Task<ApiRequestResult> QueryAsync()
        {
            var result = await _authMsRepository.QueryAsync();
            return ApiRequestResult.Success(result, "");
        }

        [HttpGet("list")]
        public async Task<string> QueryPagedAsync([FromQuery] MsParam param)
        {
            var filter = param.SearchLambda<Ms, MsParam>();
            var result = await _authMsRepository.QueryPagedAsync(param.PageNum, param.PageSize, null, filter);
            var pageData = new PagedDto<Ms>
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

        [HttpPost]
        public async Task<ApiRequestResult> AddAsync(Ms command)
        {
            await _authMsRepository.AddAsync(command);
            return ApiRequestResult.Success("添加成功");
        }

        [HttpPut]
        public async Task<ApiRequestResult> UpdateAsync(MsDto dto)
        {
            var entity = await _authMsRepository.GetAsync(dto.Id);
            var newEntity = dto.EntityMap(entity);
            await _authMsRepository.UpdateAsync(newEntity);

            return ApiRequestResult.Success("修改成功");
        }

        [HttpDelete]
        public async Task<ApiRequestResult> DeleteAsync(Guid id)
        {
            await _authMsRepository.DeleteAsync(id);
            return ApiRequestResult.Success("删除成功");
        }
    }
}