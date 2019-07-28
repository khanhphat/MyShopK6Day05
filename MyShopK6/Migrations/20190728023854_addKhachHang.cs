using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopK6.Migrations
{
    public partial class addKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKh = table.Column<string>(maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    DienThoai = table.Column<string>(maxLength: 150, nullable: true),
                    MatKhau = table.Column<string>(maxLength: 150, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 150, nullable: true),
                    RandomKey = table.Column<string>(maxLength: 10, nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
