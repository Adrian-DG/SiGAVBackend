using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PermisosController : GenericController<Permiso>
	{
		public PermisosController(IUnitOfWork unitOfWork, ISpecifaction<Permiso> specifaction) : base(unitOfWork, specifaction)
		{
		}
	}
}
