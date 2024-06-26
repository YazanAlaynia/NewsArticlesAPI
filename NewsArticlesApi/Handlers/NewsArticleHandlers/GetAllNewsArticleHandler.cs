using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.NewsArticleQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers

{
    public class GetAllNewsArticleHandler : IRequestHandler<GetallNewsArticleQuery, List<NewsArticle>>
    {
        private readonly INewsArticleService _newsArticleService;

        public GetAllNewsArticleHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<List<NewsArticle>> Handle(GetallNewsArticleQuery request, CancellationToken cancellationToken)
        {
            return (List<NewsArticle>) await _newsArticleService.GetAllNews();
        
      


        }
    }
}
