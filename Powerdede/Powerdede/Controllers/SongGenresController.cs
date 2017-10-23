using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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


        // POST: SongGenres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SongGenre songGenre) {

            using (var context = new ApplicationDbContext()) {
                context.SongGenres.Add(songGenre);

                // Commit to database
                context.SaveChanges();
            }

            // Add id to ViewBag in order to display it into the view
            //ViewBag.InsertedId = songGenre.Id;

            return RedirectToAction("Index");
        }

        // GET: SongGenres/Details/{id}
        public ActionResult Details(int id)
        {
            SongGenre songGenre = null;

            using (var context = new ApplicationDbContext())
            {
                songGenre = context.SongGenres.Find(id);
            }

            return View(songGenre);
        }

        // GET: SongGenres/Delete/{id}
        public ActionResult Delete(int id)
        {
            SongGenre songGenre;

            using (var context = new ApplicationDbContext())
            {
                songGenre = context.SongGenres.Find(id);

                context.SongGenres.Remove(songGenre);

                // Commit to database
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: SongGenres/Update
        public ActionResult Update(int id)
        {
            SongGenre songGenre = null;

            using (var context = new ApplicationDbContext())
            {
                songGenre = context.SongGenres.Find(id);

                songGenre.Name = "Modificado";

                context.SongGenres.AddOrUpdate(songGenre);

                // Commit to database
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}