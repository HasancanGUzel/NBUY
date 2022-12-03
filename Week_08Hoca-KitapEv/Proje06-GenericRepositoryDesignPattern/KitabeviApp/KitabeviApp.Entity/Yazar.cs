namespace KitabeviApp.Entity
{
    public class Yazar// KitabeviApp.Web içindeki models klasöründe bulunuyorlardı bizde katmanlı mimari yapısına uyarlamak için models leri entity klasörüne taşıdık
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? DogumYili { get; set; }
        public char Cinsiyet { get; set; }
    }
}