using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Queries.CommentQueries
{
    public class GetAllCommentQuery: IRequest<List<Comment>>
    {
    }
}
