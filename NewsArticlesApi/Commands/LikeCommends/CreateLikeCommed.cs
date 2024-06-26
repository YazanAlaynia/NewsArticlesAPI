using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.LikeCommends
{
    public class CreateLikeCommed:IRequest<Like>
    {
        public string ReaderName { get; set; }
        public DateTime CreateAt { get; set; }
        public int NewsArticleId { get; set; }
    }
}
