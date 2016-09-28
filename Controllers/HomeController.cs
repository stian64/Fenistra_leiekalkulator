using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fenistra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Instillinger()
        {
            return View();
        }

        public ActionResult Informasjon()
        {
            return View();
        }

        public ActionResult Beregning()
        {
            return View();
        }
    }
}