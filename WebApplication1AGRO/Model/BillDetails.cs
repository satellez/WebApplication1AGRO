namespace WebApplication1AGRO.Model
{
    public class BillDetails
    {
        public required int BillDeta_id { get; set; }
        public required Bills Bill_id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
