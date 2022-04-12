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
        public Passenger Passenger { get; set; }
        public  virtual Flights Flights { get; set; }  
        public virtual TypeClass TypeClass { get; set; }
      
        public DateTime RegisterDate { get; set; }
        public double Value { get; set; }
        public double PercentPromotion { get; set; }
        #endregion
    }
}
