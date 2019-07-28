using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopK6.Migrations
{
    public partial class AddDiscountFOrProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiamGia",
                table: "HangHoa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "HangHoa");
        }
    }
}
