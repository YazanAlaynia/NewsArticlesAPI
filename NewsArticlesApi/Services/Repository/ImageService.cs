using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Services.Repository
{
    public class ImageService : IImageService
    {
        private readonly DBContext _dbContext;

        public ImageService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image> CreateImage(Image image)
        {
            await _dbContext.AddAsync(image);
            _dbContext.SaveChanges();
            return image;
        }

        public   Image DeleteImage(Image image)
        {
            _dbContext.Images.Remove(image);
            _dbContext.SaveChanges();
            return image;
        }

        public async Task<IEnumerable<Image>> GetAllImages(int newsArticle = 0)
        {
            return await _dbContext.Images.Where(c => c.NewsArticleId == newsArticle || newsArticle == 0).ToListAsync();

        }

        public async Task<Image> GetImageById(int id)
        {
            return await _dbContext.Images.SingleOrDefaultAsync(c => c.Id == id);

        }

        public Task<bool> Isvolid(int id)
        {
            return _dbContext.NewsArticles.AnyAsync(n => n.Id == id);

        }

        public  Image UpdateImage(Image image)
        {
            _dbContext.Images.Update(image);
            _dbContext.SaveChanges();
            return image;
        }
    }
}
