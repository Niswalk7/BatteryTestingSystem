using System;
using System.Collections.Generic;

namespace BatteryTestingSystem.Models
{
    public enum UserRole
    {
        Manufacturer,
        Admin,
        Supervisor,
        Operator
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            CreatedAt = DateTime.Now;
        }
    }
}