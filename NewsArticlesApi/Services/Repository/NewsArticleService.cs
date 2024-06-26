using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Services.Repository
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly DBContext _dbContext;

        public NewsArticleService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NewsArticle> CreateNews(NewsArticle newsArticle)
        {
            await _dbContext.AddAsync(newsArticle);
            _dbContext.SaveChanges();
            return newsArticle;

        }

        public NewsArticle DeleteNews(NewsArticle newsArticle)
        {
            _dbContext.Remove(newsArticle);
            _dbContext.SaveChanges();
            return newsArticle;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNews()
        {
           
                return await _dbContext.NewsArticles.Select(x => new NewsArticle {Id=x.Id,PublishDate=x.PublishDate,Body=x.Body,Author=x.Author,Title=x.Title }).ToListAsync();
                
 
        }

        public async Task<NewsArticle> GetNewsById(int id)
        {
            if (_dbContext.Database.CanConnect())
                return await _dbContext.NewsArticles.SingleOrDefaultAsync(n => n.Id == id);
            return null;
        }

        public async Task<NewsArticle> GetNewsByIdWithCommentAndLike(int id)  
        {
            if(_dbContext.Database.CanConnect())
                return await _dbContext.NewsArticles.Include(f => f.Comments).Include(y => y.Likes).Include(c=>c.Images).SingleOrDefaultAsync(n => n.Id == id);
            return null;
        }

        public async Task<IEnumerable<NewsArticle>> SearchByString(string searchString)
        {
            if (_dbContext.Database.CanConnect())
            {
               var newsArticle= _dbContext.NewsArticles.Where(x => x.Title.Contains(searchString) || x.Body.Contains(searchString)).ToList();
                if (newsArticle.Count ==0)
                {
                    return null;
                }
                return newsArticle;
            }
            return null;

        }

        public NewsArticle UpdateNews(NewsArticle newsArticle)
        {
            _dbContext.Update(newsArticle);
            _dbContext.SaveChanges();
            return newsArticle;
        }
    }
}
