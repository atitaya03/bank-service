﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240829103428_MakeBankAccountTargetNullable")]
    partial class MakeBankAccountTargetNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication1.Models.BankAccount", b =>
                {
                    b.Property<long>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<double>("Balance")
                        .HasColumnType("double")
                        .HasColumnName("balance");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("BankAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("bank_account");
                });

            modelBuilder.Entity("WebApplication1.Models.History", b =>
                {
                    b.Property<long>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("action");

                    b.Property<double>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<long>("BankAccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("bank_account_owner");

                    b.Property<long?>("BankAccountTargetId")
                        .HasColumnType("bigint")
                        .HasColumnName("bank_account_target");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp")
                        .HasColumnName("date");

                    b.HasKey("HistoryId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("history");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("WebApplication1.Models.BankAccount", b =>
                {
                    b.HasOne("WebApplication1.Models.User", null)
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.History", b =>
                {
                    b.HasOne("WebApplication1.Models.BankAccount", null)
                        .WithMany("Histories")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.BankAccount", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
