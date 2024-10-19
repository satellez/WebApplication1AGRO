using System.ComponentModel.DataAnnotations;

namespace WebApplication1AGRO.Model
{
    public class Users
    {
        
        public required int User_id { get; set; }
        public required string Names { get; set; }
        public required string Last_names { get; set; }
        public required string Email { get; set; }
        public required string Document_number { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required DateTime Born_date { get; set; }
        public int UserType_id { get; set; }
        public  UserTypes UserTypes { get; set; }
        public int Document_id { get; set; }
        public  Documents Documents { get; set; }
        public required DateTime Date { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}