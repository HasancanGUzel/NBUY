namespace ShoppingApp.Web.Models.Dtos
{
    public class ProductDto // dtoları biz productları listelemek istiyoruz fakat prodcutların tüm bilgilerini listelemek istemiyorsak şimdi listelemk istediklerimi burada proplarını yazıcaz ve onları göndericez tüm product bilgilerini göndermek mantıksız.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
