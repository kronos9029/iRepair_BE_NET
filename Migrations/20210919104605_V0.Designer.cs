﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iRepair_BE_NET.Helpers;

namespace iRepair_BE_NET.Migrations
{
    [DbContext(typeof(iRepair_DEVContext))]
    [Migration("20210919104605_V0")]
    partial class V0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Customer_Id");

                    b.Property<string>("Detail")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("IsDefault")
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .HasColumnName("Is_Default")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Company_Name");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hotline")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte[]>("IsOnline")
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .HasColumnName("Is_Online")
                        .IsFixedLength(true);

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Full_Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Customer_EMAIL")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "Username" }, "UK_Customer_USERNAME")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.FavoriteBy", b =>
                {
                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Customer_Id");

                    b.Property<Guid?>("RepairmanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Repairman_Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RepairmanId");

                    b.ToTable("FavoriteBy");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.FeedBack", b =>
                {
                    b.Property<string>("FeedbackMessage")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Feedback_Message");

                    b.Property<int?>("FeedbackPoint")
                        .HasColumnType("int")
                        .HasColumnName("Feedback_Point");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Order_Id");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Service_Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.LinkedAccount", b =>
                {
                    b.Property<string>("Account")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Customer_Id");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("CustomerId");

                    b.ToTable("LinkedAccount");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.MajorField", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<Guid?>("MajorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Major_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("MajorField");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Create_Time");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Customer_Address");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Customer_Id");

                    b.Property<string>("FeedbackMessage")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Feedback_Message");

                    b.Property<int?>("FeedbackPoint")
                        .HasColumnType("int")
                        .HasColumnName("Feedback_Point");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Payment_Time");

                    b.Property<Guid>("RepairmanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Repairman_Id");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Service_Id");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RepairmanId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.OrderEvidence", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Order_Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderEvidence");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.OrderHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Order_Id");

                    b.Property<string>("StatusFrom")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Status_From");

                    b.Property<string>("StatusTo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Status_To");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Update_By");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Update_Time");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.RepairMan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Company_Id");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IsOnline")
                        .HasColumnType("int")
                        .HasColumnName("Is_Online");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex(new[] { "Email" }, "UK_RepairMan_Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "PhoneNumber" }, "UK_RepairMan_Phone")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UK_RepairMan_Username")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("RepairMan");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Company_Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Field_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Service_Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FieldId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.SpecializeIn", b =>
                {
                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Company_Id");

                    b.Property<Guid?>("MajorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Major_Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MajorId");

                    b.ToTable("SpecializeIn");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.WorkOn", b =>
                {
                    b.Property<Guid>("RepairmanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Repairman_Id");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Service_Id");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("RepairmanId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("WorkOn");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Address", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Address_Customer")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.FavoriteBy", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_FavoriteBy_Customer");

                    b.HasOne("iRepair_BE_NET.Models.Entities.RepairMan", "Repairman")
                        .WithMany()
                        .HasForeignKey("RepairmanId")
                        .HasConstraintName("FK_FavoriteBy_RepairMan");

                    b.Navigation("Customer");

                    b.Navigation("Repairman");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.FeedBack", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_FeedBack_Order")
                        .IsRequired();

                    b.HasOne("iRepair_BE_NET.Models.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_FeedBack_Service")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.LinkedAccount", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_LinkedAccount_Customer")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.MajorField", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Major", "Major")
                        .WithMany("MajorFields")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK_MajorField_Major");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Order", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customer")
                        .IsRequired();

                    b.HasOne("iRepair_BE_NET.Models.Entities.RepairMan", "Repairman")
                        .WithMany("Orders")
                        .HasForeignKey("RepairmanId")
                        .HasConstraintName("FK_Order_RepairMan")
                        .IsRequired();

                    b.HasOne("iRepair_BE_NET.Models.Entities.Service", "Service")
                        .WithMany("Orders")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_Order_Service")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Repairman");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.OrderEvidence", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderEvidence_Order");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.OrderHistory", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderHistory_Order")
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.RepairMan", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Company", "Company")
                        .WithMany("RepairMen")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_RepairMan_Company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Service", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Company", "Company")
                        .WithMany("Services")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_Service_Company")
                        .IsRequired();

                    b.HasOne("iRepair_BE_NET.Models.Entities.MajorField", "Field")
                        .WithMany("Services")
                        .HasForeignKey("FieldId")
                        .HasConstraintName("FK_Service_MajorField")
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.SpecializeIn", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_SpecializeIn_Company");

                    b.HasOne("iRepair_BE_NET.Models.Entities.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK_SpecializeIn_Major");

                    b.Navigation("Company");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.WorkOn", b =>
                {
                    b.HasOne("iRepair_BE_NET.Models.Entities.RepairMan", "Repairman")
                        .WithMany("WorkOns")
                        .HasForeignKey("RepairmanId")
                        .HasConstraintName("FK_WorkOn_RepairMan")
                        .IsRequired();

                    b.HasOne("iRepair_BE_NET.Models.Entities.Service", "Service")
                        .WithMany("WorkOns")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_WorkOn_Service")
                        .IsRequired();

                    b.Navigation("Repairman");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Company", b =>
                {
                    b.Navigation("RepairMen");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Major", b =>
                {
                    b.Navigation("MajorFields");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.MajorField", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderHistories");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.RepairMan", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WorkOns");
                });

            modelBuilder.Entity("iRepair_BE_NET.Models.Entities.Service", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WorkOns");
                });
#pragma warning restore 612, 618
        }
    }
}
