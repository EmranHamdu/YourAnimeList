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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace YourAnimeList.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CMSController : Controller
    {
        private readonly ILogger<CMSController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public CMSController(ILogger<CMSController> logger, ApplicationDbContext context, IWebHostEnvironment hostEnviroment)
        {
            _logger = logger;
            _context = context;
            this._hostEnviroment = hostEnviroment;
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
        public async Task<IActionResult> CreateAnimeAsync(Anime obj)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _hostEnviroment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                string extension = Path.GetExtension(obj.ImageFile.FileName);
                obj.AnimeURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStram = new FileStream(path, FileMode.Create))
                {
                    await obj.ImageFile.CopyToAsync(fileStram);
                }


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
