using System;
using Model;

namespace LogsService
{
    public class AircrafLog
    {


        public string Id { get; set; }
        public User User { get; set; }
        public string EntityBefore { get; set; }
        public string EntityAfter { get; set; }
        public string Operation { get; set; }
        public DateTime CreationDate { get; set; }



        var weatherForecast = new Log
        {
            User = new User
            {
                Login = "",
                Role = new Role { Description = "" },

            },
            User = new User
            {
                Login = "",
                Role = new Role { Description = "" },

            },
        };

        /*

        var weatherForecast = new Voo

        {
            Destino = new Aeroporto
            {
                Sigla = sigla[mIndex],
                Nome = aeroportonome[fIndex],
                Endereco = new Endereco { }
            },
            Origem = new Aeroporto { Sigla = sigla[mIndex], Nome = aeroportonome[fIndex], Endereco = new Endereco { } },
            Aeronave = new Aeronave { Id = sigla[mIndex], Nome = aeroportonome[fIndex] },
            HorarioEmbarque = DateTime.Parse("2019-08-01"),
            HoraDesembarque = DateTime.Parse("2019-08-01"),
            Passageiro = new Passageiro { Endereco = new Endereco { } }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(weatherForecast, options);

        Console.WriteLine(jsonString + "\n\n\n\n\n");
                }*/
    }
}
