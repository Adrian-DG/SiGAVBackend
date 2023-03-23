using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
	public interface ISpecifaction<T> where T : class
	{
		Expression<Func<T, bool>> GetFilterPredicate(Expression<Func<T, bool>> expression);
	}
}
