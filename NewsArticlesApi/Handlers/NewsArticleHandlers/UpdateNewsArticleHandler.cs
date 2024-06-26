using MediatR;
using NewsArticlesApi.Commands.NewsArticleCommands;
using NewsArticlesApi.Exceptions;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Handlers.NewsArticleHandlers
{
    public class UpdateNewsArticleHandler : IRequestHandler<UpdateNewArticleCommand, NewsArticle>
    {
        private readonly INewsArticleService _newsArticleService;
        private new List<string> _allowExtantion = new List<string> { ".jpg", ".png" };
        private long _maxLengthSize = 1048576;

        public UpdateNewsArticleHandler(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public async Task<NewsArticle> Handle(UpdateNewArticleCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsArticleService.GetNewsById(request.Id);
            if (news == null)
                return null;
            if (request.ProfileImage != null)
            {
                if (!_allowExtantion.Contains(Path.GetExtension(request.ProfileImage.FileName).ToLower()))
                    throw new ClassException($"This profile image must have the  extation type .jpg or .png ");


                if (request.ProfileImage.Length > _maxLengthSize)
                    throw new ClassException($"This profile image must to be less than 1MByte ");

                using var dataStream = new MemoryStream();
                await request.ProfileImage.CopyToAsync(dataStream);
                news.ProfileImage = dataStream.ToArray();
            }

            news.Title = request.Title;
            news.Author = request.Author;
            news.Body = request.Body;
            news.PublishDate = DateTime.UtcNow;

            return _newsArticleService.UpdateNews(news);



        }
    }
}
