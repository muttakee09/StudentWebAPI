using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.ViewModel
{
    public class AuthUser
    {
        public string Token;
        public string Name;
        public int Role;

        public AuthUser(string token, string name, int role)
        {
            Name = name;
            Role = role;
            Token = token;
        }
    }
}