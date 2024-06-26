using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace NewsArticlesApi.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-R5GOS0QQ;Database=NewsArticleDB;Trusted_Connection=SSPI;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
