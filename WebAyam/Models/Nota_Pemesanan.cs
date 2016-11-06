namespace WebAyam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nota_Pemesanan
    {
        [Key]
        public int no_nota { get; set; }

        public int id_pel { get; set; }

        public DateTime tgl_nota { get; set; }

        [Column(TypeName = "money")]
        public decimal? ongkir { get; set; }

        public virtual Pelanggan Pelanggan { get; set; }
    }
}
