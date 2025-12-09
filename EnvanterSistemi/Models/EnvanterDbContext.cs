using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace EnvanterSistemi.Models
{
    public class EnvanterDbContext: DbContext
    {
        public EnvanterDbContext(DbContextOptions<EnvanterDbContext> options)
            : base(options) { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkiler
            modelBuilder.Entity<Urun>()
                .HasOne(u => u.Kategori)
                .WithMany(k => k.Urunler)
                .HasForeignKey(u => u.KategoriID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Urun>()
                .HasOne(u => u.Tedarikci)
                .WithMany(t => t.Urunler)
                .HasForeignKey(u => u.TedarikciID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SiparisDetay>()
                .HasOne(sd => sd.Siparis)
                .WithMany(s => s.SiparisDetaylar)
                .HasForeignKey(sd => sd.SiparisID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SiparisDetay>()
                .HasOne(sd => sd.Urun)
                .WithMany(u => u.SiparisDetaylar)
                .HasForeignKey(sd => sd.UrunID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}