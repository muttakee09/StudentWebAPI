using StudentWebAPI.Models;
using StudentWebAPI.Repositories;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public Admin CreateAdmin(string name, string password, int role)
        {
            bool unique = _adminRepository.CheckIfUsernameUnique(name);
            if (unique)
            {
                Admin user = new Admin(
                    name, password, role);
                _adminRepository.CreateUser(user);
                return user;
            }
            else
            {
                return null;
            }
           
        }

        public AuthUser Login(string username, string password)
        {
            AuthUser user = _adminRepository.Login(username, password);
            return user;
        }
    }
}