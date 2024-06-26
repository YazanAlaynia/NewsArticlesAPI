using NewsArticlesApi.Models;

namespace NewsArticlesApi.Services.IRepository
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNews();
        Task<NewsArticle> GetNewsById(int id);
        Task<NewsArticle> GetNewsByIdWithCommentAndLike(int id);

        Task<NewsArticle> CreateNews(NewsArticle newsArticle);
        NewsArticle UpdateNews(NewsArticle newsArticle);
        NewsArticle DeleteNews(NewsArticle newsArticle);
        Task<IEnumerable<NewsArticle>> SearchByString(string searchString);


    }
}
