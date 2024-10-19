namespace WebApplication1AGRO.Model
{
    public class Contacts
    {
        public required int Contact_id { get; set; }
        public required string Data { get; set; }
        public required int User_id { get; set; }
        public required Users Users { get; set; }
         public required int DataType_id { get; set; }
        public required DataTypes DataTypes { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
