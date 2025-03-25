﻿// <auto-generated />
using GymnasticScores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymnasticScores.Data.Migrations
{
    [DbContext(typeof(GymnasticsScoresDbContext))]
    [Migration("20250219183555_CreateOrganizationEntity")]
    partial class CreateOrganizationEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("GymnasticScores.Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Locale")
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });
#pragma warning restore 612, 618
        }
    }
}
