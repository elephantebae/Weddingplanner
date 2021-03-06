﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using weddingplanner.Models;

namespace weddingplanner.Migrations
{
    [DbContext(typeof(WeddingContext))]
    [Migration("20181212225910_lko")]
    partial class lko
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("weddingplanner.Models.Rsvp", b =>
                {
                    b.Property<int>("RsvpId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingId");

                    b.HasKey("RsvpId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Rsvping");
                });

            modelBuilder.Entity("weddingplanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("weddingplanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("WedderOne")
                        .IsRequired();

                    b.Property<string>("WedderTwo")
                        .IsRequired();

                    b.Property<string>("WeddingAddress")
                        .IsRequired();

                    b.HasKey("WeddingId");

                    b.ToTable("weddings");
                });

            modelBuilder.Entity("weddingplanner.Models.Rsvp", b =>
                {
                    b.HasOne("weddingplanner.Models.User", "user")
                        .WithMany("WeddingPlanned")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("weddingplanner.Models.Wedding", "wedding")
                        .WithMany("Attendees")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
