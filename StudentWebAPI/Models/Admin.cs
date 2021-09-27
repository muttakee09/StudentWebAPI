using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public Admin() { }

        public Admin(string name, string password, int role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
    }
}