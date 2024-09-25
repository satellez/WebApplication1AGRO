namespace WebApplication1AGRO.Model
{
    public class PaymentMethods
    {
        public required int Method_id { get; set; }
        public required string Method_name { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
