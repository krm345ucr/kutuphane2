namespace kutuphane2.Models
{
	public interface IKitapRepository : IRepository<Kitap>
	{
		void Guncelle(Kitap kitap);
		void kaydet();

	}
}
