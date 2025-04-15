using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment04_05_MVC.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
