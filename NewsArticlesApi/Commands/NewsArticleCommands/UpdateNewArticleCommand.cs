using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.NewsArticleCommands
{
    public class UpdateNewArticleCommand : IRequest<NewsArticle>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
