using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MarcasController : GenericController<VehiculoMarca>
	{
		public MarcasController(IUnitOfWork unitOfWork, ISpecifaction<VehiculoMarca> specifaction) : base(unitOfWork, specifaction)
		{
			_predicate = x => x.Nombre.Contains(_searchTerm) &&  x.Estatus == _status;
		}
	}
}
