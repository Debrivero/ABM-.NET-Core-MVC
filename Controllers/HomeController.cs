using Examen_tecnico_COA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_tecnico_COA.Controllers
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
            try
            {
                if (ModelState.IsValid)
                         
                {
                    ExamenTecnicoCOAContext db = new ExamenTecnicoCOAContext();
                    List<Usuario> _usuarios = new List<Usuario>();
                    _usuarios = db.Usuarios.ToList();
                    return View(_usuarios);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
                return View("Index");
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
