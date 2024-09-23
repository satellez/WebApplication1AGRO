namespace WebApplication1AGRO.Model
{
    public class ProductDetails
    {
        public required int ProdDeta_id { get; set; }
        public required Product Product_id { get; set; }
        public required int Quantity_stock { get; set; }
        public required string weightPounds_pack { get; set; }
        public required int Starting_Price { get; set; }
        public required int Minimun_quantity { get; set; }
        public required Users Seller_Id { get; set; }
        public required  int Collection_Point_Id  { get; set; }
        public required DateTime Harvest_date { get; set; }

    }
}
