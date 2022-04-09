using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class User : Person
    {
        #region Properties
        public string Password { get; set; }
        public string Login { get; set; }
        public string Zone { get; set; }
        public Role Role { get; set; }

        #endregion

    }
}
