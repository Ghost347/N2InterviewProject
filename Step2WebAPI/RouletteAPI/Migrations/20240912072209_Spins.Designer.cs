﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RouletteAPI.Data;

#nullable disable

namespace RouletteAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240912072209_Spins")]
    partial class Spins
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RouletteAPI.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Win")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Winnings")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("RouletteAPI.Models.Spin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberResult")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Spins");
                });
#pragma warning restore 612, 618
        }
    }
}
