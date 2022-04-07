using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Model
{
    public class Address
    {
        #region Propertiebairs
     
        [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("bairro")]
        public string District { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string State { get; set; }
        [JsonProperty("logradouro")]
        public string Street { get; set; }
        [JsonProperty("gia")]
        public string Number { get; set; }
        [JsonProperty("complemento")]
        public string Complement { get; set; }

        #endregion
    }

   
}
