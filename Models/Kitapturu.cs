using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kutuphane2.Models
{
	public class Kitapturu
	{
		[Key]//primary key
		public int Id { get; set; }
		[Required(ErrorMessage ="kitap türü adı boş bırakılamaz")]//notnull anlamına gelir
		[MaxLength(25)]

		[DisplayName("kitap türü adı")]//ekran adı gibi düşün
		public string Ad { get; set; }
	}
}
