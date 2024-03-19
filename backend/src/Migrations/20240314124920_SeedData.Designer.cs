﻿// <auto-generated />
using System;
using FormAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240314124920_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("f7795736-611b-4951-a1f1-f9992b236718"),
                            Components = "[{\"name\":\"question1\",\"order\":0,\"label\":\"Question 1\",\"type\":\"textfield\",\"required\":true,\"minLength\":null,\"maxLength\":null,\"greaterThan\":null,\"lessThan\":null,\"radioChoices\":null},{\"name\":\"question2\",\"order\":1,\"label\":\"Question 2\",\"type\":\"radio\",\"required\":true,\"minLength\":null,\"maxLength\":null,\"greaterThan\":null,\"lessThan\":null,\"radioChoices\":[\"Yes\",\"No\",\"Maybe\"]}]",
                            Description = "This form was created as a test.",
                            Organization = "Org1",
                            Status = "draft",
                            Title = "Test Survey",
                            User = "user1@example.com"
                        });
                });

            modelBuilder.Entity("FormAPI.Models.SubmissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uuid");

                    b.Property<string>("Responses")
                        .HasColumnType("json");

                    b.Property<DateTimeOffset>("Submitted")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Submissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b12af4fb-93e9-4be6-967a-522ee77f0da0"),
                            FormId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Responses = "[{\"name\":\"question1\",\"order\":0,\"label\":\"Question 1\",\"response\":\"Yes, I agree\"},{\"name\":\"question2\",\"order\":1,\"label\":\"Question 2\",\"response\":\"No\"}]",
                            Submitted = new DateTimeOffset(new DateTime(2024, 3, 14, 12, 49, 20, 181, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("15dcfbe8-3815-4312-ae0e-e19316d9a33f"),
                            FormId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Responses = "[{\"name\":\"question1\",\"order\":0,\"label\":\"Question 1\",\"response\":\"Yes, I agree\"},{\"name\":\"question2\",\"order\":1,\"label\":\"Question 2\",\"response\":\"No\"}]",
                            Submitted = new DateTimeOffset(new DateTime(2024, 3, 14, 12, 49, 20, 181, DateTimeKind.Unspecified).AddTicks(5993), new TimeSpan(0, 0, 0, 0, 0))
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
