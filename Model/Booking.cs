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
        public virtual User Passenger { get; set; }      
        public virtual Class Class { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal Value { get; set; }
        public double PercentPromotion { get; set; }
        public string LoginUser { get; set; }
        #endregion
    }
}
