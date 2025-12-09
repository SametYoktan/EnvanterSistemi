namespace EnvanterSistemi.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public int StokMiktari { get; set; }

        // Foreign Keys
        public int? KategoriID { get; set; }
        public Kategori Kategori { get; set; }

        public int? TedarikciID { get; set; }
        public Tedarikci Tedarikci { get; set; }

        // Navigation Property
        public ICollection<SiparisDetay> SiparisDetaylar { get; set; }
    }
}
