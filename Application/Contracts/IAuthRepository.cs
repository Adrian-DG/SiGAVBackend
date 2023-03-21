using Domain.DTO;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface IAuthRepository
	{
		Task<bool> ConfirmUserExists(string username);
		Task<LoginResponse> LoginUser(LoginUserDTO model);
	}
}
