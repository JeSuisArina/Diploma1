using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuditControlSystem.Models;

namespace AuditControlSystem.Controllers
{
    public class HomeController : Controller
    {
        AuditContext db = new AuditContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Standarts
            IEnumerable<Standart> standarts = db.Standarts;
            // передаем все объекты в динамическое свойство Standarts в ViewBag
            ViewBag.Standarts = standarts;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}