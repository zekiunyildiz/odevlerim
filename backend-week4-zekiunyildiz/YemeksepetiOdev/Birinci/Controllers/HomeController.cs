using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Birinci.Services;

namespace Birinci.Controllers
{
    public class HomeController : Controller
    {
        private ISingletonService _singleton;
        private IScopedService _scoped;
        private ITransientService _transient;

        public HomeController(
            ISingletonService singleton,
            IScopedService scoped,
            ITransientService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IActionResult Index()
        {
            return View("Index", _singleton.GetGuid());
        }

        public IActionResult Scoped()
        {
            return View("Scoped", _scoped.GetGuid());
        }

        public IActionResult Transient()
        {
            return View("Transient", _transient.GetGuid());
        }
    }
}
