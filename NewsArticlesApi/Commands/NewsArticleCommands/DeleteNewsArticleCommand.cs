using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.NewsArticleCommands
{
    public class DeleteNewsArticleCommand : IRequest<NewsArticle>
    {
        public int id { get; set; }
    }

}
