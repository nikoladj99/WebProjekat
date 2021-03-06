﻿// <auto-generated />
using System;
using Bolnica_back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bolnica_back.Migrations
{
    [DbContext(typeof(BolnicaContext))]
    [Migration("20210108000320_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Bolnica_back.Models.Bolnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IME");

                    b.Property<int>("M")
                        .HasColumnType("int")
                        .HasColumnName("M");

                    b.Property<int>("N")
                        .HasColumnType("int")
                        .HasColumnName("N");

                    b.HasKey("ID");

                    b.ToTable("BolnicaPodaci");
                });

            modelBuilder.Entity("Bolnica_back.Models.Osoba", b =>
                {
                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("JMBG");

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<string>("HitanSlucaj")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HITAN_SLUCAJ");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IME");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PREZIME");

                    b.Property<string>("TipOdeljenje")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ODELJENJE");

                    b.Property<string>("TipOsiguranja")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TIP_OSIGURANJA");

                    b.HasKey("JMBG");

                    b.HasIndex("BolnicaID");

                    b.ToTable("OsobaPodaci");
                });

            modelBuilder.Entity("Bolnica_back.Models.Osoba", b =>
                {
                    b.HasOne("Bolnica_back.Models.Bolnica", "Bolnica")
                        .WithMany("Osobe")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Bolnica_back.Models.Bolnica", b =>
                {
                    b.Navigation("Osobe");
                });
#pragma warning restore 612, 618
        }
    }
}
