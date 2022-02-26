using Lab3.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    
    public class HomeController : Controller
    {
        [Route("/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Orders")]
        [Authorize]
        public IActionResult IndexOrder()
        {
            return View();
        }
    }
}
