using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
   public class AddressAirport
    {
        #region Propertiebairs
     
        public string Country { get; set; }
        [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("complement")]
        public string Complement { get; set; }

        #endregion
    }
}
