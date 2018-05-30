using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OthelloModel;
using OthelloWeb.Models;

namespace OthelloWeb.Controllers
{
    public static class Game
    {
        public static Othello OthelloGame = new Othello(new Human(), new GreedyComputer());

        public static char ToChar(this int gp)
        {
            switch (gp)
            {
                case 0:
                default:
                    return ' ';
                case 1:
                    return '\u25CF';
                case 2:
                    return '\u25CB';
            }
        }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Game.OthelloGame);
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Move(int row, int col)
        {
            if (row < 0 || col < 0 || row > 7 || col > 7)
            {
                RedirectToAction("Error");
            }

            Console.WriteLine(Game.OthelloGame.PlaceToken(row, col));

            return RedirectToAction("Index");
        }
    }
}
