﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabi.Context;

#nullable disable

namespace Tabi.Migrations
{
    [DbContext(typeof(TabiContext))]
    [Migration("20240331060351_UpdateDataTypes")]
    partial class UpdateDataTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tabi.Model.Crop", b =>
                {
                    b.Property<int>("CropID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropID"));

                    b.Property<int>("CropStatusID")
                        .HasColumnType("int");

                    b.Property<int>("CropTypeID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("HarvestDate")
                        .HasColumnType("date");

                    b.Property<float>("Hectares")
                        .HasColumnType("real");

                    b.Property<int>("LotID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("PlantingDate")
                        .HasColumnType("date");

                    b.HasKey("CropID");

                    b.HasIndex("CropStatusID");

                    b.HasIndex("CropTypeID");

                    b.HasIndex("LotID");

                    b.ToTable("Crop", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.CropStatus", b =>
                {
                    b.Property<int>("CropStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropStatusID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CropStatusID");

                    b.ToTable("CropStatus", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.CropType", b =>
                {
                    b.Property<int>("CropTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropTypeID"));

                    b.Property<float>("ExpectedYield")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CropTypeID");

                    b.ToTable("CropType", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DocumentTypeID");

                    b.ToTable("DocumentType", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.Farm", b =>
                {
                    b.Property<int>("FarmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Hectares")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FarmID");

                    b.HasIndex("UserID");

                    b.ToTable("Farm", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.Harvest", b =>
                {
                    b.Property<int>("HarvestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HarvestID"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CropID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("HarvestStatusID")
                        .HasColumnType("int");

                    b.HasKey("HarvestID");

                    b.HasIndex("CropID");

                    b.HasIndex("HarvestStatusID");

                    b.ToTable("Harvest", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.HarvestPayment", b =>
                {
                    b.Property<int>("HarvestPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HarvestPaymentID"));

                    b.Property<int>("HarvestID")
                        .HasColumnType("int");

                    b.Property<float>("HarvestedAmount")
                        .HasColumnType("real");

                    b.Property<float>("PaymentAmount")
                        .HasColumnType("real");

                    b.Property<int>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("HarvestPaymentID");

                    b.HasIndex("HarvestID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("HarvestPayment", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.HarvestStatus", b =>
                {
                    b.Property<int>("HarvestStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HarvestStatusID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("HarvestStatusID");

                    b.ToTable("HarvestStatus", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.Lot", b =>
                {
                    b.Property<int>("LotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LotID"));

                    b.Property<int>("FarmID")
                        .HasColumnType("int");

                    b.Property<float>("Hectares")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SlopeTypeID")
                        .HasColumnType("int");

                    b.HasKey("LotID");

                    b.HasIndex("FarmID");

                    b.HasIndex("SlopeTypeID");

                    b.ToTable("Lot", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentTypeID");

                    b.ToTable("PaymentType", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.SlopeType", b =>
                {
                    b.Property<int>("SlopeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlopeTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SlopeTypeID");

                    b.ToTable("SlopeType", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("DocumentTypeID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("Tabi.Model.Crop", b =>
                {
                    b.HasOne("Tabi.Model.CropStatus", "CropStatus")
                        .WithMany()
                        .HasForeignKey("CropStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.CropType", "CropType")
                        .WithMany()
                        .HasForeignKey("CropTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CropStatus");

                    b.Navigation("CropType");

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("Tabi.Model.Farm", b =>
                {
                    b.HasOne("Tabi.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tabi.Model.Harvest", b =>
                {
                    b.HasOne("Tabi.Model.Crop", "Crop")
                        .WithMany()
                        .HasForeignKey("CropID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.HarvestStatus", "HarvestStatus")
                        .WithMany()
                        .HasForeignKey("HarvestStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop");

                    b.Navigation("HarvestStatus");
                });

            modelBuilder.Entity("Tabi.Model.HarvestPayment", b =>
                {
                    b.HasOne("Tabi.Model.Harvest", "Harvest")
                        .WithMany()
                        .HasForeignKey("HarvestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Harvest");

                    b.Navigation("PaymentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tabi.Model.Lot", b =>
                {
                    b.HasOne("Tabi.Model.Farm", "Farm")
                        .WithMany()
                        .HasForeignKey("FarmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tabi.Model.SlopeType", "SlopeType")
                        .WithMany()
                        .HasForeignKey("SlopeTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");

                    b.Navigation("SlopeType");
                });

            modelBuilder.Entity("Tabi.Model.User", b =>
                {
                    b.HasOne("Tabi.Model.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeID");

                    b.HasOne("Tabi.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}