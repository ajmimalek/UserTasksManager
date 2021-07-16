﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserTasksManager.Data;

namespace UserTasksManager.Migrations
{
    [DbContext(typeof(UserTasksContext))]
    [Migration("20210715140342_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.Property<Guid>("tasksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("usersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("tasksId", "usersId");

                    b.HasIndex("usersId");

                    b.ToTable("TaskUser");
                });

            modelBuilder.Entity("UserTasksManager.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<float>("Estimate")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6badfd7c-e3ac-40e0-9db9-49e64b4fdcff"),
                            Description = "Create a project",
                            EndDate = new DateTime(2021, 7, 16, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(1678),
                            Estimate = 5.12f,
                            StartDate = new DateTime(2021, 7, 15, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(381),
                            Status = 0,
                            Title = "Creating a new Project"
                        },
                        new
                        {
                            Id = new Guid("b7fea0d2-44c2-4961-9061-a77b8d60cef8"),
                            Description = "Adding Classes to Project",
                            EndDate = new DateTime(2021, 7, 18, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(3167),
                            Estimate = 3.2f,
                            StartDate = new DateTime(2021, 7, 15, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(3131),
                            Status = 0,
                            Title = "Class Modeling"
                        });
                });

            modelBuilder.Entity("UserTasksManager.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f574d1a5-c726-4697-be9a-6af7311ffbf1"),
                            DateCreated = new DateTime(2021, 7, 15, 15, 3, 42, 125, DateTimeKind.Local).AddTicks(6832),
                            Email = "malek.ajmi@se.linedata.com",
                            Password = "malek123",
                            UserName = "ajmimalek",
                            role = 0
                        },
                        new
                        {
                            Id = new Guid("4728f314-eb27-4fe5-bc19-03a1dd7a07f0"),
                            DateCreated = new DateTime(2021, 7, 15, 15, 3, 42, 125, DateTimeKind.Local).AddTicks(7659),
                            Email = "adel.adel@se.linedata.com",
                            Password = "adel336",
                            UserName = "adeladel",
                            role = 1
                        });
                });

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.HasOne("UserTasksManager.Models.Task", null)
                        .WithMany()
                        .HasForeignKey("tasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserTasksManager.Models.User", null)
                        .WithMany()
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
