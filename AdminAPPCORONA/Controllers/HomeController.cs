using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOSPBAPP.Models;

namespace HOSPBAPP.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Bienvenido a la administracion web de la aplicacion ";
            ViewData["Message"] = "Aqui podras administrar y gestionar.";

            return View();
        }

        public ActionResult Minor()
        {
            //ViewData["SubTitle"] = "Simple example of second view";
            //ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }

    }
}