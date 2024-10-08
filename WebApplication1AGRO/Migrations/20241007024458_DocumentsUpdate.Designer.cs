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
    [Migration("20241007024458_DocumentsUpdate")]
    partial class DocumentsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1AGRO.Model.BillDetails", b =>
                {
                    b.Property<int>("BillDeta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDeta_id"));

                    b.Property<int>("Bill_id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.HasKey("BillDeta_id");

                    b.HasIndex("Bill_id");

                    b.HasIndex("Product_id");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Bills", b =>
                {
                    b.Property<int>("Bill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bill_id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PayMeth_idMethod_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Purchase_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_id2User_id")
                        .HasColumnType("int");

                    b.HasKey("Bill_id");

                    b.HasIndex("PayMeth_idMethod_id");

                    b.HasIndex("User_id2User_id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Collections", b =>
                {
                    b.Property<int>("CollectionPoint_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionPoint_id"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PointName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionPoint_id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacts", b =>
                {
                    b.Property<int>("Contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Contact_id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataType_id1")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Contact_id");

                    b.HasIndex("DataType_id1");

                    b.HasIndex("User_id1");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.DataTypes", b =>
                {
                    b.Property<int>("DataType_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataType_id"));

                    b.Property<string>("DataType_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("DataType_id");

                    b.ToTable("DataTypes");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Documents", b =>
                {
                    b.Property<int>("Document_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Document_id"));

                    b.Property<string>("Document_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Document_id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Offers", b =>
                {
                    b.Property<int>("Offer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Offer_id"));

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOffer")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinalPrice")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("WebApplication1AGRO.Model.PaymentMethods", b =>
                {
                    b.Property<int>("Method_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Method_id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Method_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Method_id");

                    b.ToTable("PaymentMethods");
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_id");

                    b.HasIndex("Category_id1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.UserTypes", b =>
                {
                    b.Property<int>("UserType_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserType_id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserType_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserType_id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Users", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<DateTime>("Born_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Document_id")
                        .HasColumnType("int");

                    b.Property<string>("Document_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Last_names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType_id")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.HasIndex("Document_id");

                    b.HasIndex("UserType_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.BillDetails", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Bills", "Bills")
                        .WithMany()
                        .HasForeignKey("Bill_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Products", "Products")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bills");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Bills", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.PaymentMethods", "PayMeth_id")
                        .WithMany()
                        .HasForeignKey("PayMeth_idMethod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Users", "User_id2")
                        .WithMany()
                        .HasForeignKey("User_id2User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PayMeth_id");

                    b.Navigation("User_id2");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacts", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.DataTypes", "DataType_id")
                        .WithMany()
                        .HasForeignKey("DataType_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.Users", "User_id")
                        .WithMany()
                        .HasForeignKey("User_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataType_id");

                    b.Navigation("User_id");
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

            modelBuilder.Entity("WebApplication1AGRO.Model.Users", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Documents", "Documents")
                        .WithMany()
                        .HasForeignKey("Document_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.UserTypes", "UserTypes")
                        .WithMany()
                        .HasForeignKey("UserType_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Documents");

                    b.Navigation("UserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
