﻿// <auto-generated />
using System;
using BusinessRiskManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessRiskManagement.Migrations
{
    [DbContext(typeof(BRMContext))]
    partial class BRMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessRiskManagement.Model.Organizacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Organizacions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Organizacion");
                });

            modelBuilder.Entity("BusinessRiskManagement.Model.Company", b =>
                {
                    b.HasBaseType("BusinessRiskManagement.Model.Organizacion");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("BusinessRiskManagement.Model.Individual", b =>
                {
                    b.HasBaseType("BusinessRiskManagement.Model.Organizacion");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Individual");
                });
#pragma warning restore 612, 618
        }
    }
}
