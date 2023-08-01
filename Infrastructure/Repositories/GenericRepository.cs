using Domain.Abstraction;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T: ModelMetadata
	{
		protected readonly MainContext _context;
		protected readonly DbSet<T> _repository;
		public GenericRepository(MainContext mainContext)
		{
			_context = mainContext;
			_repository = _context.Set<T>();
		}

		public async Task<bool> ConfirmEntityExists(Expression<Func<T, bool>> predicate) => await _repository.AnyAsync(predicate);

		public async Task Delete(int id)
		{
			var entity = await GetByIdAsync(id);

			if (entity is null) return;

			_repository.Remove(entity);
		}

		public async Task<PagedData<T>> GetAllAsync(PaginationFilter filters, Expression<Func<T, bool>> predicate)
		{
			var results = await _repository
							.Where<T>(predicate)
							.Skip<T>((filters.Page - 1) * filters.Size)
							.Take<T>(filters.Size)
							.ToListAsync<T>();

			return new PagedData<T>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords(predicate)
			};
		}

		public async Task<ICollection<T>> GetAllAsync()
		{
			return await _repository.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _repository.FindAsync(id);
		}

		public async Task<int> GetTotalRecords(Expression<Func<T, bool>> predicate) => await _repository.CountAsync(predicate);

		public async Task<int> GetTotalRecords() => await _repository.CountAsync();

		public async Task InsertAsync(T entity)
		{
			await _repository.AddAsync(entity);
		}

		public void Update(T entity)
		{
			_context.Attach<T>(entity);
			_context.Entry<T>(entity).State = EntityState.Modified;
		}
	}
}
