using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using WebAyam.DAL;
using WebAyam.Models;

namespace WebAyam.Controllers
{
    public class ShoppingCartsController : Controller
    {
        // GET: ShoppingCarts
        public ActionResult Index()
        {
            using (ShoppingCartDAL scService = new ShoppingCartDAL())
            {
                string username =
                    Session["username"] != null ? Session["username"].ToString() : string.Empty;
                return View(scService.GetAllData(username).ToList());
            }

        }
        public ActionResult AddToCart(int id)
        {
            //cek apakah user sudah login
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    var tempUser = Guid.NewGuid().ToString();
                    Session["username"] = tempUser;
                    //return RedirectToAction("Login", "Account");
                }
            }
            using (ShoppingCartDAL scService = new ShoppingCartDAL())
            {
                var newShoppingCart = new ShoppingCarts
                {
                    CartID = Session["username"].ToString(),
                    Quantity = 1,
                    id_barang = id,
                    DateCreated = DateTime.Now
                };
                scService.TambahCart(newShoppingCart);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            using (ShoppingCartDAL service = new ShoppingCartDAL())
            {
                var shop = service.GetItemByID(id);
                return View(shop);
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(ShoppingCarts shop)
        {
            using (ShoppingCartDAL service = new ShoppingCartDAL())
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int? id)
        {
                using (ShoppingCartDAL service = new ShoppingCartDAL())
                {
                    return RedirectToAction("Index");
                }
         }
        public ActionResult CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (ShoppingCartDAL service = new ShoppingCartDAL())
                {
                    string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;
                    return View(service.GetAllData(username).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

    }



}

