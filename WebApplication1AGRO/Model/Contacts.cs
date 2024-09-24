namespace WebApplication1AGRO.Model
{
    public class Contacts
    {
        public required int Contact_id { get; set; }
        public required string Data { get; set; }
        public required Users User_id { get; set; }

        public required DataTypes DataType_id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
