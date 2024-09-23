namespace WebApplication1AGRO.Model
{
    public class ProductDetails
    {
        public required int ProdDeta_id { get; set; }
        public required Products Product_id { get; set; }
        public required int QuantityStock { get; set; }
        public required int WeigthPoundsPack { get; set; }
        public required int StartingPrice { get; set; }
        public required int MinimunQuantity { get; set; }
        //public required Users User_id { get; set; }
        public required Collections CollectionPoint_id  { get; set; }
        public required DateTime HarvestDate { get; set; }
    }
}
