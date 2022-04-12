using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
using Moq;
using UserAPI.Service;
using Xunit;

namespace UserAPI.Test
{
    public class UnitTestUser
    {
        private List<User> _user;

        private async void InitializeDataBase()
        {
            _user = new List<User>();
            _user.Add(new User { Id = "1", CPF = "37301170840", Name = "Nayron Victor", Phone = "(16) 98801-5623", BirthDate = DateTime.Now, Email = "nayron@gmail.com" , Password = "123456", Login = "Nayron", });
            // new Address {Id = "1",Country = "Brasil",CEP = "159100",District = "" ,City = "Monte Alto", State = "SP",Street= "", Number = "", Complement = ""  });


        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            var mock = new Mock<IUserService>();

            mock.Setup(x => x.Get()).Returns(_user);

            IUserService mongoService = mock.Object;

            var items = mongoService.Get(); //Should call mocked service;
            var count = items.Count;
            Assert.Equal(3, count);
        }



        [Fact]
        public void TestUser()
        {

        }
    }

}