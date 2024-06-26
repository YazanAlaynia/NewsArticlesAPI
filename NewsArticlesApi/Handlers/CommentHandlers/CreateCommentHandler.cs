using MediatR;
using NewsArticlesApi.Commands.CommentCommands;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public CreateCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var isvalide = await _commentService.Isvolid(request.NewsArticleId);
            if (!isvalide)
                return null;
            var comment = new Comment
            {
                Body = request.Body,
                PublishAt = DateTime.Now,
                NewsArticleId = request.NewsArticleId,
                ReaderName = request.ReaderName,
            };
            return await _commentService.CreateComment(comment);
            
        }
    }
}
