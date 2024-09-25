namespace WebApplication1AGRO.Model
{
    public class DataTypes
    {
        public required int DataType_id { get; set; }
        public  required string DataType_name { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
