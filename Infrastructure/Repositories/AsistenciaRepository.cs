﻿using Domain.ProcedureResults;
using Domain.ResultSetsModels;
using Domain.ViewModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class AsistenciaRepository : GenericRepository<Asistencia>
	{
		public AsistenciaRepository(MainContext mainContext) : base(mainContext)
		{
		}

		private async Task<int> GetUnidadMiembroId(int unidadId)
		{
			var results = await _context.UnidadMiembro
						.Where(x => x.UnidadId == unidadId)
						.OrderByDescending(x => x.FechaCreacion)
						.ToListAsync();

			return results.First().Id;
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
				UnidadMiembroId = unidadMiembroId,
				ReportadoPor = ReportadoPor.CallCenter,
				EstatusAsistencia = EstatusAsistencia.PENDIENTE,
				UsuarioId = model.UsuarioId,
				TipoAsistencias = tipoAsistencias,
				Comentario = model.Comentario,
				Estatus = false
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
						.OrderByDescending(a => a.FechaCreacion.Date)
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
							TipoAsistencias = a.TipoAsistencias.ToList(),
							Comentario = a.Comentario,
							ReportadaPor = a.ReportadoPor.ToString(),
							FechaCreacion = a.FechaCreacion,
							EstatusAsistencia = a.EstatusAsistencia.ToString(),
							Estatus = a.Estatus
						})
						.ToListAsync();

			return new PagedData<AsistenciaViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = result,
				TotalCount = await GetTotalRecords(filters.Status)
			};
		}

		public async Task ActualizarAsistencia(UpdateAsistencia model)
		{
			var asistencia = await _repository.FindAsync(model.Id);

			asistencia.EstatusAsistencia = model.EstatusAsistencia;
			asistencia.FechaModificacion = DateTime.Now;

			if ((int) model.EstatusAsistencia == 3)
			{
				asistencia.Estatus = true;
				asistencia.TiempoCompletada = DateTime.Now;
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
				Coordenadas = model.Coordenadas,
				UnidadMiembroId = model.UnidadMiembroId,
				ReportadoPor = model.reportadoPor,
				EstatusAsistencia = EstatusAsistencia.EN_CURSO,
				UsuarioId = model.UsuarioId,
				TipoAsistencias = tipoAsistencias,
				Comentario = model.Comentario,
				Imagenes = model.Imagenes,
				Estatus = false
			};

			await _repository.AddAsync(newAsistencia);
		}

		public async Task<List<AsistenciaViewModel>> GetAsistenciasAsignadaAUnidad(string ficha)
		{
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
							.Where(x => x.UnidadMiembro.Unidad.Ficha == ficha && x.FechaCreacion == DateTime.Now.Date)
							.OrderByDescending(a => a.FechaCreacion)
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
								TipoAsistencias = a.TipoAsistencias.ToList(),
								FechaCreacion = a.FechaCreacion,
								EstatusAsistencia = a.EstatusAsistencia.ToString(),
								ReportadaPor = a.ReportadoPor.ToString(),
								Comentario = a.Comentario,
								Estatus = a.Estatus 							
							})
							.ToListAsync();

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
						.Where(x => x.UnidadMiembro.Unidad.Tramo.Id == tramoId && x.FechaCreacion.Date == DateTime.Now.Date)
						.GroupBy(x => x.UnidadMiembro.Unidad.Ficha)
						.Select(x => new AsistenciasUnidadTramoViewModel { Ficha = x.Key, Total = x.Count() })
						.ToListAsync();

			return results;
		}

		public List<SP_ReporteAsistenciasResult> GetResumenAsistenciasDiario()
		{
			return _context.SP_ReporteAsistencias_Result
				.FromSqlInterpolated($"[dbo].[CorteAsistenciasDiario]")
				.ToList();
		}

		public List<SP_ReporteAsistenciasResult> GetResumenAsistenciasPorFecha(DateFilter filter)
		{
			var initial = filter.InitialDate.ToString("yyyy-MM-dd");
			var final = filter.FinalDate.ToString("yyyy-MM-dd");
			return _context.SP_ReporteAsistencias_Result
				.FromSqlInterpolated($"[dbo].[CorteAsistencias] {initial}, {final}")
				.ToList();
		}

	}
}
