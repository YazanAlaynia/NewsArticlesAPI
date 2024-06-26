using System.ComponentModel.DataAnnotations;

namespace NewsArticlesApi.Models
{
    public class Like
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string ReaderName { get; set; }
        public DateTime CreateAt { get; set; }
        public int NewsArticleId { get; set; }
        public NewsArticle NewsArticle { get; set; }
    }
}
