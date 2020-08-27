using Annexio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            var countries = new List<Country>()
            {
                new Country
                {
                    Name = "Portugal",
                    Region = "Europe",
                    Subregion = "Southern Europe"
                },
                new Country
                {
                    Name = "Spain",
                    Region = "Europe",
                    Subregion = "Southern Europe"
                }
            };


            return View(countries);
        }
    }
}