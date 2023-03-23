using Application.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AuthController : ControllerBase
	{
		private readonly IUnitOfWork _uow;
		private readonly ServerResponse _reponse;
		public AuthController(IUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
			_reponse = new ServerResponse();
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO model)
		{
			try
			{
				if (!await _uow.AuthRepository.ConfirmUserExists(model.Username))
				{
					return Ok(_reponse.GetResponse(false, "Este usuario no existe o las credenciales son incorrectas!!"));
				}

				var rs = await _uow.AuthRepository.LoginUser(model);

				return Ok(rs);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
