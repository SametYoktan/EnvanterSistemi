using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EnvanterSistemi.Models;

public partial class EnvanterContext : DbContext
{
    public EnvanterContext()
    {
    }

    public EnvanterContext(DbContextOptions<EnvanterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<SiparisDetaylar> SiparisDetaylars { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    public virtual DbSet<Tedarikciler> Tedarikcilers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SAMETYOKTAN;Database=EnvanterSistemi;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC926CDEDDB1");

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.AktifMi).HasDefaultValue(true);
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SiparisDetaylar>(entity =>
        {
            entity.HasKey(e => e.SiparisDetayId).HasName("PK__SiparisD__DA4BD832ABA7AFAE");

            entity.ToTable("SiparisDetaylar");

            entity.Property(e => e.SiparisDetayId).HasColumnName("SiparisDetayID");
            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.UrunId).HasColumnName("UrunID");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetaylars)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK_SiparisDetay_Siparis");

            entity.HasOne(d => d.Urun).WithMany(p => p.SiparisDetaylars)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_SiparisDetay_Urun");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BDD2B361FDA");

            entity.ToTable("Siparisler");

            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.AktifMi).HasDefaultValue(true);
            entity.Property(e => e.MusteriAdi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SiparisTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Tedarikciler>(entity =>
        {
            entity.HasKey(e => e.TedarikciId).HasName("PK__Tedarikc__E0B82CC172DBF98A");

            entity.ToTable("Tedarikciler");

            entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");
            entity.Property(e => e.Adres).HasColumnType("text");
            entity.Property(e => e.AktifMi).HasDefaultValue(true);
            entity.Property(e => e.FirmaAdi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PK__Urunler__623D364BEF15114C");

            entity.ToTable("Urunler");

            entity.Property(e => e.UrunId).HasColumnName("UrunID");
            entity.Property(e => e.Aciklama).HasColumnType("text");
            entity.Property(e => e.AktifMi).HasDefaultValue(true);
            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Urunler_Kategori");

            entity.HasOne(d => d.Tedarikci).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.TedarikciId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Urunler_Tedarikci");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
