using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proyecto.Models
{
    public class Indicadores
    {
        public void ObtenerDatosServicio()
        {
            DateTime fechaActual = DateTime.Today;
            string indicador;
            string fecha1 = "01/01/2018";
            string fecha2 = Convert.ToDateTime(fechaActual).ToString("dd/mm/yyyy");
            string nombre = "Jose Julian";
            string subNivel = "N";
            cr.fi.bccr.gee.wsIndicadoresEconomicos indicadores = new cr.fi.bccr.gee.wsIndicadoresEconomicos();

            DataSet TasaPoliticaMonetaria = indicadores.ObtenerIndicadoresEconomicos("3541", fecha1, fecha2, nombre, subNivel);
            DataSet TasaBasicaPasixa = indicadores.ObtenerIndicadoresEconomicos("423", fecha1, fecha2, nombre, subNivel);
            DataSet TipoCambioVenta = indicadores.ObtenerIndicadoresEconomicos("318", fecha1, fecha2, nombre, subNivel);
            DataSet TipoCambioCompra = indicadores.ObtenerIndicadoresEconomicos("317", fecha1, fecha2, nombre, subNivel);
        }
    }
}