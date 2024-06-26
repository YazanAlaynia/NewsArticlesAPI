using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest<Comment>
    {
        public string ReaderName { get; set; }
        public string Body { get; set; }
        public DateTime PublishAt { get; set; }
        public int NewsArticleId { get; set; }
    }
}
