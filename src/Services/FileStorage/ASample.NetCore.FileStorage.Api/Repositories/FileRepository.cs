using ASample.NetCore.Common;
using ASample.NetCore.Redis;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.FileStorage.Api.Repositories
{
    public class FileRepository:IFileRepository
    {
        private readonly IASampleRedisCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileRepository(IASampleRedisCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiRequestResult> SaveFileAsync(string webRootPath, IFormFile file)
        {
            //Log.Information($"FileSaverService -> SaveFile. webRootPath: {webRootPath}, file: {JsonConvert.SerializeObject(file)}");

            try
            {

                var fileName = $"{file.FileName}";//{Path.GetExtension(file.FileName)}
                var relativePath = $@"images/{ DateTime.Now.Date:yyyyMMdd}/{ fileName}";
                var path = $@"{webRootPath}/{relativePath}";
                var fileInfo = new FileInfo(path);
                var di = fileInfo.Directory;
                if (!di.Exists)
                    di.Create();

                //if (!File.Exists(path))
                //    return ApiRequestResult.Success(fileDto, "保存成功");
                
                using (var fs = File.Create(path))
                {
                    await file.CopyToAsync(fs);
                    fs.Flush();
                }
                var request = _httpContextAccessor.HttpContext.Request;
                var savedFilePath = $@"{request.Scheme}://{request.Host}/{relativePath}";
                var fileDto = new FileDto
                {
                    Host = $@"{request.Scheme}://{request.Host}/",
                    Dir = relativePath,
                    FileFullPath = savedFilePath,
                    //AccessKeyId 
                };
                return ApiRequestResult.Success(fileDto, "保存成功");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Saving failed: FileSaverService -> SaveFile");
                return ApiRequestResult.Error(ex.Message);
            }
        }

        public async Task<ApiRequestResult> SaveMultiFileAsync(string webRootPath, List<IFormFile> files)
        {
            //Log.Information($"FileSaverService -> SaveFile. webRootPath: {webRootPath}, file: {JsonConvert.SerializeObject(file)}");

            try
            {
                var filePathList = new List<string>();
                foreach (var file in files)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                    var path = $@"{webRootPath}/{fileName}";

                    using (FileStream fs = File.Create(path))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                    var request = _httpContextAccessor.HttpContext.Request;
                    var savedFilePath = $@"{request.Scheme}://{request.Host}/{fileName}";
                    filePathList.Add(savedFilePath);
                }

                return ApiRequestResult.Success(filePathList, "保存成功");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Saving failed: FileSaverService -> SaveFile");
                return ApiRequestResult.Error(ex.Message);
            }
        }

        public ApiRequestResult DeleteFile(string webRootPath, string link)
        {
            //Log.Information($"FileSaverService -> SaveFile. webRootPath: {webRootPath}, fileName: {link}");

            try
            {
                Uri uri = new Uri(link);
                var fileName = uri.Segments.Last();
                string fullPath = $@"{webRootPath}/{fileName}";

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return ApiRequestResult.Success("文件删除成功");
                }

                return ApiRequestResult.Error("File cannot be saved");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Saving failed: FileSaverService -> DeleteFile");
                return ApiRequestResult.Error(ex.Message);
            }
        }
    }
}
