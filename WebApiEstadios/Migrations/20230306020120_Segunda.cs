using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEstadios.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    EstadioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.EstadioID);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamientos",
                columns: table => new
                {
                    EstacionamientoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    PrecioHora = table.Column<int>(type: "int", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamientos", x => x.EstacionamientoID);
                    table.ForeignKey(
                        name: "FK_Estacionamientos_Estadios_EstadioID",
                        column: x => x.EstadioID,
                        principalTable: "Estadios",
                        principalColumn: "EstadioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamientos_EstadioID",
                table: "Estacionamientos",
                column: "EstadioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamientos");

            migrationBuilder.DropTable(
                name: "Estadios");
        }
    }
}
