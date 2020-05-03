using System.Collections.Generic;
using System.Threading.Tasks;
using ASample.NetCore.Authentications;
using ASample.NetCore.FileStorage.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ASample.NetCore.FileStorage.Api.Controllers
{
    [Route("api/file/image")]
    [ApiController]
    //[JwtAuth]
    public class ImageController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IHostEnvironment _environment;
        public ImageController(IFileRepository fileRepository, 
            IHostEnvironment environment)
        {
            _fileRepository = fileRepository;
            _environment = environment;
        }

        [HttpPost]
        public async Task<ApiRequestResult> UploadAsync(IFormFile file)
        {
            //Log.Information($"UploadController -> Post. File: {JsonConvert.SerializeObject(file)}");
            //var token = HttpContext.Request.Headers["Authorization"].ToString();
            //var key = token.Replace("Bearer", "").Trim();
            //var jsonRedis = await _cache.GetStringAsync(key);
            //if (jsonRedis.IsNullOrEmpty())
            //    return ApiRequestResult.Error("登录已过期", HttpStatusCode.Unauthorized);
            //var jsonWebToken = JsonConvert.DeserializeObject<JsonWebToken>(jsonRedis);
            if (file != null)
            {
                var result = await _fileRepository.SaveFileAsync(_environment.ContentRootPath, file);
                return result;
            }

            return ApiRequestResult.Error("上传图片为空");
        }

        [HttpPost("multi")]
        public async Task<ApiRequestResult> UploadMultiAsync(List<IFormFile> files)
        {
            //Log.Information($"UploadController -> Post. File: {JsonConvert.SerializeObject(file)}");

            if (files != null && files.Count > 0)
            {
                var result = await _fileRepository.SaveMultiFileAsync(_environment.ContentRootPath, files);
                return result;
            }

            return ApiRequestResult.Error("上传图片为空");
        }

        [HttpDelete]
        public ApiRequestResult Delete(string link)
        {
            //Log.Information($"UploadController -> Delete. FileName: {link}");
            var result = _fileRepository.DeleteFile(_environment.ContentRootPath, link);
            return result;
        }
    }
}