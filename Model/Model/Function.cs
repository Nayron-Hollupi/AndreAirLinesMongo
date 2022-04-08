﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Model
{
    internal class Function
    {
        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Description { get; set; }
        public  List<Access> Access  { get; set; }
        #endregion
    }
}