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
        [Menu("", -1, null, null, "Home", icon: "wb-home")]
        public IActionResult Index()
        {
            return View();
        }

        [Menu("Outros", 9999, "Ajuda", "wb-help", "Sobre", icon: "wb-info")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Menu("Outros", 9999, "Ajuda", "wb-help", "Contato", icon: "wb-chat-group")]
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
