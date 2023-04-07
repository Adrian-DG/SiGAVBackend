using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface IGenericRepository<T> where T : ModelMetadata
	{
		Task<ICollection<T>> GetAllAsync();
		Task<PagedData<T>> GetAllAsync(PaginationFilter filters, Expression<Func<T, bool>> predicate);
		Task<T> GetByIdAsync(int id);
		Task InsertAsync(T entity);
		void Update(T entity);
		Task Delete(int id);
		Task<int> GetTotalRecords(bool status);
	}
}
