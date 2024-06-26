using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Services.Repository
{
    public class CommentsService : ICommentService
    {
        private readonly DBContext _dbContext;

        public CommentsService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            await _dbContext.AddAsync(comment);
            _dbContext.SaveChanges();
            return comment;
        }

        public Comment DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllComments(int newsArticle=0)
        {
            return await _dbContext.Comments.Where(c=>c.NewsArticleId==newsArticle||newsArticle==0).ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _dbContext.Comments.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> Isvolid(int id)
        {
           return _dbContext.NewsArticles.AnyAsync(n=>n.Id == id);
        }

        public Comment UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
            return comment;
        }
    }
}
