using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;

namespace Infrastructure.Helpers
{
	public class Specification<T> : ISpecifaction<T> where T : class
	{
		public Expression<Func<T, bool>> GetFilterPredicate(Expression<Func<T, bool>> expression)
		{
			return expression;
		}
	}
}
