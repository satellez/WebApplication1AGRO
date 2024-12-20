﻿namespace WebApplication1AGRO.Model
{
    public class Offers
    {
        public required int Offer_id { get; set; }
        public required int ProdDeta_id { get; set; }
        public required ProductDetails ProductDetails { get; set; }
        public required int QuantityOffer { get; set; }
        public required int FinalPrice { get; set; }
        public required DateTime StartOffer { get; set; }
        public required DateTime EndOffer { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
