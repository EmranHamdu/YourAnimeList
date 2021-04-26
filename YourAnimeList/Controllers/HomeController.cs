using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YourAnimeList.Models;

namespace YourAnimeList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Animes()
        {
            List<Anime> model = _context.Animes.ToList();

            return View(model);
        }

        public IActionResult AnimeDetails(int id)
        {
            Anime model = _context.Animes.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Search(String SearchString)
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                var animes = from a in _context.Animes
                            where a.AnimeName.Contains(SearchString)
                            select a;
                List<Anime> model = animes.ToList();
                ViewData["SearchString"] = SearchString;
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult YourList()
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
