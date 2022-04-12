using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    internal class Log
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Passenger User { get; set; }
        public string EntityBefore { get; set; }
        public string EntityAfter { get; set; }
        public string Operation { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion
    }
}
