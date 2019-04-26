using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Proyecto.Controllers;


namespace Proyecto.Controllers
{
    public class TBPController : Controller
    {
        
        public ActionResult IndexTBP()
        {
            IndicadorController indicador = new IndicadorController();
            DataTable indicadores = indicador.ObtenerIndicadores();
            string salida;
            salida = "[['Valor','Días'],";
            foreach (DataRow dr in indicadores.Rows)
            {
                salida = salida + "[";
                salida = salida + "'" + dr[2] + "'" + "," + dr[0];
                salida = salida + "],";
            }
            salida = salida + "]";
            @ViewBag.aqui = salida;
            return View();
        }

        //public Array[] ObtenerDatos() {
        //    IndicadorController indicador = new IndicadorController();
        //    DataTable indicadores = indicador.ObtenerIndicadores();
        //    string[] salida = new string[3500];
        //    Array[] al = new Array[3500];
        //    int dias;
        //    int meses;
        //    int year;
        //    int cont = 1;

        //    salida[0] = "['Valor','Días']";
        //    foreach (DataRow dr in indicadores.Rows)
        //    {
                
        //        dias = Convert.ToDateTime(dr[0]).Day;
        //        meses = Convert.ToDateTime(dr[0]).Month;
        //        year = Convert.ToDateTime(dr[0]).Year;
        //        al.SetValue("['" + dr[2] + "'" + "," + dias + "]", cont);
        //        salida[cont] ="['" +dr[2] +"'" + "," +dias +"]";
        //        cont++;
        //    }
            
        //    return al;
        //}
    }
}
