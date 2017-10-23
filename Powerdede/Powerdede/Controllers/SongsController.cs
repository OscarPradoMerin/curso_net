using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Powerdede.Data;
using Powerdede.Models;
using Powerdede.Services;

namespace Powerdede.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IMailService _mailService;

        public SongsController()
        {
            _mailService = new MailService();
        }

        // GET: Songs
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Author).Include(s => s.SongGenre).Include(s => s.User).Where(s => s.Active);
            return View(songs.ToList());
        }

        // GET: Songs/MySongs
        public ActionResult MySongs()
        {
            // Get current user id
            var currentUserId = User.Identity.GetUserId();

            var songs = db.Songs.Include(s => s.Author).Include(s => s.SongGenre).Include(s => s.User).Where(s => s.UserId == currentUserId);
            return View("Index", songs.ToList());
        }

        // GET: Songs/Validate/{id}
        [Authorize(Roles = RolesData.Admin + "," + RolesData.Moderator)]
        public ActionResult Validate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }

            // Set as active
            song.Active = true;

            // Update song
            db.Songs.AddOrUpdate(song);

            // Commit
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name");
            ViewBag.SongGenreId = new SelectList(db.SongGenres, "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Link,Duration,AuthorId,SongGenreId")] Song song)
        {
            if (ModelState.IsValid)
            {
                // Get current user id
                var currentUserId = User.Identity.GetUserId();
                var currentUserName = User.Identity.GetUserName();

                // Add to song
                song.UserId = currentUserId;

                // Add upload time (now)
                song.UploadTime = DateTime.Now;

                // Set as inactive, because it has to be validated by a moderator
                song.Active = false;

                db.Songs.Add(song);
                db.SaveChanges();

                // Send mail

                // Get author
                var author = db.Authors.Find(song.AuthorId);

                // Get action url
                var fullUrlValidate = Url.Action("Validate", "Songs", new { id = song.Id }, Request.Url.Scheme);

                var message =
                    $"El usuario <b>{currentUserName}</b> solicita que se apruebe su subida de contenido para: <i>{song.Title}</i> de <i>{song.Author.Name}</i>.\n\n" +
                    $"Si desea aceptar la solicitud, haga click en el siguiente enlace: <a href='{fullUrlValidate}'>VALIDAR</a>";

                _mailService.SendMail("oscarpradomerin@gmail.com", "Solicitud de aprobación", message, "Powerdede");

                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", song.AuthorId);
            ViewBag.SongGenreId = new SelectList(db.SongGenres, "Id", "Name", song.SongGenreId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", song.UserId);
            return View(song);
        }

        // GET: Songs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", song.AuthorId);
            ViewBag.SongGenreId = new SelectList(db.SongGenres, "Id", "Name", song.SongGenreId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", song.UserId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Link,Duration,UploadTime,AuthorId,SongGenreId,UserId,Active")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", song.AuthorId);
            ViewBag.SongGenreId = new SelectList(db.SongGenres, "Id", "Name", song.SongGenreId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", song.UserId);
            return View(song);
        }

        // GET: Songs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
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
