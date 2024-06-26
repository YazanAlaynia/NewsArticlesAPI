using MediatR;
using NewsArticlesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsArticlesApi.Commands.NewsArticleCommands
{
    public class CreateNewsArticleCommand : IRequest<NewsArticle>
    {

        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
