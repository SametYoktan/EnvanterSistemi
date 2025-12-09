using System;
using System.Collections.Generic;

namespace EnvanterSistemi.Models;

public partial class SiparisDetaylar
{
    public int SiparisDetayId { get; set; }

    public int SiparisId { get; set; }

    public int UrunId { get; set; }

    public int Adet { get; set; }

    public decimal Fiyat { get; set; }

    public virtual Siparisler Siparis { get; set; } = null!;

    public virtual Urunler Urun { get; set; } = null!;
}
