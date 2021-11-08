﻿// <auto-generated />
using System;
using AcademiaAllFights.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademiaAllFights.API.Migrations
{
    [DbContext(typeof(AllFightsContext))]
    [Migration("20211104191128_novaMigration")]
    partial class novaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("AcademiaAllFights.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Cpf = "16598745688",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 566, DateTimeKind.Local).AddTicks(6679),
                            DataNascimento = new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Marta",
                            Telefone = "332255553"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Cpf = "36925814755",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(204),
                            DataNascimento = new DateTime(2005, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Paula",
                            Telefone = "335428866"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Cpf = "96385274166",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(237),
                            DataNascimento = new DateTime(1993, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Laura",
                            Telefone = "556688994"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Cpf = "12345678988",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(251),
                            DataNascimento = new DateTime(1997, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Luiza",
                            Telefone = "656565923"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Cpf = "98765432100",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(263),
                            DataNascimento = new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Lucas",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            Cpf = "01203225455",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(286),
                            DataNascimento = new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Pedro",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            Cpf = "99988877700",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(297),
                            DataNascimento = new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Paulo",
                            Telefone = "987451265"
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.AlunoArteMarcial", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArteMarcialId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "ArteMarcialId");

                    b.HasIndex("ArteMarcialId");

                    b.ToTable("AlunosArtesMarciais");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            ArteMarcialId = 2
                        },
                        new
                        {
                            AlunoId = 1,
                            ArteMarcialId = 4
                        },
                        new
                        {
                            AlunoId = 1,
                            ArteMarcialId = 5
                        },
                        new
                        {
                            AlunoId = 2,
                            ArteMarcialId = 1
                        },
                        new
                        {
                            AlunoId = 2,
                            ArteMarcialId = 2
                        },
                        new
                        {
                            AlunoId = 2,
                            ArteMarcialId = 5
                        },
                        new
                        {
                            AlunoId = 3,
                            ArteMarcialId = 1
                        },
                        new
                        {
                            AlunoId = 3,
                            ArteMarcialId = 2
                        },
                        new
                        {
                            AlunoId = 3,
                            ArteMarcialId = 3
                        },
                        new
                        {
                            AlunoId = 4,
                            ArteMarcialId = 1
                        },
                        new
                        {
                            AlunoId = 4,
                            ArteMarcialId = 4
                        },
                        new
                        {
                            AlunoId = 4,
                            ArteMarcialId = 5
                        },
                        new
                        {
                            AlunoId = 5,
                            ArteMarcialId = 4
                        },
                        new
                        {
                            AlunoId = 5,
                            ArteMarcialId = 5
                        },
                        new
                        {
                            AlunoId = 6,
                            ArteMarcialId = 1
                        },
                        new
                        {
                            AlunoId = 6,
                            ArteMarcialId = 2
                        },
                        new
                        {
                            AlunoId = 6,
                            ArteMarcialId = 3
                        },
                        new
                        {
                            AlunoId = 6,
                            ArteMarcialId = 4
                        },
                        new
                        {
                            AlunoId = 7,
                            ArteMarcialId = 1
                        },
                        new
                        {
                            AlunoId = 7,
                            ArteMarcialId = 2
                        },
                        new
                        {
                            AlunoId = 7,
                            ArteMarcialId = 3
                        },
                        new
                        {
                            AlunoId = 7,
                            ArteMarcialId = 4
                        },
                        new
                        {
                            AlunoId = 7,
                            ArteMarcialId = 5
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.ArteMarcial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ArtesMarciais");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Nome = "Karatê",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Nome = "Judô",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Nome = "Jiujitsu",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Nome = "Morganti Ju-jitsu",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Nome = "Boxe",
                            ProfessorId = 4
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Cpf = "25496857488",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 556, DateTimeKind.Local).AddTicks(1938),
                            Nome = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Cpf = "36587456914",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(443),
                            Nome = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Cpf = "54879652147",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(482),
                            Nome = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Cpf = "16587412599",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(487),
                            Nome = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Cpf = "12569854211",
                            DataInicio = new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(490),
                            Nome = "Alexandre"
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.AlunoArteMarcial", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosArtesMarciais")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademiaAllFights.API.Models.ArteMarcial", "ArtesMarciais")
                        .WithMany()
                        .HasForeignKey("ArteMarcialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("ArtesMarciais");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.ArteMarcial", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Professor", "Professor")
                        .WithMany("ArtesMarciais")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Aluno", b =>
                {
                    b.Navigation("AlunosArtesMarciais");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Professor", b =>
                {
                    b.Navigation("ArtesMarciais");
                });
#pragma warning restore 612, 618
        }
    }
}