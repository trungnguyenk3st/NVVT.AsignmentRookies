using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignmentEcomerce.Migrations
{
    public partial class UpdateRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RatingProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalStar",
                table: "RatingProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RatingProducts_ApplicationUserId",
                table: "RatingProducts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingProducts_AspNetUsers_ApplicationUserId",
                table: "RatingProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingProducts_AspNetUsers_ApplicationUserId",
                table: "RatingProducts");

            migrationBuilder.DropIndex(
                name: "IX_RatingProducts_ApplicationUserId",
                table: "RatingProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RatingProducts");

            migrationBuilder.DropColumn(
                name: "TotalStar",
                table: "RatingProducts");
        }
    }
}
