﻿using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ASample.NetCore.Extension
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
