using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace GM.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        private static readonly string[] _allowed = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxSize = 2 * 1024 * 1024; // 2 MB

        public FileService(IWebHostEnvironment env) => _env = env;

        public async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!_allowed.Contains(ext))
                throw new ArgumentException("نوع الصورة غير مسموح");

            if (file.Length > MaxSize)
                throw new ArgumentException("حجم الصورة أكبر من 2 ميغا");

            var folderPath = Path.Combine(_env.WebRootPath, "images", folder);
            Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{ext}";
            var fullPath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/images/{folder}/{fileName}";
        }

        public void DeleteFile(string? fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl)) return;

            var fullPath = Path.Combine(_env.WebRootPath, fileUrl.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
