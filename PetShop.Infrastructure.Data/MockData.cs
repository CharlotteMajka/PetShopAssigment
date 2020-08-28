using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class MockData
    {
        IPetRepository petRepo;
        

        public MockData(IPetRepository repo)
        {
            petRepo = repo;
        }

        public  void InitData()
        {

            var pet1 = new Pet
            {

                Name = "doggy",
                Dob = System.DateTime.Now.AddYears(-2),
                 Price = 1000.00,
                 Type = "dog"


            };


            var pet2 = new Pet
            {

                Name = "Bo",
                Dob = System.DateTime.Now.AddYears(-3),
                Price = 1500.00,
                Type = "Bird"


            };

            petRepo.CreatePet(pet1);
            petRepo.CreatePet(pet2);


        }







    }
}
