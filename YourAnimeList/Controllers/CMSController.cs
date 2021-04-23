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
    public class CMSController : Controller
    {

        private readonly ILogger<CMSController> _logger;
        private readonly ApplicationDbContext _context;

        public CMSController(ILogger<CMSController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AddAnime()
        {
            List<Anime> model = _context.Animes.ToList();

            return View(model);
        }

        //GET 
        public IActionResult CreateAnime()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnime(Anime obj)
        {
            _context.Animes.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("AddAnime");
        }
    }
}
