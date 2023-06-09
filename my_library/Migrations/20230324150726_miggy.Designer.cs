﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using my_library.Data;

#nullable disable

namespace my_library.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230324150726_miggy")]
    partial class miggy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("my_library.Models.Media", b =>
                {
                    b.Property<int>("media_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("media_id"));

                    b.Property<int>("location_asile")
                        .HasColumnType("integer");

                    b.Property<int>("location_floor")
                        .HasColumnType("integer");

                    b.HasKey("media_id");

                    b.ToTable("media");
                });

            modelBuilder.Entity("my_library.Models.book", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("book_id"));

                    b.Property<int>("mediaId")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("book_id");

                    b.HasIndex("mediaId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("my_library.Models.computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("mediaId")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("mediaId");

                    b.ToTable("computers");
                });

            modelBuilder.Entity("my_library.Models.book", b =>
                {
                    b.HasOne("my_library.Models.Media", "media")
                        .WithMany()
                        .HasForeignKey("mediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("media");
                });

            modelBuilder.Entity("my_library.Models.computer", b =>
                {
                    b.HasOne("my_library.Models.Media", "media")
                        .WithMany()
                        .HasForeignKey("mediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("media");
                });
#pragma warning restore 612, 618
        }
    }
}
