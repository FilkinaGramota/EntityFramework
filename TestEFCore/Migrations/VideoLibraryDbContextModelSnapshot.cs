﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEFCore;

namespace TestEFCore.Migrations
{
    [DbContext(typeof(VideoLibraryDbContext))]
    partial class VideoLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEFCore.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TestEFCore.FilmOrder", b =>
                {
                    b.Property<int>("FilmId");

                    b.Property<int>("OrderId");

                    b.HasKey("FilmId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("FilmOrders");
                });

            modelBuilder.Entity("TestEFCore.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Days");

                    b.Property<DateTime>("OrderEnd");

                    b.Property<DateTime>("OrderStart");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TestEFCore.FilmOrder", b =>
                {
                    b.HasOne("TestEFCore.Film", "Film")
                        .WithMany("FilmOrders")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestEFCore.Order", "Order")
                        .WithMany("FilmOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
