namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class SearchQueryDto
    {
        public bool? IsHome { get; set; } // soru işaretsi koymmızın nedeni boş olabilir
        public bool? IsApproved { get; set; }
        public string SearchString { get; set; }
    }
}
