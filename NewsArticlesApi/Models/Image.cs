namespace NewsArticlesApi.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageArticle { get; set; }
        public int NewsArticleId { get; set; }
        public NewsArticle NewsArticle { get; set; }
    }
}
