using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Indicador
    {
        [BsonId]
        public string fecha { get; set; }

        [BsonElement("compra")]
        public double compra { get; set; }

        [BsonElement("venta")]
        public double venta { get; set; }

        [BsonElement("tasa_politica_monetaria")]
        public double tasaPoliticaMonetaria { get; set; }

        [BsonElement("tasa_basica_pasiva")]
        public double tasaBasicaPasiva { get; set; }
    }

}