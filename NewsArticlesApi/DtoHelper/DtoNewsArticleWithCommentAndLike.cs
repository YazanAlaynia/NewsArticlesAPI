using System.ComponentModel.DataAnnotations;

namespace NewsArticlesApi.DtoHelper
{
    public class DtoNewsArticleWithCommentAndLike
    {
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(2500)]
        public string Body { get; set; }
        public int NumberImage { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfLike { get; set; }
        public List<string> comment { get; set; }
       // public List<byte[]> Image { get; set; }


    }
}
