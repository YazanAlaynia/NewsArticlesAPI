using MediatR;
using NewsArticlesApi.Commands.ImageCommand;
using NewsArticlesApi.Exceptions;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using NewsArticlesApi.Services.Repository;

namespace NewsArticlesApi.Handlers.ImageHandlers
{
    public class CreateImageHandler : IRequestHandler<CreateImageCommand, Image>
    {
        private IImageService _imageService;
        private new List<string> _allowExtantion = new List<string> { ".jpg", ".png"};
        private long _maxLengthSize = 1048576;

        public CreateImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var isvalide = await _imageService.Isvolid(request.NewsArticleId);
            if (!isvalide)
                return null;
          
                if (!_allowExtantion.Contains(Path.GetExtension(request.ImageArticle.FileName).ToLower()))
                    throw new ClassException($"This Image have type of  extation .jpg or .png ");

                if (request.ImageArticle.Length > _maxLengthSize)
                    throw new ClassException($"This Image have to be less than 1MByte ");

                using var dataStream = new MemoryStream();
                await request.ImageArticle.CopyToAsync(dataStream);
                var image = new Image

                {
                    NewsArticleId = request.NewsArticleId,
                    ImageArticle = dataStream.ToArray()

                };
                return await _imageService.CreateImage(image);
        
        }
        }
    }

