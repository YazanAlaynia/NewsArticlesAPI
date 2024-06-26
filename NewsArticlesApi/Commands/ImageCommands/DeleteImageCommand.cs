using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.ImageCommands
{
    public class DeleteImageCommand:IRequest<Image>
    {
        public int id { get; set; }

    
    }
}
