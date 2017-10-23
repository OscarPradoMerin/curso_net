using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Powerdede.Models;
using Powerdede.Utils;

namespace Powerdede.Controllers {
    public class StatsController : Controller {
        // GET: Stats
        public ActionResult Index() {
            // Set data using parameters
            var statsViewModel = new StatsViewModel {LastDayUpdates = 1, LastWeekUpdates = 5, LastMonthUpdates = 20};

            using (var db = new ApplicationDbContext()) {
                // Get songs stats
                var yesterdaySongsCount = db.Songs.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 1);
                var lastWeekSongsCount = db.Songs.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 7);
                var lastMonthSongsCount = db.Songs.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 30);

                // Get videos stats
                var yesterdayVideosCount = db.Videos.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 1);
                var lastWeekVideosCount = db.Videos.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 7);
                var lastMonthVideosCount = db.Videos.Count(s => DbFunctions.DiffDays(s.UploadTime, DateTime.Today) < 30);

                // Set data using properties
                statsViewModel.LastDayUpdates = yesterdaySongsCount + yesterdayVideosCount;
                statsViewModel.LastWeekUpdates = lastWeekSongsCount + lastWeekVideosCount;
                statsViewModel.LastMonthUpdates = lastMonthSongsCount + lastMonthVideosCount;
            }

            return View(statsViewModel);
        }
    }
}