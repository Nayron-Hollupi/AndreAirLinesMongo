using System.Collections.Generic;
using Model;
using MongoDB.Driver;
using FlightsAPI.Utils;

namespace FlightsAPI.Service
{
    public class VooService
    {
        private readonly IMongoCollection<Flights> _voo;

        public VooService(IVooUtilsDatabaseSettings settings)
        {
            var vo = new MongoClient(settings.ConnectionString);
            var database = vo.GetDatabase(settings.DatabaseName);
            _voo = database.GetCollection<Flights>(settings.VooCollectionName);
        }

        public List<Flights> Get() =>
       _voo.Find(voo => true).ToList();
        public Flights Get(string id) =>
            _voo.Find<Flights>(voo => voo.Id == id).FirstOrDefault();

        public Flights Create(Flights voo)
        {
            _voo.InsertOne(voo);
            return voo;
        }

        public void Update(string id, Flights vooIn) =>
            _voo.ReplaceOne(voo => voo.Id == id, vooIn);

        public void Remove(Flights vooIn) =>
            _voo.DeleteOne(voo => voo.Id == vooIn.Id);

        public void Remove(string id) =>
           _voo.DeleteOne(voo => voo.Id == id);
    }
}
