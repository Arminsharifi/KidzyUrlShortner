﻿// <auto-generated />
using System;
using KidzyUrlShortner.DAL.EfCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KidzyUrlShortner.DAL.EfCore.Migrations
{
    [DbContext(typeof(UrlDbContext))]
    [Migration("20230817124215_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VazirUrlShortner.Domain.Entities.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("link");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("slug");

                    b.Property<int>("TimesVisited")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("times_visited");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("tbl_url", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}