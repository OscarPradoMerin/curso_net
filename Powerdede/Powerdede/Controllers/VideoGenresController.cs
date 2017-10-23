using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerdede.Models;

namespace Powerdede.Controllers
{
    public class VideoGenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoGenres
        public ActionResult Index()
        {
            return View(db.VideoGenres.ToList());
        }

        // GET: VideoGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGenre videoGenre = db.VideoGenres.Find(id);
            if (videoGenre == null)
            {
                return HttpNotFound();
            }
            return View(videoGenre);
        }

        // GET: VideoGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] VideoGenre videoGenre)
        {
            if (ModelState.IsValid)
            {
                db.VideoGenres.Add(videoGenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoGenre);
        }

        // GET: VideoGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGenre videoGenre = db.VideoGenres.Find(id);
            if (videoGenre == null)
            {
                return HttpNotFound();
            }
            return View(videoGenre);
        }

        // POST: VideoGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] VideoGenre videoGenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoGenre);
        }

        // GET: VideoGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGenre videoGenre = db.VideoGenres.Find(id);
            if (videoGenre == null)
            {
                return HttpNotFound();
            }
            return View(videoGenre);
        }

        // POST: VideoGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGenre videoGenre = db.VideoGenres.Find(id);
            db.VideoGenres.Remove(videoGenre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
