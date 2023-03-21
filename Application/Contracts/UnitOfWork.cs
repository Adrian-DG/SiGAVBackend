using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface UnitOfWork
	{
		Task<bool> CommitChangesAsync();

		IAuthRepository AuthRepository { get; }
	}
}
