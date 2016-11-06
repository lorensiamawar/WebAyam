namespace WebAyam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCarts
    {
        [Key]
        public int RecordID { get; set; }

        public string CartID { get; set; }

        public int Quantity { get; set; }

        [DisplayName("ID Barang")]
        public int id_barang { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Barang Barang { get; set; }
    }
}
