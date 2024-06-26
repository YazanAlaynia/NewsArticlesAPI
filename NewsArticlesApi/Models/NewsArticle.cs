using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsArticlesApi.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(2500)]
        public string Body { get; set; }
        public byte[]? ProfileImage { get; set; }

        //To Do Auther Model
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }



        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Image>? Images { get; set; }


    }
}
