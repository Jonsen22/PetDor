using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetDoor.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadesNome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.EspecialidadesId);
                });

            migrationBuilder.CreateTable(
                name: "TipoVacina",
                columns: table => new
                {
                    TipoVacinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Iniciais = table.Column<string>(nullable: false),
                    Estoque = table.Column<int>(nullable: false),
                    Validade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVacina", x => x.TipoVacinaId);
                });

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    TutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Aniversario = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(maxLength: 25, nullable: false),
                    Celular = table.Column<string>(maxLength: 25, nullable: false),
                    CEP = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.TutorId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    login = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false),
                    tutorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Ferias = table.Column<bool>(nullable: false),
                    Nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(maxLength: 25, nullable: false),
                    Celular = table.Column<string>(maxLength: 25, nullable: false),
                    CEP = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.VeterinarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    PetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Castrado = table.Column<bool>(nullable: false),
                    Animal = table.Column<string>(maxLength: 25, nullable: false),
                    Raca = table.Column<string>(maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    TutorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pet_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(nullable: false),
                    VeterinarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.AgendaId);
                    table.ForeignKey(
                        name: "FK_Agenda_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinario",
                        principalColumn: "VeterinarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VetEspecialidades",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(nullable: false),
                    EspecialidadesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetEspecialidades", x => new { x.VeterinarioId, x.EspecialidadesId });
                    table.ForeignKey(
                        name: "FK_VetEspecialidades_Especialidade_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "Especialidade",
                        principalColumn: "EspecialidadesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VetEspecialidades_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinario",
                        principalColumn: "VeterinarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    VacinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaAplicacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TipoVacinaId = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.VacinaId);
                    table.ForeignKey(
                        name: "FK_Vacina_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacina_TipoVacina_TipoVacinaId",
                        column: x => x.TipoVacinaId,
                        principalTable: "TipoVacina",
                        principalColumn: "TipoVacinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Presente = table.Column<string>(nullable: false),
                    Custo = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Duracao = table.Column<int>(nullable: false, defaultValue: 30),
                    PetId = table.Column<int>(nullable: false),
                    AgendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consulta_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "AgendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_VeterinarioId",
                table: "Agenda",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AgendaId",
                table: "Consulta",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PetId",
                table: "Consulta",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_TutorId",
                table: "Pet",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_PetId",
                table: "Vacina",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_TipoVacinaId",
                table: "Vacina",
                column: "TipoVacinaId");

            migrationBuilder.CreateIndex(
                name: "IX_VetEspecialidades_EspecialidadesId",
                table: "VetEspecialidades",
                column: "EspecialidadesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "VetEspecialidades");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "TipoVacina");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Tutor");
        }
    }
}
