using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Powerdede.Models;

namespace Powerdede.Controllers
{
    public class StatsController : Controller {
        // GET: Stats
        public ActionResult Index() {
            // Set data using parameters
            var statsViewModel = new StatsViewModel{LastDayUpdates = 1, LastWeekUpdates = 5, LastMonthUpdates = 20};

            // Set data using properties
            statsViewModel.LastDayUpdates = 1;
            statsViewModel.LastWeekUpdates = 5;
            statsViewModel.LastMonthUpdates = 20;

            return View(statsViewModel);
        }
    }
}