﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiEstadios;

#nullable disable

namespace WebApiEstadios.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230302214006_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiEstadios.Entidades.Estadio", b =>
                {
                    b.Property<int>("EstadioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadioID"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Equipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadioID");

                    b.ToTable("Estadios");
                });
#pragma warning restore 612, 618
        }
    }
}
