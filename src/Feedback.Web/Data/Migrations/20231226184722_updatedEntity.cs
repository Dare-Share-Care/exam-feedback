using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feedback.Web.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourierId",
                table: "Reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "Reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
