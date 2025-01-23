﻿using System;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20241231145451_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalProject.Models.Etkinlik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("KatilimSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Lokasyon")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("Topluluk")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Topluluk");

                    b.ToTable("Etkinlikler");
                });

            modelBuilder.Entity("FinalProject.Models.Katilim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("KatilmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kullanici")
                        .HasColumnType("int");

                    b.Property<int>("Topluluk")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Kullanici");

                    b.HasIndex("Topluluk");

                    b.ToTable("Katilimlar");
                });

            modelBuilder.Entity("FinalProject.Models.Topluluk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Olusturan")
                        .HasColumnType("int");

                    b.Property<bool>("Onayli")
                        .HasColumnType("bit");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Universite")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UyeSayisi")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Olusturan");

                    b.ToTable("Topluluklar");
                });

            modelBuilder.Entity("FinalProject.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KatildigiEtkinlikler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SifreHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TakipEttigiTopluluklar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İsimSoyisim")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinalProject.Models.Etkinlik", b =>
                {
                    b.HasOne("FinalProject.Models.Topluluk", null)
                        .WithMany()
                        .HasForeignKey("Topluluk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Models.Katilim", b =>
                {
                    b.HasOne("FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Kullanici")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.Topluluk", null)
                        .WithMany()
                        .HasForeignKey("Topluluk")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Models.Topluluk", b =>
                {
                    b.HasOne("FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Olusturan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
