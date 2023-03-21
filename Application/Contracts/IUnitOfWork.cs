using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface IUnitOfWork
	{
		Task<bool> CommitChangesAsync();

		IAuthRepository AuthRepository { get; }
	}
}
