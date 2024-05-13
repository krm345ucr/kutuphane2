using kutuphane2.utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace kutuphane2.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly UygulamaDbContext _uygulamaDbContext;
		internal DbSet<T> dbSet; //dbset = _uygulamadbcontext.Kitapturleri

		public Repository(UygulamaDbContext uygulamaDbContext)
		{
			_uygulamaDbContext = uygulamaDbContext;
			this.dbSet = _uygulamaDbContext.Set<T>();
		}

		public void Ekle(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> sorgu = dbSet;
			sorgu=sorgu.Where(filter);
			return sorgu.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> sorgu = dbSet;
			return sorgu.ToList();
		}

		public void Sil(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Silaralık(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
	

}

