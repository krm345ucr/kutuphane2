using kutuphane2.Models;
using kutuphane2.utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutuphane2.Controllers
{
	public class KitapController : Controller
	{
		private readonly IKitapRepository _kitaprepo;

		public IActionResult Index()
		{
			List<Kitap> objkitaplist = _kitaprepo.GetAll().ToList();//dbset türünde bir nesne
			return View(objkitaplist);
		}
		public KitapController(IKitapRepository context)
		{
			_kitaprepo = context;
		}
		public IActionResult Ekle()
		{
			return View();
		}
		
		[HttpPost]
		public IActionResult Ekle(Kitap kitap)
		{


			
			if (ModelState.IsValid)//doğrulama için gerekli
			{
				_kitaprepo.Ekle(kitap);//bilgileri tabloya eklemesi için
				_kitaprepo.kaydet();//bilgileri tabloya kaydetmek için
				TempData["basarili"] = "kitap türü oluşturuldu";
				return RedirectToAction("Index","Kitapturu");

			}
			
			return View();
			
		}

		public IActionResult Guncelle(int? id)
		{
			if(id == null || id==0)
			{
				return NotFound();
			}
			Kitap? kitapvt = _kitaprepo.Get(u=>u.Id==id);//eşit olan ıdyi getir  Expression<Func<T, bool>> filter demek 
			if (kitapvt == null)
			{
				return NotFound();
			}
			return View(kitapvt);
		}


		[HttpPost]
		public IActionResult Guncelle(Kitap kitap)
		{



			if (ModelState.IsValid)//doğrulama için gerekli
			{
				_kitaprepo.Guncelle(kitap);//bilgileri tabloya eklemesi için
				_kitaprepo.kaydet();//bilgileri tabloya kaydetmek için
				TempData["basarili"] = "kitap türü güncellendi";

				return RedirectToAction("Index", "Kitapturu");

			}

			return View();

		}

		//get action  sil cshtml dosyasını getirir
		public IActionResult Sil(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Kitap? kitapvt = _kitaprepo.Get(u => u.Id == id);
			if (kitapvt == null)
			{
				return NotFound();
			}
			return View(kitapvt);
		}

		[HttpPost, ActionName("Sil") ]
		public IActionResult SilPost(int? id)
		{
			Kitap? kitap = _kitaprepo.Get(u => u.Id == id);
			if (kitap == null)
			{
				return NotFound();
			}
			_kitaprepo.Sil(kitap);//bilgileri tabloya eklemesi için
			_kitaprepo.kaydet();
			TempData["basarili"] = "kitap türü silindi";



			return RedirectToAction("Index", "Kitapturu");
		}


	}
}
