using System;
using System.Collections.Generic;
using AircraftAPI.Service;
using AircraftAPI.Utils;
using Model;
using Moq;
using Xunit;

namespace AircraftAPI.Test
{
    public class UnitTestAircraft 
    {
        private List<Aircraft> _aircraft;

        public class ProjMongoDBApiSettings : IAircraftUtilsDatabaseSettings
        {

            public string AircraftCollectionName { get; set; } = "Aircraft";
            public string ConnectionString { get; set; } = "mongodb://localhost:27017";
            public string DatabaseName { get; set; } = "db_Aircraft";
        }

        private AircraftService InitializeDataBase()
        {

            var settings = new ProjMongoDBApiSettings();
            AircraftService aircraftService = new(settings);
            return aircraftService;
 
/*
           _aircraft = new List<Aircraft>();
            _aircraft.Add(new Aircraft { Id = "1", Registry = "A40", Name = "Boing 777", Capacity =550 });
            _aircraft.Add(new Aircraft { Id = "2", Registry = "B30", Name = "Boing 755", Capacity = 500 });
            _aircraft.Add(new Aircraft { Id = "3", Registry = "C60", Name = "Boing 725", Capacity = 540 });
            _aircraft.Add(new Aircraft { Id = "4", Registry = "D50", Name = "Boing 745", Capacity = 50 });
           */

        }
      [Fact]
        public  void GetAll()
        {

            var aircraftService = InitializeDataBase();
            var aircraft = aircraftService.Get(); 
        }

       /* [Fact]
         public  void GetId()
         {
             InitializeDataBase();

             var mock = new Mock<IAircraftService>();

             mock.Setup(x => x.Get()).Returns(_aircraft);

             IAircraftService mongoService = mock.Object;

            string aircraftId = "2";
             var item = mongoService.Get(aircraftId);
            Assert.Equal("2",item.Id);

         }
        /*
       [Fact]
        public async void Create()
        {
            InitializeDataBase();

            Aircraft aircraft = new Aircraft()
            {
                Id = "1",
                Registry = "L40",
                Name = "Boing 757",
                Capacity = 5350
            };


            var mock = new Mock<IAircraftService>();

    

            IAircraftService mongoService = mock.Object;

          await carsController.PostCar(car);
                Car carReturn = carsController.GetCar(4).Result.Value;
                Assert.Equal("Kwid", carReturn.Model);
            
        }

        /*
                [Fact]
                public void Delete()
                {
                    InitializeDataBase();

                    var mock = new Mock<IAircraftService>();

                    mock.Setup(x => x.Get()).Returns(_aircraft);

                    IAircraftService mongoService = mock.Object;
                    string Aircraft = "2";

                    var items = mongoService.Remove(Aircraft);
                    var count = items.Count;
                    Assert.Null(items);

                }*/
    }
}
