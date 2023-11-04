﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartManager.Brokers.Storages;

#nullable disable

namespace SmartManager.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20231103174616_AddBots")]
    partial class AddBots
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartManager.Models.Attendances.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("SmartManager.Models.Bots.Bot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Bots");
                });

            modelBuilder.Entity("SmartManager.Models.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SmartManager.Models.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SmartManager.Models.Statistics.Statistic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FemaleStudentsCount")
                        .HasColumnType("int");

                    b.Property<int>("MaleStudentsCount")
                        .HasColumnType("int");

                    b.Property<int>("PaidStudentsCount")
                        .HasColumnType("int");

                    b.Property<double>("PaidStudentsPercentage")
                        .HasColumnType("float");

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalStudentsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("SmartManager.Models.Students.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StatisticId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StatisticId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SmartManager.Models.Attendances.Attendance", b =>
                {
                    b.HasOne("SmartManager.Models.Students.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SmartManager.Models.Bots.Bot", b =>
                {
                    b.HasOne("SmartManager.Models.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SmartManager.Models.Payments.Payment", b =>
                {
                    b.HasOne("SmartManager.Models.Students.Student", "Student")
                        .WithMany("Payments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SmartManager.Models.Students.Student", b =>
                {
                    b.HasOne("SmartManager.Models.Groups.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");

                    b.HasOne("SmartManager.Models.Statistics.Statistic", null)
                        .WithMany("Students")
                        .HasForeignKey("StatisticId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SmartManager.Models.Groups.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SmartManager.Models.Statistics.Statistic", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SmartManager.Models.Students.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
