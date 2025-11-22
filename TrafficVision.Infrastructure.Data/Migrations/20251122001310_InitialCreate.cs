using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TrafficVision.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(110)", maxLength: 110, nullable: false),
                    cargo = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    modelo = table.Column<string>(type: "text", nullable: false),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    marca = table.Column<string>(type: "text", nullable: false),
                    cor = table.Column<string>(type: "text", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false),
                    renavam = table.Column<string>(type: "text", nullable: false),
                    chassis = table.Column<string>(type: "text", nullable: false),
                    municipio = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    condicao_dados_veiculo = table.Column<int>(type: "integer", nullable: false),
                    tipo_combustivel = table.Column<int>(type: "integer", nullable: false),
                    condicao_crime = table.Column<int>(type: "integer", nullable: false),
                    sinistrado = table.Column<bool>(type: "boolean", nullable: false),
                    restricao_judicial = table.Column<bool>(type: "boolean", nullable: false),
                    leiloado = table.Column<bool>(type: "boolean", nullable: false),
                    nome_dono = table.Column<string>(type: "text", nullable: false),
                    cpf_cnpj_dono = table.Column<string>(type: "text", nullable: false),
                    cnh_dono = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registro_relatorio",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuario_id = table.Column<long>(type: "bigint", nullable: false),
                    veiculo_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_relatorio", x => x.id);
                    table.ForeignKey(
                        name: "FK_registro_relatorio_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registro_relatorio_veiculo_veiculo_id",
                        column: x => x.veiculo_id,
                        principalTable: "veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registro_relatorio_usuario_id",
                table: "registro_relatorio",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_registro_relatorio_veiculo_id",
                table: "registro_relatorio",
                column: "veiculo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registro_relatorio");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
