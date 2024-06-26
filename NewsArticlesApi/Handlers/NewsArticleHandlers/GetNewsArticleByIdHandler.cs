using MediatR;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.NewsArticleQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers
{
    public class GetNewsArticleByIdHandler : IRequestHandler<GetNewsArticleByIdQuery, DtoNewsArticleWithCommentAndLike>
    {
        private readonly INewsArticleService _newsArticleService;

        public GetNewsArticleByIdHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<DtoNewsArticleWithCommentAndLike> Handle(GetNewsArticleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var news = await _newsArticleService.GetNewsByIdWithCommentAndLike(request.id);
                if (news == null)
                    return null;
                var respons = new DtoNewsArticleWithCommentAndLike()
                {
                    Author = news.Author,
                    Body = news.Body,
                    NumberImage = news.Images.Count(),
                    comment = news.Comments.ToList().Select(x => x.Body).ToList(),
                   // Image = news.Images.Select(s => s.ImageArticle).ToList(),
                    Title = news.Title,
                    NumberOfLike = news.Likes.Count(),
                    PublishDate = news.PublishDate,
                };
                return respons;
            }
            catch (Exception ex)
            {
                throw new Exception() { };


            }
        }
    }
}
