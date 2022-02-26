using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Lab3.Context;
using Lab3.Interfaces;

namespace Lab3.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!CheckToRegisterLoginAndEmail(model)) 
                {
                    User user = new User() { email = model.email, login = model.login, Password = model.Password,role = model.role };

                    //_dataContext.addUser(user);
                    _userManager.Add(user);
                    //_dataContext.SaveChanges();
                    await Authenticate(model.email);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Такой Пользователь уже существует");
            }
           
            return View(model);
        }

        [Route("/Login")]
        [AllowAnonymous]
        public ActionResult Login()
        { 
            return View();
        }
        [HttpPost("/Login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (CheckToRegisterLoginAndEmailAndPasswords(model))
                {
                    //var user = _dataContext.FindUser(User.Identity.Name);
                    var user = _userManager.Find(User.Identity.Name);
                    if (user.role == "Customers")
                    {
                        await Authenticate(model.login);
                        return RedirectToAction("IndexOrder", "Home");
                    }
                    await Authenticate(model.login);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Данный пользователь не существует");
            }
            return View(model);
        }


        private bool CheckToRegisterLoginAndEmail(RegisterModel model)
        {
            //var users = _dataContext.Users;
            var users = _userManager.GetAll();
            bool checkLogin = false;
            if (users == null)
            {
                checkLogin = true;   
            }
            else 
            {
                foreach (var user in users)
                {
                    if (model.login == user.login || model.email == user.email)
                    {
                        checkLogin = true;
                    }
                }
            }
            return checkLogin;//////////////////
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        private bool CheckToRegisterLoginAndEmailAndPasswords(LoginModel model)
        {
            //var users = _dataContext.Users;
            var users = _userManager.GetAll();
            bool checkLogin = false;

            foreach (var user in users)
            {
                if ((model.login == user.login || model.login == user.email) && model.Password == user.Password)
                {
                    checkLogin = true;
                }
            }
            return checkLogin;
        }
        public User FindUser(LoginModel model)
        {
            //var users = _dataContext.Users;
            var users = _userManager.GetAll();
            foreach (var user in users)
            {
                if ((model.login == user.login || model.login == user.email) && model.Password == user.Password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
