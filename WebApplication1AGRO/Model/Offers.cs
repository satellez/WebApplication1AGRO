namespace WebApplication1AGRO.Model
{
    public class Offers
    {
        public required int Offer_id { get; set; }
        public required int ProdDeta_id { get; set; }
        public required int QuantityOffer { get; set; }
        public required string Final_Price { get; set; }
        public required DateTime Start_Date { get; set; }
        public required DateTime End_Date { get; set; }

    }
}
