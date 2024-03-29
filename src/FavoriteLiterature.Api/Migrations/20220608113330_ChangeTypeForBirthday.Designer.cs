﻿// <auto-generated />
using System;
using FavoriteLiterature.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FavoriteLiterature.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220608113330_ChangeTypeForBirthday")]
    partial class ChangeTypeForBirthday
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("favoriteLiterature")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<byte>("Rating")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Authors", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Rating")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Critic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AboutMe")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<byte>("Rating")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Critics", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.CriticOpinion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<Guid>("CriticId")
                        .HasColumnType("uuid");

                    b.Property<byte>("Estimation")
                        .HasColumnType("smallint");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CriticId");

                    b.ToTable("CriticOpinions", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Documents", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Statuses", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users", "favoriteLiterature");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Author", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.User", "User")
                        .WithOne("Author")
                        .HasForeignKey("FavoriteLiterature.Api.Entities.Author", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Book", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Critic", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.User", "User")
                        .WithOne("Critic")
                        .HasForeignKey("FavoriteLiterature.Api.Entities.Critic", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.CriticOpinion", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.Book", "Book")
                        .WithMany("Opinions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteLiterature.Api.Entities.Critic", "Critic")
                        .WithMany("Opinions")
                        .HasForeignKey("CriticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Critic");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Document", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.Book", "Book")
                        .WithMany("Documents")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.User", b =>
                {
                    b.HasOne("FavoriteLiterature.Api.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Book", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Critic", b =>
                {
                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FavoriteLiterature.Api.Entities.User", b =>
                {
                    b.Navigation("Author");

                    b.Navigation("Critic");
                });
#pragma warning restore 612, 618
        }
    }
}
