using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAyam.Models;
using WebAyam.DAL;
namespace WebAyam.Controllers
{
    public class KecamatanController : Controller
    {
        // GET: Kecamatan
        private AyamModel db = new AyamModel();
        
        public ActionResult Index()
        {
            using (KecamatanDAL service = new KecamatanDAL())
            {
                var kec = service.GetData().ToList();
         

                return View(kec);
            }
        }
    }
}