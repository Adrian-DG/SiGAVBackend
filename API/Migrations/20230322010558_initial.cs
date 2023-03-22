using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EsAdministrador = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsuarioPermisos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cedula", "EsAdministrador", "Estatus", "FechaCreacion", "FechaModificacion", "FechaNacimiento", "Genero", "Nombre", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, null, true, true, new DateTime(2023, 3, 21, 21, 5, 57, 750, DateTimeKind.Local).AddTicks(2626), new DateTime(2023, 3, 21, 21, 5, 57, 750, DateTimeKind.Local).AddTicks(2633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new byte[] { 125, 255, 106, 41, 188, 224, 119, 81, 48, 128, 152, 8, 49, 244, 182, 68, 165, 63, 171, 78, 249, 129, 71, 70, 101, 233, 218, 50, 236, 93, 74, 233, 172, 164, 75, 84, 185, 93, 2, 203, 144, 154, 71, 141, 146, 232, 28, 86, 156, 123, 214, 64, 43, 22, 101, 86, 220, 13, 98, 186, 248, 35, 223, 176 }, new byte[] { 27, 140, 210, 235, 211, 169, 151, 107, 37, 105, 141, 51, 150, 203, 240, 141, 183, 188, 81, 89, 178, 54, 167, 244, 118, 151, 36, 90, 145, 169, 65, 82, 24, 20, 118, 34, 230, 146, 88, 90, 213, 98, 65, 174, 66, 33, 216, 71, 218, 167, 246, 4, 96, 165, 135, 58, 36, 75, 64, 197, 143, 210, 95, 158, 95, 89, 132, 10, 160, 135, 160, 206, 170, 23, 113, 81, 144, 239, 153, 151, 217, 42, 86, 231, 24, 191, 242, 53, 155, 199, 128, 46, 47, 86, 108, 42, 153, 203, 12, 86, 171, 122, 192, 232, 38, 25, 168, 164, 36, 13, 218, 70, 18, 238, 106, 241, 35, 53, 248, 13, 139, 145, 164, 42, 247, 53, 124, 244 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_PermisoId",
                table: "UsuarioPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_UsuarioId",
                table: "UsuarioPermisos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPermisos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
