using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukProje.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context _context = new Context();
        public ActionResult Index()
        {
            var numberOfCategory = _context.Categories.Count();
            ViewBag.numberOfCategory = numberOfCategory;

            var numberOfHeadingsInCategoryOfSoftware = _context.Headings.Count(x => x.CategoryId == 1);
            ViewBag.numberOfHeadingsInCategoryOfSoftware = numberOfHeadingsInCategoryOfSoftware;

            var numberOfWritersWithAIn = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.numberOfWritersWithAIn = numberOfWritersWithAIn;

            var categoryWithTheMostHeadings = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.categoryWithTheMostHeadings = categoryWithTheMostHeadings;

            var statusTrue = _context.Categories.Count(x => x.CategoryStatus == true);
            var statusFalse = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.TheDifferenceBetweenTrueAndFalseInCategoryTable = statusTrue - statusFalse;

            return View();
        }
    }
}