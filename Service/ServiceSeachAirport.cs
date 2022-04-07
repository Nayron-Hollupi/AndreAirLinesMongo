using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Service
{
    public class ServiceSeachAirport
    {
        static readonly HttpClient airport = new HttpClient();

        public static async Task<Airport> SeachAirport(string CodeIATA)
        {
            try
            {
                HttpResponseMessage response = await airport.GetAsync("https://localhost:44398/api/Airport/" + CodeIATA);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var airportJson = JsonConvert.DeserializeObject<Airport>(responseBody);
                return airportJson;
            }
            catch (Exception)
            {

                return null;
                //throw;
            }
        }
    }
}
