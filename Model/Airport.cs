
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Airport
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CodeIATA { get; set; }
        public string Name { get; set; }
        public AddressAirport AddressAirport { get; set; }

        #endregion  


    }

  
}
