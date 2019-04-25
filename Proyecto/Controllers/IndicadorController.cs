using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class IndicadorController : Controller
    {
        ContextoMongo daoService = new ContextoMongo();

        public void guardarIndicadores()
        {
            DataSet tablaIndicadores = ObtenerDatosServicio();
            Indicador indicador = new Indicador();

            try
            {
                for (int i = 0; i < tablaIndicadores.Tables[0].Rows.Count; i++)
                {
                    indicador.fecha = Convert.ToDateTime(tablaIndicadores.Tables[0].Rows[i].ItemArray[1]).ToString("dd/MM/yyyy");
                    indicador.tasaPoliticaMonetaria = Convert.ToDouble(tablaIndicadores.Tables[0].Rows[i].ItemArray[2]);
                    indicador.tasaBasicaPasiva = Convert.ToDouble(tablaIndicadores.Tables[1].Rows[i].ItemArray[2]);
                    indicador.venta = Convert.ToDouble(tablaIndicadores.Tables[2].Rows[i].ItemArray[2]);
                    indicador.compra = Convert.ToDouble(tablaIndicadores.Tables[3].Rows[i].ItemArray[2]);

                    daoService.Create(indicador);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }          
        }

        public DataSet ObtenerDatosServicio()
        {
            DataSet tablaIndicadores = new DataSet();

            DateTime fechaActual = DateTime.Today;
            string fecha1 = "01/01/2010";
            string fecha2 = Convert.ToDateTime(fechaActual).ToString("dd/MM/yyyy");
            string nombre = "Jose Julian";
            string subNivel = "N";
            cr.fi.bccr.gee.wsIndicadoresEconomicos indicadores = new cr.fi.bccr.gee.wsIndicadoresEconomicos();

            try { 

                        DataTable TasaPoliticaMonetaria = indicadores.ObtenerIndicadoresEconomicos("3541", fecha1, fecha2, nombre, subNivel).Tables[0].Copy();
                        DataTable TasaBasicaPasiva = indicadores.ObtenerIndicadoresEconomicos("423", fecha1, fecha2, nombre, subNivel).Tables[0].Copy();
                        DataTable TipoCambioVenta = indicadores.ObtenerIndicadoresEconomicos("318", fecha1, fecha2, nombre, subNivel).Tables[0].Copy();
                        DataTable TipoCambioCompra = indicadores.ObtenerIndicadoresEconomicos("317", fecha1, fecha2, nombre, subNivel).Tables[0].Copy();

                        TasaPoliticaMonetaria.TableName = "tablaMonetaria";
                        TasaBasicaPasiva.TableName = "tablaPasiva";
                        TipoCambioVenta.TableName = "tablaVenta";
                        TipoCambioCompra.TableName = "tablaCompra";

                        tablaIndicadores.Tables.Add(TasaPoliticaMonetaria);
                        tablaIndicadores.Tables.Add(TasaBasicaPasiva);
                        tablaIndicadores.Tables.Add(TipoCambioVenta);
                        tablaIndicadores.Tables.Add(TipoCambioCompra);

        }
            catch (Exception e)
            {
                  Console.WriteLine(e.StackTrace);
            }   

              return tablaIndicadores;


        }

        public DataTable ObtenerIndicadores()
        {

            DataTable tablaIndicadores = new DataTable();

            try { 

                        List<Indicador> lista = daoService.Get();

            
                        tablaIndicadores.Columns.Add("Fecha");
                        tablaIndicadores.Columns.Add("TasaPoliticaMonetaria");
                        tablaIndicadores.Columns.Add("TasaBasicaPasiva");
                        tablaIndicadores.Columns.Add("TipoCambioCompra");
                        tablaIndicadores.Columns.Add("TipoCambioVenta");

                        foreach(Indicador indicador in lista)
                        {
                                    DataRow row = tablaIndicadores.NewRow();

                                    row["Fecha"] = indicador.fecha;
                                    row["TasaPoliticaMonetaria"] = indicador.tasaPoliticaMonetaria;
                                    row["TasaBasicaPasiva"] = indicador.tasaBasicaPasiva;
                                    row["TipoCambioCompra"] = indicador.compra;
                                    row["TipoCambioVenta"] = indicador.venta;

                                    tablaIndicadores.Rows.Add(row);
                        }

        }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }   

               return tablaIndicadores;
        }

    }

}