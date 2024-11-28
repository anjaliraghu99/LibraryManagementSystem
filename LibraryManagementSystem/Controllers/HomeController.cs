using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;
        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() { 

            return View();
        }
        [HttpPost]
        public IActionResult Logins(string email,string password)
        {
            
            var data = _databaseContext.User.Where(x=>x.Email == email && x.Password==password);
            if(data != null)
            {
                RedirectToAction("Index");
            }
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
