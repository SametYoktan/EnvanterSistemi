using System;
using System.Collections.Generic;

namespace EnvanterSistemi.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public string? Aciklama { get; set; }

    public decimal Fiyat { get; set; }

    public int StokMiktari { get; set; }

    public int? KategoriId { get; set; }

    public int? TedarikciId { get; set; }

    public bool AktifMi { get; set; }

    public virtual Kategoriler? Kategori { get; set; }

    public virtual ICollection<SiparisDetaylar> SiparisDetaylars { get; set; } = new List<SiparisDetaylar>();

    public virtual Tedarikciler? Tedarikci { get; set; }
}
