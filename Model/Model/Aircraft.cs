

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Aircraft
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Registry { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string LoginUser { get; set; }

        #endregion
    }

}
