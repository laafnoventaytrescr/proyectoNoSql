﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndicadorController indicador = new IndicadorController();
            indicador.guardarIndicadores();

            return View();
        }
    }
}