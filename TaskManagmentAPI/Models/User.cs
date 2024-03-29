﻿namespace TaskManagmentAPI.Models
{
    public class User
    {
        
        public int UserId { get; set; } 
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


        public List<TaskItem> Tasks { get; set; }
    }

}
