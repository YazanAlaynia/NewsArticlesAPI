using MediatR;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.ImagesQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.ImageHandlers
{
    public class GetAllImagesHandler : IRequestHandler<GetAllImagesQueries, List<Image>>
    {
        private readonly IImageService _imageService;

        public GetAllImagesHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<List<Image>> Handle(GetAllImagesQueries request, CancellationToken cancellationToken)
        {
            return (List<Image>)await _imageService.GetAllImages();
        }
    }
}
