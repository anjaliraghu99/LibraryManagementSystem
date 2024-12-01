using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public IActionResult UserHomepage()
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
         [HttpGet]
        public IActionResult AdminDashboard() {
            var books= _databaseContext.Book;

            return View(books);
        }
        [HttpGet]
        public IActionResult CreateBook(string DataAction, int Id)
        {
            ViewBag.Action = DataAction;
            if(DataAction== "Edit")
            {
                var data = _databaseContext.Book.FirstOrDefault(x => x.BookID == Id);
                if(data!=null)
                {
                    return View(data);
                }

            }
           
            return View();
        }
        public IActionResult DeleteData(int Id)
        {
            if(Id!= null) {
                var data = _databaseContext.Book.FirstOrDefault(x => x.BookID == Id);
                if(data!=null)
                {
                    _databaseContext.Book.Remove(data);
                    _databaseContext.SaveChanges();
                    return RedirectToAction("AdminDashboard");

                }
            }
            return RedirectToAction("AdminDashboard");

        }


        [HttpPost]
        public IActionResult BookActions(string DataAction,Book books){

            if(DataAction== "Create")
            {
                if (books.BookID != null)
                {
                    var data =_databaseContext.Book.FirstOrDefault(x=>x.BookID == books.BookID);
                    if(data==null)
                    {
                        _databaseContext.Book.Add(books);
                        _databaseContext.SaveChanges();
                        return RedirectToAction("AdminDashboard");

                    }

                }
            }
            if (DataAction == "Edit")
            {
                if (books.BookID != null)
                {
                    var data = _databaseContext.Book.FirstOrDefault(x => x.BookID == books.BookID);
                    if (data != null)
                    {
                        _databaseContext.Entry(data).CurrentValues.SetValues(books);

                        _databaseContext.SaveChanges();
                        return RedirectToAction("AdminDashboard");
                    }
                }

            }

            return RedirectToAction("AdminDashboard");

        }

        [HttpGet]
        public ActionResult GetCategoryData(string categoryName) {
            var data=new List<string>();
            switch (categoryName)
            {
                case "category":
                    var categorydata = _databaseContext.Category
                                .Select(category => new
                                {
                                    category.CategoryID, 
                                    category.CategoryName
                                })
                                .Distinct()
                                .ToList();
                                return Json(categorydata);
                                break;
                 case "Author":
                    var Authordata = _databaseContext.Author
                                .Select(publisher => new
                                {
                                    publisher.AuthorID,
                                    publisher.Name
                                })
                                .Distinct()
                                .ToList();
                                return Json(Authordata);
                                break;

                case "Publisher":
                    var Publisherdata = _databaseContext.Publisher
                                .Select(category => new
                                {
                                    category.PublisherID, 
                                    category.Name
                                })
                                .Distinct()
                                            .ToList();
                                return Json(Publisherdata);
                                break;
            }
            
            

            return Ok();
        }

        [HttpPost]
        public IActionResult Logins(string email,string password)
        {
            
            var data = _databaseContext.User.Where(x=>x.Email == email && x.Password==password);
            if(data != null)
            {
                return RedirectToAction("UserHomepage");
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
