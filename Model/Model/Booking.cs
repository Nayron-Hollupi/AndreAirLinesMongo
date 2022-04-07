using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace Model
{
    public class Booking
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public  virtual Flights Flights { get; set; }
        public virtual Passenger Passenger { get; set; }
        public decimal Value { get; set; }
        public virtual Class Class { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion
    }
}
