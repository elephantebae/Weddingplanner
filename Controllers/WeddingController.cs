using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using weddingplanner.Models; 
using Microsoft.AspNetCore.Identity;

namespace weddingplanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext dbContext;
        
        public WeddingController(WeddingContext context)
        {
            dbContext = context;
        }
        
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult DashboardView(){
            List<Wedding> ShowAllWeddings = dbContext.weddings.Include(x => x.Attendees).ToList();
            ViewBag.CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            return View(ShowAllWeddings);
        }
        [HttpGet]
        [Route("AddWedding")]
        public IActionResult AddWeddingView()
        {
            ViewBag.CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            return View();
        }
        [HttpPost]
        [Route("AddWeddingProcess")]
        public IActionResult AddWeddingProcess(Wedding NewWedding)
        {
            if (HttpContext.Session.GetInt32("CurrentUser") == null)
            {
                return RedirectToAction("index", "Home");
            }
            dbContext.weddings.Add(NewWedding);
            dbContext.SaveChanges();
            ViewBag.CurrentUser = HttpContext.Session.GetInt32("CurrentUser");
            return Redirect($"ShowWeddingDetail/{NewWedding.WeddingId}");
        }
        [HttpGet]
        [Route("ShowWeddingDetail/{WeddingId}")]
        public IActionResult ShowWeddingDetail(int WeddingId)
        {
            System.Console.WriteLine("###########");   
            Wedding WeddingDetails = dbContext.weddings
            .Include(w => w.Attendees)
            .ThenInclude(u => u.user)
            .FirstOrDefault(i=> i.WeddingId == WeddingId);
            System.Console.WriteLine(WeddingDetails);
            return View(WeddingDetails);

        }
        [HttpGet]
        [Route("AddRsvp/{id}")]
        public IActionResult AddRsvp(int id)
        {
            // if(HttpContext.Session.GetInt32("CurrentUser")== null)
            // {
            //     return RedirectToAction("index", "Home");
            // }
            int? UserId = HttpContext.Session.GetInt32("CurrentUser");
            Wedding CurrentWedding = dbContext.weddings
            .Include(wh => wh.Attendees)
            .ThenInclude(g => g.user)
            .FirstOrDefault(w=> w.WeddingId == id); 
            User CurrentUser = dbContext.Users.FirstOrDefault(i => i.UserId == UserId);
            Rsvp WantingToRsvp = dbContext.Rsvping.Where(w => w.WeddingId == id && w.UserId == CurrentUser.UserId)
            .FirstOrDefault();
            if(WantingToRsvp != null)
            {
                CurrentWedding.Attendees.Remove(WantingToRsvp);
            }
            else
            {
                Rsvp NewRsvp = new Rsvp();
                {
                    NewRsvp.UserId = (int)UserId;
                    NewRsvp.WeddingId = id;
                }
                CurrentWedding.Attendees.Add(NewRsvp);
            }
            dbContext.SaveChanges();
            return Redirect($"/ShowWeddingDetail/{id}");
        }
        [HttpGet]
        [Route("DeleteWedding/{id}")]
        public IActionResult DeleteWedding(int id)
        {
            Wedding Delete = dbContext.weddings.FirstOrDefault(i => i.WeddingId == id);
            dbContext.Remove(Delete);
            dbContext.SaveChanges();
            return RedirectToAction("DashBoardView");
        }
    }
}

    