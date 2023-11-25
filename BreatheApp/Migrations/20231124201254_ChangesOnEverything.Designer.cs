﻿// <auto-generated />
using System;
using BreatheApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace BreatheApp.Migrations
{
    [DbContext(typeof(BreatheContext))]
    [Migration("20231124201254_ChangesOnEverything")]
    partial class ChangesOnEverything
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BreatheApp.Models.Diagnostico", b =>
                {
                    b.Property<int>("DiagnosticoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagnosticoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("DoencaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("DiagnosticoId");

                    b.HasIndex("DoencaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Diagnostico", (string)null);
                });

            modelBuilder.Entity("BreatheApp.Models.Doenca", b =>
                {
                    b.Property<int>("DoencaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoencaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR2(280)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)");

                    b.Property<string>("Recomendacoes")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("DoencaId");

                    b.ToTable("Doenca", (string)null);
                });

            modelBuilder.Entity("BreatheApp.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("LogradouroId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("PontoDeReferencia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("LogradouroId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("BreatheApp.Models.Logradouro", b =>
                {
                    b.Property<int>("LogradouroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogradouroId"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Numero")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("LogradouroId");

                    b.ToTable("Logradouro");
                });

            modelBuilder.Entity("BreatheApp.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("NVARCHAR2(280)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("BreatheApp.Models.Diagnostico", b =>
                {
                    b.HasOne("BreatheApp.Models.Doenca", "Doenca")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("DoencaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreatheApp.Models.Usuario", "Usuario")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doenca");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BreatheApp.Models.Endereco", b =>
                {
                    b.HasOne("BreatheApp.Models.Logradouro", "Logradouro")
                        .WithMany("Enderecos")
                        .HasForeignKey("LogradouroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logradouro");
                });

            modelBuilder.Entity("BreatheApp.Models.Usuario", b =>
                {
                    b.HasOne("BreatheApp.Models.Endereco", "Endereco")
                        .WithMany("Usuarios")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("BreatheApp.Models.Doenca", b =>
                {
                    b.Navigation("Diagnosticos");
                });

            modelBuilder.Entity("BreatheApp.Models.Endereco", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("BreatheApp.Models.Logradouro", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("BreatheApp.Models.Usuario", b =>
                {
                    b.Navigation("Diagnosticos");
                });
#pragma warning restore 612, 618
        }
    }
}
