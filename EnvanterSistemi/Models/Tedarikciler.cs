using System;
using System.Collections.Generic;

namespace EnvanterSistemi.Models;

public partial class Tedarikciler
{
    public int TedarikciId { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public string? Telefon { get; set; }

    public string? Adres { get; set; }

    public bool AktifMi { get; set; }

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
