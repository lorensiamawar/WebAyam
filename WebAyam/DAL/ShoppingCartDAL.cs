using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAyam.Models;

namespace WebAyam.DAL
{
    public class ShoppingCartDAL : IDisposable
    {
        private AyamModel db = new AyamModel();

        public IQueryable<ShoppingCarts> GetAllData(string username)
        {
            var results = from s in db.ShoppingCarts.Include("Barang")
                          where s.CartID == username
                          orderby s.RecordID ascending
                          select s;
            return results;

        }

        public ShoppingCarts GetItemByUser(string username, int id)
        {
            var result = (from s in db.ShoppingCarts
                          where s.CartID == username && s.id_barang == id
                          select s).FirstOrDefault();

            return result;
        }

        public void UbahCart(string tempUsername, string username)
        {
            var results = from s in db.ShoppingCarts
                          where s.CartID == tempUsername
                          select s;

            foreach (var sc in results)
            {
                sc.CartID = username;
            }
            db.SaveChanges();
        }

        public void TambahCart(ShoppingCarts sc)
        {
            var result = GetItemByUser(sc.CartID, sc.id_barang);
            if (result != null)
            {
                //update
                result.Quantity += 1;
            }
            else
            {
                //tambah baru
                db.ShoppingCarts.Add(sc);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void TambahNota(Nota_Pemesanan nota)
        {
            var result = GetItemByID(nota.no_nota);
            if (result != null)
            {
                //update
                result.Quantity += 1;
            }
            else
            {
                //tambah baru
                db.Nota_Pemesanan.Add(nota);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ShoppingCarts GetItemByID(int id)
        {
            var result = (from s in db.ShoppingCarts
                          where s.RecordID == id
                          select s).SingleOrDefault();
            return result;
        }

        public void Delete(int id)
        {
            var shop = GetItemByID(id);
            if (shop != null)
            {
                db.ShoppingCarts.Remove(shop);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Not Found!");
            }
        }

        public void Edit(ShoppingCarts shop)
        {
            var result = GetItemByID(shop.RecordID);
            if (result != null)
            {
                result.Quantity = shop.Quantity;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data not Found!");
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}