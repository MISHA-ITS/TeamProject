using Microsoft.AspNetCore.Http;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Image
{
    public interface IImageService
    {
        Task<string?> SaveImageAsync(IFormFile image, string filePath);
        void DeleteImage(string directory);

        Task<List<string>> SaveProductImagesAsync(List<IFormFile> images, string path);
    }
}
