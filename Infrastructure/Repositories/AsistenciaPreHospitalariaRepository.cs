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
	public class AsistenciaPreHospitalariaRepository : GenericRepository<AsistenciaPreHospitalaria>
	{
		public AsistenciaPreHospitalariaRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<PagedData<AsistenciaPreHospitalariaViewModel>> GetAsistenciaPreHospitalaria(AsistenciaPaginationFilter filters, Expression<Func<AsistenciaPreHospitalaria, bool>> predicate)
		{
			var result = await _repository
						.Where(predicate)
						.Skip((filters.Page - 1) * filters.Size)
						.Take(filters.Size)
						.OrderByDescending(x => x.FechaCreacion)
						.Select(a => new AsistenciaPreHospitalariaViewModel
						{
							Id = a.Id,
							Identificacion = a.Identificacion,
							NombreCompleto = $"{a.Nombre} {a.Apellido}",
							Edad = a.Edad,
							Sexo = a.Sexo.ToString(),
							Telefono = a.Telefono,
							Nacionalidad = a.Nacionalidad.Nombre,
							Provincia = a.Provincia.Nombre,
							Municipio = a.Municipio.Nombre,
							Denominacion = a.Denominacion.Nombre,
							Ficha = a.Unidad.Ficha,
							FechaCreacion = a.FechaCreacion,
							Zona = a.Zona.ToString().Replace("_", " "),
							TipoAsistencia = a.TipoAsistencia.ToString().Replace("_", " "),
							TipoCausa = a.TipoCausa.ToString().Replace("_", " "),
							CausaTraslado = a.CausaTraslado.ToString().Replace("_", " "),
							ApoyoBrindado = a.ApoyoBrindado.ToString().Replace("_", " "),
						})
						.ToListAsync();

			return new PagedData<AsistenciaPreHospitalariaViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = result,
				TotalCount = await GetTotalRecords(predicate)
			};
		}


		public async Task CreateAsistenciaPreHospitalariaAgente(AsistenciaPreHospitalariaCreateDto asistenciaModel)
		{
			var unidadMiembro = await _context.UnidadMiembro.SingleOrDefaultAsync(x => x.Id == asistenciaModel.UnidadMiembroId);

			IList<SignosVitales> signosVitales = new List<SignosVitales>();

			signosVitales.Add(new SignosVitales
			{
				Temperatura = asistenciaModel.Temperatura,
				AperturaOcular = asistenciaModel.AperturaOcular,
				FrecuenciaCardiaca = asistenciaModel.FrecuenciaCardiaca,
				FrecuenciaRespiratoria = asistenciaModel.FrecuenciaRespiratoria,
				LlenadoCapilar = asistenciaModel.LlenadoCapilar,
				RespuestaMotora = asistenciaModel.RespuestaMotora,
				RespuestaVerbal = asistenciaModel.RespuestaVerbal,
				SaturacionParcialOxigeno = asistenciaModel.SaturacionParcialOxigeno,
				TensionArterialDiastolica = asistenciaModel.TensionArterialDiastolica,
				TensionArterialSistolica = asistenciaModel.TensionArterialSistolica
			});			

			var asistenciaPreHospitalaria = new AsistenciaPreHospitalaria
			{
				// Ciudadano 
				Identificacion = asistenciaModel.Identificacion,
				Nombre = asistenciaModel.Nombre,
				Apellido = asistenciaModel.Apellido,
				Sexo = asistenciaModel.Sexo,
				Edad = asistenciaModel.Edad,
				Telefono = asistenciaModel.Telefono,
				NacionalidadId = asistenciaModel.NacionalidadId,

				TipoCausa = asistenciaModel.TipoCausa,
				EsTraslado = asistenciaModel.EsTraslado,
				CausaTraslado = asistenciaModel.CausaTraslado,
				DespachadaPor = asistenciaModel.DespachadaPor,
				ApoyoBrindado = asistenciaModel.ApoyoBrindado,
				EsEventoCampo = asistenciaModel.EsEventoCampo,
				EsEventoEspecial = asistenciaModel.EsEventoEspecial,
				NombreEventoEspecial = asistenciaModel.NombreEventoEspecial,
				Zona = asistenciaModel.Zona,
				ProvinciaId = asistenciaModel.ProvinciaId,
				MunicipioId = asistenciaModel.MunicipioId,
				UnidadId = unidadMiembro.UnidadId,
				DenominacionId = unidadMiembro.Unidad.DenominacionId,
				HospitalId = asistenciaModel.HospitalId,
				PersonaRecibioEnHospital = asistenciaModel.PersonaRecibioEnHospital,
				AntecedentesMorbidos = asistenciaModel.AntecedentesMorbidos,
				TipoAsistencia = asistenciaModel.TipoAsistencia,
				DetalleAsistencia = asistenciaModel.DetalleAsistencia,
				SignosVitales = signosVitales,
				HallazgoPositivo = asistenciaModel.HallazgoPositivo,
				DiagnosticoPresuntivo = asistenciaModel.DiagnosticoPresuntivo,
				ProcedimientosRealizados = asistenciaModel.ProcedimientosRealizados,
				InsumosUtilizados = asistenciaModel.InsumosUtilizados,

				MedicoId = asistenciaModel.MedicoId ?? 0,
				Componente1Id = asistenciaModel.Componente1Id ?? 0,
				Componente2Id = asistenciaModel.Componente2Id ?? 0,
				ReguladorEmergeciaId = asistenciaModel.ReguladorEmergenciaId ?? 0,
				EstatusAsistencia = EstatusAsistencia.EN_CURSO
			};

			await _repository.AddAsync(asistenciaPreHospitalaria);
		}
	}
}
