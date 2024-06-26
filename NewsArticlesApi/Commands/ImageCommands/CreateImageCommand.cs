using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.ImageCommand
{
    public class CreateImageCommand:IRequest<Image>
    {
        public IFormFile ImageArticle { get; set; }
        public int NewsArticleId { get; set; }
    }
}
