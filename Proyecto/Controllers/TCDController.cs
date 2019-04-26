using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace Proyecto.Controllers
{
    public class TCDController : Controller
    {
        public ActionResult IndexTCD()
        {
            IndicadorController indicador = new IndicadorController();
            DataTable indicadores = indicador.ObtenerIndicadores();
            string salida;
            salida = "[['Fecha','Venta','Compra'],";
            foreach (DataRow dr in indicadores.Rows)
            {
                salida = salida + "[";
                salida = salida + "'" + dr[0] + "'" + ",'" + dr[3];
                salida = salida + "','" + dr[4] + "'";
                salida = salida + "],";
            }
            salida = salida + "]";
            @ViewBag.aqq = salida;
            return View();
        }
        public string ObtenerDatos()
        {
            IndicadorController indicador = new IndicadorController();
            DataTable indicadores = indicador.ObtenerIndicadores();
            string salida;

            salida = "[['Valor','Días'],";
            foreach (DataRow dr in indicadores.Rows)
            {
                salida = salida + "[";
                salida = salida + "'" + dr[2] + "'" + "," + Convert.ToDateTime(dr[0]).ToString("dd");
                salida = salida + "],";
            }
            salida = salida + "]";

            return salida;
        }
    }
}
