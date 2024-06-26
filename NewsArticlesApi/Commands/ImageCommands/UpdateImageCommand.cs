using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.ImageCommands
{
    public class UpdateImageCommand:IRequest<Image>
    {
        public int Id { get; set; }
        public IFormFile ImageArticle { get; set; }
    }
}
