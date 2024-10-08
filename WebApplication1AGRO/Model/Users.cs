﻿namespace WebApplication1AGRO.Model
{
    public class Users
    {
        public required int User_id { get; set; }
        public required string Names { get; set; }
        public required string Last_names { get; set; }
        public required string Document_number { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required DateTime Born_date { get; set; }
        public required UserTypes UserTypes { get; set; }
        public required Documents Document_types { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}