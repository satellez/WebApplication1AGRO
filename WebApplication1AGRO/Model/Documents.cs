namespace WebApplication1AGRO.Model
{
    public class Documents
    {
        public  required int Document_id { get; set; }

        public required string Document_name { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
