using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeodev.Models;

namespace projeodev.Controllers
{
    public class DetayController : Controller
    {
        public DataContext db;
        public DetayController(DataContext _db)
        {
            db = _db;
        }

    
       
        public IActionResult DetaySayfa(int id)
        {

            var r = db.Resimler.Include(x => x.oda).Include(x => x.detay).First(x => x.ID == id);
       
            
            return View(r);
        }

        [HttpPost] 
        public IActionResult RezervasyonYap(int resimlerID,DateTime rezervasyonBaslangic,DateTime rezervasyonBitis)
        {
            
          //var  r = db.Resimler.Include(x => x.oda).Include(x => x.detay).First(x => x.ID == resimlerID);
          Resimler r = new Resimler();
            r = db.Resimler.Find(resimlerID);
           Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.BaslangıcTarih=rezervasyonBaslangic;
            rezervasyon.BitisTarih=rezervasyonBitis;
            rezervasyon.OdaID = r.OdaId;
            if ((SessionHelper.Session.GetString("KullanıcıID") != null))
            {
                rezervasyon.KullanıcıId = int.Parse(SessionHelper.Session.GetString("KullanıcıID"));
                try
                {
                    db.Rezervarsyon.Add(rezervasyon);
                    db.SaveChanges();
                    TempData["RezervasyonMesaj"] = "Rezervasyon Başarıyla Oluştu.";
                    return RedirectToAction("Index", "Home");
                    //Rezervasyon yapılıp ana sayfaya yönlendirecek ana sayfaya gidince kullanıcın anlaması için bilgilendirme mesajı eklenebilir


                }
                catch 
                {
                    return RedirectToAction("Index", "Home");
                    //Rezervasyon yapılamasada (bir hata çıkarsa) ana sayfaya yönlendirecek ana sayfaya gidince kullanıcın anlaması için bilgilendirme mesajı eklenebilir


                }
            }
            else
            {
                return RedirectToAction("Index","Home");
                //Kullanıcı bilgisi çekilmezse oturum kapatılmış olabilir rezervasyon yapılmayıp ana sayfaya yönlendirecek kullanıcın anlaması için bilgilendirme mesajı eklenebilir
            }


        }


        [HttpPost]
        public IActionResult RezervasyonIptal(int rezervasyonId)
        {
            var rezervasyon = db.Rezervarsyon.Find(rezervasyonId); // Rezervasyonu bul
            if (rezervasyon != null)
            {
                try
                {
                    db.Rezervarsyon.Remove(rezervasyon); // Rezervasyonu sil
                    db.SaveChanges(); // Değişiklikleri kaydet
                    TempData["RezervasyonMesaj"] = "Rezervasyon başarıyla iptal edildi.";
                }
                catch (Exception)
                {
                    TempData["RezervasyonMesaj"] = "Rezervasyon iptal edilemedi. Lütfen tekrar deneyin.";
                }
            }
            else
            {
                TempData["RezervasyonMesaj"] = "Rezervasyon bulunamadı.";
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult RezervasyonGuncelle(int id)
        {
            var rezervasyon = db.Rezervarsyon.Include(r => r.oda).FirstOrDefault(r => r.Id == id);
            if (rezervasyon == null)
            {
                return RedirectToAction("DetaySayfa", "Detay"); // Geçerli bir sayfaya yönlendirme
            }
            return View(rezervasyon);
        }
        [HttpPost]
        public IActionResult RezervasyonGuncelleKaydet(int Id, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            var rezervasyon = db.Rezervarsyon.FirstOrDefault(r => r.Id == Id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            rezervasyon.BaslangıcTarih = BaslangicTarih;
            rezervasyon.BitisTarih = BitisTarih;
            db.SaveChanges();

            TempData["SuccessMessage"] = "Rezervasyon başarıyla güncellendi.";

            return RedirectToAction("RezervasyonGuncelle", new { id = Id });
        }

















    }















}

