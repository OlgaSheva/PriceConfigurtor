﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceConfigurator.DataAccess;

namespace PriceConfigurator.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200619103320_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("PriceConfigurator.DataAccess.Models.CategoryModel.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PriceConfigurator.DataAccess.Models.ProductModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsPriceAutoUpdate")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsUpdated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mark")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PriceLastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PriceWithoutVAT_BYN")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PriceWithoutVAT_EUR")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Provider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("XPath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceConfigurator.DataAccess.Models.ProductModel.Product", b =>
                {
                    b.HasOne("PriceConfigurator.DataAccess.Models.ProductModel.Product", null)
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
