using MediatR;
using NewsArticlesApi.Commands.LikeCommends;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.LikeHandlers
{
    public class DeleteLikeHandler : IRequestHandler<DeleteLikeCommend, Like>
    {
        private readonly ILikeService _likeService;

        public DeleteLikeHandler(ILikeService likeService)
        {
            _likeService = likeService;
        }

        public async Task<Like> Handle(DeleteLikeCommend request, CancellationToken cancellationToken)
        {
            try
            {
                var like = await _likeService.GetLikeById(request.id);
                if (like == null)
                    return null;

                var delteLike = _likeService.DeleteLike(like);
                return delteLike;
            }
            catch (Exception ex)
            {
                throw new Exception() { };


            }

        }
    }
}
