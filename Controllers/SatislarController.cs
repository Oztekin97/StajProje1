using StajProje1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProje1.Controllers
{
    public class SatislarController : Controller
    {
        StokTakipEntities db = new StokTakipEntities();
        // GET: Satislar
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SATIS satis)
        {
            db.SATIS.Add(satis);
            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-VKU0E66J;Initial Catalog=StokTakip;Integrated Security=True");
            SqlCommand komut = new SqlCommand("UPDATE URUN SET STOK=STOK-@adet WHERE URUNID=@id",baglanti);
            komut.Parameters.AddWithValue("adet",satis.ADET);
            komut.Parameters.AddWithValue("@id", satis.URUN);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}