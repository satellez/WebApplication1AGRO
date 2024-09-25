namespace WebApplication1AGRO.Model
{
    public class UserTypes
    {
        public required int UserType_id { get; set; }
        public required string UserType_name { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
