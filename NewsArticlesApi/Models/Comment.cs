using System.ComponentModel.DataAnnotations;

namespace NewsArticlesApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(100)]
        //To Do User Model
        public string ReaderName { get; set; }
        [MaxLength(500)]
        public string Body { get; set; }
        public DateTime PublishAt { get; set; }

        public int NewsArticleId { get; set; }
        public NewsArticle NewsArticle { get; set; }
    }
}
