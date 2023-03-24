using Domain.ViewModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
						.Skip((filters.Page - 1) * filters.Size)
						.Take(filters.Size)
						.OrderByDescending(a => a.FechaCreacion)
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
							TipoAsistencias = a.TipoAsistencias.Select(x => new TipoAsistenciaViewModel { TipoAsistencia = x.Nombre, CategoriaAsistencia = x.CategoriaAsistencia.ToString() }).ToList(),
							Comentario = a.Comentario,
							ReportadaPor = a.ReportadoPor.ToString(),
							FechaCreacion = a.FechaCreacion,
							EstatusAsistencia = (int)a.EstatusAsistencia
						})
						.ToListAsync();

			return new PagedData<AsistenciaViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = result,
				TotalCount = await GetTotalRecords()
			};
		}
	}
}
