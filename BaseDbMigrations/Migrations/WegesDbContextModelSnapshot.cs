﻿// <auto-generated />
using System;
using ApiModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    [DbContext(typeof(WegesDbContext))]
    partial class WegesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("weges")
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiModel.NeoModels.Acesso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AcessoTipo")
                        .HasColumnType("integer");

                    b.Property<long?>("EntidadeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Utilizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeId");

                    b.ToTable("Acesso", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.CertificadoERS", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Certificado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DataValidade")
                        .HasColumnType("date");

                    b.Property<long>("EstabelecimentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ficheiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CertificadosERS", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.DirecaoClinica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("CcDataValidade")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CedulaDataValidade")
                        .HasColumnType("date");

                    b.Property<string>("CedulaProfissional")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("DeclaracaoAceitacao")
                        .HasColumnType("boolean");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ordem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubDiretor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubDiretorCC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("SubDiretorCcDataValidade")
                        .HasColumnType("date");

                    b.Property<DateOnly>("SubDiretorCedulaDataValidade")
                        .HasColumnType("date");

                    b.Property<string>("SubDiretorCedulaProfissional")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubDiretorOrdem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DirecoesClinicas", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Entidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entidades", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Estabelecimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AutorizacaoInfarmed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodigoApa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DataInicioAtividade")
                        .HasColumnType("date");

                    b.Property<string>("Denominacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("DirecaoClinicaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoPrestador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DirecaoClinicaId");

                    b.ToTable("Estabelecimentos", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.LicencaERS", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("DataValidade")
                        .HasColumnType("date");

                    b.Property<long>("EstabelecimentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ficheiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Licenca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LicencasERS", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Mensagem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("EntidadeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeId");

                    b.ToTable("Mensagem", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Servico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CertificadoId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeclaracaoAceitacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Denominacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiretorCC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DiretorCcDataValidade")
                        .HasColumnType("date");

                    b.Property<string>("DiretorCedulaProfissional")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiretorOrdem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("EstabelecimentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("LicencaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CertificadoId");

                    b.HasIndex("LicencaId");

                    b.ToTable("Servicos", "weges");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Acesso", b =>
                {
                    b.HasOne("ApiModel.NeoModels.Entidade", null)
                        .WithMany("Acessos")
                        .HasForeignKey("EntidadeId");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Estabelecimento", b =>
                {
                    b.HasOne("ApiModel.NeoModels.DirecaoClinica", "DirecaoClinica")
                        .WithMany()
                        .HasForeignKey("DirecaoClinicaId");

                    b.Navigation("DirecaoClinica");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Mensagem", b =>
                {
                    b.HasOne("ApiModel.NeoModels.Entidade", null)
                        .WithMany("Mensagens")
                        .HasForeignKey("EntidadeId");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Servico", b =>
                {
                    b.HasOne("ApiModel.NeoModels.CertificadoERS", "Certificado")
                        .WithMany()
                        .HasForeignKey("CertificadoId");

                    b.HasOne("ApiModel.NeoModels.LicencaERS", "Licenca")
                        .WithMany()
                        .HasForeignKey("LicencaId");

                    b.Navigation("Certificado");

                    b.Navigation("Licenca");
                });

            modelBuilder.Entity("ApiModel.NeoModels.Entidade", b =>
                {
                    b.Navigation("Acessos");

                    b.Navigation("Mensagens");
                });
#pragma warning restore 612, 618
        }
    }
}
