using DropDown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDown.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Sports> sports = new List<Sports>();
            for (int i = 0; i < 10; i++)
            {
                sports.Add(new Sports()
                {
                    Id = i,
                    SportsName = "Sports name " + i.ToString()
                });
            }


            ViewData["AllSports"] = from s in sports
                                    select
                   new SelectListItem()
                   {
                       Value = s.Id.ToString(),
                       Text = s.SportsName,
                       Selected = false
                   };
            ViewData["AllEvents"] = new List<SelectListItem>();
            return View();
        }

        [HttpPost]
        public JsonResult GetEventsBySportId(int[] sportIds)
        {
            List<Events> events = new List<Events>();

            foreach (int sportid in sportIds)
            {
                events.Add(new Events()
                {
                    Id = sportid,
                    EventName = "Event Name for Sport id - " + sportid.ToString()
                });
            }
            return Json(events);
        }
    }
}