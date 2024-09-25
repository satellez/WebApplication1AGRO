namespace WebApplication1AGRO.Model
{
    public class Bills
    {
        public required int Bill_id { get; set; }
        public required Users User_id2 { get; set; }

        public required DateTime Purchase_date { get; set; }
        public required PaymentMethods PayMeth_id { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
