using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaAllFights.API.Migrations
{
    public partial class novaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtesMarciais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtesMarciais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtesMarciais_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosArtesMarciais",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArteMarcialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosArtesMarciais", x => new { x.AlunoId, x.ArteMarcialId });
                    table.ForeignKey(
                        name: "FK_AlunosArtesMarciais_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosArtesMarciais_ArtesMarciais_ArteMarcialId",
                        column: x => x.ArteMarcialId,
                        principalTable: "ArtesMarciais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 1, true, "16598745688", null, new DateTime(2021, 11, 4, 16, 11, 27, 566, DateTimeKind.Local).AddTicks(6679), new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "332255553" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 2, true, "36925814755", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(204), new DateTime(2005, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paula", "335428866" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 3, true, "96385274166", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(237), new DateTime(1993, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "556688994" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 4, true, "12345678988", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(251), new DateTime(1997, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luiza", "656565923" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 5, true, "98765432100", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(263), new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 6, true, "01203225455", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(286), new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Nome", "Telefone" },
                values: new object[] { 7, true, "99988877700", null, new DateTime(2021, 11, 4, 16, 11, 27, 567, DateTimeKind.Local).AddTicks(297), new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paulo", "987451265" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Nome" },
                values: new object[] { 1, true, "25496857488", null, new DateTime(2021, 11, 4, 16, 11, 27, 556, DateTimeKind.Local).AddTicks(1938), "Lauro" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Nome" },
                values: new object[] { 2, true, "36587456914", null, new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(443), "Roberto" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Nome" },
                values: new object[] { 3, true, "54879652147", null, new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(482), "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Nome" },
                values: new object[] { 4, true, "16587412599", null, new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(487), "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Nome" },
                values: new object[] { 5, true, "12569854211", null, new DateTime(2021, 11, 4, 16, 11, 27, 563, DateTimeKind.Local).AddTicks(490), "Alexandre" });

            migrationBuilder.InsertData(
                table: "ArtesMarciais",
                columns: new[] { "Id", "Ativo", "Nome", "ProfessorId" },
                values: new object[] { 1, true, "Karatê", 1 });

            migrationBuilder.InsertData(
                table: "ArtesMarciais",
                columns: new[] { "Id", "Ativo", "Nome", "ProfessorId" },
                values: new object[] { 2, true, "Judô", 1 });

            migrationBuilder.InsertData(
                table: "ArtesMarciais",
                columns: new[] { "Id", "Ativo", "Nome", "ProfessorId" },
                values: new object[] { 3, true, "Jiujitsu", 2 });

            migrationBuilder.InsertData(
                table: "ArtesMarciais",
                columns: new[] { "Id", "Ativo", "Nome", "ProfessorId" },
                values: new object[] { 4, true, "Morganti Ju-jitsu", 3 });

            migrationBuilder.InsertData(
                table: "ArtesMarciais",
                columns: new[] { "Id", "Ativo", "Nome", "ProfessorId" },
                values: new object[] { 5, true, "Boxe", 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "AlunosArtesMarciais",
                columns: new[] { "AlunoId", "ArteMarcialId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosArtesMarciais_ArteMarcialId",
                table: "AlunosArtesMarciais",
                column: "ArteMarcialId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtesMarciais_ProfessorId",
                table: "ArtesMarciais",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosArtesMarciais");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "ArtesMarciais");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
