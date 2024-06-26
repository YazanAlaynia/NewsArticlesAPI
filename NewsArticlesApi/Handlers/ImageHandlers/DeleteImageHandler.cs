using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewsArticlesApi.Commands.ImageCommands;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.ImageHandlers
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageCommand, Image>
    {
    
        private readonly IImageService _imageService;

        public DeleteImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<Image> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var image = await _imageService.GetImageById(request.id);
                if (image == null)
                    return null;
                return _imageService.DeleteImage(image);
            }
            catch (Exception ex) {
                throw new Exception();
                    }
            }
    }
}
