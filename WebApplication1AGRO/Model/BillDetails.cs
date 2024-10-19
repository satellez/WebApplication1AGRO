namespace WebApplication1AGRO.Model
{
    public class BillDetails
    {
        public required int BillDeta_id { get; set; }
        public required int Bill_id { get; set; }
        public required Bills Bills { get; set; }

        public required int Product_id { get; set; }
        public required Products Products  { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
