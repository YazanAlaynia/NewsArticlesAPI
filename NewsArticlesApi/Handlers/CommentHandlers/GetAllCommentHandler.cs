using MediatR;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.CommentQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.CommentHandlers
{
    public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, List<Comment>>
    {
        private readonly ICommentService _commentService;

        public GetAllCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<List<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            return (List<Comment>)await _commentService.GetAllComments();
        }
    }
}
