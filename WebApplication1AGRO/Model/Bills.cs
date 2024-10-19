namespace WebApplication1AGRO.Model
{
    public class Bills
    {
        public required int Bill_id { get; set; }
        public required int User_id { get; set; }
        public required Users Users { get; set; }
        

        
        public required int Method_id { get; set; }
        public required PaymentMethods PaymentMethods { get; set; }
        public required DateTime Purchase_date { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
