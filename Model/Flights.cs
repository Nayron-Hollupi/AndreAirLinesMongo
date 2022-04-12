using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Model
{
    public class Flights
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Airport Destination { get; set; }
        public Airport Origin { get; set; }
        public Aircraft Aircraft { get; set; }
        public DateTime BoardingTime { get; set; }
        public DateTime LandingTime { get; set; }
        #endregion
    }
}
