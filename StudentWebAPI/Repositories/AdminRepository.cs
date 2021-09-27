using StudentWebAPI.Models;
using StudentWebAPI.Services;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PetaPoco.Database _dataContext;
        private readonly IJwtUtils _jwtUtils;

        public AdminRepository(IJwtUtils jwtUtils)
        {
            _dataContext = new PetaPoco.Database("studentdbstring");
            _jwtUtils = jwtUtils;
        }
        public bool CheckIfUsernameUnique(string username)
        {
            var users = _dataContext.Query<Admin>(
                "SELECT * FROM Users WHERE Name = @0", $"{username}").ToList();
            return users.Count <= 0;
        }

        public void CreateUser(Admin admin)
        {
            _dataContext.Insert("users", "Id", admin);
        }

        public AuthUser Login(string username, string password)
        {
            var user = _dataContext.Query<Admin>(
                "SELECT * FROM Users WHERE Name = @0", $"{username}").SingleOrDefault();
            if (user != null)
            {
                if (password == user.Password)
                {
                    string token = _jwtUtils.GenerateToken(user);
                    AuthUser authUser = new AuthUser(token, user.Name, user.Role);
                    return authUser;

                }
            }
            return null;
        }
    }
}