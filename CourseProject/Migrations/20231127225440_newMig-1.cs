using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    public partial class newMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tags",
                newName: "SecondTitle");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Tags",
                newName: "FirstTitle");

            migrationBuilder.RenameColumn(
                name: "SecondTitle",
                table: "SliderItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FirstTitle",
                table: "SliderItems",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SliderItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SliderItems");

            migrationBuilder.RenameColumn(
                name: "SecondTitle",
                table: "Tags",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FirstTitle",
                table: "Tags",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SliderItems",
                newName: "SecondTitle");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "SliderItems",
                newName: "FirstTitle");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
