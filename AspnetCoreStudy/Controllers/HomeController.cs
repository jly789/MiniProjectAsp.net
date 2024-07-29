using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace AspnetCoreStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         




            



            return View();
        }

        public IActionResult LoginOk(User model)
        {








            return View(model);
        }

  

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
