﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_WebAPI.Data;

#nullable disable

namespace WebApplication_WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20230820161452_init4")]
    partial class init4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication_WebAPI.Models.NationalPark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Established")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NatinalParks");
                });

            modelBuilder.Entity("WebApplication_WebAPI.Models.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Distance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elevation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationalParkId");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("WebApplication_WebAPI.Models.Trail", b =>
                {
                    b.HasOne("WebApplication_WebAPI.Models.NationalPark", "NatinalPark")
                        .WithMany()
                        .HasForeignKey("NationalParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NatinalPark");
                });
#pragma warning restore 612, 618
        }
    }
}
