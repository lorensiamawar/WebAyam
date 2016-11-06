namespace WebAyam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_Pesanan
    {
        [Key]
        [Column(Order = 0)]
        public int no_nota { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_barang { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal harga_sat { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int qty { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal total { get; set; }

        public virtual Barang Barang { get; set; }
    }
}
