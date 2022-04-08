using System;
using Model.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Passenger : Person

    {
        #region Properties
     
        public string CodePassport { get; set; }

        #endregion

    }
}
