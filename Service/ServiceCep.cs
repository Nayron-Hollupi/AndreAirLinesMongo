using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Service
{
    public class ServiceCep
    {
        static readonly HttpClient endereco = new HttpClient();



        public static async Task<Address> CorreioApi(string cep)
        {

            try
            {
                HttpResponseMessage response = await ServiceCep.endereco.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string jsonendereco = await response.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<Address>(jsonendereco);


                return endereco;

            }
            catch (HttpRequestException)
            {
                return null;
                //throw;

            }
        }
    }
}
