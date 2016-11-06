using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAyam.Models;
namespace WebAyam.DAL
{
    public class PemesananDAL : IDisposable
    {
        private AyamModel db = new AyamModel();

        public IQueryable<Pelanggan> GetData()
        {
            var result = from p in db.Pelanggan
                         orderby p.nama_pel
                         select p;
            return result;
        }

        public Pelanggan GetDataId(int id)
        {
            var result = (from p in db.Pelanggan
                          where p.id_pel == id
                          orderby p.nama_pel
                          select p).SingleOrDefault();
            //return result;
           if (result != null)
            {
                return result;
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