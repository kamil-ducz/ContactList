﻿// <auto-generated />
using System;
using ContactList.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactList.Infrastructure.Migrations
{
    [DbContext(typeof(ContactListDbContext))]
    [Migration("20230805080157_Fix names in contact seeder")]
    partial class Fixnamesincontactseeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactList.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.smith@gmail.com",
                            FirstName = "John",
                            LastName = "Smith",
                            Password = "Ex@mpleP@$$sowrd",
                            PhoneNumber = "700-800-900"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jack.dean@gmail.com",
                            FirstName = "Jack",
                            LastName = "Dean",
                            Password = "Ex@mpleP@$$sowrd1",
                            PhoneNumber = "777-888-999",
                            SubCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eg@gmail.com",
                            FirstName = "Edgar",
                            LastName = "Gold",
                            Password = "Ex@mpleP@$$sowrd2",
                            PhoneNumber = "500-600-700",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rsapphire@gmail.com",
                            FirstName = "Roger",
                            LastName = "Sapphire",
                            Password = "Ex@mpleP@$$sowrd3",
                            PhoneNumber = "555-666-777"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Entities.ContactCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Private"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Entities.ContactSubCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactSubCategories");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Client"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Boss"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Entities.Contact", b =>
                {
                    b.HasOne("ContactList.Domain.Entities.ContactCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContactList.Domain.Entities.ContactSubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
