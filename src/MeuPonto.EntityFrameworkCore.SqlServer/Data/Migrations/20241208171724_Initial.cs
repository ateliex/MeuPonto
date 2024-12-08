using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeuPonto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Configuracoes",
                schema: "dbo",
                columns: table => new
                {
                    JavascriptIsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Empregadores",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Momento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Momento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pausa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pausa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusFolha",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFolha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoImagem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoImagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EmpregadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Empregadores_EmpregadorId",
                        column: x => x.EmpregadorId,
                        principalSchema: "dbo",
                        principalTable: "Empregadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos_JornadaTrabalhoDiaria",
                schema: "dbo",
                columns: table => new
                {
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tempo = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos_JornadaTrabalhoDiaria", x => new { x.ContratoId, x.DiaSemana });
                    table.ForeignKey(
                        name: "FK_Contratos_JornadaTrabalhoDiaria_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalSchema: "dbo",
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ApuracaoMensal_TempoTotalPeriodoAnterior = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folhas_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalSchema: "dbo",
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MomentoId = table.Column<int>(type: "int", nullable: false),
                    PausaId = table.Column<int>(type: "int", nullable: true),
                    Estimado = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontos_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalSchema: "dbo",
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folhas_ApuracaoDiaria",
                schema: "dbo",
                columns: table => new
                {
                    Dia = table.Column<int>(type: "int", nullable: false),
                    FolhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TempoPrevisto = table.Column<long>(type: "bigint", nullable: false),
                    TempoApurado = table.Column<long>(type: "bigint", nullable: true),
                    DiferencaTempo = table.Column<long>(type: "bigint", nullable: true),
                    TempoAbonado = table.Column<long>(type: "bigint", nullable: true),
                    Feriado = table.Column<bool>(type: "bit", nullable: false),
                    Falta = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas_ApuracaoDiaria", x => new { x.FolhaId, x.Dia });
                    table.ForeignKey(
                        name: "FK_Folhas_ApuracaoDiaria_Folhas_FolhaId",
                        column: x => x.FolhaId,
                        principalSchema: "dbo",
                        principalTable: "Folhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comprovantes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PontoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TipoImagemId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprovantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprovantes_Pontos_PontoId",
                        column: x => x.PontoId,
                        principalSchema: "dbo",
                        principalTable: "Pontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Momento",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Saída" },
                    { 3, "Errado" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pausa",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Almoço" },
                    { 2, "Café/Lanche" },
                    { 3, "Banheiro" },
                    { 4, "Conversa/Reunião" },
                    { 5, "Telefonema" },
                    { 6, "Genérica" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "StatusFolha",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 0, "Aberta" },
                    { 1, "Fechada" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoImagem",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Original" },
                    { 2, "Tratada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprovantes_PontoId",
                schema: "dbo",
                table: "Comprovantes",
                column: "PontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_EmpregadorId",
                schema: "dbo",
                table: "Contratos",
                column: "EmpregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_ContratoId",
                schema: "dbo",
                table: "Folhas",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_ContratoId",
                schema: "dbo",
                table: "Pontos",
                column: "ContratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprovantes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Configuracoes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contratos_JornadaTrabalhoDiaria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Folhas_ApuracaoDiaria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Momento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pausa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StatusFolha",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoImagem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pontos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Folhas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contratos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Empregadores",
                schema: "dbo");
        }
    }
}
