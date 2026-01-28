using System;
using System.Collections.Generic;

namespace EnvanterSistemi.Models;

public partial class Siparisler
{
    public int SiparisId { get; set; }

    public string MusteriAdi { get; set; } = null!;

    public DateTime? SiparisTarihi { get; set; }

    public bool AktifMi { get; set; }

    public virtual ICollection<SiparisDetaylar> SiparisDetaylars { get; set; } = new List<SiparisDetaylar>();
}
