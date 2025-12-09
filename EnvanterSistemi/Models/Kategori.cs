namespace EnvanterSistemi.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        // Navigation Property
        public ICollection<Urun> Urunler { get; set; }
    }
}
