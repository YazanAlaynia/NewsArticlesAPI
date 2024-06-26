using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.NewsArticleQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers
{
    public class SearchNewsArticleHandler : IRequestHandler<SearchForNewsArticleQuery, List< NewsArticle>>
    {
        private INewsArticleService _newsArticleService;

        public SearchNewsArticleHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<List<NewsArticle>> Handle(SearchForNewsArticleQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SearchItem))
            {
                return new List<NewsArticle>() ;
            }
            var article = await _newsArticleService.SearchByString(request.SearchItem);
            if (article == null)
                return null;
            return (List<NewsArticle>)article;
        }
    }
}
