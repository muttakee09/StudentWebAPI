using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public IHttpActionResult Login()
        {
            try
            {
                var name = HttpContext.Current.Request.Form["username"];
                var password = HttpContext.Current.Request.Form["password"];
                var user = _adminService.Login(name, password);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Signup()
        {
            try
            {
                var name = HttpContext.Current.Request.Form["username"];
                var password = HttpContext.Current.Request.Form["password"];
                var role = int.Parse(HttpContext.Current.Request.Form["role"]);
                _adminService.CreateAdmin(name, password, role);
                return Ok("User created successfully");
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
