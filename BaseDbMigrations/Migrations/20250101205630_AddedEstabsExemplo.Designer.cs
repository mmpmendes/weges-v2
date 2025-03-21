﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ApiModel;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    [DbContext(typeof(WegesDbContext))]
    [Migration("20250101205630_AddedEstabsExemplo")]
    partial class AddedEstabsExemplo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("weges")
                .HasAnnotation("ProductVersion", "8.0.11")
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

                    b.ToTable("CodCaeEntidade", "weges");
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
                        .HasColumnType("text");

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CodCaes", "weges");
                });

            modelBuilder.Entity("ApiModel.Models.Entidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system-usr");

                    b.Property<string>("Denominacao")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("EmailNotificacoesERS")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("EmailNotificacoesGerais")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system-usr");

                    b.Property<string>("Morada")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("NifNipc")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<string>("NrERS")
                        .HasColumnType("text");

                    b.Property<string>("Sigla")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.HasKey("Id");

                    b.ToTable("Entidades", "weges");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Denominacao = "Entidade 1",
                            Email = "emailteste@email.email",
                            EmailNotificacoesERS = "emailnotificacoes@email.email",
                            EmailNotificacoesGerais = "emailnotificacoes@email.email",
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Morada = "Rua do Teste 1",
                            NifNipc = "123123123",
                            NrERS = "A-1234",
                            Sigla = "ent1",
                            Telefone = "921111111"
                        },
                        new
                        {
                            Id = 2L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Denominacao = "Entidade 2",
                            Email = "emailteste@email.email",
                            EmailNotificacoesERS = "emailnotificacoes@email.email",
                            EmailNotificacoesGerais = "emailnotificacoes@email.email",
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Morada = "Rua do Teste 2",
                            NifNipc = "123123123",
                            NrERS = "A-1234",
                            Sigla = "ent2",
                            Telefone = "921111111"
                        });
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

                    b.ToTable("Estabelecimentos", "weges");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Denominacao = "Estabelecimento 1",
                            Email = "email@email.email",
                            InicioAtividade = new DateOnly(2020, 2, 20),
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Morada = "estab 1 morada",
                            Sigla = "estab1",
                            Telefone = "291111111",
                            TipoPrestador = "Tipo de Prestador"
                        },
                        new
                        {
                            Id = 2L,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Denominacao = "Estabelecimento 2",
                            Email = "email@email.email",
                            InicioAtividade = new DateOnly(2023, 2, 20),
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Morada = "estab 2 morada",
                            Sigla = "estab2",
                            Telefone = "291111112",
                            TipoPrestador = "Tipo de Prestador"
                        });
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
