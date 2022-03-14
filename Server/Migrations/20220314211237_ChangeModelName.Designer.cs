﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Server.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220314211237_ChangeModelName")]
    partial class ChangeModelName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeId");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Fridges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e34e76a7-62ea-4333-b158-bb90faff3789"),
                            ModelId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Name = "Fridge1",
                            OwnerName = "Boston Griffin"
                        },
                        new
                        {
                            Id = new Guid("9a0d5d8c-5fdf-4d5a-8c29-cc5cea0ed972"),
                            ModelId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Name = "Fridge2",
                            OwnerName = "Silas Evans"
                        },
                        new
                        {
                            Id = new Guid("d128b600-b7d0-4732-9fbd-bc9be3098f2d"),
                            ModelId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Name = "Fridge3",
                            OwnerName = "Seth Hughes"
                        },
                        new
                        {
                            Id = new Guid("ca0276e6-e7f7-43f4-8d96-c40e8387fb90"),
                            ModelId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Name = "Fridge4",
                            OwnerName = "Gary Bryant"
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Name = "Beko RCSK 310M20",
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Name = "Tesler RC-55 White",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Name = "Pozis RK-139 W",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeProduct", b =>
                {
                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("FridgeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProduct");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<int>("DefaulQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80344d69-8951-4e2d-abf5-fd65d5801342"),
                            DefaulQuantity = 2,
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = new Guid("5494c80a-8a16-45a8-812a-3e5e5db514ad"),
                            DefaulQuantity = 1,
                            Name = "Lemon"
                        },
                        new
                        {
                            Id = new Guid("a640c941-9723-430c-88ce-de6f4f1c1185"),
                            DefaulQuantity = 1,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = new Guid("eeb0a8e9-5334-422c-8356-4861d172c77e"),
                            DefaulQuantity = 5,
                            Name = "Potato"
                        },
                        new
                        {
                            Id = new Guid("279a3151-c742-4e21-af9e-517e687afed2"),
                            DefaulQuantity = 2,
                            Name = "Onion"
                        });
                });

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.HasOne("Entities.Models.FridgeModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Entities.Models.FridgeProduct", b =>
                {
                    b.HasOne("Entities.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}