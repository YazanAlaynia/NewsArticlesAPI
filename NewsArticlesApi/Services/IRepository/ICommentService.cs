using NewsArticlesApi.Models;

namespace NewsArticlesApi.Services.IRepository
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllComments(int newsArticle=0);
        Task<Comment> GetCommentById(int id);
        Task<Comment> CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        Comment DeleteComment(Comment comment);
        Task<bool> Isvolid(int id);
    }
}
