using System.ComponentModel.DataAnnotations;

namespace kutuphane2.Models
{
	public class Kitap
	{
		[Key]

		public int Id { get; set; }

		[Required]
		public string Kitapadi { get; set; }

		public string Tanim { get; set; }

		[Required]
		public string Yazar { get; set; }

		[Required]
		[Range(10, 5000)]
		public string Fiyat { get; set; }

	}
}
