using MediatR;
using NewsArticlesApi.Commands.NewsArticleCommands;
using NewsArticlesApi.Exceptions;
using NewsArticlesApi.Migrations;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers
{
    public class CreateNewsArticleHandler : IRequestHandler<CreateNewsArticleCommand, NewsArticle>
    {
        private readonly INewsArticleService _newsArticleService;
        private new List<string> _allowExtantion = new List<string> { ".jpg", ".png" };
        private long _maxLengthSize = 1048576;
        public CreateNewsArticleHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<NewsArticle> Handle(CreateNewsArticleCommand request, CancellationToken cancellationToken)
        {
            if (request.ProfileImage != null)
            {
                if (!_allowExtantion.Contains(Path.GetExtension(request.ProfileImage.FileName).ToLower()))
                    throw new ClassException($"This profile image must have the  extation type .jpg or .png ");

                if (request.ProfileImage.Length > _maxLengthSize)
                    throw new ClassException($"This profile image must to be less than 1MByte ");

                using var dataStream = new MemoryStream();
                await request.ProfileImage.CopyToAsync(dataStream);
                var news = new NewsArticle
                {
                    Title = request.Title,
                    Body = request.Body,
                    ProfileImage = dataStream.ToArray(),
                    PublishDate = DateTime.UtcNow,
                    Author = request.Author,

                };
                return await _newsArticleService.CreateNews(news);

            }
            else
            {

                var news = new NewsArticle
                {
                    Title = request.Title,
                    Body = request.Body,
                    PublishDate = DateTime.UtcNow,
                    Author = request.Author,

                };
                return await _newsArticleService.CreateNews(news);
            }
        }
    }
}
