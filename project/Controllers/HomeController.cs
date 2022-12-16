using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;
using Contentful.Core;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContentfulClient _client;

        public HomeController(ILogger<HomeController> logger, IContentfulClient client)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var trainingen = await _client.GetEntries<trainingen>();
            return View(trainingen);
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

        [HttpPost]
        public IActionResult Index(string Training1, string Training2, string Wedstrijd, string Evenement)
        {
            ViewBag.aanwezigheid = string.Format("Training 1: {0}", Training1);
            ViewBag.aanwezigheid2 = string.Format("Training 2: {0}", Training2);
            ViewBag.aanwezigheid3 = string.Format("Wedstrijd: {0}", Wedstrijd);
            ViewBag.aanwezigheid4 = string.Format("Evenement: {0}", Evenement);
            return View("resultaat");
        }
    }
}
