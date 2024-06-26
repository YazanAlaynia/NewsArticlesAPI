using MediatR;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Queries.NewsArticleQueries
{
    public class GetNewsArticleByIdQuery : IRequest<DtoNewsArticleWithCommentAndLike>
    {
        public int id { get; }
        public GetNewsArticleByIdQuery(int Id)
        {
            id = Id;
        }


    }
}
