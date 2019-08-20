﻿// <auto-generated />
using Manifest.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manifest.Persistence.Migrations
{
    [DbContext(typeof(ManifestDbContext))]
    [Migration("20190715020939_AddJumpTable")]
    partial class AddJumpTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manifest.Domain.Entities.Aircraft", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<int>("Capacity");

                    b.HasKey("Name");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("Manifest.Domain.Entities.Jump", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("DefaultAltitude");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Jumps");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Jump");

                    b.HasData(
                        new
                        {
                            Id = "14,500",
                            DefaultAltitude = 14500,
                            Price = 26.00m
                        },
                        new
                        {
                            Id = "PRPAY",
                            DefaultAltitude = 14500,
                            Price = 0.00m
                        },
                        new
                        {
                            Id = "COUPON",
                            DefaultAltitude = 14500,
                            Price = 0.00m
                        },
                        new
                        {
                            Id = "GRWTS",
                            DefaultAltitude = 14500,
                            Price = 51.00m
                        },
                        new
                        {
                            Id = "COACHJ",
                            DefaultAltitude = 14500,
                            Price = 26.00m
                        },
                        new
                        {
                            Id = "COACHI",
                            DefaultAltitude = 14500,
                            Price = 0.00m
                        },
                        new
                        {
                            Id = "OBS",
                            DefaultAltitude = 14500,
                            Price = 30.00m
                        },
                        new
                        {
                            Id = "AWTS13",
                            DefaultAltitude = 14500,
                            Price = 200.00m
                        },
                        new
                        {
                            Id = "AWTS47",
                            DefaultAltitude = 14500,
                            Price = 175.00m
                        },
                        new
                        {
                            Id = "ADJ 47",
                            DefaultAltitude = 14500,
                            Price = 170.00m
                        },
                        new
                        {
                            Id = "ACW 13",
                            DefaultAltitude = 14500,
                            Price = 196.00m
                        },
                        new
                        {
                            Id = "ACW 47",
                            DefaultAltitude = 14500,
                            Price = 170.00m
                        },
                        new
                        {
                            Id = "GRCW",
                            DefaultAltitude = 14500,
                            Price = 48.00m
                        });
                });

            modelBuilder.Entity("Manifest.Domain.Entities.Person", b =>
                {
                    b.Property<string>("ManifestNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAffInstructor");

                    b.Property<bool>("IsCoach");

                    b.Property<bool>("IsTandemInstructor");

                    b.Property<bool>("IsVideographer");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("ManifestNumber");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Manifest.Domain.Entities.AffJump", b =>
                {
                    b.HasBaseType("Manifest.Domain.Entities.Jump");

                    b.HasDiscriminator().HasValue("AffJump");

                    b.HasData(
                        new
                        {
                            Id = "IAFF2",
                            DefaultAltitude = 14500,
                            Price = 200.00m
                        },
                        new
                        {
                            Id = "IAFF1",
                            DefaultAltitude = 14500,
                            Price = 175.00m
                        });
                });

            modelBuilder.Entity("Manifest.Domain.Entities.TandemJump", b =>
                {
                    b.HasBaseType("Manifest.Domain.Entities.Jump");

                    b.HasDiscriminator().HasValue("TandemJump");

                    b.HasData(
                        new
                        {
                            Id = "TAN",
                            DefaultAltitude = 14500,
                            Price = 225.00m
                        },
                        new
                        {
                            Id = "TANVST",
                            DefaultAltitude = 14500,
                            Price = 325.00m
                        },
                        new
                        {
                            Id = "TANGFT",
                            DefaultAltitude = 14500,
                            Price = 0.00m
                        },
                        new
                        {
                            Id = "TANADV",
                            DefaultAltitude = 14500,
                            Price = 0.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
