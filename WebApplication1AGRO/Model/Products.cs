namespace WebApplication1AGRO.Model
{
    public class Products
    {
        public required int Product_id { get; set; }
        public required string Product_name { get; set; }
        public required int Category_id { get; set; }
        public required ProductCategories ProductCategories { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
