﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ApiModel;

#nullable disable

namespace DbMigrations.Migrations
{
    [DbContext(typeof(WegesDbContext))]
    [Migration("20241126234442_entidadeECodCae")]
    partial class entidadeECodCae
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodCaeEntidade", b =>
                {
                    b.Property<long>("CodCaesId")
                        .HasColumnType("bigint");

                    b.Property<long>("EntidadesId")
                        .HasColumnType("bigint");

                    b.HasKey("CodCaesId", "EntidadesId");

                    b.HasIndex("EntidadesId");

                    b.ToTable("CodCaeEntidade");
                });

            modelBuilder.Entity("ApiModel.Models.CodCae", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CodCaes");
                });

            modelBuilder.Entity("ApiModel.Models.Entidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Denominacao")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmailNotificacoesERS")
                        .HasColumnType("text");

                    b.Property<string>("EmailNotificacoesGerais")
                        .HasColumnType("text");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Morada")
                        .HasColumnType("text");

                    b.Property<string>("NifNipc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NrERS")
                        .HasColumnType("integer");

                    b.Property<string>("Sigla")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entidades");
                });

            modelBuilder.Entity("ApiModel.Models.Estabelecimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Denominacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateOnly>("InicioAtividade")
                        .HasColumnType("date");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Morada")
                        .HasColumnType("text");

                    b.Property<string>("Sigla")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.Property<string>("TipoPrestador")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("CodCaeEntidade", b =>
                {
                    b.HasOne("ApiModel.Models.CodCae", null)
                        .WithMany()
                        .HasForeignKey("CodCaesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiModel.Models.Entidade", null)
                        .WithMany()
                        .HasForeignKey("EntidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
