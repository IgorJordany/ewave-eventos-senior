﻿// <auto-generated />
using System;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eventos.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210526150033_palestraMaping")]
    partial class palestraMaping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eventos.Core.Entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Eventos.Core.Entities.EventoFuncionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("EventoFuncionario");
                });

            modelBuilder.Entity("Eventos.Core.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Eventos.Core.Entities.Palestra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnName("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<float>("Duracao")
                        .HasColumnName("Duracao")
                        .HasColumnType("real");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnName("Local")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("PalestranteId")
                        .HasColumnName("PalestranteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnName("Tema")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PalestranteId");

                    b.ToTable("Palestra");
                });

            modelBuilder.Entity("Eventos.Core.Entities.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Confirmou")
                        .HasColumnName("Confirmou")
                        .HasColumnType("bit");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PalestraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PalestraId");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("Eventos.Core.Entities.EventoFuncionario", b =>
                {
                    b.HasOne("Eventos.Core.Entities.Evento", "Evento")
                        .WithMany("Organizadores")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventos.Core.Entities.Funcionario", "Funcionario")
                        .WithMany("Eventos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Eventos.Core.Entities.Palestra", b =>
                {
                    b.HasOne("Eventos.Core.Entities.Funcionario", null)
                        .WithMany("Palestrantes")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Eventos.Core.Entities.Participante", b =>
                {
                    b.HasOne("Eventos.Core.Entities.Funcionario", "Funcionario")
                        .WithMany("Participantes")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventos.Core.Entities.Palestra", "Palestra")
                        .WithMany("Participantes")
                        .HasForeignKey("PalestraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}