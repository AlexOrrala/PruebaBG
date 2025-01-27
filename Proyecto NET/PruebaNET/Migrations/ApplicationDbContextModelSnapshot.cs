﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PruebaNET.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PRUEBANET.Models.DiscrepanciasAORRALA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric");

                    b.Property<bool>("Resuelta")
                        .HasColumnType("boolean");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("discrepancias_aorrala");
                });

            modelBuilder.Entity("PRUEBANET.Models.MovimientosBancariosAORRALA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("movimientosbancarios_aorrala");
                });

            modelBuilder.Entity("PRUEBANET.Models.RegistrosContablesAORRALA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("registroscontables_aorrala");
                });
#pragma warning restore 612, 618
        }
    }
}
