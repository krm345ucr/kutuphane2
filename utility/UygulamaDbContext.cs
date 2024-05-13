using kutuphane2.Models;
using Microsoft.EntityFrameworkCore;

namespace kutuphane2.utility
{
	public class UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : DbContext(options)
	{
		//BURDA HER YAZDIĞIMIZ TABLOYA DÖNÜŞÜYOR
		public DbSet<Kitapturu> Kitapturu { get; set; }   //yeni tabloyu oluşturmak için yazılır
		public DbSet<Kitap> kitaps { get; set; }





	}
}
