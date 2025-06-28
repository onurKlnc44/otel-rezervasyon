using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projeodev.Models;

namespace projeodev.Controllers
{
    public class KullanıcıController : Controller
    {
        public DataContext db;
        public KullanıcıController(DataContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Kullanıcı kullanıcı)
        {


            Kullanıcı k = new Kullanıcı();
            // Kullanıcıyı veritabanına ekle
            k = kullanıcı;
           
            try
            {
                db.Kullanıcı.Add(kullanıcı);
                db.SaveChanges();
            }
            catch (Exception)
            {

                return View();
            }

            // Başarılı işlem sonrası giriş yap sayfasına yönlendir
            return RedirectToAction("GirisYap");
        }

        public IActionResult GirisYap()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(string mail,string sifre)
        {
            var kullanici=db.Kullanıcı.FirstOrDefault(x => x.Mail == mail && x.Sifre==sifre);
            if (kullanici==null)
            {
                TempData["Mesaj"] = "Kullanıcı Adı veya Parola Hatalı";
                

                return View();
            }
            HttpContext.Session.SetString("FullName",kullanici.Isim + " "+kullanici.Soyadi);
            HttpContext.Session.SetString("KullanıcıID", kullanici.Id.ToString());
          
            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        public IActionResult Detay(int kullaniciID)
        {
           
            var r = db.Rezervarsyon.Include(x => x.kullanıcı).Include(x => x.oda).Where(x => x.KullanıcıId ==kullaniciID);
           
            return View(r);
        }
        public IActionResult CikisYap()
        {

            HttpContext.Session.Remove("FullName");
            HttpContext.Session.Remove("KullanıcıID");

            return RedirectToAction("Index","Home");
        }

       

    }
}
