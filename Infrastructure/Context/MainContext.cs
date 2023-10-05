using Domain.Entities;
using Domain.Enums;
using Domain.ProcedureResults;
using Domain.ResultSetModels;
using Domain.ResultSetsModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
	public class MainContext : DbContext
	{
		public MainContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseLazyLoadingProxies(); // enables LazyLoading on virtual properties
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			/* ------- STORED PROCEDURE --------------- */

			// SP detalle de asistencias 
			modelBuilder.Entity<SP_ReporteAsistenciasDetalles>(e => e.HasNoKey());

			// SP Contador de asistencias para las unidades
			modelBuilder.Entity<SP_ContadorAsistenciasPorUnidad>(e => e.HasNoKey());

			// SP create login unidad miembro aplicacion 
			modelBuilder.Entity<SP_CreateUnidadMiembro>(e => e.HasNoKey());

			// SP busqueda autocompletar unidades
			modelBuilder.Entity<SP_UnidadAutoCompleteResult>(e => e.HasNoKey());

			// SP_Asistencias_Por_Region (SQL Procedure)
			modelBuilder.Entity<SP_ReporteAsistenciasResult>(e => e.HasNoKey());

			modelBuilder.Entity<SP_HistorialAsistencia>(e => e.HasNoKey());

			modelBuilder.Entity<SP_ReporteEstadisticoAsistencias>(e => e.HasNoKey());

			// Resumen estadistico asistencias unidad (solo para los supervisores y encargados de tramo)
			modelBuilder.Entity<SP_ReporteEstadisticoUnidadApp>(e => e.HasNoKey());

			modelBuilder.Entity<SP_ReporteEstadisticoTramoApp>(e => e.HasNoKey());


			/* ---------- VALUES PARSER (CONVERSIONS) --------------- */

			
			// Guardamos listado como JSON a la base de datos 

			modelBuilder.Entity<Asistencia>()
				.Property(a => a.TipoAsistencias).HasConversion(
					v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
					v => JsonConvert.DeserializeObject<IList<TipoAsistencia>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
				);

			// Guardamos el listado de imagenes base64 como un string 

			modelBuilder.Entity<Asistencia>()
				.Property(a => a.Imagenes).HasConversion(
					v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
					v => JsonConvert.DeserializeObject<IList<string>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
				);

			/* ----------- DATA SEEDING TO TABLES --------------- */

			if (false)
			{
				// Generamos el cifrado de la clave del usuario administrador
				new Infrastructure.Helpers.EncryptHelper().CreatePasswordHash("admin01", out byte[] passwordHash, out byte[] passwordSalt);

				modelBuilder.Entity<Usuario>().HasData(
					new Usuario { Id = 1, Username = "admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt, EsAdministrador = true, UsuarioId = null,Estatus = true }
				);				

				// Tipo Unidad

				modelBuilder.Entity<TipoUnidad>().HasData(
						new TipoUnidad { Id = (int)TipoUnidadEnum.Supervisor, Nombre = "Supervisor" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Encargado, Nombre = "Encargado" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Unidad, Nombre = "Unidad" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Movil, Nombre = "Movil" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Ambulancia, Nombre = "Ambulanccia" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Grua, Nombre = "Grua" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Rescate, Nombre = "Rescate" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.CODEVIAL, Nombre = "CODEVIAL" },
						new TipoUnidad { Id = (int)TipoUnidadEnum.Motorizada, Nombre = "Motorizada" }
					);

				// Regiones Asistencia Vial

				modelBuilder.Entity<RegionesAsistencia>().HasData(
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_Este, Nombre = "Region Este" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_Las_Americas, Nombre = "Region Las Americas" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_del_Nordeste, Nombre = "Region del Nordeste" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_Cibao_Sur, Nombre = "Region Cibao Sur" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_del_Noroeste, Nombre = "Region Noroeste" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_Cibao_Norte, Nombre = "Region Cibao Norte" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.Region_Sureste, Nombre = "Region Sureste" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.region_Suroeste, Nombre = "Region Suroeste" },
							new RegionesAsistencia { Id = (int)RegionesAsistenciaEnum.REGIÓN_CIRCUNVALACIÓN_SANTO_DOMINGO, Nombre = "Region Circunvalacion de Santo Domingo" }
					);

				// Provincias

				modelBuilder.Entity<Provincia>().HasData(
						new Provincia { Id = (int)ProvinciasEnum.AZUA, Nombre = "AZUA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.BAHORUCO, Nombre = "BAHORUCO", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.BARAHONA, Nombre = "BARAHONA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.DAJABON, Nombre = "DAJABON", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.DISTRITO_NACIONAL, Nombre = "DISTRITO NACIONAL", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.DUARTE, Nombre = "DUARTE", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.EL_SEYBO, Nombre = "EL SEYBO", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.ELIAS_PIÑA, Nombre = "ELIAS PIÑA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.ESPAILLAT, Nombre = "ESPAILLAT", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.HATO_MAYOR, Nombre = "HATO MAYOR", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.HERMANAS_MIRABAL_o_Salcedo, Nombre = "HERMANAS MIRABAL o Salcedo", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.INDEPENDENCIA, Nombre = "INDEPENDENCIA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.LA_ALTAGRACIA, Nombre = "LA ALTAGRACIA", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.LA_ROMANA, Nombre = "LA ROMANA", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.LA_VEGA, Nombre = "LA VEGA", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.MARIA_TRINIDAD_SANCHEZ, Nombre = "MARIA TRINIDAD SANCHEZ", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.MONSEÑOR_NOUEL, Nombre = "MONSEÑOR NOUEL", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.MONTE_PLATA, Nombre = "MONTE PLATA", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.MONTECRISTI, Nombre = "MONTECRISTI", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.PEDERNALES, Nombre = "PEDERNALES", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.PERAVIA, Nombre = "PERAVIA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.PUERTO_PLATA, Nombre = "PUERTO PLATA", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.SAMANA, Nombre = "SAMANA", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.SAN_CRISTOBAL, Nombre = "SAN CRISTOBAL", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.SAN_JOSE_DE_OCOA, Nombre = "SAN JOSE DE OCOA", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.SAN_JUAN, Nombre = "SAN JUAN", RegionMacro = RegionMacro.Region_Sur },
						new Provincia { Id = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS, Nombre = "SAN PEDRO DE MACORIS", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.SANCHEZ_RAMIREZ, Nombre = "SANCHEZ RAMIREZ", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.SANTIAGO, Nombre = "SANTIAGO", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.SANTIAGO_RODRIGUEZ, Nombre = "SANTIAGO RODRIGUEZ", RegionMacro = RegionMacro.Region_Norte },
						new Provincia { Id = (int)ProvinciasEnum.SANTO_DOMINGO, Nombre = "SANTO DOMINGO", RegionMacro = RegionMacro.Region_Este },
						new Provincia { Id = (int)ProvinciasEnum.VALVERDE, Nombre = "VALVERDE", RegionMacro = RegionMacro.Region_Norte }
					);

				modelBuilder.Entity<Municipio>().HasData(
						// Distrito Nacional
						new Municipio { Id = 1, Nombre = "Distrito Nacional", ProvinciaId = (int)ProvinciasEnum.DISTRITO_NACIONAL },
						// Azua
						new Municipio { Id = 2, Nombre = "Azua de Compostela", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 3, Nombre = "Estebanía", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 4, Nombre = "Guayabal", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 5, Nombre = "Las Charcas", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 6, Nombre = "Las Yayas de Viajama", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 7, Nombre = "Padre Las Casas", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 8, Nombre = "Peralta", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 9, Nombre = "Pueblo Viejo", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 10, Nombre = "Sabana Yegua", ProvinciaId = (int)ProvinciasEnum.AZUA },
						new Municipio { Id = 11, Nombre = "Tábara Arriba", ProvinciaId = (int)ProvinciasEnum.AZUA },

						// Bahoruco o Neiba
						new Municipio { Id = 12, Nombre = "Neiba", ProvinciaId = (int)ProvinciasEnum.BAHORUCO },
						new Municipio { Id = 13, Nombre = "Galván", ProvinciaId = (int)ProvinciasEnum.BAHORUCO },
						new Municipio { Id = 14, Nombre = "Los Ríos", ProvinciaId = (int)ProvinciasEnum.BAHORUCO },
						new Municipio { Id = 15, Nombre = "Villa Jaragua", ProvinciaId = (int)ProvinciasEnum.BAHORUCO },
						new Municipio { Id = 16, Nombre = "Tamayo", ProvinciaId = (int)ProvinciasEnum.BAHORUCO },

						// Barahona
						new Municipio { Id = 17, Nombre = "Barahona", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 18, Nombre = "Cabral", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 19, Nombre = "El Peñón", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 20, Nombre = "Enriquillo", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 21, Nombre = "Fundación", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 22, Nombre = "Jaquimeyes", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 23, Nombre = "La Ciénaga", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 24, Nombre = "Las Salinas", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 25, Nombre = "Paraíso", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 26, Nombre = "Polo", ProvinciaId = (int)ProvinciasEnum.BARAHONA },
						new Municipio { Id = 27, Nombre = "Vicente Noble", ProvinciaId = (int)ProvinciasEnum.BARAHONA },

						// Dajabón
						new Municipio { Id = 28, Nombre = "Dajabón", ProvinciaId = (int)ProvinciasEnum.DAJABON },
						new Municipio { Id = 29, Nombre = "El Pino", ProvinciaId = (int)ProvinciasEnum.DAJABON },
						new Municipio { Id = 30, Nombre = "Loma de Cabrera", ProvinciaId = (int)ProvinciasEnum.DAJABON },
						new Municipio { Id = 31, Nombre = "Partido", ProvinciaId = (int)ProvinciasEnum.DAJABON },
						new Municipio { Id = 32, Nombre = "Restauración", ProvinciaId = (int)ProvinciasEnum.DAJABON },

						// Duarte
						new Municipio { Id = 33, Nombre = "San Francisco de Macorís", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 34, Nombre = "Arenoso", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 35, Nombre = "Castillo", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 36, Nombre = "Eugenio María de Hostos", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 37, Nombre = "Las Guáranas", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 38, Nombre = "Pimentel", ProvinciaId = (int)ProvinciasEnum.DUARTE },
						new Municipio { Id = 39, Nombre = "Villa Riva", ProvinciaId = (int)ProvinciasEnum.DUARTE },

						// Elías Piña
						new Municipio { Id = 40, Nombre = "Comendador", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },
						new Municipio { Id = 41, Nombre = "Bánica", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },
						new Municipio { Id = 42, Nombre = "El Llano", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },
						new Municipio { Id = 43, Nombre = "Hondo Valle", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },
						new Municipio { Id = 44, Nombre = "Juan Santiago", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },
						new Municipio { Id = 45, Nombre = "Pedro Santana", ProvinciaId = (int)ProvinciasEnum.ELIAS_PIÑA },

						// Espaillat
						new Municipio { Id = 46, Nombre = "Moca", ProvinciaId = (int)ProvinciasEnum.ESPAILLAT },
						new Municipio { Id = 47, Nombre = "Cayetano Germosén", ProvinciaId = (int)ProvinciasEnum.ESPAILLAT },
						new Municipio { Id = 48, Nombre = "Gaspar Hernández", ProvinciaId = (int)ProvinciasEnum.ESPAILLAT },
						new Municipio { Id = 49, Nombre = "Jamao al Norte", ProvinciaId = (int)ProvinciasEnum.ESPAILLAT },

						// Hato Mayor
						new Municipio { Id = 50, Nombre = "Hato Mayor del Rey", ProvinciaId = (int)ProvinciasEnum.HATO_MAYOR },
						new Municipio { Id = 51, Nombre = "El Valle", ProvinciaId = (int)ProvinciasEnum.HATO_MAYOR },
						new Municipio { Id = 52, Nombre = "Sabana de la Mar", ProvinciaId = (int)ProvinciasEnum.HATO_MAYOR },

						// Hermanas Mirabal
						new Municipio { Id = 53, Nombre = "Salcedo", ProvinciaId = (int)ProvinciasEnum.HERMANAS_MIRABAL_o_Salcedo },
						new Municipio { Id = 54, Nombre = "Tenares", ProvinciaId = (int)ProvinciasEnum.HERMANAS_MIRABAL_o_Salcedo },
						new Municipio { Id = 55, Nombre = "Villa Tapia", ProvinciaId = (int)ProvinciasEnum.HERMANAS_MIRABAL_o_Salcedo },

						// Independencia
						new Municipio { Id = 56, Nombre = "Jimaní", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },
						new Municipio { Id = 57, Nombre = "Cristóbal", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },
						new Municipio { Id = 58, Nombre = "Duvergé", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },
						new Municipio { Id = 59, Nombre = "La Descubierta", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },
						new Municipio { Id = 60, Nombre = "Mella", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },
						new Municipio { Id = 61, Nombre = "Postrer Río", ProvinciaId = (int)ProvinciasEnum.INDEPENDENCIA },

						// La Altagracia
						new Municipio { Id = 62, Nombre = "Higüey", ProvinciaId = (int)ProvinciasEnum.LA_ALTAGRACIA },
						new Municipio { Id = 63, Nombre = "San Rafael del Yuma", ProvinciaId = (int)ProvinciasEnum.LA_ALTAGRACIA },

						// La Romana
						new Municipio { Id = 64, Nombre = "La Romana", ProvinciaId = (int)ProvinciasEnum.LA_ROMANA },
						new Municipio { Id = 65, Nombre = "Guaymate", ProvinciaId = (int)ProvinciasEnum.LA_ROMANA },
						new Municipio { Id = 66, Nombre = "Villa Hermosa", ProvinciaId = (int)ProvinciasEnum.LA_ROMANA },

						// La Vega
						new Municipio { Id = 67, Nombre = "La Concepción de La Vega", ProvinciaId = (int)ProvinciasEnum.LA_VEGA },
						new Municipio { Id = 68, Nombre = "Constanza", ProvinciaId = (int)ProvinciasEnum.LA_VEGA },
						new Municipio { Id = 69, Nombre = "Jarabacoa", ProvinciaId = (int)ProvinciasEnum.LA_VEGA },
						new Municipio { Id = 70, Nombre = "Jima Abajo", ProvinciaId = (int)ProvinciasEnum.LA_VEGA },

						// María Trinidad Sánchez
						new Municipio { Id = 71, Nombre = "Nagua", ProvinciaId = (int)ProvinciasEnum.MARIA_TRINIDAD_SANCHEZ },
						new Municipio { Id = 72, Nombre = "Cabrera", ProvinciaId = (int)ProvinciasEnum.MARIA_TRINIDAD_SANCHEZ },
						new Municipio { Id = 73, Nombre = "El Factor", ProvinciaId = (int)ProvinciasEnum.MARIA_TRINIDAD_SANCHEZ },
						new Municipio { Id = 74, Nombre = "Río San Juan", ProvinciaId = (int)ProvinciasEnum.MARIA_TRINIDAD_SANCHEZ },

						// Monseñor Nouel
						new Municipio { Id = 75, Nombre = "Bonao", ProvinciaId = (int)ProvinciasEnum.MONSEÑOR_NOUEL },
						new Municipio { Id = 76, Nombre = "Maimón", ProvinciaId = (int)ProvinciasEnum.MONSEÑOR_NOUEL },
						new Municipio { Id = 77, Nombre = "Piedra Blanca", ProvinciaId = (int)ProvinciasEnum.MONSEÑOR_NOUEL },

						// Montecristi
						new Municipio { Id = 78, Nombre = "Montecristi", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },
						new Municipio { Id = 79, Nombre = "Castañuela", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },
						new Municipio { Id = 80, Nombre = "Guayubín", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },
						new Municipio { Id = 81, Nombre = "Las Matas de Santa Cruz", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },
						new Municipio { Id = 82, Nombre = "Pepillo Salcedo", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },
						new Municipio { Id = 83, Nombre = "Villa Vásquez", ProvinciaId = (int)ProvinciasEnum.MONTECRISTI },

						// Monte Plata
						new Municipio { Id = 84, Nombre = "Monte Plata", ProvinciaId = (int)ProvinciasEnum.MONTE_PLATA },
						new Municipio { Id = 85, Nombre = "Bayaguana", ProvinciaId = (int)ProvinciasEnum.MONTE_PLATA },
						new Municipio { Id = 86, Nombre = "Peralvillo", ProvinciaId = (int)ProvinciasEnum.MONTE_PLATA },
						new Municipio { Id = 87, Nombre = "Sabana Grande de Boyá", ProvinciaId = (int)ProvinciasEnum.MONTE_PLATA },
						new Municipio { Id = 88, Nombre = "Yamasá", ProvinciaId = (int)ProvinciasEnum.MONTE_PLATA },

						// Pedernales
						new Municipio { Id = 89, Nombre = "Pedernales", ProvinciaId = (int)ProvinciasEnum.PEDERNALES },
						new Municipio { Id = 90, Nombre = "Oviedo", ProvinciaId = (int)ProvinciasEnum.PEDERNALES },

						// Peravia
						new Municipio { Id = 91, Nombre = "Baní", ProvinciaId = (int)ProvinciasEnum.PERAVIA },
						new Municipio { Id = 92, Nombre = "Nizao", ProvinciaId = (int)ProvinciasEnum.PERAVIA },

						// Puerto Plata
						new Municipio { Id = 93, Nombre = "Puerto Plata", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 94, Nombre = "Altamira", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 95, Nombre = "Guananico", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 96, Nombre = "Imbert", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 97, Nombre = "Los Hidalgos", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 98, Nombre = "Luperón", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 99, Nombre = "Sosúa", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 100, Nombre = "Villa Isabela", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },
						new Municipio { Id = 101, Nombre = "Villa Montellano", ProvinciaId = (int)ProvinciasEnum.PUERTO_PLATA },

						// Samaná
						new Municipio { Id = 102, Nombre = "Samaná", ProvinciaId = (int)ProvinciasEnum.SAMANA },
						new Municipio { Id = 103, Nombre = "Las Terrenas", ProvinciaId = (int)ProvinciasEnum.SAMANA },
						new Municipio { Id = 104, Nombre = "Sánchez", ProvinciaId = (int)ProvinciasEnum.SAMANA },

						// San Cristóbal
						new Municipio { Id = 105, Nombre = "San Cristóbal", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 106, Nombre = "Bajos de Haina", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 107, Nombre = "Cambita Garabito", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 108, Nombre = "Los Cacaos", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 109, Nombre = "Sabana Grande de Palenque", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 110, Nombre = "San Gregorio de Nigua", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 111, Nombre = "Villa Altagracia", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },
						new Municipio { Id = 112, Nombre = "Yaguate", ProvinciaId = (int)ProvinciasEnum.SAN_CRISTOBAL },

						// San José de Ocoa
						new Municipio { Id = 113, Nombre = "San José de Ocoa", ProvinciaId = (int)ProvinciasEnum.SAN_JOSE_DE_OCOA },
						new Municipio { Id = 114, Nombre = "Rancho Arriba", ProvinciaId = (int)ProvinciasEnum.SAN_JOSE_DE_OCOA },
						new Municipio { Id = 115, Nombre = "Sabana Larga", ProvinciaId = (int)ProvinciasEnum.SAN_JOSE_DE_OCOA },

						// San juan
						new Municipio { Id = 116, Nombre = "BOHECHIO", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },
						new Municipio { Id = 117, Nombre = "EL CERCADO", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },
						new Municipio { Id = 118, Nombre = "JUAN DE HERRERA", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },
						new Municipio { Id = 119, Nombre = "LAS MATAS DE FARFAN", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },
						new Municipio { Id = 120, Nombre = "SAN JUAN DE LA MAGUANA", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },
						new Municipio { Id = 121, Nombre = "VALLEJUELO", ProvinciaId = (int)ProvinciasEnum.SAN_JUAN },

						// San Pedro de Macorís
						new Municipio { Id = 122, Nombre = "San Pedro de Macorís", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },
						new Municipio { Id = 123, Nombre = "Consuelo", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },
						new Municipio { Id = 124, Nombre = "Guayacanes", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },
						new Municipio { Id = 125, Nombre = "Quisqueya", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },
						new Municipio { Id = 126, Nombre = "Ramón Santana", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },
						new Municipio { Id = 127, Nombre = "San José de Los Llano", ProvinciaId = (int)ProvinciasEnum.SAN_PEDRO_DE_MACORIS },

						// Sánchez Ramírez
						new Municipio { Id = 128, Nombre = "Cotui", ProvinciaId = (int)ProvinciasEnum.SANCHEZ_RAMIREZ },
						new Municipio { Id = 129, Nombre = "Cevicos", ProvinciaId = (int)ProvinciasEnum.SANCHEZ_RAMIREZ },
						new Municipio { Id = 130, Nombre = "Fantino", ProvinciaId = (int)ProvinciasEnum.SANCHEZ_RAMIREZ },
						new Municipio { Id = 131, Nombre = "La Mata", ProvinciaId = (int)ProvinciasEnum.SANCHEZ_RAMIREZ },

						// Santiago
						new Municipio { Id = 132, Nombre = "Santiago", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 133, Nombre = "Bisonó", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 134, Nombre = "Jánico", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 135, Nombre = "Licey al Medio", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 136, Nombre = "Puñal", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 137, Nombre = "Sabana Iglesia", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 138, Nombre = "San José de las Matas", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 139, Nombre = "Tamboril", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },
						new Municipio { Id = 140, Nombre = "Villa González", ProvinciaId = (int)ProvinciasEnum.SANTIAGO },

						// Santiago Rodríguez
						new Municipio { Id = 141, Nombre = "San Ignacio de Sabaneta", ProvinciaId = (int)ProvinciasEnum.SANTIAGO_RODRIGUEZ },
						new Municipio { Id = 142, Nombre = "Los Almácigos", ProvinciaId = (int)ProvinciasEnum.SANTIAGO_RODRIGUEZ },
						new Municipio { Id = 143, Nombre = "Monción", ProvinciaId = (int)ProvinciasEnum.SANTIAGO_RODRIGUEZ },

						// Santo Domingo
						new Municipio { Id = 144, Nombre = "Santo Domingo Este", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 145, Nombre = "Boca Chica", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 146, Nombre = "Los Alcarrizos", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 147, Nombre = "Pedro Brand", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 148, Nombre = "San Antonio de Guerra", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 149, Nombre = "Santo Domingo Norte", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },
						new Municipio { Id = 150, Nombre = "Santo Domingo Oeste", ProvinciaId = (int)ProvinciasEnum.SANTO_DOMINGO },

						// Valverde
						new Municipio { Id = 151, Nombre = "Mao", ProvinciaId = (int)ProvinciasEnum.VALVERDE },
						new Municipio { Id = 152, Nombre = "Esperanza", ProvinciaId = (int)ProvinciasEnum.VALVERDE },
						new Municipio { Id = 153, Nombre = "Laguna Salada", ProvinciaId = (int)ProvinciasEnum.VALVERDE }

					);

				// Rangos 

				modelBuilder.Entity<Rango>().HasData(
						new Rango { Id = (int)RangosEnum.MAYOR_GENERAL_VICEALMIRANTE, Nombre = "MAYOR GENERAL/VICEALMIRANTE" },
						new Rango { Id = (int)RangosEnum.GENERAL_CONTRALMIRANTE, Nombre = "GENERAL/CONTRALMIRANTE" },
						new Rango { Id = (int)RangosEnum.CORONEL_CAPITAN_DE_NAVIO, Nombre = "CORONEL/CAPITAN DE NAVIO" },
						new Rango { Id = (int)RangosEnum.TENIENTE_CORONEL_CAPITAN_DE_FRAGATA, Nombre = "TENIENTE CORONEL/CAPITAN DE FRAGATA" },
						new Rango { Id = (int)RangosEnum.MAYOR_CAPITAN_CORBETA, Nombre = "MAYOR/CAPITAN CORBETA" },
						new Rango { Id = (int)RangosEnum.CAPITAN_TENIENTE_NAVIO, Nombre = "CAPITAN/TENIENTE NAVIO" },
						new Rango { Id = (int)RangosEnum.PRIMER_TENIENTE_TENIENTE_FRAGATA, Nombre = "1ER TENIENTE/TENIENTE FRAGATA" },
						new Rango { Id = (int)RangosEnum.SEGUNDO_TENIENTE_TENIENTE_CORBETA, Nombre = "2DO TENIENTE/TENIENTE CORBETA" },
						new Rango { Id = (int)RangosEnum.SARGENTO_MAYOR, Nombre = "SARGENTO MAYOR" },
						new Rango { Id = (int)RangosEnum.SARGENTO, Nombre = "SARGENTO" },
						new Rango { Id = (int)RangosEnum.CABO, Nombre = "CABO" },
						new Rango { Id = (int)RangosEnum.RASO_MARINERO, Nombre = "RASO/MARINERO" },
						new Rango { Id = (int)RangosEnum.ASIMILADO, Nombre = "ASIMILADO" },
						new Rango { Id = (int)RangosEnum.AGENTE_MOPC, Nombre = "AGENTE MOPC" }
					);


				// Tipo de asistencias

				modelBuilder.Entity<TipoAsistencia>().HasData(
						// Accidentes
						new TipoAsistencia { Id = 1, Nombre = "Choque", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						new TipoAsistencia { Id = 2, Nombre = "Choque Multiple", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						new TipoAsistencia { Id = 3, Nombre = "Choque con animal", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						new TipoAsistencia { Id = 4, Nombre = "Deslizamiento", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						new TipoAsistencia { Id = 5, Nombre = "Volcadura", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						new TipoAsistencia { Id = 6, Nombre = "Atropellamiento", CategoriaAsistencia = CategoriaAsistencia.Accidente },
						// Asistencias
						new TipoAsistencia { Id = 7, Nombre = "Seguridad", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 8, Nombre = "Neumático", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 9, Nombre = "Combustible", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 10, Nombre = "Mecanica", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 11, Nombre = "Electrica", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 12, Nombre = "Calentamiento", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 13, Nombre = "Grúas", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 14, Nombre = "Ambulancia", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 15, Nombre = "Talleres", CategoriaAsistencia = CategoriaAsistencia.Asistencia },
						new TipoAsistencia { Id = 16, Nombre = "Camión. Rescate", CategoriaAsistencia = CategoriaAsistencia.Asistencia }
					);

				// Tramos

				modelBuilder.Entity<Tramo>().HasData(
						// Region Este
						new Tramo { Id = 1, Nombre = "Tramo Carretero Miches", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Este },
						new Tramo { Id = 2, Nombre = "Tramo Carretero Punta Cana", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Este },
						new Tramo { Id = 3, Nombre = "Tramo El Coral y Circ. Romana", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Este },
						new Tramo { Id = 4, Nombre = "9-1-1 Romana", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Este },
						new Tramo { Id = 5, Nombre = "Tramo del Seibo", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Este },

						// Region Las Americas
						new Tramo { Id = 6, Nombre = "Las Américas tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Las_Americas },
						new Tramo { Id = 7, Nombre = "Las Américas tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Las_Americas },
						new Tramo { Id = 8, Nombre = "Tramo  Hato Mayor", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Las_Americas },

						// Region Nordeste
						new Tramo { Id = 9, Nombre = "Tramo Samaná", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_del_Nordeste },

						// Region Norte o Cibao
						new Tramo { Id = 10, Nombre = "Cibao Sur tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Sur },
						new Tramo { Id = 11, Nombre = "Tramo San Francisco de Macorís", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Sur },
						new Tramo { Id = 12, Nombre = "Cibao Sur Tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Sur },
						new Tramo { Id = 13, Nombre = "Tramo Cotuí", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Sur },
						new Tramo { Id = 14, Nombre = "Tramo Salcedo", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Sur },

						// Region Nor-Oeste
						new Tramo { Id = 15, Nombre = "Tramo Circunvalación Norte", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_del_Noroeste },
						new Tramo { Id = 16, Nombre = "Noroeste tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_del_Noroeste },
						new Tramo { Id = 17, Nombre = "Noroeste tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_del_Noroeste },
						new Tramo { Id = 18, Nombre = "Tramo Mao, Valverde", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_del_Noroeste },

						// Region Cibao-Norte
						new Tramo { Id = 19, Nombre = "Tramo Cibao Norte", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Norte },
						new Tramo { Id = 20, Nombre = "Atlántico tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Norte },
						new Tramo { Id = 21, Nombre = "Tramo Luperón", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Norte },
						new Tramo { Id = 22, Nombre = "Atlántico tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Norte },
						new Tramo { Id = 23, Nombre = "Tramo Rio San Juan", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Cibao_Norte },

						// Region Sur-Este
						new Tramo { Id = 24, Nombre = "Sureste tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Sureste },
						new Tramo { Id = 25, Nombre = "Sureste tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Sureste },
						new Tramo { Id = 26, Nombre = "Tramo  San Juan de la Maguana", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Sureste },
						new Tramo { Id = 27, Nombre = "Tramo San José de Ocoa", RegionAsistenciaId = (int)RegionesAsistenciaEnum.Region_Sureste },

						// Region Sur-Oeste
						new Tramo { Id = 28, Nombre = "Suroeste tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.region_Suroeste },
						new Tramo { Id = 29, Nombre = "Suroeste tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.region_Suroeste },

						// REGIÓN CIRCUNVALACIÓN SANTO DOMINGO
						new Tramo { Id = 30, Nombre = "Circunvalación Santo Domingo tramo I", RegionAsistenciaId = (int)RegionesAsistenciaEnum.REGIÓN_CIRCUNVALACIÓN_SANTO_DOMINGO },
						new Tramo { Id = 31, Nombre = "Circunvalación Santo Domingo tramo II", RegionAsistenciaId = (int)RegionesAsistenciaEnum.REGIÓN_CIRCUNVALACIÓN_SANTO_DOMINGO },
						new Tramo { Id = 32, Nombre = "Corredores del Distrito Nacional", RegionAsistenciaId = (int)RegionesAsistenciaEnum.REGIÓN_CIRCUNVALACIÓN_SANTO_DOMINGO }
					);

				// Colores

				modelBuilder.Entity<VehiculoColor>().HasData(
						new VehiculoColor { Id = 1, Nombre = "Otro" },
						new VehiculoColor { Id = 2, Nombre = "Amarillo" },
						new VehiculoColor { Id = 3, Nombre = "Azul" },
						new VehiculoColor { Id = 4, Nombre = "Blanco" },
						new VehiculoColor { Id = 5, Nombre = "Crema" },
						new VehiculoColor { Id = 6, Nombre = "Gris" },
						new VehiculoColor { Id = 7, Nombre = "Gris oscuro" },
						new VehiculoColor { Id = 8, Nombre = "Marron" },
						new VehiculoColor { Id = 9, Nombre = "Naranja" },
						new VehiculoColor { Id = 10, Nombre = "Negro" },
						new VehiculoColor { Id = 11, Nombre = "Rojo" },
						new VehiculoColor { Id = 12, Nombre = "Rojo Vino" },
						new VehiculoColor { Id = 13, Nombre = "Verde" },
						new VehiculoColor { Id = 14, Nombre = "Morado" }
					);

				// Tipo Vehiculo

				modelBuilder.Entity<VehiculoTipo>().HasData(
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Otro, Nombre = "Desconocido" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Autobus, Nombre = "Autobus" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Camion, Nombre = "Camión" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Camioneta, Nombre = "Camioneta" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Carro, Nombre = "Carro" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Jeepeta, Nombre = "Jeepeta" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Jeep, Nombre = "Jeep" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Guagua, Nombre = "Guagua" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Motor_o_Motocicleta, Nombre = "Motor o Motocicleta" },
						new VehiculoTipo { Id = (int)VehiculoTipoEnum.Patana, Nombre = "Patana" }
					);

				// Marcas de vehiculos

				modelBuilder.Entity<VehiculoMarca>().HasData(
						new VehiculoMarca { Id = 1, Nombre = "Desconocida" },
						new VehiculoMarca { Id = 2, Nombre = "Acura" },
						new VehiculoMarca { Id = 3, Nombre = "Audi" },
						new VehiculoMarca { Id = 4, Nombre = "BMW" },
						new VehiculoMarca { Id = 5, Nombre = "Chevrolet" },
						new VehiculoMarca { Id = 6, Nombre = "Daihatsu" },
						new VehiculoMarca { Id = 7, Nombre = "Ford" },
						new VehiculoMarca { Id = 8, Nombre = "Hyundai" },
						new VehiculoMarca { Id = 9, Nombre = "Honda" },
						new VehiculoMarca { Id = 10, Nombre = "Infiniti" },
						new VehiculoMarca { Id = 11, Nombre = "Isuzu" },
						new VehiculoMarca { Id = 12, Nombre = "Jeep" },
						new VehiculoMarca { Id = 13, Nombre = "Kia" },
						new VehiculoMarca { Id = 14, Nombre = "Lexus" },
						new VehiculoMarca { Id = 15, Nombre = "Mazda" },
						new VehiculoMarca { Id = 16, Nombre = "Mercedes Benz" },
						new VehiculoMarca { Id = 17, Nombre = "Nissan" },
						new VehiculoMarca { Id = 18, Nombre = "Otro" },
						new VehiculoMarca { Id = 19, Nombre = "Scion" },
						new VehiculoMarca { Id = 20, Nombre = "Skoda" },
						new VehiculoMarca { Id = 21, Nombre = "Toyota" },
						new VehiculoMarca { Id = 22, Nombre = "Volkswagen" },
						new VehiculoMarca { Id = 23, Nombre = "Volvo" },
						new VehiculoMarca { Id = 24, Nombre = "Subaru" }
					);

				// Modelos de vehiculos

				modelBuilder.Entity<VehiculoModelo>().HasData(

						// Toyota
						new VehiculoModelo { Id = 1, Nombre = "Camry", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 2, Nombre = "Corrolla", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 3, Nombre = "Highlander", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 4, Nombre = "LandCruiser", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 5, Nombre = "Hilux", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 6, Nombre = "Tacoma", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 7, Nombre = "Tundra", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 8, Nombre = "Sequoia", VehiculoMarcaId = 21, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Honda
						new VehiculoModelo { Id = 9, Nombre = "Civic", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 10, Nombre = "CR-V", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 11, Nombre = "Fit", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 12, Nombre = "HR-V", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 13, Nombre = "Pilot", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 14, Nombre = "Accord", VehiculoMarcaId = 9, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						// Nissan
						new VehiculoModelo { Id = 15, Nombre = "Frontier", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 16, Nombre = "Sentra", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 17, Nombre = "Tiida", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 18, Nombre = "Pathfinder", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 19, Nombre = "Kicks", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 20, Nombre = "Titan", VehiculoMarcaId = 17, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						// Mazda
						new VehiculoModelo { Id = 21, Nombre = "Mazda 3", VehiculoMarcaId = 15, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 22, Nombre = "Mazda 6", VehiculoMarcaId = 15, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 23, Nombre = "CX-5", VehiculoMarcaId = 15, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 24, Nombre = "CX-9", VehiculoMarcaId = 15, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 25, Nombre = "Mazda 2 (Demio)", VehiculoMarcaId = 15, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						// Hyundai
						new VehiculoModelo { Id = 26, Nombre = "Accent", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 27, Nombre = "Sonata", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 28, Nombre = "Tucson", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 29, Nombre = "Santa Fe", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 30, Nombre = "Elantra", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 31, Nombre = "Y20", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 32, Nombre = "i10", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 33, Nombre = "i20", VehiculoMarcaId = 8, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						// Kia
						new VehiculoModelo { Id = 34, Nombre = "K5", VehiculoMarcaId = 13, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 35, Nombre = "Forte", VehiculoMarcaId = 13, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 36, Nombre = "Sorento", VehiculoMarcaId = 13, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 37, Nombre = "Sportage", VehiculoMarcaId = 13, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 38, Nombre = "Rio", VehiculoMarcaId = 13, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						// Daihatsu
						new VehiculoModelo { Id = 39, Nombre = "Mira", VehiculoMarcaId = 6, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 40, Nombre = "Sirion", VehiculoMarcaId = 6, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 41, Nombre = "Camion", VehiculoMarcaId = 6, VehiculoTipoId = (int)VehiculoTipoEnum.Camion },
						new VehiculoModelo { Id = 42, Nombre = "Terios", VehiculoMarcaId = 6, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Ford
						new VehiculoModelo { Id = 43, Nombre = "Escape", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 44, Nombre = "F-150", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 45, Nombre = "Focus", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 46, Nombre = "Explorer", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 47, Nombre = "Ranger", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 48, Nombre = "Ecosport", VehiculoMarcaId = 7, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Jeep
						new VehiculoModelo { Id = 49, Nombre = "Wrangler", VehiculoMarcaId = 12, VehiculoTipoId = (int)VehiculoTipoEnum.Jeep },
						new VehiculoModelo { Id = 50, Nombre = "Cherokee", VehiculoMarcaId = 12, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 51, Nombre = "Grand Cherokee", VehiculoMarcaId = 12, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Chevrolet
						new VehiculoModelo { Id = 52, Nombre = "Cruize", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 53, Nombre = "Aveo", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 54, Nombre = "Colorado", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 55, Nombre = "Silverado", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 56, Nombre = "Trax", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 57, Nombre = "Traverse", VehiculoMarcaId = 5, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Otra
						new VehiculoModelo { Id = 58, Nombre = "Otro", VehiculoMarcaId = 1, VehiculoTipoId = (int)VehiculoTipoEnum.Otro },
						// Volkswagen
						new VehiculoModelo { Id = 59, Nombre = "Touareg", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 60, Nombre = "Tiguan", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 61, Nombre = "Jetta", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 62, Nombre = "Passat", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 63, Nombre = "Golf", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 64, Nombre = "Fox", VehiculoMarcaId = 22, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						// Isuzu
						new VehiculoModelo { Id = 65, Nombre = "D-MAX", VehiculoMarcaId = 11, VehiculoTipoId = (int)VehiculoTipoEnum.Camioneta },
						new VehiculoModelo { Id = 66, Nombre = "Rodeo", VehiculoMarcaId = 11, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 67, Nombre = "MUX", VehiculoMarcaId = 11, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Volvo 
						new VehiculoModelo { Id = 68, Nombre = "XC-60", VehiculoMarcaId = 23, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 69, Nombre = "XC-90", VehiculoMarcaId = 23, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 70, Nombre = "XC-40", VehiculoMarcaId = 23, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						// Subaru 
						new VehiculoModelo { Id = 71, Nombre = "Legacy", VehiculoMarcaId = 24, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 72, Nombre = "Impreza", VehiculoMarcaId = 24, VehiculoTipoId = (int)VehiculoTipoEnum.Carro },
						new VehiculoModelo { Id = 73, Nombre = "Outback", VehiculoMarcaId = 24, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 74, Nombre = "Forester", VehiculoMarcaId = 24, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta },
						new VehiculoModelo { Id = 75, Nombre = "XV (Crosstrek)", VehiculoMarcaId = 24, VehiculoTipoId = (int)VehiculoTipoEnum.Jeepeta }
					);
			}		

		}

        // Stored Procedure result set's
        public DbSet<SP_ReporteAsistenciasDetalles> SP_ReporteAsistenciasDetalles_Result { get; set; }
        public DbSet<SP_ContadorAsistenciasPorUnidad> SP_ContadorAsistenciasPorUnidad_Result { get; set; }
		public DbSet<SP_CreateUnidadMiembro> SP_CreateUnidadMiembro_Result { get; set; }
		public DbSet<SP_UnidadAutoCompleteResult> SP_UnidadAutoComplete_Result { get; set; }
		public DbSet<SP_ReporteAsistenciasResult> SP_ReporteAsistencias_Result { get; set; }
		public DbSet<SP_HistorialAsistencia> SP_HistorialAsistencias_Result { get; set; }
		public DbSet<SP_ReporteEstadisticoAsistencias> SP_ReporteEstadisticoAsistencias_Result { get; set; }
		public DbSet<SP_ReporteEstadisticoUnidadApp> SP_ReporteEstadisticoUnidadApp_Result { get; set; }
		public DbSet<SP_ReporteEstadisticoTramoApp> SP_ReporteEstadisticoTramoApp_Result { get; set; }

		// Tables
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Permiso> Permisos { get; set; }
		public DbSet<UsuarioPermiso> UsuarioPermisos { get; set; }

		public DbSet<Asistencia> Asistencias { get; set; }
		public DbSet<Provincia> Provincias { get; set; }
		public DbSet<Municipio> Municipios { get; set; }		
		public DbSet<RegionesAsistencia> RegionesAsistencia { get; set; }
		public DbSet<Tramo> Tramo { get; set; }
		public DbSet<TipoAsistencia> TipoAsistencias { get; set; }
		public DbSet<Unidad> Unidades { get; set; }
		public DbSet<TipoUnidad> TipoUnidades { get; set; }
		public DbSet<UnidadMiembro> UnidadMiembro { get; set; }
		public DbSet<Miembro> Miembro { get; set; }
		public DbSet<VehiculoColor> VehiculoColores { get; set; }
		public DbSet<VehiculoMarca> VehiculoMarcas { get; set; }
		public DbSet<VehiculoModelo> VehiculoModelos { get; set; }
		public DbSet<VehiculoTipo> VehiculoTipos { get; set; }
		public DbSet<Rango> Rangos { get; set; }
		public DbSet<SupervisorEncargado> SupervisoresEncargados { get; set; }
		public DbSet<SupervisorEncargadoTramo> SupervisoresEncargadosTramos { get; set; }

		public DbSet<HistoricoAsistencia> HistoricoAsistencias { get; set; }
		public DbSet<HistoricoUnidad> HistoricoUnidades { get; set; }

	}
}
