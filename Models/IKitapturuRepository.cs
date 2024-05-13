namespace kutuphane2.Models
{
	public interface IKitapturuRepository : IRepository<Kitapturu>
	{
		void Guncelle(Kitapturu kitapturu);
		void kaydet();

	}
}
