using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_per_il_monitoraggio_delle_api_mellifere.Migrations
{
    /// <inheritdoc />
    public partial class CreazioneIniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alveari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Umidita = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    AttivitaApi = table.Column<int>(type: "int", nullable: false),
                    UltimoAggiornamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alveari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alveari");
        }
    }
}
