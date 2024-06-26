using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.LikeCommends
{
    public class DeleteLikeCommend:IRequest<Like>
    {
        public int id { get; set; }

    }
}
