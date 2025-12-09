namespace EnvanterSistemi.Models
{
    public class Tedarikci
    {
        public int TedarikciID { get; set; }
        public string FirmaAdi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        // Navigation Property
        public ICollection<Urun> Urunler { get; set; }
    }
}
