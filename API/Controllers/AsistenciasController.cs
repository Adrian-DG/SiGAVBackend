using Application.DataAccess;
using Domain.Entities;
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
				var response = _response.GetResponse(await _uow.CommitChangesAsync());
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
		[HttpGet("all/{ficha}")]
		public async Task<IActionResult> GetAsistenciasAsignadaAUnidad([FromRoute] string ficha)
		{
			try
			{
				var result = await _asistencias.GetAsistenciasAsignadaAUnidad(ficha);
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

		[HttpGet("reporte/resumen_diario")]
		public IActionResult GetReporteResumenAsistenciasDiario()
		{
			try
			{
				var result = _asistencias.GetResumenAsistenciasDiario();

				var stream = new MemoryStream();

				using (var excel = new ExcelPackage(stream))
				{
					var worksheet = excel.Workbook.Worksheets.Add("Resumen");
					var namedStyle = excel.Workbook.Styles.CreateNamedStyle("HyperLink");
					namedStyle.Style.Font.UnderLine = true;
					namedStyle.Style.Font.Color.SetColor(Color.Blue);

					worksheet.Cells["A1"].Value = "Resumen Asistencias Diario";

					using (var header = worksheet.Cells["A1:D1"])
					{
						header.Merge = true;
						header.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
						header.Style.Font.Size = 20;
						header.Style.Font.Bold = true;
					}

					// Fecha de impresion (datos)
					var fecha = worksheet.Cells["A3"];
					fecha.Value = "Fecha Impresión";
					fecha.Style.Font.Bold = true;
					string printDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
					worksheet.Cells["B3"].Value = printDate;

					// nota (advertencia)
					var disclaimer = worksheet.Cells["A5"];
					disclaimer.Merge = true;
					disclaimer.Style.Font.Bold = true;
					disclaimer.LoadFromText("Nota: Este documento, pretende servir como apoyo para realizar el corte de las asistencias realizadas.");

					// Table header 
					worksheet.Cells["A7"].Value = "Region";
					worksheet.Cells["B7"].Value = "Categoria";
					worksheet.Cells["C7"].Value = "Tipo";
					worksheet.Cells["D7"].Value = "Total";

					var tableHeader = worksheet.Cells["A7:D7"];
					tableHeader.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					tableHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					tableHeader.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(38, 46, 133));
					tableHeader.Style.Font.Color.SetColor(Color.White);
					tableHeader.Style.Font.Bold = true;

					// Data rows 
					var startRow = worksheet.Cells["A8:D8"];
					startRow.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
					startRow.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					startRow.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
					startRow.LoadFromCollection(result);

					excel.Workbook.Properties.Title = "Resumen Diario";
					excel.Workbook.Properties.Author = "Admin";
					excel.Workbook.Properties.Subject = "Resumen Asistencias";
					// save the new spreadsheet
					excel.Save();

				}

				stream.Position = 0;
				return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"resumen_asistencia_diario_{DateTime.Now.ToString("dd-MM-yyyy")}");
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

				var stream = new MemoryStream();

				using (var excel = new ExcelPackage(stream))
				{
					var worksheet = excel.Workbook.Worksheets.Add("Resumen");
					var namedStyle = excel.Workbook.Styles.CreateNamedStyle("HyperLink");
					namedStyle.Style.Font.UnderLine = true;
					namedStyle.Style.Font.Color.SetColor(Color.Blue);

					const int startRow = 5;
					var row = startRow;

					worksheet.Cells["A1"].Value = "Resumen Asistencias";

					using (var header = worksheet.Cells["A1:C1"])
					{
						header.Merge = true;
						header.Style.Font.Color.SetColor(Color.White);
						header.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
						header.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
						header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
					}

					worksheet.Cells["A3"].Value = "Fecha";
					string printDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"); 
					worksheet.Cells["B3"].Value = printDate;

					foreach (var item in result)
					{
						worksheet.Cells[row, 1].Value = item.Region;
						worksheet.Cells[row, 2].Value = item.CategoriaAsistencia;
						worksheet.Cells[row, 3].Value = item.TipoAsistencia;
						worksheet.Cells[row, 4].Value = item.Total;
					}

					excel.Workbook.Properties.Title = "User List";
					excel.Workbook.Properties.Author = "Mohamad Lawand";
					excel.Workbook.Properties.Subject = "User List";
					// save the new spreadsheet
					excel.Save();

				}

				stream.Position = 0;
				return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Resumen_Asistencias_{DateTime.Now.ToString("dd/MM/yyyy")}.xlsx");
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
                var stream = new MemoryStream();

				using (var excel = new ExcelPackage(stream))
				{
                    var worksheet = excel.Workbook.Worksheets.Add("Resumen");
                    var namedStyle = excel.Workbook.Styles.CreateNamedStyle("HyperLink");
                    namedStyle.Style.Font.UnderLine = true;
                    namedStyle.Style.Font.Color.SetColor(Color.Blue);

                    const int startRow = 5;
                    var row = startRow;

					var header = worksheet.Cells["A1:C1"]; 
					header.LoadFromText("Detalle de Asistencias");
                    header.Merge = true;
                    header.Style.Font.Color.SetColor(Color.White);
                    header.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    header.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));

					worksheet.Cells["A3"].Value = "Fecha Impresion";
					worksheet.Cells["B3"].Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

					var items = worksheet.Cells[startRow, 26].LoadFromCollection(result);

					excel.Save();

                    stream.Position = 0;
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Detalle_Asistencias_{DateTime.Now.ToString("dd/MM/yyyy")}.xlsx");

                }


            }
			catch (Exception)
			{
				throw;
			}
		}


    }
}
