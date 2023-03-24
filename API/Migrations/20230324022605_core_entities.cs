using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class core_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionMacro = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rangos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rangos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionesAsistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionMacro = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionesAsistencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAsistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaAsistencia = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsistencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUnidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUnidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMiembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMiembro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoColores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoColores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoMarcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoMarcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangoId = table.Column<int>(type: "int", nullable: false),
                    Institucion = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Miembro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miembro_Rangos_RangoId",
                        column: x => x.RangoId,
                        principalTable: "Rangos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tramo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionAsistenciaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramo_RegionesAsistencia_RegionAsistenciaId",
                        column: x => x.RegionAsistenciaId,
                        principalTable: "RegionesAsistencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoModelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoMarcaId = table.Column<int>(type: "int", nullable: false),
                    VehiculoTipoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoModelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculoModelos_VehiculoMarcas_VehiculoMarcaId",
                        column: x => x.VehiculoMarcaId,
                        principalTable: "VehiculoMarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehiculoModelos_VehiculoTipos_VehiculoTipoId",
                        column: x => x.VehiculoTipoId,
                        principalTable: "VehiculoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ficha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuntosAsignados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cobertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUnidadId = table.Column<int>(type: "int", nullable: false),
                    TramoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_TipoUnidades_TipoUnidadId",
                        column: x => x.TipoUnidadId,
                        principalTable: "TipoUnidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Unidades_Tramo_TramoId",
                        column: x => x.TramoId,
                        principalTable: "Tramo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionMacro" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1944), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1945), "AZUA", 3 },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1947), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1947), "BAHORUCO", 3 },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1948), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1949), "BARAHONA", 3 },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1949), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1950), "DAJABON", 3 },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1951), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1951), "DISTRITO NACIONAL", 2 },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1952), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1952), "DUARTE", 1 },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1953), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1954), "EL SEYBO", 2 },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1955), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1955), "ELIAS PIÑA", 3 },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1956), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1956), "ESPAILLAT", 1 },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1957), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1957), "HATO MAYOR", 2 },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1958), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1959), "HERMANAS MIRABAL o Salcedo", 1 },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1960), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1960), "INDEPENDENCIA", 3 },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1961), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1961), "LA ALTAGRACIA", 2 },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1962), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1962), "LA ROMANA", 2 },
                    { 15, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1963), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1964), "LA VEGA", 1 },
                    { 16, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1964), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1965), "MARIA TRINIDAD SANCHEZ", 1 },
                    { 17, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1966), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1966), "MONSEÑOR NOUEL", 1 },
                    { 18, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1967), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1967), "MONTE PLATA", 2 },
                    { 19, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1968), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1969), "MONTECRISTI", 1 },
                    { 20, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1969), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1970), "PEDERNALES", 3 },
                    { 21, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1971), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1971), "PERAVIA", 3 },
                    { 22, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1972), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1972), "PUERTO PLATA", 1 },
                    { 23, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1973), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1974), "SAMANA", 1 },
                    { 24, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1974), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1975), "SAN CRISTOBAL", 2 },
                    { 25, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1976), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1977), "SAN JOSE DE OCOA", 3 },
                    { 26, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1978), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1978), "SAN JUAN", 3 },
                    { 27, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1979), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1979), "SAN PEDRO DE MACORIS", 2 },
                    { 28, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1980), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1981), "SANCHEZ RAMIREZ", 1 },
                    { 29, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1982), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1982), "SANTIAGO", 1 },
                    { 30, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1983), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1983), "SANTIAGO RODRIGUEZ", 1 },
                    { 31, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1984), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1985), "SANTO DOMINGO", 2 },
                    { 32, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1985), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1986), "VALVERDE", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rangos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2403), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2404), "GENERAL" },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2410), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2410), "CORONEL" },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2411), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2411), "TENIENTE CORONEL" },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2412), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2412), "MAYOR" },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2413), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2414), "CAPITAN" },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2414), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2415), "1ER TENIENTE" },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2416), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2416), "2DO TENIENTE" },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2417), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2417), "SARGENTO MAYOR" },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2418), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2418), "SARGENTO" },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2419), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2420), "CABO" }
                });

            migrationBuilder.InsertData(
                table: "Rangos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2420), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2421), "RASO" },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2421), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2422), "ASIMILADO" },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2423), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2423), "AGENTE MOPC" }
                });

            migrationBuilder.InsertData(
                table: "RegionesAsistencia",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionMacro" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1767), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1778), "Region Este", 0 },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1781), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1782), "Region Las Americas", 0 },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1783), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1783), "Region del Nordeste", 0 },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1784), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1784), "Region Cibao Sur", 0 },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1785), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1786), "Region Noroeste", 0 },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1786), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1787), "Region Cibao Norte", 0 },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1787), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1788), "Region Sureste", 0 },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1789), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1789), "Region Suroeste", 0 },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1790), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(1790), "Region Circunvalacion de Santo Domingo", 0 }
                });

            migrationBuilder.InsertData(
                table: "TipoAsistencias",
                columns: new[] { "Id", "CategoriaAsistencia", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2445), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2446), "Choque" },
                    { 2, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2447), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2447), "Choque Multiple" },
                    { 3, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2448), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2449), "Choque con animal" },
                    { 4, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2449), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2450), "Deslizamiento" },
                    { 5, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2451), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2451), "Volcadura" },
                    { 6, 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2453), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2453), "Atropellamiento" },
                    { 7, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2454), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2455), "Seguridad" },
                    { 8, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2455), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2456), "Neumático" },
                    { 9, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2457), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2457), "Combustible" },
                    { 10, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2458), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2458), "Mecanica" },
                    { 11, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2459), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2460), "Electrica" },
                    { 12, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2460), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2461), "Calentamiento" },
                    { 13, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2461), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2462), "Grúas" },
                    { 14, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2463), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2463), "Ambulancia" },
                    { 15, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2464), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2464), "Talleres" },
                    { 16, 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2465), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2466), "Camión. Rescate" }
                });

            migrationBuilder.InsertData(
                table: "VehiculoColores",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2602), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2603), "Otro" },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2604), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2604), "Amarillo" },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2605), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2605), "Azul" },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2606), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2607), "Blanco" },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2607), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2608), "Crema" },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2608), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2609), "Gris" },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2610), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2610), "Gris oscuro" },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2611), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2612), "Marron" },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2612), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2613), "Naranja" },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2613), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2614), "Negro" },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2615), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2615), "Rojo" },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2616), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2616), "Rojo Vino" },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2617), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2617), "Verde" },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2618), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2619), "Morado" }
                });

            migrationBuilder.InsertData(
                table: "VehiculoMarcas",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2677), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2677), "Otra" },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2678), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2679), "Acura" },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2679), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2680), "Audi" },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2681), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2681), "BMW" },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2682), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2682), "Chevrolet" },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2683), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2683), "Daihatsu" },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2684), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2684), "Ford" },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2685), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2686), "Hyundai" },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2686), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2687), "Honda" },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2687), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2688), "Infiniti" },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2689), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2689), "Isuzu" },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2690), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2690), "Jeep" },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2691), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2691), "Kia" },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2692), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2693), "Lexus" },
                    { 15, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2693), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2694), "Mazda" },
                    { 16, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2694), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2695), "Mercedes Benz" },
                    { 17, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2696), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2696), "Nissan" },
                    { 18, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2697), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2697), "Otro" },
                    { 19, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2698), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2698), "Scion" },
                    { 20, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2699), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2700), "Skoda" },
                    { 21, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2700), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2701), "Toyota" },
                    { 22, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2701), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2702), "Volkswagen" },
                    { 23, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2703), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2703), "Volvo" },
                    { 24, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2704), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2704), "Subaru" }
                });

            migrationBuilder.InsertData(
                table: "VehiculoTipos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2641), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2641), "Otro" },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2642), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2643), "Autobus" },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2645), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2646), "Camion" },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2646), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2647), "Camioneta" },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2648), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2648), "Carro" },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2649), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2649), "Jeepeta" },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2650), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2650), "Jeep" },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2651), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2652), "Guagua" },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2652), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2653), "Motor o Motocicleta" },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2653), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2654), "Patana" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2017), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2017), "Distrito Nacional", 5 },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2018), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2019), "Azua de Compostela", 1 },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2020), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2020), "Estebanía", 1 },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2021), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2021), "Guayabal", 1 },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2022), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2023), "Las Charcas", 1 },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2023), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2024), "Las Yayas de Viajama", 1 },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2025), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2025), "Padre Las Casas", 1 },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2026), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2026), "Peralta", 1 },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2027), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2028), "Pueblo Viejo", 1 },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2028), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2029), "Sabana Yegua", 1 },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2029), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2030), "Tábara Arriba", 1 },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2031), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2031), "Neiba", 2 },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2032), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2032), "Galván", 2 },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2033), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2034), "Los Ríos", 2 },
                    { 15, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2034), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2035), "Villa Jaragua", 2 },
                    { 16, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2036), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2036), "Tamayo", 2 },
                    { 17, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2037), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2037), "Barahona", 3 },
                    { 18, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2038), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2039), "Cabral", 3 },
                    { 19, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2039), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2040), "El Peñón", 3 },
                    { 20, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2041), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2041), "Enriquillo", 3 },
                    { 21, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2042), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2042), "Fundación", 3 },
                    { 22, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2044), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2044), "Jaquimeyes", 3 },
                    { 23, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2045), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2045), "La Ciénaga", 3 },
                    { 24, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2046), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2047), "Las Salinas", 3 },
                    { 25, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2047), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2048), "Paraíso", 3 },
                    { 26, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2049), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2049), "Polo", 3 },
                    { 27, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2050), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2050), "Vicente Noble", 3 },
                    { 28, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2122), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2122), "Dajabón", 4 },
                    { 29, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2124), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2124), "El Pino", 4 },
                    { 30, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2125), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2126), "Loma de Cabrera", 4 },
                    { 31, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2126), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2127), "Partido", 4 },
                    { 32, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2128), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2128), "Restauración", 4 },
                    { 33, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2129), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2129), "San Francisco de Macorís", 6 },
                    { 34, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2130), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2131), "Arenoso", 6 },
                    { 35, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2131), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2132), "Castillo", 6 },
                    { 36, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2133), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2133), "Eugenio María de Hostos", 6 },
                    { 37, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2134), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2134), "Las Guáranas", 6 },
                    { 38, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2135), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2136), "Pimentel", 6 },
                    { 39, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2136), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2137), "Villa Riva", 6 },
                    { 40, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2138), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2138), "Comendador", 8 },
                    { 41, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2139), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2139), "Bánica", 8 },
                    { 42, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2140), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2141), "El Llano", 8 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 43, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2141), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2142), "Hondo Valle", 8 },
                    { 44, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2142), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2143), "Juan Santiago", 8 },
                    { 45, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2144), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2144), "Pedro Santana", 8 },
                    { 46, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2145), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2145), "Moca", 9 },
                    { 47, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2146), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2147), "Cayetano Germosén", 9 },
                    { 48, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2147), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2148), "Gaspar Hernández", 9 },
                    { 49, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2149), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2149), "Jamao al Norte", 9 },
                    { 50, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2150), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2150), "Hato Mayor del Rey", 10 },
                    { 51, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2151), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2152), "El Valle", 10 },
                    { 52, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2156), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2156), "Sabana de la Mar", 10 },
                    { 53, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2157), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2157), "Salcedo", 11 },
                    { 54, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2158), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2159), "Tenares", 11 },
                    { 55, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2159), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2160), "Villa Tapia", 11 },
                    { 56, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2161), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2161), "Jimaní", 12 },
                    { 57, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2162), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2162), "Cristóbal", 12 },
                    { 58, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2163), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2163), "Duvergé", 12 },
                    { 59, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2164), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2165), "La Descubierta", 12 },
                    { 60, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2166), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2166), "Mella", 12 },
                    { 61, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2167), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2167), "Postrer Río", 12 },
                    { 62, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2168), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2169), "Higüey", 13 },
                    { 63, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2169), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2170), "San Rafael del Yuma", 13 },
                    { 64, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2170), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2171), "La Romana", 14 },
                    { 65, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2172), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2172), "Guaymate", 14 },
                    { 66, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2173), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2173), "Villa Hermosa", 14 },
                    { 67, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2174), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2175), "La Concepción de La Vega", 15 },
                    { 68, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2175), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2176), "Constanza", 15 },
                    { 69, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2177), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2177), "Jarabacoa", 15 },
                    { 70, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2178), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2178), "Jima Abajo", 15 },
                    { 71, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2179), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2180), "Nagua", 16 },
                    { 72, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2180), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2181), "Cabrera", 16 },
                    { 73, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2182), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2182), "El Factor", 16 },
                    { 74, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2183), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2183), "Río San Juan", 16 },
                    { 75, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2184), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2185), "Bonao", 17 },
                    { 76, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2185), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2186), "Maimón", 17 },
                    { 77, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2187), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2187), "Piedra Blanca", 17 },
                    { 78, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2188), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2188), "Montecristi", 19 },
                    { 79, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2189), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2190), "Castañuela", 19 },
                    { 80, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2190), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2191), "Guayubín", 19 },
                    { 81, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2192), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2192), "Las Matas de Santa Cruz", 19 },
                    { 82, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2194), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2194), "Pepillo Salcedo", 19 },
                    { 83, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2195), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2195), "Villa Vásquez", 19 },
                    { 84, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2196), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2197), "Monte Plata", 18 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 85, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2198), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2198), "Bayaguana", 18 },
                    { 86, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2199), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2199), "Peralvillo", 18 },
                    { 87, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2200), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2200), "Sabana Grande de Boyá", 18 },
                    { 88, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2201), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2202), "Yamasá", 18 },
                    { 89, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2202), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2203), "Pedernales", 20 },
                    { 90, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2204), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2204), "Oviedo", 20 },
                    { 91, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2205), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2205), "Baní", 21 },
                    { 92, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2206), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2207), "Nizao", 21 },
                    { 93, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2207), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2208), "Puerto Plata", 22 },
                    { 94, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2209), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2209), "Altamira", 22 },
                    { 95, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2210), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2211), "Guananico", 22 },
                    { 96, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2211), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2212), "Imbert", 22 },
                    { 97, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2213), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2213), "Los Hidalgos", 22 },
                    { 98, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2214), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2214), "Luperón", 22 },
                    { 99, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2215), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2215), "Sosúa", 22 },
                    { 100, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2216), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2217), "Villa Isabela", 22 },
                    { 101, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2217), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2218), "Villa Montellano", 22 },
                    { 102, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2219), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2219), "Samaná", 23 },
                    { 103, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2220), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2220), "Las Terrenas", 23 },
                    { 104, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2221), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2222), "Sánchez", 23 },
                    { 105, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2222), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2223), "San Cristóbal", 24 },
                    { 106, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2224), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2224), "Bajos de Haina", 24 },
                    { 107, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2225), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2225), "Cambita Garabito", 24 },
                    { 108, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2226), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2226), "Los Cacaos", 24 },
                    { 109, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2227), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2228), "Sabana Grande de Palenque", 24 },
                    { 110, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2228), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2229), "San Gregorio de Nigua", 24 },
                    { 111, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2230), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2230), "Villa Altagracia", 24 },
                    { 112, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2232), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2232), "Yaguate", 24 },
                    { 113, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2233), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2234), "San José de Ocoa", 25 },
                    { 114, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2234), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2235), "Rancho Arriba", 25 },
                    { 115, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2236), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2236), "Sabana Larga", 25 },
                    { 116, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2237), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2237), "BOHECHIO", 26 },
                    { 117, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2238), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2239), "EL CERCADO", 26 },
                    { 118, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2239), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2240), "JUAN DE HERRERA", 26 },
                    { 119, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2240), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2241), "LAS MATAS DE FARFAN", 26 },
                    { 120, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2242), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2242), "SAN JUAN DE LA MAGUANA", 26 },
                    { 121, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2243), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2243), "VALLEJUELO", 26 },
                    { 122, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2244), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2245), "San Pedro de Macorís", 27 },
                    { 123, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2245), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2246), "Consuelo", 27 },
                    { 124, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2247), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2247), "Guayacanes", 27 },
                    { 125, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2248), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2249), "Quisqueya", 27 },
                    { 126, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2249), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2250), "Ramón Santana", 27 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 127, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2251), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2251), "San José de Los Llano", 27 },
                    { 128, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2252), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2252), "Cotui", 28 },
                    { 129, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2253), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2253), "Cevicos", 28 },
                    { 130, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2254), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2255), "Fantino", 28 },
                    { 131, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2255), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2256), "La Mata", 28 },
                    { 132, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2257), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2257), "Santiago", 29 },
                    { 133, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2258), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2258), "Bisonó", 29 },
                    { 134, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2259), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2260), "Jánico", 29 },
                    { 135, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2260), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2261), "Licey al Medio", 29 },
                    { 136, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2262), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2262), "Puñal", 29 },
                    { 137, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2263), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2263), "Sabana Iglesia", 29 },
                    { 138, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2264), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2264), "San José de las Matas", 29 },
                    { 139, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2265), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2266), "Tamboril", 29 },
                    { 140, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2266), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2267), "Villa González", 29 },
                    { 141, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2268), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2268), "San Ignacio de Sabaneta", 30 },
                    { 142, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2270), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2270), "Los Almácigos", 30 },
                    { 143, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2271), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2271), "Monción", 30 },
                    { 144, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2272), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2272), "Santo Domingo Este", 31 },
                    { 145, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2273), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2274), "Boca Chica", 31 },
                    { 146, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2274), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2275), "Los Alcarrizos", 31 },
                    { 147, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2276), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2276), "Pedro Brand", 31 },
                    { 148, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2277), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2277), "San Antonio de Guerra", 31 },
                    { 149, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2278), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2279), "Santo Domingo Norte", 31 },
                    { 150, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2279), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2280), "Santo Domingo Oeste", 31 },
                    { 151, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2281), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2281), "Mao", 32 },
                    { 152, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2282), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2282), "Esperanza", 32 },
                    { 153, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2283), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2284), "Laguna Salada", 32 }
                });

            migrationBuilder.InsertData(
                table: "Tramo",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionAsistenciaId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2486), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2487), "Tramo Carretero Miches", 1 },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2488), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2488), "Tramo Carretero Punta Cana", 1 },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2489), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2489), "Tramo El Coral y Circ. Romana", 1 },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2490), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2491), "9-1-1 Romana", 1 },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2491), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2492), "Tramo del Seibo", 1 },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2493), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2493), "Las Américas tramo I", 2 },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2494), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2494), "Las Américas tramo II", 2 },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2495), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2496), "Tramo  Hato Mayor", 2 },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2496), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2497), "Tramo Samaná", 3 },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2498), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2498), "Cibao Sur tramo I", 4 },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2499), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2499), "Tramo San Francisco de Macorís", 4 },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2501), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2501), "Cibao Sur Tramo II", 4 },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2544), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2545), "Tramo Cotuí", 4 },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2546), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2546), "Tramo Salcedo", 4 },
                    { 15, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2547), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2548), "Tramo Circunvalación Norte", 5 }
                });

            migrationBuilder.InsertData(
                table: "Tramo",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionAsistenciaId" },
                values: new object[,]
                {
                    { 16, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2549), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2549), "Noroeste tramo I", 5 },
                    { 17, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2550), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2550), "Noroeste tramo II", 5 },
                    { 18, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2551), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2552), "Tramo Mao, Valverde", 5 },
                    { 19, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2553), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2554), "Tramo Cibao Norte", 6 },
                    { 20, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2555), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2555), "Atlántico tramo I", 6 },
                    { 21, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2556), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2556), "Tramo Luperón", 6 },
                    { 22, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2557), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2558), "Atlántico tramo II", 6 },
                    { 23, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2558), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2559), "Tramo Rio San Juan", 6 },
                    { 24, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2560), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2560), "Sureste tramo I", 7 },
                    { 25, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2561), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2561), "Sureste tramo II", 7 },
                    { 26, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2562), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2562), "Tramo  San Juan de la Maguana", 7 },
                    { 27, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2563), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2564), "Tramo San José de Ocoa", 7 },
                    { 28, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2564), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2565), "Suroeste tramo I", 8 },
                    { 29, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2566), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2566), "Suroeste tramo II", 8 },
                    { 30, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2567), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2567), "Circunvalación Santo Domingo tramo I", 9 },
                    { 31, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2568), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2569), "Circunvalación Santo Domingo tramo II", 9 },
                    { 32, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2569), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2570), "Corredores del Distrito Nacional", 9 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2723), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2723), "Camry", 21, 5 },
                    { 2, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2725), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2725), "Corrolla", 21, 5 },
                    { 3, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2726), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2726), "Highlander", 21, 6 },
                    { 4, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2727), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2728), "LandCruiser", 21, 6 },
                    { 5, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2729), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2729), "Hilux", 21, 4 },
                    { 6, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2730), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2730), "Tacoma", 21, 4 },
                    { 7, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2731), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2732), "Tundra", 21, 4 },
                    { 8, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2732), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2733), "Sequoia", 21, 6 },
                    { 9, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2734), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2734), "Civic", 9, 5 },
                    { 10, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2735), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2735), "CR-V", 9, 6 },
                    { 11, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2736), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2737), "Fit", 9, 5 },
                    { 12, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2737), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2738), "HR-V", 9, 6 },
                    { 13, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2739), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2739), "Pilot", 9, 6 },
                    { 14, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2971), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2972), "Accord", 9, 5 },
                    { 15, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2974), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2974), "Frontier", 17, 4 },
                    { 16, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2975), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2976), "Sentra", 17, 5 },
                    { 17, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2977), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2977), "Tiida", 17, 5 },
                    { 18, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2978), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2978), "Pathfinder", 17, 6 },
                    { 19, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2979), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2980), "Kicks", 17, 6 },
                    { 20, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2980), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2981), "Titan", 17, 4 },
                    { 21, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2982), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2982), "Mazda 3", 15, 5 },
                    { 22, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2983), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2984), "Mazda 6", 15, 5 },
                    { 23, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2984), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2985), "CX-5", 15, 6 },
                    { 24, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2986), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2986), "CX-9", 15, 6 },
                    { 25, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2987), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2987), "Mazda 2 (Demio)", 15, 5 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 26, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2988), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2989), "Accent", 8, 5 },
                    { 27, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2990), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2990), "Sonata", 8, 5 },
                    { 28, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2992), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2993), "Tucson", 8, 6 },
                    { 29, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2993), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2994), "Santa Fe", 8, 6 },
                    { 30, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2995), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2995), "Elantra", 8, 5 },
                    { 31, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2996), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2996), "Y20", 8, 5 },
                    { 32, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2997), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2998), "i10", 8, 5 },
                    { 33, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2999), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(2999), "i20", 8, 5 },
                    { 34, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3000), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3000), "K5", 13, 5 },
                    { 35, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3001), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3002), "Forte", 13, 5 },
                    { 36, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3002), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3003), "Sorento", 13, 6 },
                    { 37, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3004), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3004), "Sportage", 13, 6 },
                    { 38, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3005), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3005), "Rio", 13, 5 },
                    { 39, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3006), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3007), "Mira", 6, 5 },
                    { 40, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3007), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3008), "Sirion", 6, 5 },
                    { 41, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3009), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3009), "Camion", 6, 3 },
                    { 42, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3010), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3011), "Terios", 6, 6 },
                    { 43, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3011), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3012), "Escape", 7, 6 },
                    { 44, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3013), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3013), "F-150", 7, 4 },
                    { 45, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3014), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3014), "Focus", 7, 5 },
                    { 46, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3015), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3016), "Explorer", 7, 6 },
                    { 47, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3016), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3017), "Ranger", 7, 4 },
                    { 48, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3018), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3018), "Ecosport", 7, 6 },
                    { 49, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3019), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3020), "Wrangler", 12, 7 },
                    { 50, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3020), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3021), "Cherokee", 12, 6 },
                    { 51, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3022), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3022), "Grand Cherokee", 12, 6 },
                    { 52, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3023), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3023), "Cruize", 5, 5 },
                    { 53, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3025), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3025), "Aveo", 5, 5 },
                    { 54, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3027), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3027), "Colorado", 5, 4 },
                    { 55, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3028), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3029), "Silverado", 5, 4 },
                    { 56, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3029), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3030), "Trax", 5, 6 },
                    { 57, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3031), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3031), "Traverse", 5, 6 },
                    { 58, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3032), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3032), "Otro", 1, 1 },
                    { 59, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3033), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3034), "Touareg", 22, 6 },
                    { 60, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3034), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3035), "Tiguan", 22, 6 },
                    { 61, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3036), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3036), "Jetta", 22, 5 },
                    { 62, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3037), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3038), "Passat", 22, 5 },
                    { 63, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3038), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3039), "Golf", 22, 5 },
                    { 64, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3040), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3040), "Fox", 22, 5 },
                    { 65, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3041), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3041), "D-MAX", 11, 4 },
                    { 66, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3042), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3043), "Rodeo", 11, 6 },
                    { 67, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3043), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3044), "MUX", 11, 6 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 68, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3045), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3045), "XC-60", 23, 6 },
                    { 69, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3046), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3046), "XC-90", 23, 6 },
                    { 70, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3047), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3048), "XC-40", 23, 6 },
                    { 71, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3048), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3049), "Legacy", 24, 5 },
                    { 72, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3050), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3050), "Impreza", 24, 5 },
                    { 73, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3051), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3052), "Outback", 24, 6 },
                    { 74, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3052), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3053), "Forester", 24, 6 },
                    { 75, true, new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3054), new DateTime(2023, 3, 23, 22, 26, 4, 963, DateTimeKind.Local).AddTicks(3054), "XV (Crosstrek)", 24, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_RangoId",
                table: "Miembro",
                column: "RangoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramo_RegionAsistenciaId",
                table: "Tramo",
                column: "RegionAsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TipoUnidadId",
                table: "Unidades",
                column: "TipoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TramoId",
                table: "Unidades",
                column: "TramoId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoModelos_VehiculoMarcaId",
                table: "VehiculoModelos",
                column: "VehiculoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoModelos_VehiculoTipoId",
                table: "VehiculoModelos",
                column: "VehiculoTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Miembro");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "TipoAsistencias");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "UnidadMiembro");

            migrationBuilder.DropTable(
                name: "VehiculoColores");

            migrationBuilder.DropTable(
                name: "VehiculoModelos");

            migrationBuilder.DropTable(
                name: "Rangos");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "TipoUnidades");

            migrationBuilder.DropTable(
                name: "Tramo");

            migrationBuilder.DropTable(
                name: "VehiculoMarcas");

            migrationBuilder.DropTable(
                name: "VehiculoTipos");

            migrationBuilder.DropTable(
                name: "RegionesAsistencia");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cedula", "EsAdministrador", "Estatus", "FechaCreacion", "FechaModificacion", "FechaNacimiento", "Genero", "Nombre", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, null, true, true, new DateTime(2023, 3, 21, 21, 5, 57, 750, DateTimeKind.Local).AddTicks(2626), new DateTime(2023, 3, 21, 21, 5, 57, 750, DateTimeKind.Local).AddTicks(2633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new byte[] { 125, 255, 106, 41, 188, 224, 119, 81, 48, 128, 152, 8, 49, 244, 182, 68, 165, 63, 171, 78, 249, 129, 71, 70, 101, 233, 218, 50, 236, 93, 74, 233, 172, 164, 75, 84, 185, 93, 2, 203, 144, 154, 71, 141, 146, 232, 28, 86, 156, 123, 214, 64, 43, 22, 101, 86, 220, 13, 98, 186, 248, 35, 223, 176 }, new byte[] { 27, 140, 210, 235, 211, 169, 151, 107, 37, 105, 141, 51, 150, 203, 240, 141, 183, 188, 81, 89, 178, 54, 167, 244, 118, 151, 36, 90, 145, 169, 65, 82, 24, 20, 118, 34, 230, 146, 88, 90, 213, 98, 65, 174, 66, 33, 216, 71, 218, 167, 246, 4, 96, 165, 135, 58, 36, 75, 64, 197, 143, 210, 95, 158, 95, 89, 132, 10, 160, 135, 160, 206, 170, 23, 113, 81, 144, 239, 153, 151, 217, 42, 86, 231, 24, 191, 242, 53, 155, 199, 128, 46, 47, 86, 108, 42, 153, 203, 12, 86, 171, 122, 192, 232, 38, 25, 168, 164, 36, 13, 218, 70, 18, 238, 106, 241, 35, 53, 248, 13, 139, 145, 164, 42, 247, 53, 124, 244 }, "admin" });
        }
    }
}
