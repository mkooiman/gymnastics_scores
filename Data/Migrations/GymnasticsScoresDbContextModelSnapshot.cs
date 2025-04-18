﻿// <auto-generated />
using System;
using GymnasticScores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymnasticScores.Data.Migrations
{
    [DbContext(typeof(GymnasticsScoresDbContext))]
    partial class GymnasticsScoresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("GymnasticScores.Data.Entities.DisciplineEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Added")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Exercise")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShowFlags")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("GymnasticScores.Data.Entities.EventEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Added")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Venue")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GymnasticScores.Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Added")
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

            modelBuilder.Entity("GymnasticScores.Data.Entities.DisciplineEntity", b =>
                {
                    b.HasOne("GymnasticScores.Data.Entities.EventEntity", "Event")
                        .WithMany("Disciplines")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("GymnasticScores.Data.Entities.EventEntity", b =>
                {
                    b.HasOne("GymnasticScores.Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Events")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("GymnasticScores.Data.Entities.EventEntity", b =>
                {
                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("GymnasticScores.Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
