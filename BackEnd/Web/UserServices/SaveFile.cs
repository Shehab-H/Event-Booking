using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.UserServices
{
    public class SaveFile : ISaveFile
    {
        private readonly IWebHostEnvironment _environment;

        public SaveFile(IWebHostEnvironment environment)
        {
           _environment = environment;
        }
        public async Task<string> Save(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded.");
            }
            var uploadsFolder =_environment.WebRootPath;

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return file.FileName;

        }

    }
}
