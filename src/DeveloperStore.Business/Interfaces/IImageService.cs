using Microsoft.AspNetCore.Http;

namespace DeveloperStore.Business.Interfaces;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile file, string fileName);
    Task<string> SaveImageAsync(string file, string fileName);
    Task<string> UpdateImageAsync(string file, string fileName, string oldFileName);
    bool DeleteFile(string fileName);
    string ConvertImageToBase64(string image);
}