using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Commands.CommentCommands
{
    public class DeleteCommentCommand:IRequest<Comment>
    {
        public int id { get; set; }

    }
}
