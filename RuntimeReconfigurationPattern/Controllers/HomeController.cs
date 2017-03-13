using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuntimeReconfigurationPattern.Models;
using Microsoft.Extensions.Options;

namespace RuntimeReconfigurationPattern.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppSettings _settings;

        public HomeController(IOptionsSnapshot<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return Content("" + _settings.MyImportantSetting);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
