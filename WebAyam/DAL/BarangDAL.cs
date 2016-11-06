using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAyam.Models;

namespace WebAyam.DAL
{
    public class BarangDAL : IDisposable
    {
        private AyamModel db = new AyamModel();

        public IQueryable<Barang> GetData()
        {
            var result = from b in db.Barang
                         orderby b.nama_barang
                         select b;
            return result;
        }

        public Barang GetDataId(int id)
        {
            var result = (from b in db.Barang
                          where b.id_barang == id
                          orderby b.nama_barang
                          select b).SingleOrDefault();
            //return result;
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Data Tidak Ditemukan !");
            }
        }

        public void Edit(Barang brg)
        {
            var result = GetDataId(brg.id_barang);
            if (result != null)
            {
                result.id_barang = brg.id_barang;
                result.nama_barang = brg.nama_barang;
                result.satuan = brg.satuan;
                result.gambar = brg.gambar;
                result.harga_jual = brg.harga_jual;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Tidak Ditemukan!");
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}