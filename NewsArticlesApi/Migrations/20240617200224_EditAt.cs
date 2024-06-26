using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsArticlesApi.Migrations
{
    /// <inheritdoc />
    public partial class EditAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_NewsArticles_ArticleNameId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ArticleNameId",
                table: "Comments",
                newName: "NewsArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleNameId",
                table: "Comments",
                newName: "IX_Comments_NewsArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_NewsArticles_NewsArticleId",
                table: "Comments",
                column: "NewsArticleId",
                principalTable: "NewsArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_NewsArticles_NewsArticleId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "NewsArticleId",
                table: "Comments",
                newName: "ArticleNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_NewsArticleId",
                table: "Comments",
                newName: "IX_Comments_ArticleNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_NewsArticles_ArticleNameId",
                table: "Comments",
                column: "ArticleNameId",
                principalTable: "NewsArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
