using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace ServicceAircraft
{
    public class ServiceSeachAircraft
    {
        static readonly HttpClient aircraft = new HttpClient();

        public static async Task<Aircraft> SeachAircraft(string Registry)
        {


            try
            {
                HttpResponseMessage response = await aircraft.GetAsync("https://localhost:44387/api/Aircraft/" + Registry.ToUpper());
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var aircraftJson = JsonConvert.DeserializeObject<Aircraft>(responseBody);
                return aircraftJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
