using kutuphane2.Models;
using kutuphane2.utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutuphane2.Controllers
{
	public class KitapturuController : Controller
	{
		private readonly IKitapturuRepository _kitaptururepo;

		public IActionResult Index()
		{
			List<Kitapturu> objkitapturulist = _kitaptururepo.GetAll().ToList();//dbset türünde bir nesne
			return View(objkitapturulist);
		}
		public KitapturuController(IKitapturuRepository context)
		{
			_kitaptururepo = context;
		}
		public IActionResult Ekle()
		{
			return View();
		}
		
		[HttpPost]
		public IActionResult Ekle(Kitapturu kitapturu)
		{


			
			if (ModelState.IsValid)//doğrulama için gerekli
			{
				_kitaptururepo.Ekle(kitapturu);//bilgileri tabloya eklemesi için
				_kitaptururepo.kaydet();//bilgileri tabloya kaydetmek için
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
			Kitapturu? kitapturuvt = _kitaptururepo.Get(u=>u.Id==id);//eşit olan ıdyi getir  Expression<Func<T, bool>> filter demek 
			if (kitapturuvt == null)
			{
				return NotFound();
			}
			return View(kitapturuvt);
		}


		[HttpPost]
		public IActionResult Guncelle(Kitapturu kitapturu)
		{



			if (ModelState.IsValid)//doğrulama için gerekli
			{
				_kitaptururepo.Guncelle(kitapturu);//bilgileri tabloya eklemesi için
				_kitaptururepo.kaydet();//bilgileri tabloya kaydetmek için
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
			Kitapturu? kitapturuvt = _kitaptururepo.Get(u => u.Id == id);
			if (kitapturuvt == null)
			{
				return NotFound();
			}
			return View(kitapturuvt);
		}

		[HttpPost, ActionName("Sil") ]
		public IActionResult SilPost(int? id)
		{
			Kitapturu? kitapturu = _kitaptururepo.Get(u => u.Id == id);
			if (kitapturu == null)
			{
				return NotFound();
			}
			_kitaptururepo.Sil(kitapturu);//bilgileri tabloya eklemesi için
			_kitaptururepo.kaydet();
			TempData["basarili"] = "kitap türü silindi";



			return RedirectToAction("Index", "Kitapturu");
		}


	}
}
