using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ContextoMongo
    {
        private readonly IMongoCollection<Indicador> _indicador;

        public ContextoMongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("IndicadoresEconomicos");
            _indicador = database.GetCollection<Indicador>("indicador");
        }

        public List<Indicador> Get()
        {
            return _indicador.Find(indicador => true).ToList();
        }

        public Indicador Get(string id)
        {
            return _indicador.Find<Indicador>(indicador => indicador.fecha == id).FirstOrDefault();
        }

        public Indicador Create(Indicador indicador)
        {
            _indicador.InsertOne(indicador);
            return indicador;
        }

        public void Update(string fecha, Indicador indicadorIn)
        {
            _indicador.ReplaceOne(indicador => indicador.fecha == fecha, indicadorIn);
        }

        public void Remove(Indicador indicadorIn)
        {
            _indicador.DeleteOne(indicador => indicador.fecha == indicadorIn.fecha);
        }

        public void Remove(string fecha)
        {
            _indicador.DeleteOne(indicador => indicador.fecha == fecha);
        }



    }
}