using MediatR;
using NewsArticlesApi.Commands.NewsArticleCommands;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers
{
    public class DeleteNewsArticleHandler : IRequestHandler<DeleteNewsArticleCommand, NewsArticle>
    {
        private readonly INewsArticleService _newsArticleService;

        public DeleteNewsArticleHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<NewsArticle> Handle(DeleteNewsArticleCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsArticleService.GetNewsById(request.id);
            if (news == null)
                return null;
            var deleteNews = _newsArticleService.DeleteNews(news);
            return deleteNews;


        }
    }
}
