using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("ball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {   
            ViewBag.WomenLeagues = context.Leagues
                .Where(l => l.Name.Contains("Womens"));
                // .ToList();
            ViewBag.Hockey= context.Leagues
                .Where(l => l.Sport.Contains("Hockey"));
            ViewBag.ExceptFootball= context.Leagues
                .Where(l => l.Sport != "Football");
            ViewBag.Conference= context.Leagues
                .Where(l => l.Name.Contains("Conference"));
            ViewBag.Atlantic= context.Leagues
                .Where(l => l.Name.Contains("Atlantic"));
            ViewBag.Dallas= context.Teams
                .Where(t => t.Location.Contains("Dallas"));
            ViewBag.Raptors= context.Teams
                .Where(t => t.TeamName.Contains("Raptors"));
            ViewBag.City= context.Teams
                .Where(t => t.Location.Contains("City"));
            ViewBag.T= context.Teams
                .Where(t => t.TeamName[0] == 'T');
            ViewBag.SortLocation= context.Teams
                .OrderBy(t=>t.Location);
            ViewBag.ReverseName= context.Teams
                .OrderByDescending(t=>t.TeamName);
            ViewBag.Cooper= context.Players
                .Where(p => p.LastName.Contains("Cooper"));
            ViewBag.Joshua= context.Players
                .Where(p => p.FirstName.Contains("Joshua"));
            ViewBag.CooperWithoutJoshua= context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .Where(p => p.FirstName != "Joshua");
            ViewBag.AlexAndWyatt= context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt");            
            
            foreach(var t in ViewBag.Joshua)
            {   
                System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                System.Console.WriteLine(t.TeamId);
            }
            
            
            
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}