using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAyam.Models;
using WebAyam.DAL;

namespace WebAyam.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            using (BarangDAL brg = new BarangDAL())
            {
                var result = brg.GetData().ToList();
                return View(result);
            }
        }

        public ActionResult Details(int id)
        {
            using (BarangDAL brg = new BarangDAL())
            {
                var result = brg.GetDataId(id);
                return View(result);
            }
        }
    }
}