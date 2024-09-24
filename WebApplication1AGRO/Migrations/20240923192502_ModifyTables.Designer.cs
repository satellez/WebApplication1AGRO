﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1AGRO.Context;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    [DbContext(typeof(AgroDbContext))]
    [Migration("20240923192502_ModifyTables")]
    partial class ModifyTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointName")
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

                    b.Property<DateTime>("EndOffer")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinalPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProdDeta_id1")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOffer")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOffer")
                        .HasColumnType("datetime2");

                    b.HasKey("Offer_id");

                    b.HasIndex("ProdDeta_id1");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductCategories", b =>
                {
                    b.Property<int>("Category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Category_id"));

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Category_id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductDetails", b =>
                {
                    b.Property<int>("ProdDeta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdDeta_id"));

                    b.Property<int>("CollectionPoint_id1")
                        .HasColumnType("int");

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MinimunQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.Property<int>("StartingPrice")
                        .HasColumnType("int");

                    b.Property<int>("User_id1")
                        .HasColumnType("int");

                    b.Property<int>("WeigthPoundsPack")
                        .HasColumnType("int");

                    b.HasKey("ProdDeta_id");

                    b.HasIndex("CollectionPoint_id1");

                    b.HasIndex("Product_id1");

                    b.HasIndex("User_id1");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Products", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_id"));

                    b.Property<int>("Category_id1")
                        .HasColumnType("int");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_id");

                    b.HasIndex("Category_id1");

                    b.ToTable("Products");
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

                    b.Property<string>("Last_names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Offers", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.ProductDetails", "ProdDeta_id")
                        .WithMany()
                        .HasForeignKey("ProdDeta_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdDeta_id");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.ProductDetails", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Collections", "CollectionPoint_id")
                        .WithMany()
                        .HasForeignKey("CollectionPoint_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Products", "Product_id")
                        .WithMany()
                        .HasForeignKey("Product_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Users", "User_id")
                        .WithMany()
                        .HasForeignKey("User_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollectionPoint_id");

                    b.Navigation("Product_id");

                    b.Navigation("User_id");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Products", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.ProductCategories", "Category_id")
                        .WithMany()
                        .HasForeignKey("Category_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category_id");
                });
#pragma warning restore 612, 618
        }
    }
}
