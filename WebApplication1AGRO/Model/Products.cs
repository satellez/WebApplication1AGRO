namespace WebApplication1AGRO.Model
{
    public class Products
    {
        public required int Product_id { get; set; }
        public string Product_name { get; set; }
        public required ProductCategories Category_id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
