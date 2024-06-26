using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Services.Repository
{
    public class LikeService : ILikeService
    {
        private readonly DBContext _dbContext;

        public LikeService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Like> CreateLike(Like like)
        {
            await _dbContext.AddAsync(like);
            _dbContext.SaveChanges();
            return like;
        }

        public Like DeleteLike(Like like)
        {
            _dbContext.Remove(like);
            _dbContext.SaveChanges();
            return like;
        }

        public async Task<IEnumerable<Like>> GetAllLikes(int newArticle)
        {
            return await _dbContext.Likes.Where(x=>x.NewsArticleId==newArticle||newArticle==0).ToListAsync();
        }

        public async Task<Like> GetLikeById(int id)
        {
            return await _dbContext.Likes.SingleOrDefaultAsync(x=> x.Id == id);
        }
        public Task<bool> Isvolid(int id)
        {
            return _dbContext.NewsArticles.AnyAsync(n => n.Id == id);
        }
        public Like UpdateLike(Like like)
        {
            _dbContext.Update(like);
            _dbContext.SaveChanges();
            return like;
        }
    }
}
