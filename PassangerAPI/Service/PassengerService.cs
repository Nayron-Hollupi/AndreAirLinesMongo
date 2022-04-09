using System.Collections.Generic;
using Model;
using MongoDB.Driver;
using PassengerAPI.Utils;

namespace PassengerAPI.Service
{
    public class PassengerService 
    {
        private readonly IMongoCollection<User> _passenger;

        public PassengerService(IPassengerUtilsDatabaseSettings settings)
        {
            var passenge = new MongoClient(settings.ConnectionString);
            var database = passenge.GetDatabase(settings.DatabaseName);
            _passenger = database.GetCollection<User>(settings.PassengerCollectionName);
        }

        public List<User> Get() =>
       _passenger.Find(passenger => true).ToList();
        public User Get(string id) =>
            _passenger.Find<User>(passenger => passenger.Id == id).FirstOrDefault();

        public User ExistCPF(string CPF) =>
            _passenger.Find<User>(passenger => passenger.CPF == CPF).FirstOrDefault();


        public User Create(User passenger)
        {

            _passenger.InsertOne(passenger);
            return passenger;
        }

        public void Update(string id, User passengerIn) =>
            _passenger.ReplaceOne(passenger => passenger.Id == id, passengerIn);

        public void Remove(User passengerIn) =>
            _passenger.DeleteOne(passenger => passenger.Id == passengerIn.Id);

        public void Remove(string id) =>
           _passenger.DeleteOne(passenger => passenger.Id == id);


        public bool CheckCpf(string cpf)
        {
            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierOne[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierTwo[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
    }

    
}

