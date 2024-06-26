using MediatR;
using NewsArticlesApi.Commands.LikeCommends;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using NewsArticlesApi.Services.Repository;

namespace NewsArticlesApi.Handlers.LikeHandlers
{
    public class CreateLikeHandler : IRequestHandler<CreateLikeCommed, Like>
    {
        private readonly ILikeService _likeService;

        public CreateLikeHandler(ILikeService likeService)
        {
            _likeService = likeService;
        }

        public async Task<Like> Handle(CreateLikeCommed request, CancellationToken cancellationToken)
        {
            var isvalide = await _likeService.Isvolid(request.NewsArticleId);
            if (!isvalide)
                return null;

            var like = new Like
            {
                CreateAt = DateTime.UtcNow,
                ReaderName = request.ReaderName,
                NewsArticleId = request.NewsArticleId,
            };
            return await _likeService.CreateLike(like);

        }
    }
}
