using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using weddingplanner.Models; 
using Microsoft.AspNetCore.Identity;

namespace weddingplanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext dbContext;
        public HomeController(WeddingContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(LoginAndReg Register)

        {
             if(TryValidateModel("regmodel"))
                {
                if(dbContext.Users.Any(u => u.Email == Register.regmodel.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("index",Register);
                }
                PasswordHasher<User> hasher= new PasswordHasher<User>();
                User newUser = new User
                {
                    FirstName = Register.regmodel.FirstName,
                    LastName = Register.regmodel.LastName,
                    Email = Register.regmodel.Email,
                    Password = hasher.HashPassword(Register.regmodel, Register.regmodel.Password)
                };
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("CurrentUser", Register.regmodel.UserId);
                return RedirectToAction("DashboardView", "Wedding");
            }
            return View("Index", Register);
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginAndReg user)
        {
            if(TryValidateModel("logmodel"))
                {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == user.logmodel.Email);
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("index", user);
                }
            
                // Initialize hasher object
                var hasher = new PasswordHasher<Login>();
            
                // varify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(user.logmodel, userInDb.Password, user.logmodel.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Password", "Incorrect Password");
                    return View("index", user);
                }
                HttpContext.Session.SetInt32("CurrentUser", userInDb.UserId); 
                return RedirectToAction("DashboardView", "Wedding");
            }
            return View("index", user);
        }
    }
}
