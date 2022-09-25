using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajProje1.Models.Entity;

namespace StajProje1.Controllers
{
    public class KategoriController : Controller
    {
        StokTakipEntities db = new StokTakipEntities();
        // GET: Kategori
        public ActionResult Index(string p)
        {
            var liste = from d in db.KATEGORI select d;
            if (!string.IsNullOrEmpty(p))
            {
                liste = liste.Where(m => m.KATEGORIAD.Contains(p));
            }
            return View(liste.ToList());
        }
        [HttpGet]
        public ActionResult EKLE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EKLE(KATEGORI kategori)
        {
            db.KATEGORI.Add(kategori);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.KATEGORI.Find(id);
            db.KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var kategori = db.KATEGORI.Find(id);
            return View("GUNCELLE", kategori);
        }
        [HttpPost]
        public ActionResult GUNCELLE(KATEGORI ktg)
        {
            var kategori = db.KATEGORI.Find(ktg.KATEGORIID);
            kategori.KATEGORIAD = ktg.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}