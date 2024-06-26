using NewsArticlesApi.Models;

namespace NewsArticlesApi.Services.IRepository
{
    public interface ILikeService
    {
        Task<IEnumerable<Like>> GetAllLikes(int newsArticle=0);
        Task<Like> GetLikeById(int id);
        Task<Like> CreateLike(Like like);
        Like UpdateLike(Like like);
        Like DeleteLike(Like like);
        Task<bool> Isvolid(int id);
    }
}
