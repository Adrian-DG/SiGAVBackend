using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class DenominacionesController : GenericController<Denominacion>
	{
		public DenominacionesController(IUnitOfWork unitOfWork, ISpecifaction<Denominacion> specifaction) : base(unitOfWork, specifaction)
		{
		}
	}
}
