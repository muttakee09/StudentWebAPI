using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebAPI.Services
{
    public interface IAdminService
    {
        Admin CreateAdmin(string name, string password, int role);
        AuthUser Login(string username, string password);
    }
}
