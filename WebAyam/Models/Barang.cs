namespace WebAyam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barang")]
    public partial class Barang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barang()
        {
            Detail_Pesanan = new HashSet<Detail_Pesanan>();
        }

        [Key]
        [DisplayName("ID Barang")]
        public int id_barang { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nama Barang")]
        public string nama_barang { get; set; }

        [Required]
        [StringLength(6)]
        [DisplayName("Satuan")]
        public string satuan { get; set; }

        [Column(TypeName = "money")]
        public decimal harga_jual { get; set; }

        public int stok { get; set; }

        [StringLength(50)]
        [DisplayName("Gambar")]
        public string gambar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Pesanan> Detail_Pesanan { get; set; }
    }
}
