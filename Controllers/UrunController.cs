using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajProje1.Models.Entity;
namespace StajProje1.Controllers
{
    public class UrunController : Controller
    {
        StokTakipEntities db = new StokTakipEntities();
        // GET: Urun
        public ActionResult Index(string p)
        {
            var liste = from d in db.URUN select d;
            if (!string.IsNullOrEmpty(p))
            {
                liste = liste.Where(m => m.URUNAD.Contains(p));
            }
            return View(liste.ToList());
        }
        [HttpGet]
        public ActionResult EKLE()
        {
            List<SelectListItem> degerler = (from i in db.KATEGORI.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString()}).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult EKLE(URUN urun)
        {
            var kategori = db.KATEGORI.Where(m => m.KATEGORIID == urun.KATEGORI.KATEGORIID).FirstOrDefault();
            urun.KATEGORI = kategori;
            db.URUN.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.URUN.Find(id);
            db.URUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var urun = db.URUN.Find(id);
            return View("GUNCELLE", urun);
        }
        [HttpPost]
        public ActionResult GUNCELLE(URUN urun)
        {
            var guncelUrun = db.URUN.Find(urun.URUNID);
            guncelUrun.URUNAD = urun.URUNAD;
            guncelUrun.MARKA = urun.MARKA;
            guncelUrun.URUNKATEGORI= urun.URUNKATEGORI;
            guncelUrun.FIYAT = urun.FIYAT;
            guncelUrun.STOK = urun.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}