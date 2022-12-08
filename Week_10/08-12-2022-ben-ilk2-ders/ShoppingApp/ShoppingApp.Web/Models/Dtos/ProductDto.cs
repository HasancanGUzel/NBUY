namespace ShoppingApp.Web.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; } // resim için sonradan ekledik
        public DateTime DateAdded { get; set; }
    }
}
