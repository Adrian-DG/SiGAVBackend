using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class AsistenciasController : GenericController<Asistencia>
	{
		public AsistenciasController(IUnitOfWork unitOfWork, ISpecifaction<Asistencia> specifaction) : base(unitOfWork, specifaction)
		{
			_predicate = x => (x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm) || x.Identificacion.Contains(_searchTerm) || x.Identificacion.Contains(_searchTerm));
		}
	}
}
