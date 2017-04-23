using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GABMontevideo2017RaffleApp.Raffle;
using GABMontevideo2017RaffleApp.Models;
using Microsoft.AspNetCore.Http;

namespace GABMontevideo2017RaffleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Raffle()
        {
            ViewData["Message"] = "Este es el sorteo del Global Azure Bootcamp Montevideo 2017!";

            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(SubscribeModel model)
        {
            if (RaffleAdmin.IsOpen)
            {
                if (ModelState.IsValid)
                {
                    if (HttpContext.Session.GetString("EsPlayer") != "true")
                    {
                        RaffleAdmin.AddPlayer(new RafflePlayer() { Email = model.Email });
                        HttpContext.Session.SetString("EsPlayer", "true");
                    }
                    else
                    {
                        ViewData["Message"] = "No te hagas el loco que ya estas participando!";
                        return View("Raffle");
                    }
                }

                ViewData["Message"] = "Estas participando!";
                return View("Raffle");
            }
            else
            {
                ViewData["Message"] = "Te apuraste!";
                return View("Raffle");
            }
        }

        public IActionResult EnableRaffle()
        {
            if (this.Request.Query.ContainsKey("soyfabian"))
            {
                RaffleAdmin.SetOpen(true);
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Winners()
        {
            if (RaffleAdmin.IsOpen)
            {
                List<RafflePlayer> winners = RaffleAdmin.Players.Take(8).ToList();
                var winnerMessage = string.Empty;
                foreach (var player in winners)
                {
                    winnerMessage += player.Email + Environment.NewLine;
                }
                ViewData["Message"] = winnerMessage;
                return View("Winners");
            }
            else
            {
                ViewData["Message"] = "No empezo el sorteo aun!";
                return View("Winners");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
