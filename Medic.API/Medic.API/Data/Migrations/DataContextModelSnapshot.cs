﻿// <auto-generated />
using System;
using Medic.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medic.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Medic.API.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("Medic.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orders")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://randomuser.me/api/portraits/men/23.jpg",
                            LastLogin = new DateTime(2024, 7, 30, 12, 17, 43, 794, DateTimeKind.Local).AddTicks(8459),
                            Name = "John Doe",
                            Orders = 0,
                            PasswordHash = "7UP5JL0unol4NQegO6hePmSrKI24UOFBAaXkqR8mmDI=",
                            PasswordSalt = "GMzTqHylfrYMsg/uTUcY4Q==",
                            RoleId = 1,
                            Status = "Active",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1997, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://randomuser.me/api/portraits/women/39.jpg",
                            LastLogin = new DateTime(2024, 7, 30, 12, 17, 43, 794, DateTimeKind.Local).AddTicks(8506),
                            Name = "Jane Doe",
                            Orders = 6,
                            PasswordHash = "rSzPXNZr9vt0KKh8fxCh/nww0RXVK5KKnMAYCOg+oKc=",
                            PasswordSalt = "IJQ0hhHlLmVMl+fjjCIFLw==",
                            RoleId = 2,
                            Status = "Active",
                            Username = "janedoe"
                        });
                });

            modelBuilder.Entity("Medic.API.Entities.User", b =>
                {
                    b.HasOne("Medic.API.Entities.Roles", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Medic.API.Entities.Roles", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
