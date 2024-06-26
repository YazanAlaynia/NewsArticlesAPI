using MediatR;
using NewsArticlesApi.Models;
using System.Xml;

namespace NewsArticlesApi.Queries.NewsArticleQueries
{
    public class SearchForNewsArticleQuery:IRequest<List<NewsArticle>>
    {
        public string? SearchItem { get; set; }
    }
}
