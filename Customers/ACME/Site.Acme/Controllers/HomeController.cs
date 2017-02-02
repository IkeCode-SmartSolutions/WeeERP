using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wee.Common;

namespace Site.Acme.Controllers
{
    public class HomeController : Controller
    {
        [Menu("", -1, null, "Home", icon: "wb-dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Menu("Outros", 9999, "Ajuda", "Sobre")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Menu("Outros", 9999, "Ajuda", "Contato")]
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
