using System.Linq.Expressions;

namespace kutuphane2.Models
{
	public interface IRepository<T> where T : class
	{
		//T=>Kitapturu
		IEnumerable<T> GetAll(); //tümünü getir 
		T Get(Expression<Func<T ,bool>> filter);
		void Ekle(T entity);
		void Sil(T entity);
		void Silaralık(IEnumerable<T> entities);

	}
}
