﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DotnetCore_TAS_CandidateAPI.Models;

namespace TAS_AngularCoreProj.Migrations
{
    [DbContext(typeof(CandidateProcessDBContext))]
    [Migration("20200401164420_tasmigration_010420")]
    partial class tasmigration_010420
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("City", b =>
                {
                    b.Property<int>("CityPKID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("CityPKID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EmailNotification", b =>
                {
                    b.Property<int>("EmailPKID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("MailingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MessageBody")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Recepients")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(4000)");

                    b.HasKey("EmailPKID");

                    b.ToTable("EmailNotifications");
                });

            modelBuilder.Entity("State", b =>
                {
                    b.Property<int>("StatePKID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StateName")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("StatePKID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserPKID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(4000)");

                    b.Property<int>("CityFKID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DOJ")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("varchar(4000)");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemember")
                        .HasColumnName("IsRemember")
                        .HasColumnType("bit");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("NewPassword")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("OldPassword")
                        .HasColumnType("varchar(4000)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("varchar(4000)");

                    b.Property<int>("RoleFKID")
                        .HasColumnType("int");

                    b.Property<int>("StateFKID")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserEmail")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(4000)");

                    b.HasKey("UserPKID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
