﻿// <auto-generated />
using System;
using FormAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FormAPI.Models.FormEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Components")
                        .HasColumnType("json");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Organization")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Published")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("User")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Forms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4c62b945-1107-4abe-8c0e-0d2709bbfc06"),
                            Description = "This form was created as a test.",
                            Organization = "Org1",
                            Status = "draft",
                            Title = "Test Survey",
                            User = "user1@example.com"
                        });
                });

            modelBuilder.Entity("FormAPI.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Organization")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "a@a.com",
                            Organization = "A.com",
                            Password = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            Email = "johnny@testepartementet.no",
                            Organization = "Testdepartementet",
                            Password = "johnny123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "test@test.com",
                            Organization = "",
                            Password = "12345678"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
