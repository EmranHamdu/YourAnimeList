using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using YourAnimeList.Models;

namespace YourAnimeList.Controllers
{
    [Authorize(Roles = "Manager")]
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
            if(ModelState.IsValid)
            {
                _context.Animes.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("AddAnime");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Animes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Anime obj)
        {
            if (ModelState.IsValid)
            {
                _context.Animes.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("AddAnime");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Animes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _context.Animes.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
                _context.Animes.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("AddAnime");
        }
    }
}
