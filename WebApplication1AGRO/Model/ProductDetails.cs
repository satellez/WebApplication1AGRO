namespace WebApplication1AGRO.Model
{
    public class ProductDetails
    {
        public required int ProdDeta_id { get; set; }
        public required int Product_id { get; set; }
        public required Products Products { get; set; }
        public required int QuantityStock { get; set; }
        public required int WeigthPoundsPack { get; set; }
        public required int StartingPrice { get; set; }
        public required int MinimunQuantity { get; set; }
        public required int User_id { get; set; }
        public required Users Users { get; set; }
        public required int CollectionPoint_id { get; set; }
        public required Collections Collections { get; set; }
        
        public required DateTime HarvestDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
