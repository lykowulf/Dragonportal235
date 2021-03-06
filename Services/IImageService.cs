﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dragonportal235.Services
{
    public interface IImageService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
        public Task<byte[]> AssignDefaultAvatarAsync(string avatar);
    }
}
