using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeodev.Models;
using projeodev.ViewModels;

namespace projeodev.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        public HomeController(DataContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            indexVM indexVM = new indexVM()
            {
                resimlers = db.Resimler.Include(x => x.oda).Include(x=>x.detay),
                oda=db.Oda.Include(x=>x.DetayID)
                
            };
            TempData["KullaniciAdi"] = HttpContext.Session.GetString("FullName");
            return View(indexVM);
        }

        
     
    }
}
