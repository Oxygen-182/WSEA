using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSEA.Migrations
{
    /// <inheritdoc />
    public partial class AddedRealtorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealtorId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealtorId",
                table: "AspNetUsers");
        }
    }
}
