﻿using kutuphane2.utility;
using System.Linq.Expressions;

namespace kutuphane2.Models
{
	public class KitapRepository : Repository<Kitap>, IKitapRepository
	{
		private readonly UygulamaDbContext _uygulamaDbContext;

		public KitapRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
		{
			_uygulamaDbContext=uygulamaDbContext;
		}

		public void Guncelle(Kitap kitap)
		{
			_uygulamaDbContext.Update(kitap);
		}

		public void kaydet()
		{
			_uygulamaDbContext.SaveChanges();
		}
	}
}
