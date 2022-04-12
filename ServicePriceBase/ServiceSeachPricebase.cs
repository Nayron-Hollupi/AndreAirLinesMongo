using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace ServicePriceBase
{
    public class ServiceSeachPriceBase
    {

        static readonly HttpClient priceBase = new HttpClient();

        public static async Task<PriceBase> SeachPriceBase(string destination, string origin)
        {
            try
            {

                HttpResponseMessage response = await priceBase.GetAsync("https://localhost:44338/api/PriceBase/"+ origin +"/"+ destination);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var priceBaseJson = JsonConvert.DeserializeObject<PriceBase>(responseBody);
                return priceBaseJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
