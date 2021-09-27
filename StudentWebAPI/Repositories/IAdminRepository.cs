using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebAPI.Repositories
{
    public interface IAdminRepository
    {
        void CreateUser(Admin admin);
        bool CheckIfUsernameUnique(string username);
        AuthUser Login(string username, string password);
    }
}
