using kutuphane2.utility;
using System.Linq.Expressions;

namespace kutuphane2.Models
{
	public class KitapturuRepository : Repository<Kitapturu>, IKitapturuRepository
	{
		private readonly UygulamaDbContext _uygulamaDbContext;

		public KitapturuRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
		{
			_uygulamaDbContext=uygulamaDbContext;
		}

		public void Guncelle(Kitapturu kitapturu)
		{
			_uygulamaDbContext.Update(kitapturu);
		}

		public void kaydet()
		{
			_uygulamaDbContext.SaveChanges();
		}
	}
}
