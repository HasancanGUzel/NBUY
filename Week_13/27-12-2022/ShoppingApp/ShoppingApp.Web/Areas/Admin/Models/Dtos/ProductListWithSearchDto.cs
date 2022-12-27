using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class ProductListWithSearchDto // productListDto ve SearchWueryDto yu birleştirdik çünkü bizim index viewımızda önceden ProductListDto tipinde gönderiyorduk ama ona ek olarak SearchQueryDto da gelmişti.
    {
        public List<ProductListDto> ProductListDtos { get; set; }
        public SearchQueryDto SearchQueryDto { get; set; }
        public List<SelectListItem>IsHomeList{ get; set; }
        public List<SelectListItem>IsApprovedList{ get; set; }
    }
}
