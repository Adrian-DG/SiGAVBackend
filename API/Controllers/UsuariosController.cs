using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UsuariosController : GenericController<Usuario>
	{
		private readonly UsuariosRepository _usuarios;
		public UsuariosController(IUnitOfWork unitOfWork, ISpecifaction<Usuario> specifaction) : base(unitOfWork, specifaction)
		{
			_predicate = x => (x.Nombre.Contains(_searchTerm) ||  x.Apellido.Contains(_searchTerm) || x.Username.Contains(_searchTerm) || x.Cedula.Contains(_searchTerm)) && x.Estatus == _status;
			_usuarios = (UsuariosRepository) _repository;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllUsuarios([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = filters.SearchTerm is null ? "" : filters.SearchTerm;
				_status = filters.Status;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _usuarios.GetAllUsuariosAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}


		[HttpPost("create")]
		public async Task<IActionResult> CreateUsuario(CreateUserDTO model)
		{
			try
			{
				if (!await _usuarios.CreateUsuario(model)) return Ok(_response.GetResponse(false, "Este usuario ya esta en uso !!"));

				var response = _response.GetResponse(await _uow.CommitChangesAsync());

				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("{id}/details")]
		public async Task<IActionResult> GetUsuarioDetalles([FromRoute] int id)
		{
			try
			{
				var result = await _usuarios.GetUsuarioPermisoDetalle(id);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost("permisos/create")]
		public async Task<IActionResult> CreateUsuarioPermiso([FromBody] CreateUsuarioPermisoDTO model)
		{
			try
			{
				await _usuarios.AsignarPermiso(model);
				var response = _response.GetResponse(await _uow.CommitChangesAsync());
				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut("authorize")]
		public async Task<IActionResult> UpdateUsuarioEstatus([FromBody] int id)
		{
			try
			{
				await _usuarios.UpdateUsuarioEstatus(id);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
