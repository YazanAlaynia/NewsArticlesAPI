using MediatR;
using NewsArticlesApi.Commands.CommentCommands;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using NewsArticlesApi.Services.Repository;

namespace NewsArticlesApi.Handlers.CommentHandlers
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public DeleteCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentService.GetCommentById(request.id);
            if (comment == null)
                return null;
            var deleteComment = _commentService.DeleteComment(comment);
            return deleteComment;
        }
    }
}
