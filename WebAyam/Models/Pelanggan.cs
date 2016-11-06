namespace WebAyam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pelanggan")]
    public partial class Pelanggan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelanggan()
        {
            Nota_Pemesanan = new HashSet<Nota_Pemesanan>();
        }

        [Key]
        public int id_pel { get; set; }

        [DisplayName("Nama")]
        [Required]
        [StringLength(20)]
        public string nama_pel { get; set; }
        [Required]
        [DisplayName("Alamat")]
        [StringLength(50)]
        public string alamat { get; set; }

        public int id_kec { get; set; }

        [DisplayName("No.Telp")]
        [Required]
        [StringLength(12)]
        public string no_telp { get; set; }

        public virtual Master_kec Master_kec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota_Pemesanan> Nota_Pemesanan { get; set; }
    }
}
