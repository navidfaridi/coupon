using Microsoft.EntityFrameworkCore;
using Noyanet.Coupon.Core.Interfaces;
using System.Linq.Expressions;

namespace Noyanet.Coupon.MsSql.Repository
{
	public class AsyncRepository<T> : IAsyncRepository<T> where T : class
	{
		protected CouponDbContext _dbContext;
        public AsyncRepository(CouponDbContext context)
        {
            _dbContext = context;
        }

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}
		public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null)
		{
			if (predicate == null) return _dbContext.Set<T>().AnyAsync();
			return _dbContext.Set<T>().AnyAsync(predicate);
		}
		public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
		{
			return await _dbContext.Set<T>().Where(predicate).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();
			if (disableTracking) query = query.AsNoTracking();

			if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

			if (predicate != null) query = query.Where(predicate);

			if (orderBy != null)
				return await orderBy(query).ToListAsync();
			return await query.ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();
			if (disableTracking) query = query.AsNoTracking();

			if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

			if (predicate != null) query = query.Where(predicate);

			if (orderBy != null)
				return await orderBy(query).ToListAsync();
			return await query.ToListAsync();
		}

		public virtual async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

		public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().Where(predicate).SingleOrDefaultAsync();

		public async Task<T> AddAsync(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			await SaveChangesAsync();
			return entity;
		}

		public async Task AddRangeAsync(List<T> entities)
		{
			_dbContext.Set<T>().AddRange(entities);
			await SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity, bool saveChanges = true)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			if (saveChanges) await SaveChangesAsync();
		}
		public async Task UpdateRangeAsync(List<T> entities)
		{
			foreach (var entity in entities)
				UpdateAsync(entity, false);

			await SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await SaveChangesAsync();
		}

		public async Task DeleteRangeAsync(IEnumerable<T> entities)
		{
			_dbContext.Set<T>().RemoveRange(entities);
			await SaveChangesAsync();
		}

		private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
	}
}
