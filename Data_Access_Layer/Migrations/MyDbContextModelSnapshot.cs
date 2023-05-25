﻿// <auto-generated />
using System;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data_Access_Layer.Context.CustomerEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("customerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Data_Access_Layer.Context.RepairEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("aard")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("calibernummer")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("customerId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kastnummer")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("kenmerk")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mechanism")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("merk")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("serienummer")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtMakers")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Repair");
                });

            modelBuilder.Entity("Data_Access_Layer.Context.StatusOverviewEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("creationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("repairId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("statusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("watchMaker")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusOverview");
                });

            modelBuilder.Entity("Data_Access_Layer.Context.UserEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("PublicIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data_Access_Layer.Context.WorkActivitiesEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("creationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("performedWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("priceExclVat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("priceInclVat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("repairId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("workId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WorkActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
