﻿// <auto-generated />
using System;
using AcademiaAllFights.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademiaAllFights.API.Migrations
{
    [DbContext(typeof(AllFightsContext))]
    partial class AllFightsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcademiaAllFights.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Cpf = "16598745688",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 953, DateTimeKind.Local).AddTicks(7404),
                            DataNascimento = new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Marta",
                            Telefone = "332255553"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Cpf = "36925814755",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3855),
                            DataNascimento = new DateTime(2005, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Paula",
                            Telefone = "335428866"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Cpf = "96385274166",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3901),
                            DataNascimento = new DateTime(1993, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Laura",
                            Telefone = "556688994"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Cpf = "12345678988",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3916),
                            DataNascimento = new DateTime(1997, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Luiza",
                            Telefone = "656565923"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Cpf = "98765432100",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3927),
                            DataNascimento = new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Lucas",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            Cpf = "01203225455",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3951),
                            DataNascimento = new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Pedro",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            Cpf = "99988877700",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 954, DateTimeKind.Local).AddTicks(3962),
                            DataNascimento = new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Paulo",
                            Telefone = "987451265"
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.AlunoArteMarcial", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("ArteMarcialId")
                        .HasColumnType("int");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtesMarciais");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Nome = "Karatê"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Nome = "Judô"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Nome = "Jiujitsu"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Nome = "Morganti Ju-jitsu"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Nome = "Boxe"
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Funcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArteMarcialId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArteMarcialId");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArteMarcialId = 2,
                            Ativo = true,
                            Cpf = "25496857488",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 945, DateTimeKind.Local).AddTicks(543),
                            Nome = "Lauro",
                            Telefone = "89546823"
                        },
                        new
                        {
                            Id = 2,
                            ArteMarcialId = 3,
                            Ativo = true,
                            Cpf = "36587456914",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 946, DateTimeKind.Local).AddTicks(8228),
                            Nome = "Roberto",
                            Telefone = "85478622"
                        },
                        new
                        {
                            Id = 3,
                            ArteMarcialId = 4,
                            Ativo = true,
                            Cpf = "54879652147",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 946, DateTimeKind.Local).AddTicks(8310),
                            Nome = "Ronaldo",
                            Telefone = "25647855"
                        },
                        new
                        {
                            Id = 4,
                            ArteMarcialId = 5,
                            Ativo = true,
                            Cpf = "16587412599",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 946, DateTimeKind.Local).AddTicks(8320),
                            Nome = "Rodrigo",
                            Telefone = "36587742"
                        },
                        new
                        {
                            Id = 5,
                            ArteMarcialId = 1,
                            Ativo = true,
                            Cpf = "12569854211",
                            DataInicio = new DateTime(2021, 12, 15, 23, 19, 56, 946, DateTimeKind.Local).AddTicks(8324),
                            Nome = "Alexandre",
                            Telefone = "54178854"
                        });
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.UsuarioFuncoes", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.AlunoArteMarcial", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosArtesMarciais")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademiaAllFights.API.Models.ArteMarcial", "ArteMarcial")
                        .WithMany()
                        .HasForeignKey("ArteMarcialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("ArteMarcial");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Professor", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.ArteMarcial", "ArteMarcial")
                        .WithMany()
                        .HasForeignKey("ArteMarcialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArteMarcial");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.UsuarioFuncoes", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Funcao", "Funcao")
                        .WithMany("UsuarioFuncoes")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademiaAllFights.API.Models.Usuario", "Usuario")
                        .WithMany("UsuarioFuncoes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Funcao", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AcademiaAllFights.API.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Aluno", b =>
                {
                    b.Navigation("AlunosArtesMarciais");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Funcao", b =>
                {
                    b.Navigation("UsuarioFuncoes");
                });

            modelBuilder.Entity("AcademiaAllFights.API.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioFuncoes");
                });
#pragma warning restore 612, 618
        }
    }
}
