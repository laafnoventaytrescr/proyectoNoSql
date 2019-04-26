using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Proyecto.Controllers
{
    public class TPMController : Controller
    {
        public ActionResult IndexTPM()
        {
            IndicadorController indicador = new IndicadorController();
            DataTable indicadores = indicador.ObtenerIndicadores();
            string salida;
            salida = "[['Valor','Días'],";
            foreach (DataRow dr in indicadores.Rows)
            {
                salida = salida + "[";
                salida = salida + "'" + dr[1] + "'" + "," + dr[0];
                salida = salida + "],";
            }
            salida = salida + "]";
            @ViewBag.aq = salida;
            return View();
        }
    }
}

