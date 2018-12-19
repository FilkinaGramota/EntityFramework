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
    [Migration("20181219002440_SomethingChanged")]
    partial class SomethingChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEFCore.Entities.Cassette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.HasKey("Id");

                    b.ToTable("Cassettes");
                });

            modelBuilder.Entity("TestEFCore.Entities.CassetteFilm", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("CassetteId");

                    b.HasKey("FilmId", "CassetteId");

                    b.HasIndex("CassetteId");

                    b.ToTable("CassetteFilms");
                });

            modelBuilder.Entity("TestEFCore.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("TestEFCore.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TestEFCore.Entities.FilmGenre", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("GenreId");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("TestEFCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("TestEFCore.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<int>("Cost");

                    b.Property<DateTime>("OrderEnd");

                    b.Property<DateTime>("OrderFactEnd");

                    b.Property<DateTime>("OrderStart");

                    b.Property<int>("Surcharge");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TestEFCore.Entities.OrderCassette", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("CassetteId");

                    b.HasKey("OrderId", "CassetteId");

                    b.HasIndex("CassetteId");

                    b.ToTable("OrderCassettes");
                });

            modelBuilder.Entity("TestEFCore.Entities.CassetteFilm", b =>
                {
                    b.HasOne("TestEFCore.Entities.Cassette", "Cassette")
                        .WithMany("CassetteFilms")
                        .HasForeignKey("CassetteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Entities.Film", "Film")
                        .WithMany("CassetteFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestEFCore.Entities.Client", b =>
                {
                    b.OwnsOne("TestEFCore.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int?>("ClientId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName");

                            b1.ToTable("Client");

                            b1.HasOne("TestEFCore.Entities.Client")
                                .WithOne("Name")
                                .HasForeignKey("TestEFCore.Entities.Name", "ClientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TestEFCore.Entities.FilmGenre", b =>
                {
                    b.HasOne("TestEFCore.Entities.Film", "Film")
                        .WithMany("FilmGenres")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Entities.Genre", "Genre")
                        .WithMany("FilmGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestEFCore.Entities.Order", b =>
                {
                    b.HasOne("TestEFCore.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("TestEFCore.Entities.OrderCassette", b =>
                {
                    b.HasOne("TestEFCore.Entities.Cassette", "Cassette")
                        .WithMany("OrderCassettes")
                        .HasForeignKey("CassetteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Entities.Order", "Order")
                        .WithMany("OrderCassettes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
