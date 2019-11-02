﻿// <auto-generated />
using System;
using Bank.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank.Api.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    partial class StoreDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bank.Api.Models.Account", b =>
                {
                    b.Property<long>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.HasKey("AccountNumber");

                    b.ToTable("account");
                });

            modelBuilder.Entity("Bank.Api.Models.Operations.AbstractOperation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountNumber");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("OperationType")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("Rate")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber");

                    b.ToTable("operation");

                    b.HasDiscriminator<string>("OperationType").HasValue("AbstractOperation");
                });

            modelBuilder.Entity("Bank.Api.Models.Operations.DepositOperation", b =>
                {
                    b.HasBaseType("Bank.Api.Models.Operations.AbstractOperation");

                    b.HasDiscriminator().HasValue("DepositOperation");
                });

            modelBuilder.Entity("Bank.Api.Models.Operations.AbstractOperation", b =>
                {
                    b.HasOne("Bank.Api.Models.Account", "Account")
                        .WithMany("Operations")
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
