﻿using System.Collections.Generic;
using Model;
using MongoDB.Driver;
using FlightsAPI.Utils;

namespace FlightsAPI.Service
{
    public class FightService
    {
        private readonly IMongoCollection<Flights> _fight;

        public FightService(IFightUtilsDatabaseSettings settings)
        {
            var figh = new MongoClient(settings.ConnectionString);
            var database = figh.GetDatabase(settings.DatabaseName);
            _fight = database.GetCollection<Flights>(settings.FightCollectionName);
        }

        public List<Flights> Get() =>
       _fight.Find(fight => true).ToList();
        public Flights Get(string id) =>
            _fight.Find<Flights>(fight => fight.Id == id).FirstOrDefault();

        public Flights Create(Flights fight)
        {
            _fight.InsertOne(fight);
            return fight;
        }

        public void Update(string id, Flights fightIn) =>
            _fight.ReplaceOne(fight => fight.Id == id, fightIn);

        public void Remove(Flights fightIn) =>
            _fight.DeleteOne(fight => fight.Id == fightIn.Id);

        public void Remove(string id) =>
           _fight.DeleteOne(fight => fight.Id == id);
    }
}
