using MediatR;
using NewsArticlesApi.Commands.CommentCommands;
using NewsArticlesApi.Exceptions;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.CommentHandlers
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public UpdateCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentService.GetCommentById(request.Id);
            if (comment == null)
            {
                return null;
            }

            var isvalide = await _commentService.Isvolid(request.NewsArticleId);
            if (!isvalide)
                throw new ClassException($"This News Article Id does not exist  ");

            comment.Body = request.Body;
            comment.PublishAt = DateTime.UtcNow;
            comment.ReaderName = request.ReaderName;
            comment.NewsArticleId = request.NewsArticleId;

           return  _commentService.UpdateComment(comment);




        }
    }
}
