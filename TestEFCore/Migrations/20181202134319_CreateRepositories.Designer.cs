﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEFCore;

namespace TestEFCore.Migrations
{
    [DbContext(typeof(VideoLibraryDbContext))]
    [Migration("20181202134319_CreateRepositories")]
    partial class CreateRepositories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEFCore.Cassette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.HasKey("Id");

                    b.ToTable("Cassettes");
                });

            modelBuilder.Entity("TestEFCore.CassetteFilm", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("CassetteId");

                    b.HasKey("FilmId", "CassetteId");

                    b.HasIndex("CassetteId");

                    b.ToTable("CassetteFilms");
                });

            modelBuilder.Entity("TestEFCore.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("TestEFCore.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TestEFCore.FilmGenre", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("GenreId");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("TestEFCore.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("TestEFCore.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("OrderEnd");

                    b.Property<DateTime>("OrderStart");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TestEFCore.OrderCassette", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("CassetteId");

                    b.HasKey("OrderId", "CassetteId");

                    b.HasIndex("CassetteId");

                    b.ToTable("OrderCassettes");
                });

            modelBuilder.Entity("TestEFCore.CassetteFilm", b =>
                {
                    b.HasOne("TestEFCore.Cassette", "Cassette")
                        .WithMany("CassetteFilms")
                        .HasForeignKey("CassetteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Film", "Film")
                        .WithMany("CassetteFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestEFCore.FilmGenre", b =>
                {
                    b.HasOne("TestEFCore.Film", "Film")
                        .WithMany("FilmGenres")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Genre", "Genre")
                        .WithMany("FilmGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestEFCore.Order", b =>
                {
                    b.HasOne("TestEFCore.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("TestEFCore.OrderCassette", b =>
                {
                    b.HasOne("TestEFCore.Cassette", "Cassette")
                        .WithMany("OrderCassettes")
                        .HasForeignKey("CassetteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Order", "Order")
                        .WithMany("OrderCassettes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}