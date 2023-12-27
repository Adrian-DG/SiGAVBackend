using Domain.Entities;
using Domain.ProcedureResults;
using Domain.ResultSetsModels;
using Domain.ViewModels;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace Infrastructure.Repositories
{
	public class AsistenciaRepository : GenericRepository<Asistencia>
	{
		private readonly SpreadsheetsResource.ValuesResource _googleSheetValues;

		private const string SPREADSHEET_ID = "1q8x_9-tZaAyXKDxiC1FceoKwtVsGubky9QvRyeX25RU";
		private const string SHEET_NAME = "prueba";

		public AsistenciaRepository(MainContext mainContext) : base(mainContext)
		{
			_googleSheetValues = new GoogleSheetHelper().Service.Spreadsheets.Values;
		}

		// Map Excel section

		public static IList<IList<object>> MapToRangeData(AsistenciaExcelSheetModel item)
		{
			var objectList = new List<object>()
			{
				item.TipoAsistencia,
				item.CategoriaAsistencia,

				item.Unidad,

				item.Region,									
				item.Provincia,
				item.Municipio,
				item.Tramo,
				item.Fecha,

				item.Ficha,				

				item.Identificacion,
				item.NombreCiudadano,
				item.Telefono,
				item.Sexo,
				item.EsExtranjero,

				item.Tipo,
				item.Color,
				item.Marca,
				item.Modelo,
				item.Placa,				

				item.Institucion,
				item.RangoAgente,
				item.CedulaSoldado,
				item.NombreSoldado,
				
				item.FechaCreacion,
				item.TiempoCreacion,
				item.TiempoLlegada,				
				item.TiempoCompletada,
				item.QuienReporta,
				item.Usuario,
				item.Comentario
			};
			var rangeData = new List<IList<object>> { objectList };
			return rangeData;
		}

		public async Task AddNewRowToExcel(Asistencia model)
		{
			var unidadMiembro = await _context.UnidadMiembro.FindAsync(model.UnidadMiembroId);

			await _context.Entry(unidadMiembro).Reference(u => u.Unidad).LoadAsync();
			await _context.Entry(unidadMiembro.Unidad).Reference(u => u.Tramo).LoadAsync();
			await _context.Entry(unidadMiembro.Unidad.Tramo).Reference(u => u.RegionAsistencia).LoadAsync();

			var municipio = await _context.Municipios.FindAsync(model.MunicipioId);

			await _context.Entry(municipio).Reference(m => m.Provincia).LoadAsync();

			await _context.Entry(unidadMiembro).Reference(m => m.Miembro).LoadAsync();
			await _context.Entry(unidadMiembro.Miembro).Reference(m => m.Rango).LoadAsync();

			await _context.Entry(model).Reference(m => m.VehiculoColor).LoadAsync();
			await _context.Entry(model).Reference(m => m.VehiculoMarca).LoadAsync();
			await _context.Entry(model).Reference(m => m.VehiculoModelo).LoadAsync();
			await _context.Entry(model).Reference(m => m.VehiculoTipo).LoadAsync();

			string nombreUsuario = null;

			if (model.UsuarioId == 0)
			{
				nombreUsuario = "No Disponible - Completada en Campo";
			}
			else
			{
				nombreUsuario = (await _context.Usuarios.SingleOrDefaultAsync(x => x.Id == model.UsuarioId)).NombreCompleto();
			}

			foreach (var item in model.TipoAsistencias)
			{
				var excelModel = new AsistenciaExcelSheetModel()
				{
					//Tipo = item.Nombre,
					//Categoria = item.CategoriaAsistencia.ToString(),
					//Unidad = unidadMiembro.Unidad.Denominacion,
					//Region = unidadMiembro.Unidad.Tramo.RegionAsistencia.Nombre,
					//Provincia = municipio.Provincia.Nombre,
					//Municipio = municipio.Nombre,
					//Tramo = unidadMiembro.Unidad.Tramo.Nombre,
					//Fecha = model.TiempoCompletada.ToString("dd/MM/yyyy")

					TipoAsistencia = item.Nombre,
					CategoriaAsistencia = item.CategoriaAsistencia.ToString(),
					Unidad = unidadMiembro.Unidad.Denominacion,
					Region = unidadMiembro.Unidad.Tramo.RegionAsistencia.Nombre,
					Provincia = model.Provincia.Nombre,
					Municipio = municipio.Nombre,
					Tramo = unidadMiembro.Unidad.Tramo.Nombre,
					Fecha = model.TiempoLlegada.ToString("dd/MM/yyyy"),

					Ficha = unidadMiembro.Unidad.Ficha,							

					Identificacion = model.Identificacion,
					NombreCiudadano = $"{model.Nombre} {model.Apellido}",
					Telefono = model.Telefono,
					Sexo = model.Genero.ToString(),
					EsExtranjero = model.EsExtranjero ? "Si": "No",

					Tipo = model.VehiculoTipo.Nombre,
					Marca = model.VehiculoMarca.Nombre,
					Modelo = model.VehiculoModelo.Nombre,
					Placa = model.Placa,
					Color = model.VehiculoColor.Nombre,
					
					Institucion = model.UnidadMiembro.Miembro.Institucion.ToString(),
					RangoAgente = model.UnidadMiembro.Miembro.Rango.Nombre,
					CedulaSoldado = model.UnidadMiembro.Miembro.Cedula,
					NombreSoldado = model.UnidadMiembro.Miembro.NombreCompleto(),

					FechaCreacion = model.FechaCreacion.ToString("dd/MM/yyyy"),
					TiempoCreacion = model.FechaCreacion.ToString("HH:mm"),
					TiempoLlegada = model.TiempoLlegada.ToString("HH:mm"),
					
					TiempoCompletada = model.TiempoCompletada.ToString("HH:mm"),
					QuienReporta = model.ReportadoPor.ToString(),
					Usuario = nombreUsuario,
					Comentario = model.Comentario
				};

				var valueRange = new ValueRange
				{
					Values = MapToRangeData(excelModel)
				};

				var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, $"{SHEET_NAME}!A:I");
				appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
				appendRequest.Execute();
			}

		}

		private async Task<int> GetUnidadMiembroId(int unidadId)
		{
			var results = await _context.UnidadMiembro
						.Where(x => x.UnidadId == unidadId)
						.OrderByDescending(x => x.FechaCreacion)
						.ToListAsync();

			return (results.Count > 0) ? results.First().Id : 0;
		}

		public async Task CreateAsistenciaR5(CreateAsistenciaR5 model)
		{

			List<TipoAsistencia> tipoAsistencias = new();

			foreach (var item in model.TipoAsistencias)
			{
				var tipo = await _context.TipoAsistencias.FindAsync(item);
				tipoAsistencias.Add(tipo);
			}

			var unidadMiembroId = await GetUnidadMiembroId(model.UnidadId);

			if (unidadMiembroId == 0) return;

			string identificacion = model.EsExtranjero 
				? model.Identificacion.Replace("-", "").ToUpper() 
				: model.Identificacion.Replace("-", "");

			string telefono = model.Telefono.Replace("-", "");

			string placa = model.Placa.ToUpper();

			var newAsistencia = new Asistencia
			{
				// Ciudadano
				Identificacion = identificacion,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				Genero = model.Genero,
				Telefono = telefono,
				EsExtranjero = model.EsExtranjero,
				// Vehiculo
				VehiculoTipoId = model.VehiculoTipoId.Equals(0) ? 1 : model.VehiculoTipoId,
				VehiculoColorId = model.VehiculoColorId.Equals(0) ? 1 : model.VehiculoColorId,
				VehiculoModeloId = model.VehiculoModeloId.Equals(0) ? 1 : model.VehiculoModeloId,
				VehiculoMarcaId = model.VehiculoMarcaId.Equals(0) ? 1 : model.VehiculoMarcaId,
				Placa = placa,
				// asistencia (sin coordenadas)
				MunicipioId = model.MunicipioId.Equals(0) ? 1 : model.MunicipioId,
				ProvinciaId = model.ProvinciaId.Equals(0) ? 33 : model.ProvinciaId,
				Direccion = model.Direccion,
				ReportadoPor = ReportadoPor.CallCenter,
				EstatusAsistencia = EstatusAsistencia.PENDIENTE,
				UnidadMiembroId = unidadMiembroId,
				UsuarioId = model.UsuarioId,
				TipoAsistencias = tipoAsistencias,
				Comentario = model.Comentario,
				Estatus = false,
				FechaCreacion = DateTime.Now.AddHours(-4)
			};

			await _repository.AddAsync(newAsistencia);
		}

		public async Task<PagedData<SP_ObtenerListadoAsistencias>> GetAllAsistencias(AsistenciaPaginationFilter filters, Expression<Func<Asistencia, bool>> predicate)
		{
			var results = await _context.SP_ObtenerListadoAsistencias_Result
						.FromSqlInterpolated($"[dbo].[ObtenerListadoAsistencia] @page={filters.Page - 1}, @size={filters.Size}, @searchTerm={filters.SearchTerm}, @estatusAsistencia={filters.EstatusAsistencia}").ToListAsync();

			return new PagedData<SP_ObtenerListadoAsistencias>
			{
				Items = results,
				Page = filters.Page,
				Size = filters.Size,
				TotalCount = await GetTotalRecords(predicate)
			};
		}

		public async Task<ServerResponse> ActualizarAsistencia(UpdateAsistencia model)
		{
			var result = await _context.SP_ActualizarAsistencias_Result
						  .FromSqlInterpolated(@$"
						  [dbo].[ActualizarEstatusAsistencia] 
						  @IdAsistencia={model.Id}, 
						  @EstatusAsistencia = {model.EstatusAsistencia},
						  @UsuarioId = {model.CodUsuario}")
						  .ToListAsync();

			var response = (ServerResponse) result.FirstOrDefault();

			if (model.EstatusAsistencia == 3 && response.Status)
			{
				var asistencia = await _repository.FindAsync(model.Id);

				if (asistencia != null)
				{
					await AddNewRowToExcel(asistencia);
				}				
			}

			return response;

		}


		public async Task CreateAsistenciaAgente(CreateAsistenciaAgente model)
		{

			List<TipoAsistencia> tipoAsistencias = new();

			foreach (var item in model.TipoAsistencias)
			{
				var tipo = await _context.TipoAsistencias.FindAsync(item);
				tipoAsistencias.Add(tipo);
			}

			string identificacion = model.EsExtranjero
				? model.Identificacion.Replace("-", "").ToUpper().Trim()
				: model.Identificacion.Replace("-", "").Trim();

			string telefono = model.Telefono.Trim().Replace("-", "");

			string placa = model.Placa.Trim().ToUpper();

			int usuarioId = 0;

			var newAsistencia = new Asistencia
			{
				// Ciudadano
				Identificacion = identificacion,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				Genero = model.Genero,
				Telefono = telefono,
				EsExtranjero = model.EsExtranjero,
				// Vehiculo
				VehiculoTipoId = model.VehiculoTipoId,
				VehiculoColorId = model.VehiculoColorId,
				VehiculoModeloId = model.VehiculoModeloId,
				VehiculoMarcaId = model.VehiculoMarcaId,
				Placa = placa,
				// asistencia (sin coordenadas)
				MunicipioId = model.MunicipioId,
				ProvinciaId = model.ProvinciaId,
				Direccion = model.Direccion,
				Coordenadas = model.Coordenadas,
				UnidadMiembroId = model.UnidadMiembroId,
				ReportadoPor = (model.reportadoPor == 0 ? ReportadoPor.AgenteCampo : model.reportadoPor),
				EstatusAsistencia = (model.FueCompletada ? EstatusAsistencia.COMPLETADA : EstatusAsistencia.EN_CURSO),
				UsuarioId = usuarioId,
				TipoAsistencias = tipoAsistencias,
				Comentario = model.Comentario,
				Imagenes = model.Imagenes,
				Estatus = model.FueCompletada,
				FechaCreacion = DateTime.Now.AddHours(-4)
			};

			if(model.FueCompletada)
			{
				newAsistencia.TiempoLlegada = DateTime.Now.AddHours(-4);
				newAsistencia.TiempoCompletada = DateTime.Now.AddHours(-4);
				newAsistencia.FechaModificacion = DateTime.Now.AddHours(-4);
			}

			await _repository.AddAsync(newAsistencia);

			if (model.FueCompletada)
			{
				await AddNewRowToExcel(newAsistencia);
			}
		}

		private bool checkFieldsHoldValue(string field)
		{
			return String.IsNullOrEmpty(field) || String.IsNullOrEmpty(field.Trim());
		}

		public async Task<List<SP_AsistenciaAsignadaUnidad>> GetAsistenciasAsignadaAUnidad(string ficha, int estatusAsistencia)
		{

			var results = await _context.SP_AsistenciaAsignadaUnidad_Result
						.FromSqlInterpolated($"[dbo].[AsistenciasAsignadasPorUnidad] @ficha={ficha}, @estatusAsistencia={estatusAsistencia}")
						.ToListAsync();			

			return results;

		}

		public SP_ContadorAsistenciasPorUnidad GetTotalAsistenciasUnidad(int unidadMiembroId)
		{
			return _context.SP_ContadorAsistenciasPorUnidad_Result
				.FromSqlInterpolated($"[dbo].[ContadorAsistenciasPorUnidad] {unidadMiembroId}")
				.ToList()[0];
		}
		

		public async Task<List<SP_ReporteEstadisticoUnidadTramoApp>> GetMetricasAsistenciasUnidadByTramo(int tramoId)
		{
			return await _context.SP_ReporteEstadisticoUnidadTramoApp_Result
				.FromSqlInterpolated($"exec [dbo].[ReporteEstadisticoTramoApp] @tramoId={tramoId}")
				.ToListAsync();
		}

		public async Task<List<SP_ReporteEstadisticoTipoAsistenciaUnidadApp>> GetMetricasAsistenciasUnidadByTipo(int unidadId)
		{
			return await _context.SP_ReporteEstadisticoTipoAsistenciaUnidadApp_Result
				.FromSqlInterpolated($"exec [dbo].[ReporteEstadisticoUnidadApp] @unidadId={unidadId}")
				.ToListAsync();
		}

		public async Task<AsistenciaEditViewModel> GetAsistenciaEditViewModel(int Id)
		{
			var asistencia = await _repository
							.Select(x => new AsistenciaEditViewModel
							{
								// Ciudadano
								Id = x.Id,
								Identificacion = x.Identificacion,
								Nombre = x.Nombre,
								Apellido = x.Apellido,
								Genero = x.Genero,
								Telefono = x.Telefono,
								// Vehiculo
								VehiculoColorId = x.VehiculoColorId,
								VehiculoTipoId = x.VehiculoTipoId,
								VehiculoMarcaId = x.VehiculoMarcaId,
								VehiculoModeloId = x.VehiculoModeloId,
								Placa = x.Placa,
								// Ubicacion
								ProvinciaId = x.ProvinciaId,
								MunicipioId = x.MunicipioId,
								Direccion = x.Direccion,
								Comentario = x.Comentario,
								TipoAsistencias = new List<int>()
							})
							.SingleAsync(x => x.Id == Id);

			return asistencia;
		}

		public async Task CompletarInformacionAsistencia(AsistenciaEditViewModel model)
		{
			var entity = await _repository.FindAsync(model.Id);

			entity.Identificacion = model.Identificacion;
			entity.Nombre = model.Nombre;
			entity.Apellido = model.Apellido;
			entity.Telefono = model.Telefono;
			entity.Comentario = model.Comentario;

			entity.VehiculoTipoId = model.VehiculoTipoId;
			entity.VehiculoColorId = model.VehiculoColorId;
			entity.VehiculoMarcaId = model.VehiculoMarcaId;
			entity.VehiculoModeloId = model.VehiculoModeloId;

			entity.Placa = model.Placa;

			_context.Attach<Asistencia>(entity);
			_context.Entry<Asistencia>(entity).State = EntityState.Modified;

		}

		public List<SP_ReporteAsistenciasResult> GetResumenAsistenciasDiario()
		{
			return _context.SP_ReporteAsistencias_Result
				.FromSqlInterpolated($"[dbo].[CorteAsistenciasDiario]")
				.ToList();
		}

		public List<SP_ReporteAsistenciasDetalles> GetResumenAsistenciasPorFecha(DateFilter filter)
		{
			var initial = filter.InitialDate.ToString("yyyy-MM-dd");
			var final = filter.FinalDate.ToString("yyyy-MM-dd");
			return _context.SP_ReporteAsistenciasDetalles_Result
				.FromSqlInterpolated($"[dbo].[CorteAsistenciasDetallePorFecha] {initial}, {final}")
				.ToList();
		}


		public List<SP_ReporteAsistenciasDetalles> GetResumenAsistenciasDetalles()
		{
			return _context.SP_ReporteAsistenciasDetalles_Result.FromSqlInterpolated($"dbo.CorteAsistenciasDetalle").ToList();
		}

		public async Task<IList<string>> GetImagenesAsistencia(int id) => (await _repository.FindAsync(id)).Imagenes;


		public async Task<bool> ReasignarAsistencia(UpdateReasignarAsistenciaDTO model)
		{
			var asistencia = await _repository.SingleOrDefaultAsync(x => x.Id == model.IdAsistencia);

			if (asistencia == null) return false;

			var transaction = await _context.Database.BeginTransactionAsync();

			int oldUnidadaMiembro = asistencia.UnidadMiembroId; // save old Id

			try
			{
				var newUnidadMiembro = _context.UnidadMiembro
									.Where(x => x.UnidadId.Equals(model.NewUnidadId))
									.OrderByDescending(x => x.FechaCreacion)
									.FirstOrDefault();

				// Update

				asistencia.UnidadMiembroId = newUnidadMiembro.Id;
				asistencia.FechaModificacion = DateTime.Now.AddHours(-4);
				_context.Attach<Asistencia>(asistencia);
				_context.Entry<Asistencia>(asistencia).State = EntityState.Modified;

				// Insert 

				await _context.HistoricoAsistencias.AddAsync(new HistoricoAsistencia { IdUnidadMiembro = oldUnidadaMiembro, IdAsistencia = asistencia.Id, UsuarioId = model.UsuarioId });

				await _context.SaveChangesAsync();

				await transaction.CommitAsync();

				return true;
			}
			catch (Exception)
			{
				await transaction.RollbackAsync();
				return false;
			}

		}

		public async Task<List<SP_HistorialAsistencia>> GetHistorialAsistencia(int idAsistencia)
		{
			return await _context.SP_HistorialAsistencias_Result
				.FromSqlInterpolated($"exec [dbo].[HistorialAsistencia] @IdAsistencia = {idAsistencia}").ToListAsync();
		}

		public async Task<List<SP_ReporteEstadisticoAsistencias>> GetReporteEstadisticoAsistencias(int filtrarPor, DateTime initialDate, DateTime finalDate)
		{
			return await _context.SP_ReporteEstadisticoAsistencias_Result
				.FromSqlInterpolated($"exec [dbo].[ReporteEstadisticoAsistencia] @filtrarPor={filtrarPor}, @initialDate={initialDate}, @finalDate={finalDate}")
				.ToListAsync();
		}

	}
}
