using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAyam.Models;
namespace WebAyam.DAL
{
    public class KecamatanDAL : IDisposable

    {
        private AyamModel db = new AyamModel();

        public IQueryable<Master_kec> GetData()
        {
            var results = from k in db.Master_kec
                          orderby k.nama_kec ascending
                          select k;
            return results;
        }

        public Master_kec GetDataByID(int id_kec)
        {
            var result = (from k in db.Master_kec
                          where k.id_kec == id_kec
                          select k).SingleOrDefault();
            return result;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}