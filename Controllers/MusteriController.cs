using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajProje1.Models.Entity;
namespace StajProje1.Controllers
{
    public class MusteriController : Controller
    {
        StokTakipEntities db = new StokTakipEntities();
        // GET: Musteri
        public ActionResult Index(string p)
        {
            var liste = from d in db.MUSTERI select d;
            if (!string.IsNullOrEmpty(p))
            {
                liste = liste.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(liste.ToList());
        }
        [HttpGet]
        public ActionResult EKLE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EKLE(MUSTERI musteri)
        {
            db.MUSTERI.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.MUSTERI.Find(id);
            db.MUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var musteri = db.MUSTERI.Find(id);
            return View("GUNCELLE", musteri);
        }
        [HttpPost]
        public ActionResult GUNCELLE(MUSTERI musteri)
        {
            var guncel = db.MUSTERI.Find(musteri.MUSTERIID);
            guncel.MUSTERIAD = musteri.MUSTERIAD;
            guncel.MUSTERISOYAD = musteri.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}