﻿// <auto-generated />
using System;
using Inchiriere_Instrumente.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inchiriere_Instrumente.Migrations
{
    [DbContext(typeof(Inchiriere_InstrumenteContext))]
    [Migration("20230109183739_InstrumentCategory")]
    partial class InstrumentCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Instrument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.InstrumentCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("InstrumentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("InstrumentID");

                    b.ToTable("InstrumentCategory");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Instrument", b =>
                {
                    b.HasOne("Inchiriere_Instrumente.Models.Owner", "Owner")
                        .WithMany("Instruments")
                        .HasForeignKey("OwnerID");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.InstrumentCategory", b =>
                {
                    b.HasOne("Inchiriere_Instrumente.Models.Category", "Category")
                        .WithMany("InstrumentCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inchiriere_Instrumente.Models.Instrument", "Instrument")
                        .WithMany("InstrumentCategories")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Category", b =>
                {
                    b.Navigation("InstrumentCategories");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Instrument", b =>
                {
                    b.Navigation("InstrumentCategories");
                });

            modelBuilder.Entity("Inchiriere_Instrumente.Models.Owner", b =>
                {
                    b.Navigation("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}