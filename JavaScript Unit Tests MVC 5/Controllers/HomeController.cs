using Foolproof.UnitTests.JavaScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JavaScript_Unit_Tests_MVC_5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Model());
        }
    }
}