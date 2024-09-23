﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1AGRO.Context;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    [DbContext(typeof(AgroDbContext))]
    partial class AgroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1AGRO.Model.Collections", b =>
                {
                    b.Property<int>("CollectionPoint_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionPoint_id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionPoint_id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Offers", b =>
                {
                    b.Property<int>("Offer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Offer_id"));

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Final_Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdDeta_id")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOffer")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Offer_id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_id"));

                    b.Property<string>("Product_Cate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductCategories", b =>
                {
                    b.Property<int>("ProdCat_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdCat_id"));

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdCat_id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductDetails", b =>
                {
                    b.Property<int>("ProdDeta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdDeta_id"));

                    b.Property<int>("Collection_Point_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Harvest_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Minimun_quantity")
                        .HasColumnType("int");

                    b.Property<int>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity_stock")
                        .HasColumnType("int");

                    b.Property<int>("Seller_IdUser_id")
                        .HasColumnType("int");

                    b.Property<int>("Starting_Price")
                        .HasColumnType("int");

                    b.Property<string>("weightPounds_pack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdDeta_id");

                    b.HasIndex("Product_id1");

                    b.HasIndex("Seller_IdUser_id");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Users", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<DateTime>("Born_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Document_type")
                        .HasColumnType("int");

                    b.Property<string>("Last_names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_type")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductDetails", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Product", "Product_id")
                        .WithMany()
                        .HasForeignKey("Product_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Users", "Seller_Id")
                        .WithMany()
                        .HasForeignKey("Seller_IdUser_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_id");

                    b.Navigation("Seller_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
