using MediatR;
using NewsArticlesApi.Commands.ImageCommands;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Exceptions;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using NewsArticlesApi.Services.Repository;

namespace NewsArticlesApi.Handlers.ImageHandlers
{
    public class UpdateImageHandler : IRequestHandler<UpdateImageCommand, Image>
    { 
        private readonly IImageService _imageService;
        private new List<string> _allowExtantion = new List<string> { ".jpg", ".png" };
        private long _maxLengthSize = 1048576;

        public UpdateImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<Image> Handle(UpdateImageCommand request, CancellationToken cancellationToken )
        {
            var image = await _imageService.GetImageById(request.Id);
            if (image == null)
            {
                throw new ClassException($"Image with ID {request.Id} Does not exist");
            }
            if (!_allowExtantion.Contains(Path.GetExtension(request.ImageArticle.FileName).ToLower()))
                throw new ClassException($"This Image have to be Extation .jpg or .png ");

            if (request.ImageArticle.Length > _maxLengthSize)
                throw new ClassException($"This Image have to be less than 1MByte ");
            using var dataStream = new MemoryStream();
            await request.ImageArticle.CopyToAsync(dataStream);

            image.ImageArticle=dataStream.ToArray();

            return _imageService.UpdateImage(image);


        }
    }
}
