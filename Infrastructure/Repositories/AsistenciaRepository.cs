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
				item.Tipo,
				item.Categoria,
				item.Unidad,
				item.Region,
				item.Provincia,
				item.Municipio,
				item.Tramo,
				item.Fecha
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

			foreach (var item in model.TipoAsistencias)
			{
				var excelModel = new AsistenciaExcelSheetModel()
				{
					Tipo = item.Nombre,
					Categoria = item.CategoriaAsistencia.ToString(),
					Unidad = unidadMiembro.Unidad.Denominacion,
					Region = unidadMiembro.Unidad.Tramo.RegionAsistencia.Nombre,
					Provincia = municipio.Provincia.Nombre,
					Municipio = municipio.Nombre,
					Tramo = unidadMiembro.Unidad.Tramo.Nombre,
					Fecha = DateTime.Now.ToString("d")
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

			var newAsistencia = new Asistencia
			{
				// Ciudadano
				Identificacion = model.Identificacion,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				Genero = model.Genero,
				Telefono = model.Telefono,
				EsExtranjero = model.EsExtranjero,
				// Vehiculo
				VehiculoTipoId = model.VehiculoTipoId.Equals(0) ? 1 : model.VehiculoTipoId,
				VehiculoColorId = model.VehiculoColorId.Equals(0) ? 1 : model.VehiculoColorId,
				VehiculoModeloId = model.VehiculoModeloId.Equals(0) ? 1 : model.VehiculoModeloId,
				VehiculoMarcaId = model.VehiculoMarcaId.Equals(0) ? 1 : model.VehiculoMarcaId,
				Placa = model.Placa,
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

		public async Task<PagedData<AsistenciaViewModel>> GetAllAsistencias(PaginationFilter filters, Expression<Func<Asistencia, bool>> predicate)
		{
			var result = await _repository
						// Vehiculo
						.Include(a => a.VehiculoTipo)
						.Include(a => a.VehiculoColor)
						.Include(a => a.VehiculoModelo)
						.Include(a => a.VehiculoMarca)
						// Unidad & Miembro & Tramo & Rango
						.Include(a => a.UnidadMiembro.Miembro)
						.Include(a => a.UnidadMiembro.Miembro.Rango)
						.Include(a => a.UnidadMiembro.Unidad)
						.Include(a => a.UnidadMiembro.Unidad.Tramo)
						.Include(a => a.UnidadMiembro.Unidad.TipoUnidad)
						// Ubicacion
						.Include(a => a.Municipio)
						.Include(a => a.Provincia)
						.Where(predicate)
						.OrderByDescending(a => a.FechaCreacion)
						.ThenByDescending(a => a.FechaCreacion.TimeOfDay)
						.Skip((filters.Page - 1) * filters.Size)
						.Take(filters.Size)
						.Select(a => new AsistenciaViewModel
						{
							Id = a.Id,
							// Ciudadano
							Identificacion = a.Identificacion,
							NombreCiudadano = String.Concat(a.Nombre, " ", a.Apellido),
							Telefono = a.Telefono,
							Genero = a.Genero.ToString(),
							EsExtranjero = a.EsExtranjero,
							// Vehiculo
							VehiculoTipo = a.VehiculoTipo.Nombre,
							VehiculoColor = a.VehiculoColor.Nombre,
							VehiculoModelo = a.VehiculoModelo.Nombre,
							VehiculoMarca = a.VehiculoMarca.Nombre,
							Placa = a.Placa,
							// Ubicacion
							Coordenadas = a.Coordenadas,
							Municipio = a.Municipio.Nombre,
							Provincia = a.Provincia.Nombre,
							Tramo = a.UnidadMiembro.Unidad.Tramo.Nombre,
							FichaUnidad = a.UnidadMiembro.Unidad.Ficha,
							DenominacionUnidad = a.UnidadMiembro.Unidad.Denominacion,
							TipoUnidad = a.UnidadMiembro.Unidad.TipoUnidad.Nombre,
							// Agente
							CedulaAgente = a.UnidadMiembro.Miembro.Cedula,
							NombreAgente = String.Concat(a.UnidadMiembro.Miembro.Nombre, " ", a.UnidadMiembro.Miembro.Apellido),
							RangoAgente = a.UnidadMiembro.Miembro.Rango.Nombre,
							Institucion = a.UnidadMiembro.Miembro.Institucion.ToString(),
							TipoAsistencias = a.TipoAsistencias.ToList(),
							Comentario = a.Comentario,
							ReportadaPor = a.ReportadoPor.ToString(),
							FechaCreacion = a.FechaCreacion,
							EstatusAsistencia = a.EstatusAsistencia.ToString(),
							Estatus = a.Estatus,
							PerteneceA = a.UnidadMiembro.Miembro.PerteneceA.ToString()
						})
						.ToListAsync();

			return new PagedData<AsistenciaViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = result,
				TotalCount = await GetTotalRecords(predicate)
			};
		}

		public async Task ActualizarAsistencia(UpdateAsistencia model)
		{
			var asistencia = await _repository.FindAsync(model.Id);

			asistencia.EstatusAsistencia = model.EstatusAsistencia;
			
			if((int)model.EstatusAsistencia == 2)
			{
				asistencia.TiempoLlegada = DateTime.Now;
				asistencia.UnidadMiembroId = (int) model.UnidadMiembroId;
			}
			
			asistencia.FechaModificacion = DateTime.Now.AddHours(-4);

			if ((int) model.EstatusAsistencia == 3)
			{
				asistencia.Estatus = true;
				asistencia.TiempoCompletada = DateTime.Now;
				asistencia.UsuarioId = (int) model.CodUsuario;

				// insert to excel
				await AddNewRowToExcel(asistencia);
			}			

			_context.Attach<Asistencia>(asistencia);
			_context.Entry<Asistencia>(asistencia).State = EntityState.Modified;
		}


		public async Task CreateAsistenciaAgente(CreateAsistenciaAgente model)
		{

			List<TipoAsistencia> tipoAsistencias = new();

			foreach (var item in model.TipoAsistencias)
			{
				var tipo = await _context.TipoAsistencias.FindAsync(item);
				tipoAsistencias.Add(tipo);
			}	

			var newAsistencia = new Asistencia
			{
				// Ciudadano
				Identificacion = model.Identificacion,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				Genero = model.Genero,
				Telefono = model.Telefono,
				EsExtranjero = model.EsExtranjero,
				// Vehiculo
				VehiculoTipoId = model.VehiculoTipoId,
				VehiculoColorId = model.VehiculoColorId,
				VehiculoModeloId = model.VehiculoModeloId,
				VehiculoMarcaId = model.VehiculoMarcaId,
				Placa = model.Placa,
				// asistencia (sin coordenadas)
				MunicipioId = model.MunicipioId,
				ProvinciaId = model.ProvinciaId,
				Direccion = model.Direccion,
				Coordenadas = model.Coordenadas,
				UnidadMiembroId = model.UnidadMiembroId,
				ReportadoPor = model.reportadoPor,
				EstatusAsistencia = EstatusAsistencia.EN_CURSO,
				UsuarioId = model.UsuarioId,
				TipoAsistencias = tipoAsistencias,
				Comentario = model.Comentario,
				Imagenes = model.Imagenes,
				Estatus = false,
				FechaCreacion = DateTime.Now.AddHours(-4)
			};

			await _repository.AddAsync(newAsistencia);
		}

		private bool checkFieldsHoldValue(string field)
		{
			return String.IsNullOrEmpty(field) || String.IsNullOrEmpty(field.Trim());
		}

		public async Task<List<AsistenciaViewModel>> GetAsistenciasAsignadaAUnidad(string ficha, int estatusAsistencia)
		{
			Expression<Func<Asistencia, bool>> predicate = x => x.UnidadMiembro.Unidad.Ficha == ficha && (int) x.EstatusAsistencia == estatusAsistencia;

			if (estatusAsistencia == 3) predicate = x => x.UnidadMiembro.Unidad.Ficha == ficha && (int) x.EstatusAsistencia == estatusAsistencia && x.TiempoCompletada.Date == DateTime.Now.Date;


			var results = await _repository
							.Include(a => a.VehiculoMarca)
							.Include(a => a.VehiculoModelo)
							.Include(a => a.VehiculoTipo)
							.Include(a => a.VehiculoColor)
							.Include(a => a.UnidadMiembro.Miembro)
							.Include(a => a.UnidadMiembro.Unidad)
							.Include(a => a.UnidadMiembro.Unidad.Tramo)
							.Include(a => a.UnidadMiembro.Miembro.Rango)
							.Include(a => a.Provincia)
							.Include(a => a.Municipio)
							.Where(predicate)
							.OrderByDescending(a => a.FechaCreacion.Date)
							.Select(a => new AsistenciaViewModel
							{
								Id = a.Id,
								// ciudadano
								Identificacion = a.Identificacion,
								NombreCiudadano = $"{a.Nombre} {a.Apellido}",
								Genero = a.Genero.ToString(),
								EsExtranjero = a.EsExtranjero,
								Telefono = a.Telefono,
								// vehiculo
								VehiculoColor = a.VehiculoColor.Nombre,
								VehiculoTipo = a.VehiculoTipo.Nombre,
								VehiculoMarca = a.VehiculoMarca.Nombre,
								VehiculoModelo = a.VehiculoModelo.Nombre,
								Placa = a.Placa,
								// agente
								Institucion = a.UnidadMiembro.Miembro.Institucion.ToString(),
								RangoAgente = a.UnidadMiembro.Miembro.Rango.Nombre,
								CedulaAgente = a.UnidadMiembro.Miembro.Cedula,
								NombreAgente = a.UnidadMiembro.Miembro.NombreCompleto(),
								// unidad
								FichaUnidad = a.UnidadMiembro.Unidad.Ficha,
								DenominacionUnidad = a.UnidadMiembro.Unidad.Denominacion,
								TipoUnidad = a.UnidadMiembro.Unidad.TipoUnidad.ToString(),
								// ubicacion
								Provincia = a.Provincia.Nombre,
								Municipio = a.Municipio.Nombre,
								Coordenadas = a.Coordenadas,
								Tramo = a.UnidadMiembro.Unidad.Tramo.Nombre,
								EsEmergencia = false,
								TipoAsistencias = a.TipoAsistencias.ToList(),
								FechaCreacion = a.FechaCreacion,
								EstatusAsistencia = a.EstatusAsistencia.ToString(),
								ReportadaPor = a.ReportadoPor.ToString(),
								Comentario = a.Comentario,
								Estatus = a.Estatus,
								TieneDatosCompletados = true
							})
							.ToListAsync();

			foreach(var item in results)
			{
				item.EsEmergencia = (int)item.TipoAsistencias[0].CategoriaAsistencia == 1;
			}

			return results;

		}

		public SP_ContadorAsistenciasPorUnidad GetTotalAsistenciasUnidad(int unidadMiembroId)
		{
			return _context.SP_ContadorAsistenciasPorUnidad_Result
				.FromSqlInterpolated($"[dbo].[ContadorAsistenciasPorUnidad] {unidadMiembroId}")
				.ToList()[0];
		}


		public async Task<List<AsistenciasUnidadTramoViewModel>> GetMetricasAsistenciasUnidadByTramo(int tramoId)
		{
			var results = await _repository
						.Include(x => x.UnidadMiembro)
						.Include(x => x.UnidadMiembro.Unidad)
						.Include(x => x.UnidadMiembro.Unidad.Tramo)						
						.Where(x => x.UnidadMiembro.Unidad.Tramo.Id == tramoId && x.FechaCreacion.Date == DateTime.Now.Date && (int) x.EstatusAsistencia == 3)
						.GroupBy(x => x.UnidadMiembro.Unidad.Ficha)
						.Select(x => new AsistenciasUnidadTramoViewModel { Ficha = x.Key, Total = x.Count() })
						.ToListAsync();

			return results;
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

	}
}
