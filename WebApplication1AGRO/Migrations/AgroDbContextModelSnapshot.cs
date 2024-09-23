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

            modelBuilder.Entity("WebApplication1AGRO.Model.BillDetails", b =>
                {
                    b.Property<int>("BillDeta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDeta_id"));

                    b.Property<int>("Bill_id1")
                        .HasColumnType("int");

                    b.HasKey("BillDeta_id");

                    b.HasIndex("Bill_id1");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Bills", b =>
                {
                    b.Property<int>("Bill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bill_id"));

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

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacs", b =>
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

                    b.HasKey("Document_id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.PaymentMethods", b =>
                {
                    b.Property<int>("Method_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Method_id"));

                    b.Property<string>("Method_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Method_id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.UserTypes", b =>
                {
                    b.Property<int>("UserType_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserType_id"));

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

                    b.Property<string>("Document_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Document_typesDocument_id")
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

                    b.Property<int>("UserTypesUserType_id")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.HasIndex("Document_typesDocument_id");

                    b.HasIndex("UserTypesUserType_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.BillDetails", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Bills", "Bill_id")
                        .WithMany()
                        .HasForeignKey("Bill_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill_id");
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

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacs", b =>
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

            modelBuilder.Entity("WebApplication1AGRO.Model.Users", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Documents", "Document_types")
                        .WithMany()
                        .HasForeignKey("Document_typesDocument_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1AGRO.Model.UserTypes", "UserTypes")
                        .WithMany()
                        .HasForeignKey("UserTypesUserType_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document_types");

                    b.Navigation("UserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
