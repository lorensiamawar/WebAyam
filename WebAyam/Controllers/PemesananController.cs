using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAyam.DAL;
using WebAyam.Models;
namespace WebAyam.Controllers
{
    public class PemesananController : Controller
    {
        // GET: Pemesanan
        public ActionResult Index()
        {
            using (PemesananDAL svPelanggan = new PemesananDAL())
            {
                var results = svPelanggan.GetData().ToList();
                return View(results);
            }
            
        }

        public ActionResult Create()
        {
            var lstKec = new List<SelectListItem>();
            using (KecamatanDAL svKec = new KecamatanDAL())
            {
                foreach (var kec in svKec.GetData())
                {
                    lstKec.Add(new SelectListItem
                    {
                        Value = kec.id_kec.ToString(),
                        Text = kec.nama_kec
                    });
                }
                ViewBag.Kecamatan = lstKec;
            }

            return View();
        }
    }
}