using NewsArticlesApi.Models;

namespace NewsArticlesApi.Services.IRepository
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetAllImages(int newsArticle = 0);
        Task<Image> GetImageById(int id);
        Task<Image> CreateImage(Image image);
        Image UpdateImage(Image image);
        Image DeleteImage(Image image);
        Task<bool> Isvolid(int id);
    }
}
