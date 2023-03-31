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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUnidades", x => x.Id);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                name: "VehiculoColores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
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
                name: "SupervisoresEncargados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IOT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaSupervisor = table.Column<int>(type: "int", nullable: false),
                    MiembroId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoresEncargados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisoresEncargados_Miembro_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembro",
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
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "SupervisoresEncargadosTramos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorEncargadoId = table.Column<int>(type: "int", nullable: false),
                    TramoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoresEncargadosTramos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisoresEncargadosTramos_SupervisoresEncargados_SupervisorEncargadoId",
                        column: x => x.SupervisorEncargadoId,
                        principalTable: "SupervisoresEncargados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupervisoresEncargadosTramos_Tramo_TramoId",
                        column: x => x.TramoId,
                        principalTable: "Tramo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMiembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    MiembroId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMiembro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadMiembro_Miembro_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UnidadMiembro_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    EsExtranjero = table.Column<bool>(type: "bit", nullable: false),
                    VehiculoTipoId = table.Column<int>(type: "int", nullable: false),
                    VehiculoColorId = table.Column<int>(type: "int", nullable: false),
                    VehiculoModeloId = table.Column<int>(type: "int", nullable: false),
                    VehiculoMarcaId = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    UnidadMiembroId = table.Column<int>(type: "int", nullable: false),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAsistencias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportadoPor = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiempoCompletada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstatusAsistencia = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistencias_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_UnidadMiembro_UnidadMiembroId",
                        column: x => x.UnidadMiembroId,
                        principalTable: "UnidadMiembro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoColores_VehiculoColorId",
                        column: x => x.VehiculoColorId,
                        principalTable: "VehiculoColores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoMarcas_VehiculoMarcaId",
                        column: x => x.VehiculoMarcaId,
                        principalTable: "VehiculoMarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoModelos_VehiculoModeloId",
                        column: x => x.VehiculoModeloId,
                        principalTable: "VehiculoModelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_VehiculoTipos_VehiculoTipoId",
                        column: x => x.VehiculoTipoId,
                        principalTable: "VehiculoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionMacro", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4168), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4168), "AZUA", 3, 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4169), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4170), "BAHORUCO", 3, 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4170), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4171), "BARAHONA", 3, 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4171), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4172), "DAJABON", 3, 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4172), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4173), "DISTRITO NACIONAL", 2, 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4213), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4213), "DUARTE", 1, 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4215), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4216), "EL SEYBO", 2, 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4216), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4217), "ELIAS PIÑA", 3, 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4217), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4218), "ESPAILLAT", 1, 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4218), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4219), "HATO MAYOR", 2, 1 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4219), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4220), "HERMANAS MIRABAL o Salcedo", 1, 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4220), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4221), "INDEPENDENCIA", 3, 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4221), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4222), "LA ALTAGRACIA", 2, 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4222), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4223), "LA ROMANA", 2, 1 },
                    { 15, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4223), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4224), "LA VEGA", 1, 1 },
                    { 16, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4224), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4225), "MARIA TRINIDAD SANCHEZ", 1, 1 },
                    { 17, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4225), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4226), "MONSEÑOR NOUEL", 1, 1 },
                    { 18, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4226), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4227), "MONTE PLATA", 2, 1 },
                    { 19, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4227), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4228), "MONTECRISTI", 1, 1 },
                    { 20, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4228), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4229), "PEDERNALES", 3, 1 },
                    { 21, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4229), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4230), "PERAVIA", 3, 1 },
                    { 22, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4230), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4231), "PUERTO PLATA", 1, 1 },
                    { 23, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4231), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4232), "SAMANA", 1, 1 },
                    { 24, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4233), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4233), "SAN CRISTOBAL", 2, 1 },
                    { 25, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4234), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4234), "SAN JOSE DE OCOA", 3, 1 },
                    { 26, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4235), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4235), "SAN JUAN", 3, 1 },
                    { 27, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4236), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4237), "SAN PEDRO DE MACORIS", 2, 1 },
                    { 28, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4237), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4238), "SANCHEZ RAMIREZ", 1, 1 },
                    { 29, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4238), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4239), "SANTIAGO", 1, 1 },
                    { 30, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4239), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4240), "SANTIAGO RODRIGUEZ", 1, 1 },
                    { 31, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4240), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4241), "SANTO DOMINGO", 2, 1 },
                    { 32, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4241), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4241), "VALVERDE", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rangos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4728), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4729), "MAYOR GENERAL/VICEALMIRANTE", 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4730), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4730), "GENERAL/CONTRALMIRANTE", 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4731), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4732), "CORONEL/CAPITAN DE NAVIO", 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4732), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4733), "TENIENTE CORONEL/CAPITAN DE FRAGATA", 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4733), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4734), "MAYOR/CAPITAN CORBETA", 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4734), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4735), "CAPITAN/TENIENTE NAVIO", 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4735), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4736), "1ER TENIENTE/TENIENTE FRAGATA", 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4736), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4737), "2DO TENIENTE/TENIENTE CORBETA", 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4737), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4738), "SARGENTO MAYOR", 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4738), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4739), "SARGENTO", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rangos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4739), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4740), "CABO", 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4740), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4741), "RASO/MARINERO", 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4741), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4742), "ASIMILADO", 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4742), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4743), "AGENTE MOPC", 1 }
                });

            migrationBuilder.InsertData(
                table: "RegionesAsistencia",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionMacro", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4142), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4143), "Region Este", 0, 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4144), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4144), "Region Las Americas", 0, 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4145), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4145), "Region del Nordeste", 0, 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4146), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4146), "Region Cibao Sur", 0, 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4146), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4147), "Region Noroeste", 0, 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4147), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4148), "Region Cibao Norte", 0, 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4148), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4149), "Region Sureste", 0, 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4149), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4150), "Region Suroeste", 0, 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4150), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4151), "Region Circunvalacion de Santo Domingo", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "TipoAsistencias",
                columns: new[] { "Id", "CategoriaAsistencia", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4758), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4759), "Choque", 1 },
                    { 2, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4760), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4760), "Choque Multiple", 1 },
                    { 3, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4761), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4761), "Choque con animal", 1 },
                    { 4, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4762), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4762), "Deslizamiento", 1 },
                    { 5, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4763), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4763), "Volcadura", 1 },
                    { 6, 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4764), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4764), "Atropellamiento", 1 },
                    { 7, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4765), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4765), "Seguridad", 1 },
                    { 8, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4766), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4766), "Neumático", 1 },
                    { 9, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4767), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4767), "Combustible", 1 },
                    { 10, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4768), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4769), "Mecanica", 1 },
                    { 11, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4769), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4770), "Electrica", 1 },
                    { 12, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4770), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4771), "Calentamiento", 1 },
                    { 13, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4771), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4772), "Grúas", 1 },
                    { 14, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4772), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4773), "Ambulancia", 1 },
                    { 15, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4773), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4774), "Talleres", 1 },
                    { 16, 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4774), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4775), "Camión. Rescate", 1 }
                });

            migrationBuilder.InsertData(
                table: "TipoUnidades",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4113), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4113), "Supervisor", 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4115), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4115), "Encargado", 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4117), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4118), "Movil", 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4116), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4117), "Unidad", 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4118), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4118), "Ambulanccia", 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4119), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4119), "Grua", 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4120), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4120), "Rescate", 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4121), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4121), "CODEVIAL", 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4122), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4122), "Motorizada", 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cedula", "EsAdministrador", "Estatus", "FechaCreacion", "FechaModificacion", "FechaNacimiento", "Genero", "Nombre", "PasswordHash", "PasswordSalt", "Username", "UsuarioId" },
                values: new object[] { 1, null, null, true, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(3988), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, new byte[] { 53, 144, 201, 170, 39, 39, 201, 174, 170, 162, 222, 61, 47, 7, 84, 51, 62, 82, 229, 22, 212, 99, 15, 146, 101, 209, 146, 104, 25, 100, 157, 48, 199, 249, 192, 21, 235, 19, 247, 183, 18, 57, 145, 217, 82, 183, 12, 64, 138, 118, 141, 215, 133, 154, 91, 11, 48, 126, 92, 241, 131, 101, 91, 206 }, new byte[] { 148, 210, 167, 166, 241, 176, 40, 85, 222, 202, 146, 247, 113, 59, 102, 15, 224, 128, 130, 42, 195, 74, 132, 68, 6, 233, 2, 109, 21, 49, 226, 25, 175, 214, 185, 153, 149, 81, 59, 97, 9, 216, 245, 69, 29, 210, 224, 105, 85, 101, 1, 173, 114, 191, 243, 77, 195, 78, 55, 103, 195, 247, 191, 86, 59, 113, 20, 140, 53, 172, 225, 97, 197, 9, 12, 231, 98, 250, 10, 46, 26, 78, 112, 209, 91, 176, 159, 59, 124, 76, 62, 171, 162, 172, 5, 32, 118, 162, 192, 39, 125, 176, 9, 210, 82, 158, 137, 240, 146, 189, 148, 185, 74, 206, 71, 43, 61, 200, 190, 162, 208, 22, 175, 177, 123, 31, 182, 111 }, "admin", null });

            migrationBuilder.InsertData(
                table: "VehiculoColores",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5014), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5015), "Otro", 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5015), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5016), "Amarillo", 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5016), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5017), "Azul", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoColores",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5017), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5018), "Blanco", 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5018), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5019), "Crema", 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5019), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5020), "Gris", 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5020), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5021), "Gris oscuro", 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5021), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5022), "Marron", 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5022), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5023), "Naranja", 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5023), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5024), "Negro", 1 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5024), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5025), "Rojo", 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5025), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5026), "Rojo Vino", 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5026), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5026), "Verde", 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5027), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5027), "Morado", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoMarcas",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5068), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5069), "Otra", 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5070), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5070), "Acura", 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5071), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5071), "Audi", 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5072), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5072), "BMW", 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5073), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5074), "Chevrolet", 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5074), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5074), "Daihatsu", 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5075), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5075), "Ford", 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5076), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5076), "Hyundai", 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5077), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5077), "Honda", 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5078), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5078), "Infiniti", 1 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5079), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5079), "Isuzu", 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5080), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5080), "Jeep", 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5081), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5081), "Kia", 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5082), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5082), "Lexus", 1 },
                    { 15, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5083), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5083), "Mazda", 1 },
                    { 16, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5084), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5084), "Mercedes Benz", 1 },
                    { 17, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5085), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5085), "Nissan", 1 },
                    { 18, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5086), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5086), "Otro", 1 },
                    { 19, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5087), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5087), "Scion", 1 },
                    { 20, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5088), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5088), "Skoda", 1 },
                    { 21, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5089), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5089), "Toyota", 1 },
                    { 22, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5089), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5090), "Volkswagen", 1 },
                    { 23, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5091), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5091), "Volvo", 1 },
                    { 24, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5092), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5092), "Subaru", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoTipos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5047), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5048), "Otro", 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5048), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5049), "Autobus", 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5049), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5050), "Camion", 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5050), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5051), "Camioneta", 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5051), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5052), "Carro", 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5052), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5053), "Jeepeta", 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5053), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5054), "Jeep", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoTipos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[] { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5054), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5054), "Guagua", 1 });

            migrationBuilder.InsertData(
                table: "VehiculoTipos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[] { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5055), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5055), "Motor o Motocicleta", 1 });

            migrationBuilder.InsertData(
                table: "VehiculoTipos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId" },
                values: new object[] { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5056), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5056), "Patana", 1 });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4264), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4264), "Distrito Nacional", 5, 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4265), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4266), "Azua de Compostela", 1, 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4266), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4267), "Estebanía", 1, 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4267), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4268), "Guayabal", 1, 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4268), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4269), "Las Charcas", 1, 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4269), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4270), "Las Yayas de Viajama", 1, 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4271), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4271), "Padre Las Casas", 1, 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4272), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4272), "Peralta", 1, 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4273), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4273), "Pueblo Viejo", 1, 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4274), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4274), "Sabana Yegua", 1, 1 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4275), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4275), "Tábara Arriba", 1, 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4276), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4276), "Neiba", 2, 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4277), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4277), "Galván", 2, 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4278), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4278), "Los Ríos", 2, 1 },
                    { 15, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4279), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4279), "Villa Jaragua", 2, 1 },
                    { 16, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4280), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4280), "Tamayo", 2, 1 },
                    { 17, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4281), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4281), "Barahona", 3, 1 },
                    { 18, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4282), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4282), "Cabral", 3, 1 },
                    { 19, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4283), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4283), "El Peñón", 3, 1 },
                    { 20, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4284), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4284), "Enriquillo", 3, 1 },
                    { 21, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4285), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4285), "Fundación", 3, 1 },
                    { 22, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4286), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4286), "Jaquimeyes", 3, 1 },
                    { 23, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4287), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4287), "La Ciénaga", 3, 1 },
                    { 24, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4288), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4289), "Las Salinas", 3, 1 },
                    { 25, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4289), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4290), "Paraíso", 3, 1 },
                    { 26, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4290), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4291), "Polo", 3, 1 },
                    { 27, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4291), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4292), "Vicente Noble", 3, 1 },
                    { 28, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4292), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4293), "Dajabón", 4, 1 },
                    { 29, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4293), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4294), "El Pino", 4, 1 },
                    { 30, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4294), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4295), "Loma de Cabrera", 4, 1 },
                    { 31, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4295), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4296), "Partido", 4, 1 },
                    { 32, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4296), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4297), "Restauración", 4, 1 },
                    { 33, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4297), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4298), "San Francisco de Macorís", 6, 1 },
                    { 34, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4299), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4300), "Arenoso", 6, 1 },
                    { 35, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4300), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4301), "Castillo", 6, 1 },
                    { 36, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4302), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4302), "Eugenio María de Hostos", 6, 1 },
                    { 37, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4303), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4303), "Las Guáranas", 6, 1 },
                    { 38, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4304), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4304), "Pimentel", 6, 1 },
                    { 39, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4305), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4305), "Villa Riva", 6, 1 },
                    { 40, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4306), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4306), "Comendador", 8, 1 },
                    { 41, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4307), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4307), "Bánica", 8, 1 },
                    { 42, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4308), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4308), "El Llano", 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 43, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4309), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4496), "Hondo Valle", 8, 1 },
                    { 44, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4497), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4498), "Juan Santiago", 8, 1 },
                    { 45, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4498), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4500), "Pedro Santana", 8, 1 },
                    { 46, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4501), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4502), "Moca", 9, 1 },
                    { 47, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4502), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4503), "Cayetano Germosén", 9, 1 },
                    { 48, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4505), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4505), "Gaspar Hernández", 9, 1 },
                    { 49, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4506), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4506), "Jamao al Norte", 9, 1 },
                    { 50, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4507), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4507), "Hato Mayor del Rey", 10, 1 },
                    { 51, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4508), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4508), "El Valle", 10, 1 },
                    { 52, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4510), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4510), "Sabana de la Mar", 10, 1 },
                    { 53, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4511), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4511), "Salcedo", 11, 1 },
                    { 54, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4512), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4512), "Tenares", 11, 1 },
                    { 55, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4513), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4513), "Villa Tapia", 11, 1 },
                    { 56, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4514), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4514), "Jimaní", 12, 1 },
                    { 57, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4515), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4516), "Cristóbal", 12, 1 },
                    { 58, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4516), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4517), "Duvergé", 12, 1 },
                    { 59, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4517), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4518), "La Descubierta", 12, 1 },
                    { 60, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4518), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4519), "Mella", 12, 1 },
                    { 61, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4519), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4520), "Postrer Río", 12, 1 },
                    { 62, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4548), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4555), "Higüey", 13, 1 },
                    { 63, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4556), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4556), "San Rafael del Yuma", 13, 1 },
                    { 64, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4558), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4558), "La Romana", 14, 1 },
                    { 65, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4559), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4559), "Guaymate", 14, 1 },
                    { 66, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4560), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4560), "Villa Hermosa", 14, 1 },
                    { 67, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4561), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4562), "La Concepción de La Vega", 15, 1 },
                    { 68, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4562), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4563), "Constanza", 15, 1 },
                    { 69, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4563), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4564), "Jarabacoa", 15, 1 },
                    { 70, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4564), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4565), "Jima Abajo", 15, 1 },
                    { 71, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4565), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4566), "Nagua", 16, 1 },
                    { 72, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4566), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4567), "Cabrera", 16, 1 },
                    { 73, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4567), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4568), "El Factor", 16, 1 },
                    { 74, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4568), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4569), "Río San Juan", 16, 1 },
                    { 75, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4569), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4570), "Bonao", 17, 1 },
                    { 76, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4570), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4571), "Maimón", 17, 1 },
                    { 77, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4572), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4572), "Piedra Blanca", 17, 1 },
                    { 78, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4573), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4573), "Montecristi", 19, 1 },
                    { 79, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4574), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4574), "Castañuela", 19, 1 },
                    { 80, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4575), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4575), "Guayubín", 19, 1 },
                    { 81, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4576), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4576), "Las Matas de Santa Cruz", 19, 1 },
                    { 82, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4577), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4577), "Pepillo Salcedo", 19, 1 },
                    { 83, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4578), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4578), "Villa Vásquez", 19, 1 },
                    { 84, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4579), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4579), "Monte Plata", 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 85, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4580), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4580), "Bayaguana", 18, 1 },
                    { 86, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4581), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4581), "Peralvillo", 18, 1 },
                    { 87, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4582), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4582), "Sabana Grande de Boyá", 18, 1 },
                    { 88, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4583), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4583), "Yamasá", 18, 1 },
                    { 89, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4584), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4585), "Pedernales", 20, 1 },
                    { 90, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4585), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4586), "Oviedo", 20, 1 },
                    { 91, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4586), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4587), "Baní", 21, 1 },
                    { 92, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4587), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4588), "Nizao", 21, 1 },
                    { 93, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4588), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4589), "Puerto Plata", 22, 1 },
                    { 94, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4593), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4593), "Altamira", 22, 1 },
                    { 95, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4594), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4594), "Guananico", 22, 1 },
                    { 96, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4595), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4595), "Imbert", 22, 1 },
                    { 97, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4596), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4596), "Los Hidalgos", 22, 1 },
                    { 98, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4597), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4597), "Luperón", 22, 1 },
                    { 99, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4598), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4598), "Sosúa", 22, 1 },
                    { 100, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4599), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4599), "Villa Isabela", 22, 1 },
                    { 101, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4600), "Villa Montellano", 22, 1 },
                    { 102, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4601), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4601), "Samaná", 23, 1 },
                    { 103, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4602), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4602), "Las Terrenas", 23, 1 },
                    { 104, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4603), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4604), "Sánchez", 23, 1 },
                    { 105, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4604), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4605), "San Cristóbal", 24, 1 },
                    { 106, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4605), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4606), "Bajos de Haina", 24, 1 },
                    { 107, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4606), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4607), "Cambita Garabito", 24, 1 },
                    { 108, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4607), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4608), "Los Cacaos", 24, 1 },
                    { 109, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4609), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4609), "Sabana Grande de Palenque", 24, 1 },
                    { 110, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4610), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4610), "San Gregorio de Nigua", 24, 1 },
                    { 111, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4611), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4611), "Villa Altagracia", 24, 1 },
                    { 112, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4612), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4612), "Yaguate", 24, 1 },
                    { 113, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4613), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4613), "San José de Ocoa", 25, 1 },
                    { 114, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4614), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4614), "Rancho Arriba", 25, 1 },
                    { 115, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4615), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4615), "Sabana Larga", 25, 1 },
                    { 116, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4616), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4616), "BOHECHIO", 26, 1 },
                    { 117, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4617), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4617), "EL CERCADO", 26, 1 },
                    { 118, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4618), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4618), "JUAN DE HERRERA", 26, 1 },
                    { 119, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4619), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4620), "LAS MATAS DE FARFAN", 26, 1 },
                    { 120, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4620), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4621), "SAN JUAN DE LA MAGUANA", 26, 1 },
                    { 121, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4622), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4622), "VALLEJUELO", 26, 1 },
                    { 122, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4623), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4623), "San Pedro de Macorís", 27, 1 },
                    { 123, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4624), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4624), "Consuelo", 27, 1 },
                    { 124, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4626), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4626), "Guayacanes", 27, 1 },
                    { 125, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4627), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4627), "Quisqueya", 27, 1 },
                    { 126, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4628), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4628), "Ramón Santana", 27, 1 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 127, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4629), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4629), "San José de Los Llano", 27, 1 },
                    { 128, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4630), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4630), "Cotui", 28, 1 },
                    { 129, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4631), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4631), "Cevicos", 28, 1 },
                    { 130, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4632), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4632), "Fantino", 28, 1 },
                    { 131, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4633), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4633), "La Mata", 28, 1 },
                    { 132, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4634), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4634), "Santiago", 29, 1 },
                    { 133, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4635), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4635), "Bisonó", 29, 1 },
                    { 134, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4636), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4636), "Jánico", 29, 1 },
                    { 135, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4637), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4637), "Licey al Medio", 29, 1 },
                    { 136, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4638), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4638), "Puñal", 29, 1 },
                    { 137, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4639), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4639), "Sabana Iglesia", 29, 1 },
                    { 138, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4640), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4640), "San José de las Matas", 29, 1 },
                    { 139, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4641), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4642), "Tamboril", 29, 1 },
                    { 140, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4642), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4643), "Villa González", 29, 1 },
                    { 141, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4643), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4644), "San Ignacio de Sabaneta", 30, 1 },
                    { 142, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4644), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4645), "Los Almácigos", 30, 1 },
                    { 143, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4645), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4646), "Monción", 30, 1 },
                    { 144, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4646), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4647), "Santo Domingo Este", 31, 1 },
                    { 145, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4647), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4648), "Boca Chica", 31, 1 },
                    { 146, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4648), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4649), "Los Alcarrizos", 31, 1 },
                    { 147, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4650), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4650), "Pedro Brand", 31, 1 },
                    { 148, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4651), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4651), "San Antonio de Guerra", 31, 1 },
                    { 149, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4652), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4652), "Santo Domingo Norte", 31, 1 },
                    { 150, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4657), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4657), "Santo Domingo Oeste", 31, 1 },
                    { 151, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4658), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4659), "Mao", 32, 1 },
                    { 152, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4660), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4660), "Esperanza", 32, 1 },
                    { 153, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4661), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4662), "Laguna Salada", 32, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tramo",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionAsistenciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4792), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4793), "Tramo Carretero Miches", 1, 1 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4794), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4794), "Tramo Carretero Punta Cana", 1, 1 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4795), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4796), "Tramo El Coral y Circ. Romana", 1, 1 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4796), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4797), "9-1-1 Romana", 1, 1 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4797), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4798), "Tramo del Seibo", 1, 1 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4798), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4799), "Las Américas tramo I", 2, 1 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4799), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4800), "Las Américas tramo II", 2, 1 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4800), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4801), "Tramo  Hato Mayor", 2, 1 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4801), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4802), "Tramo Samaná", 3, 1 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4802), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4803), "Cibao Sur tramo I", 4, 1 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4804), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4804), "Tramo San Francisco de Macorís", 4, 1 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4805), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4805), "Cibao Sur Tramo II", 4, 1 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4806), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4806), "Tramo Cotuí", 4, 1 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4807), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4807), "Tramo Salcedo", 4, 1 },
                    { 15, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4808), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4808), "Tramo Circunvalación Norte", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tramo",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "RegionAsistenciaId", "UsuarioId" },
                values: new object[,]
                {
                    { 16, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4809), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4809), "Noroeste tramo I", 5, 1 },
                    { 17, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4810), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4810), "Noroeste tramo II", 5, 1 },
                    { 18, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4811), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4811), "Tramo Mao, Valverde", 5, 1 },
                    { 19, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4812), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4812), "Tramo Cibao Norte", 6, 1 },
                    { 20, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4813), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4813), "Atlántico tramo I", 6, 1 },
                    { 21, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4814), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4814), "Tramo Luperón", 6, 1 },
                    { 22, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4815), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4815), "Atlántico tramo II", 6, 1 },
                    { 23, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4816), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4816), "Tramo Rio San Juan", 6, 1 },
                    { 24, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4817), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4817), "Sureste tramo I", 7, 1 },
                    { 25, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4818), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4818), "Sureste tramo II", 7, 1 },
                    { 26, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4819), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4819), "Tramo  San Juan de la Maguana", 7, 1 },
                    { 27, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4847), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4847), "Tramo San José de Ocoa", 7, 1 },
                    { 28, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4848), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4849), "Suroeste tramo I", 8, 1 },
                    { 29, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4850), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4850), "Suroeste tramo II", 8, 1 },
                    { 30, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4851), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4852), "Circunvalación Santo Domingo tramo I", 9, 1 },
                    { 31, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4852), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4853), "Circunvalación Santo Domingo tramo II", 9, 1 },
                    { 32, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4853), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(4854), "Corredores del Distrito Nacional", 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5110), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5111), "Camry", 1, 21, 5 },
                    { 2, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5112), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5112), "Corrolla", 1, 21, 5 },
                    { 3, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5113), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5113), "Highlander", 1, 21, 6 },
                    { 4, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5114), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5114), "LandCruiser", 1, 21, 6 },
                    { 5, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5115), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5115), "Hilux", 1, 21, 4 },
                    { 6, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5116), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5116), "Tacoma", 1, 21, 4 },
                    { 7, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5117), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5117), "Tundra", 1, 21, 4 },
                    { 8, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5118), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5118), "Sequoia", 1, 21, 6 },
                    { 9, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5119), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5119), "Civic", 1, 9, 5 },
                    { 10, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5121), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5121), "CR-V", 1, 9, 6 },
                    { 11, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5122), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5122), "Fit", 1, 9, 5 },
                    { 12, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5123), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5123), "HR-V", 1, 9, 6 },
                    { 13, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5124), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5124), "Pilot", 1, 9, 6 },
                    { 14, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5125), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5125), "Accord", 1, 9, 5 },
                    { 15, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5126), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5127), "Frontier", 1, 17, 4 },
                    { 16, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5127), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5128), "Sentra", 1, 17, 5 },
                    { 17, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5128), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5129), "Tiida", 1, 17, 5 },
                    { 18, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5129), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5130), "Pathfinder", 1, 17, 6 },
                    { 19, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5208), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5208), "Kicks", 1, 17, 6 },
                    { 20, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5209), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5210), "Titan", 1, 17, 4 },
                    { 21, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5211), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5211), "Mazda 3", 1, 15, 5 },
                    { 22, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5212), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5212), "Mazda 6", 1, 15, 5 },
                    { 23, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5213), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5213), "CX-5", 1, 15, 6 },
                    { 24, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5214), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5214), "CX-9", 1, 15, 6 },
                    { 25, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5215), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5215), "Mazda 2 (Demio)", 1, 15, 5 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 26, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5216), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5216), "Accent", 1, 8, 5 },
                    { 27, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5217), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5217), "Sonata", 1, 8, 5 },
                    { 28, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5218), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5218), "Tucson", 1, 8, 6 },
                    { 29, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5219), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5219), "Santa Fe", 1, 8, 6 },
                    { 30, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5220), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5220), "Elantra", 1, 8, 5 },
                    { 31, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5221), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5221), "Y20", 1, 8, 5 },
                    { 32, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5222), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5222), "i10", 1, 8, 5 },
                    { 33, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5223), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5223), "i20", 1, 8, 5 },
                    { 34, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5224), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5224), "K5", 1, 13, 5 },
                    { 35, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5225), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5225), "Forte", 1, 13, 5 },
                    { 36, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5226), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5226), "Sorento", 1, 13, 6 },
                    { 37, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5227), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5228), "Sportage", 1, 13, 6 },
                    { 38, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5229), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5230), "Rio", 1, 13, 5 },
                    { 39, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5230), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5231), "Mira", 1, 6, 5 },
                    { 40, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5231), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5232), "Sirion", 1, 6, 5 },
                    { 41, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5232), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5233), "Camion", 1, 6, 3 },
                    { 42, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5233), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5234), "Terios", 1, 6, 6 },
                    { 43, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5234), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5235), "Escape", 1, 7, 6 },
                    { 44, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5235), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5236), "F-150", 1, 7, 4 },
                    { 45, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5237), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5237), "Focus", 1, 7, 5 },
                    { 46, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5238), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5238), "Explorer", 1, 7, 6 },
                    { 47, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5239), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5239), "Ranger", 1, 7, 4 },
                    { 48, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5240), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5240), "Ecosport", 1, 7, 6 },
                    { 49, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5241), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5241), "Wrangler", 1, 12, 7 },
                    { 50, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5242), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5242), "Cherokee", 1, 12, 6 },
                    { 51, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5243), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5243), "Grand Cherokee", 1, 12, 6 },
                    { 52, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5244), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5244), "Cruize", 1, 5, 5 },
                    { 53, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5245), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5245), "Aveo", 1, 5, 5 },
                    { 54, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5246), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5246), "Colorado", 1, 5, 4 },
                    { 55, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5247), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5247), "Silverado", 1, 5, 4 },
                    { 56, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5248), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5248), "Trax", 1, 5, 6 },
                    { 57, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5249), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5249), "Traverse", 1, 5, 6 },
                    { 58, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5250), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5250), "Otro", 1, 1, 1 },
                    { 59, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5251), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5251), "Touareg", 1, 22, 6 },
                    { 60, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5252), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5252), "Tiguan", 1, 22, 6 },
                    { 61, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5253), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5254), "Jetta", 1, 22, 5 },
                    { 62, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5254), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5255), "Passat", 1, 22, 5 },
                    { 63, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5256), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5256), "Golf", 1, 22, 5 },
                    { 64, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5257), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5257), "Fox", 1, 22, 5 },
                    { 65, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5258), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5258), "D-MAX", 1, 11, 4 },
                    { 66, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5259), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5259), "Rodeo", 1, 11, 6 },
                    { 67, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5260), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5260), "MUX", 1, 11, 6 }
                });

            migrationBuilder.InsertData(
                table: "VehiculoModelos",
                columns: new[] { "Id", "Estatus", "FechaCreacion", "FechaModificacion", "Nombre", "UsuarioId", "VehiculoMarcaId", "VehiculoTipoId" },
                values: new object[,]
                {
                    { 68, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5261), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5261), "XC-60", 1, 23, 6 },
                    { 69, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5262), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5263), "XC-90", 1, 23, 6 },
                    { 70, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5263), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5264), "XC-40", 1, 23, 6 },
                    { 71, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5264), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5265), "Legacy", 1, 24, 5 },
                    { 72, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5265), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5266), "Impreza", 1, 24, 5 },
                    { 73, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5266), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5267), "Outback", 1, 24, 6 },
                    { 74, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5267), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5268), "Forester", 1, 24, 6 },
                    { 75, true, new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5268), new DateTime(2023, 3, 28, 20, 56, 44, 732, DateTimeKind.Local).AddTicks(5269), "XV (Crosstrek)", 1, 24, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_MunicipioId",
                table: "Asistencias",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ProvinciaId",
                table: "Asistencias",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_UnidadMiembroId",
                table: "Asistencias",
                column: "UnidadMiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoColorId",
                table: "Asistencias",
                column: "VehiculoColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoMarcaId",
                table: "Asistencias",
                column: "VehiculoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoModeloId",
                table: "Asistencias",
                column: "VehiculoModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_VehiculoTipoId",
                table: "Asistencias",
                column: "VehiculoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_RangoId",
                table: "Miembro",
                column: "RangoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoresEncargados_MiembroId",
                table: "SupervisoresEncargados",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoresEncargadosTramos_SupervisorEncargadoId",
                table: "SupervisoresEncargadosTramos",
                column: "SupervisorEncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoresEncargadosTramos_TramoId",
                table: "SupervisoresEncargadosTramos",
                column: "TramoId");

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
                name: "IX_UnidadMiembro_MiembroId",
                table: "UnidadMiembro",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadMiembro_UnidadId",
                table: "UnidadMiembro",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_PermisoId",
                table: "UsuarioPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_UsuarioId",
                table: "UsuarioPermisos",
                column: "UsuarioId");

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
                name: "SupervisoresEncargadosTramos");

            migrationBuilder.DropTable(
                name: "TipoAsistencias");

            migrationBuilder.DropTable(
                name: "UsuarioPermisos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "UnidadMiembro");

            migrationBuilder.DropTable(
                name: "VehiculoColores");

            migrationBuilder.DropTable(
                name: "VehiculoModelos");

            migrationBuilder.DropTable(
                name: "SupervisoresEncargados");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "VehiculoMarcas");

            migrationBuilder.DropTable(
                name: "VehiculoTipos");

            migrationBuilder.DropTable(
                name: "Miembro");

            migrationBuilder.DropTable(
                name: "TipoUnidades");

            migrationBuilder.DropTable(
                name: "Tramo");

            migrationBuilder.DropTable(
                name: "Rangos");

            migrationBuilder.DropTable(
                name: "RegionesAsistencia");
        }
    }
}
