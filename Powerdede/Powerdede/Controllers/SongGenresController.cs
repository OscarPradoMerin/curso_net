using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Powerdede.Models;

namespace Powerdede.Controllers {
    public class SongGenresController : Controller {

        // GET: SongGenres
        public ActionResult Index(string filter = "") {
            var songGenres = new List<SongGenre>();

            using (var context = new ApplicationDbContext()) {

                // Get filtered songs
                if (filter.IsEmpty()) {
                    songGenres = context.SongGenres.ToList();
                } else {
                    songGenres = context.SongGenres.Where(s => s.Name.ToLower().Contains(filter.ToLower())).ToList();
                }
                
            }

            return View(songGenres);
        }


        // GET: SongGenres/Create
        public ActionResult Create() {
            var songGenre = new SongGenre {Name = "Test"};

            using (var context = new ApplicationDbContext()) {
                context.SongGenres.Add(songGenre);

                // Commit to database
                context.SaveChanges();
            }

            // Add id to ViewBag in order to display it into the view
            ViewBag.InsertedId = songGenre.Id;

            return View();
        }
    }
}