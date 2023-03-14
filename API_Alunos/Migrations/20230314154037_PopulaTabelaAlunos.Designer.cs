﻿// <auto-generated />
using API_Alunos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Alunos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230314154037_PopulaTabelaAlunos")]
    partial class PopulaTabelaAlunos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_Alunos.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "aluno01@escola.com.br",
                            Idade = 20,
                            Nome = "Aluno 01"
                        },
                        new
                        {
                            Id = 2,
                            Email = "aluno02@escola.com.br",
                            Idade = 22,
                            Nome = "Aluno 02"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}