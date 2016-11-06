namespace WebAyam.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AyamModel : DbContext
    {
        public AyamModel()
            : base("name=AyamModel")
        {
        }

        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<Master_kec> Master_kec { get; set; }
        public virtual DbSet<Nota_Pemesanan> Nota_Pemesanan { get; set; }
        public virtual DbSet<Pelanggan> Pelanggan { get; set; }
        public virtual DbSet<ShoppingCarts> ShoppingCarts { get; set; }
        public virtual DbSet<Detail_Pesanan> Detail_Pesanan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>()
                .Property(e => e.harga_jual)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Barang>()
                .HasMany(e => e.Detail_Pesanan)
                .WithRequired(e => e.Barang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Master_kec>()
                .HasMany(e => e.Pelanggan)
                .WithRequired(e => e.Master_kec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nota_Pemesanan>()
                .Property(e => e.ongkir)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pelanggan>()
                .Property(e => e.no_telp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pelanggan>()
                .HasMany(e => e.Nota_Pemesanan)
                .WithRequired(e => e.Pelanggan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detail_Pesanan>()
                .Property(e => e.harga_sat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Detail_Pesanan>()
                .Property(e => e.total)
                .HasPrecision(19, 4);
        }
    }
}
