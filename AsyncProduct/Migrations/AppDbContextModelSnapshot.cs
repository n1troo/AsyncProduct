﻿// <auto-generated />
using AsyncProduct.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsyncProduct.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("AsyncProduct.Models.ListingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EstimatedCompetionTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestBody")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RquestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ListingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
