using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Model
{
    public class PriceBase
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public virtual Airport Origin { get; set; }  
        public  virtual Airport Destination { get; set; }     
        public decimal Value { get; set; }
        public double PercentPromotion { get; set; }
        public  virtual Class Class { get; set; }
        public DateTime InclusionDate {get; set;}
        #endregion
    }
}
