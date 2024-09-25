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
    [Migration("20240919195914_newcontacts2")]
    partial class newcontacts2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacs", b =>
                {
                    b.Property<int>("Contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Contact_id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Contact_id");

                    b.HasIndex("User_id1");

                    b.ToTable("Contacts");
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

                    b.HasIndex("UserTypesUserType_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Contacs", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.Users", "User_id")
                        .WithMany()
                        .HasForeignKey("User_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_id");
                });

            modelBuilder.Entity("WebApplication1AGRO.Model.Users", b =>
                {
                    b.HasOne("WebApplication1AGRO.Model.UserTypes", "UserTypes")
                        .WithMany()
                        .HasForeignKey("UserTypesUserType_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}