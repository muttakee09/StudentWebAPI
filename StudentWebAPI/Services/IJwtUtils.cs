using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebAPI.Services
{
    public interface IJwtUtils
    {
        string GenerateToken(Admin user);
        Encoded ValidateToken(string token);
    }

}
