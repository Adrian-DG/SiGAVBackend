using Application.DataAccess;
using Domain.Entities;
using Domain.ProcedureResults;
using Domain.ResultSetsModels;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Drawing;
using System.Linq.Expressions;

namespace API.Controllers
{
	public class AsistenciasController : GenericController<Asistencia>
	{
		private readonly AsistenciaRepository _asistencias;
		public AsistenciasController(IUnitOfWork unitOfWork, ISpecifaction<Asistencia> specifaction) : base(unitOfWork, specifaction)
		{
			_asistencias = (AsistenciaRepository)_repository;
			_predicate = x => (x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm) || x.Identificacion.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[HttpPost("createR5")]
		public async Task<IActionResult> CreateAsistenciaR5([FromBody] CreateAsistenciaR5 model)
		{
			try
			{
				await _asistencias.CreateAsistenciaR5(model);
				var response = (await _uow.CommitChangesAsync())
					? new ServerResponse { Message = "Los cambios se guardaron correctamente !!", Status = true }
					: new ServerResponse { Message = "Error: Solo es posible asignar asistencias si la unidad esta conectada a la aplicación !!", Status = false };
				return Ok(response);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPost("create")]
		public async Task<IActionResult> CreateAsistenciaAgente([FromBody] CreateAsistenciaAgente model)
		{
			try
			{
				await _asistencias.CreateAsistenciaAgente(model);
				var response = _response.GetResponse(await _uow.CommitChangesAsync());
				return Ok(response.Status);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllAsistencias([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _asistencias.GetAllAsistencias(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut("actualizar")]
		public async Task<IActionResult> ActualizarAsistencia([FromBody] UpdateAsistencia model)
		{
			try
			{
				await _asistencias.ActualizarAsistencia(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPut("iniciar")]
		public async Task<IActionResult> IniciarAsistencia([FromBody] UpdateAsistencia model)
		{
			try
			{
				await _asistencias.ActualizarAsistencia(model);
				await _uow.CommitChangesAsync();
				return Ok();
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("contador")]
		public IActionResult GetTotalAsistenciasUnidad([FromQuery] int unidadMiembroId)
		{
			try
			{
				var result = _asistencias.GetTotalAsistenciasUnidad(unidadMiembroId);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("all/filterBy")]
		public async Task<IActionResult> GetAsistenciasAsignadaAUnidad([FromQuery] FilterAsistenciaUnidadDTO model)
		{
			try
			{
				var result = await _asistencias.GetAsistenciasAsignadaAUnidad(model.Ficha, model.EstatusAsistencia);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("metricas")]
		public async Task<IActionResult> GetMetricasAsistenciasUnidadByTramo([FromQuery] int tramoId)
		{
			try
			{
				var result = await _asistencias.GetMetricasAsistenciasUnidadByTramo(tramoId);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("edit/{id}")]
		public async Task<IActionResult> GetAsistenciaEditViewModel([FromRoute] int Id)
		{
			try
			{
				var result = await _asistencias.GetAsistenciaEditViewModel(Id);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPut("edit")]
		public async Task<IActionResult> CompletarInformacionAsistencia([FromBody] AsistenciaEditViewModel model)
		{
			try
			{
				await _asistencias.CompletarInformacionAsistencia(model);

				return Ok(await _uow.CommitChangesAsync());
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("reporte/resumen_diario")]
		public IActionResult GetReporteResumenAsistenciasDiario()
		{
			try
			{
				var result = _asistencias.GetResumenAsistenciasDiario();

				using (ExcelPackage package = new ExcelPackage())
				{
					var worksheet = package.Workbook.Worksheets.Add("Resumen Estadisticas Asistencias");

					// Encabezado
					var header = worksheet.Cells[1, 1];
					header.Style.Font.Bold = true;
					header.Style.Font.Size = 24;
					header.LoadFromText("Reporte Estadistico Asistencias");

					var disclaimer = worksheet.Cells[3, 1];
					disclaimer.Style.Font.Bold = true;
					disclaimer.LoadFromText("Este documento es el resumen detallado de todas las asistencias completadas durante el dia.");

					var printDate = worksheet.Cells[3, 4];
					printDate.Style.Font.Bold = true;
					printDate.LoadFromText("Fecha Impresion");

					worksheet.Cells[3, 5].LoadFromText($"{DateTime.Now.ToShortDateString()}");

					int rowIndex = 5;

					// Apply styling to column headers
					using (var range = worksheet.Cells[rowIndex, 1, rowIndex, 5])
					{
						range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
						range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(69, 75, 127));
						range.Style.Font.Bold = true;
						range.Style.Font.Color.SetColor(System.Drawing.Color.White);
					}

					// insert data to sheet
					worksheet.Cells[rowIndex, 1].LoadFromCollection(result, true);

					worksheet.Cells.AutoFitColumns();

					using (MemoryStream ms = new MemoryStream())
					{
						package.SaveAs(ms);
						byte[] file = ms.ToArray();
						return File(file, "	application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"reporte_estadistico_asistencias_{DateTime.Now.ToString("dd-MM-yyyy")}");
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}


		[HttpGet("reporte/resumen_fecha")]
		public IActionResult GetReporteResumenAsistenciasPorFecha([FromQuery] DateFilter filter)
		{
			try
			{
				var result = _asistencias.GetResumenAsistenciasPorFecha(filter);

				using (ExcelPackage package = new ExcelPackage())
				{
					var worksheet = package.Workbook.Worksheets.Add("Resumen de Asistencias");

					// Encabezado
					var header = worksheet.Cells[1, 1];
					header.Style.Font.Bold = true;
					header.Style.Font.Size = 24;
					header.LoadFromText("Reporte Detalle Asistencia");

					var disclaimer = worksheet.Cells[3, 1];
					disclaimer.Style.Font.Bold = true;
					disclaimer.LoadFromText($"Este documento es el resumen detallado de todas las asistencias completadas durante el período {filter.InitialDate.ToString("dd-MM-yyyy")} al {filter.FinalDate.ToString("dd-MM-yyyy")}");

					var printDate = worksheet.Cells[3, 4];
					printDate.Style.Font.Bold = true;
					printDate.LoadFromText("Fecha Impresion");

					worksheet.Cells[3, 5].LoadFromText($"{DateTime.Now.ToString("dd-MM-yyyy")}");

					int rowIndex = 5;

					// Apply styling to column headers
					using (var range = worksheet.Cells[rowIndex, 1, rowIndex, 28])
					{
						range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
						range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(69, 75, 127));
						range.Style.Font.Bold = true;
						range.Style.Font.Color.SetColor(System.Drawing.Color.White);
					}

					// insert data to sheet
					worksheet.Cells[rowIndex, 1].LoadFromCollection(result, true);

					worksheet.Cells.AutoFitColumns();

					using (MemoryStream ms = new MemoryStream())
					{
						package.SaveAs(ms);
						byte[] file = ms.ToArray();
						return File(file, "	application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"reporte_detalle_asistencias_período_{DateTime.Now.ToString("dd-MM-yyyy")}");
					}

				}


			}
			catch (Exception)
			{
				throw;
			}
		}



		[HttpGet("reporte/resumen_detalles")]
		public ActionResult GetResumenAsistenciasDetalles()
		{
			try
			{
				var result = _asistencias.GetResumenAsistenciasDetalles();

				using (ExcelPackage package = new ExcelPackage())
				{
					var worksheet = package.Workbook.Worksheets.Add("Resumen de Asistencias");

					// Encabezado
					var header = worksheet.Cells[1, 1];
					header.Style.Font.Bold = true;
					header.Style.Font.Size = 24;
					header.LoadFromText("Reporte Detalle Asistencia");

					var disclaimer = worksheet.Cells[3, 1];
					disclaimer.Style.Font.Bold = true;
					disclaimer.LoadFromText("Este documento es el resumen detallado de todas las asistencias completadas durante el dia.");

					var printDate = worksheet.Cells[3, 4];
					printDate.Style.Font.Bold = true;
					printDate.LoadFromText("Fecha Impresion");

					worksheet.Cells[3, 5].LoadFromText($"{DateTime.Now.ToShortDateString()}");

					int rowIndex = 5;

					// Apply styling to column headers
					using (var range = worksheet.Cells[rowIndex, 1, rowIndex, 28])
					{
						range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
						range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(69, 75, 127));
						range.Style.Font.Bold = true;						
						range.Style.Font.Color.SetColor(System.Drawing.Color.White);
					}

					// insert data to sheet
					worksheet.Cells[rowIndex, 1].LoadFromCollection(result, true);

					worksheet.Cells.AutoFitColumns();

					using (MemoryStream ms = new MemoryStream())
					{
						package.SaveAs(ms);
						byte[] file = ms.ToArray();
						return File(file, "	application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"reporte_detalle_asistencias_{DateTime.Now.ToString("dd-MM-yyyy")}");
					}

				}


			}
            catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("{id}/imagenes")]
		public async Task<IActionResult> GetImagenesAsistencia([FromRoute] int Id)
		{
			try
			{
				var result = await _asistencias.GetImagenesAsistencia(Id);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost("reasignar")]
		public async Task<IActionResult> ReasignarAsistencia([FromBody] UpdateReasignarAsistenciaDTO model)
		{
			try
			{
				var response = await _asistencias.ReasignarAsistencia(model);
				return response ? Ok(response) : BadRequest(response);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("historial")]
		public async Task<IActionResult> GetHistorialAsistencia([FromQuery] int IdAsistencia)
		{
			try
			{
				var result = await _asistencias.GetHistorialAsistencia(IdAsistencia);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

    }				
}
