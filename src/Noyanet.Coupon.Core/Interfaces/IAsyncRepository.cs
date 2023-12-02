using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Noyanet.Coupon.Core.Interfaces
{
	public interface IAsyncRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);
		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
										Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
										string includeString = null,
										bool disableTracking = true);
		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
									   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
									   List<Expression<Func<T, object>>> includes = null,
									   bool disableTracking = true);
		Task<T> GetByIdAsync(int id);
		Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
		Task<T> AddAsync(T entity);
		Task AddRangeAsync(List<T> entities);
		Task UpdateAsync(T entity, bool saveChanges = true);
		Task UpdateRangeAsync(List<T> entities);
		Task DeleteAsync(T entity);
		Task DeleteRangeAsync(IEnumerable<T> entities);
	}
}
