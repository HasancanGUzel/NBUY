using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryListDto
    {
        public List<Category> Categories { get; set; }//bunu web katmnında bizim direk entity ler ile iletişime geçmesinlerde biz aracı oluşturalım diye yaptık
        // yani Categories adında category listesi tutan dto tanımladık
    }
}
