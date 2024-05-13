using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers
{
    public class HomeController : Controller
    {
        public static Eruption[] AllEruption = new Eruption[]
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };

        public IActionResult Index()
        {
            Eruption firstEruptionInChile = AllEruption.FirstOrDefault(e => e.Location == "Chile");
            ViewBag.FirstEruptionInChile = firstEruptionInChile != null
                ? $"First eruption in Chile: {firstEruptionInChile}"
                : "No eruption found in Chile.";

            Eruption firstEruptionInHawaii = AllEruption.FirstOrDefault(e => e.Location == "Hawaiian Is");
            ViewBag.FirstEruptionInHawaii = firstEruptionInHawaii != null
                ? $"First eruption in Hawaiian Is: {firstEruptionInHawaii}"
                : "No eruption found in Hawaiian Is.";

            Eruption firstEruptionInGreenland = AllEruption.FirstOrDefault(e => e.Location == "Greenland");
            ViewBag.FirstEruptionInGreenland = firstEruptionInGreenland != null
                ? $"First eruption in Greenland: {firstEruptionInGreenland}"
                : "No eruption found in Greenland.";

            Eruption firstEruptionInNewZealandAfter1900 = AllEruption.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
            ViewBag.FirstEruptionInNewZealandAfter1900 = firstEruptionInNewZealandAfter1900 != null
                ? $"First eruption in New Zealand after 1900: {firstEruptionInNewZealandAfter1900}"
                : "No eruption found in New Zealand after 1900.";

            IEnumerable<Eruption> highElevationEruptions = AllEruption.Where(e => e.ElevationInMeters > 2000);
            PrintEach(highElevationEruptions, "Eruptions with elevation over 2000m:");

            IEnumerable<Eruption> eruptionsStartingWithL = AllEruption.Where(e => e.Volcano.StartsWith("L")).ToList();
            PrintEach(eruptionsStartingWithL, "Eruptions with volcano names starting with 'L':");
            Console.WriteLine($"Number of eruptions starting with 'L': {eruptionsStartingWithL.Count()}");

            int highestElevation = AllEruption.Max(e => e.ElevationInMeters);
            Console.WriteLine($"Highest elevation: {highestElevation}");

            Eruption volcanoWithHighestElevation = AllEruption.FirstOrDefault(e => e.ElevationInMeters == highestElevation);
            if (volcanoWithHighestElevation != null)
                Console.WriteLine($"Volcano with the highest elevation: {volcanoWithHighestElevation.Volcano}");

            IEnumerable<string> uniqueLocations = AllEruption.Select(e => e.Location).Distinct();
            Console.WriteLine("\nUnique locations:");
            foreach (string location in uniqueLocations)
            {
                Console.WriteLine(location);
            }
            List<LINQEruption.Models.Eruption> eruptions = AllEruption.ToList();
            return View(eruptions);
        }

        static void PrintEach(IEnumerable<Eruption> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);
            foreach (Eruption item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }

}