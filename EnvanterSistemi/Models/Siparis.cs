namespace EnvanterSistemi.Models
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }

        // Navigation Property
        public ICollection<SiparisDetay> SiparisDetaylar { get; set; }
    }
}
