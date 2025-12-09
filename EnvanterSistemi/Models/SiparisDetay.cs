namespace EnvanterSistemi.Models
{
    public class SiparisDetay
    {
        public int SiparisDetayID { get; set; }

        public int SiparisID { get; set; }
        public Siparis Siparis { get; set; }

        public int UrunID { get; set; }
        public Urun Urun { get; set; }

        public int Adet { get; set; }
        public decimal Fiyat { get; set; }  // Sipariş anındaki ürün fiyatı
    }
}
