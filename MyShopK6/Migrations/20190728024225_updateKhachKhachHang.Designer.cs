﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShopK6.Models;

namespace MyShopK6.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190728024225_updateKhachKhachHang")]
    partial class updateKhachKhachHang
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyShopK6.Models.HangHoa", b =>
                {
                    b.Property<int>("MaHh")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGia");

                    b.Property<int>("GiamGia");

                    b.Property<string>("Hinh")
                        .HasMaxLength(150);

                    b.Property<int>("MaLoai");

                    b.Property<string>("MaTh")
                        .HasMaxLength(50);

                    b.Property<string>("MoTa");

                    b.Property<int>("SoLuong");

                    b.Property<string>("TenHh")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("MaHh");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaTh");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("MyShopK6.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKh")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(150);

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("RandomKey")
                        .HasMaxLength(10);

                    b.HasKey("MaKh");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("MyShopK6.Models.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh")
                        .HasMaxLength(150);

                    b.Property<int?>("MaLoaiCha");

                    b.Property<string>("MoTa");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(50);

                    b.HasKey("MaLoai");

                    b.HasIndex("MaLoaiCha");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("MyShopK6.Models.ThuongHieu", b =>
                {
                    b.Property<string>("MaTh")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(150);

                    b.Property<string>("DienThoai")
                        .HasMaxLength(50);

                    b.Property<string>("Logo")
                        .HasMaxLength(150);

                    b.Property<string>("TenThuongHieu")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("MaTh");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("MyShopK6.Models.HangHoa", b =>
                {
                    b.HasOne("MyShopK6.Models.Loai", "Loai")
                        .WithMany()
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyShopK6.Models.ThuongHieu", "ThuongHieu")
                        .WithMany()
                        .HasForeignKey("MaTh");
                });

            modelBuilder.Entity("MyShopK6.Models.Loai", b =>
                {
                    b.HasOne("MyShopK6.Models.Loai", "LoaiCha")
                        .WithMany()
                        .HasForeignKey("MaLoaiCha");
                });
#pragma warning restore 612, 618
        }
    }
}
