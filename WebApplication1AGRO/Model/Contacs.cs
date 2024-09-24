namespace WebApplication1AGRO.Model
{
    public class Contacs
    {
        public required int Contact_id { get; set; }
        public required string Data { get; set; }
        public required Users User_id { get; set; }

        public required DataTypes DataType_id { get; set; }
        
    }
}
