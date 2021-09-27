using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.ViewModel
{
    public class Encoded
    {
        public int Role;
        public int UserId;

        public Encoded(int role, int userId)
        {
            Role = role;
            UserId = userId;
        }
    }
}