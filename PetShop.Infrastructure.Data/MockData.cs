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
                 Price = 1000,
                 Type = "dog"


            };


            var pet2 = new Pet
            {

                Name = "Bo",
                Dob = System.DateTime.Now.AddYears(-3),
                Price = 1500,
                Type = "Bird"


            };

            var pet3 = new Pet
            {

                Name = "HAns",
                Dob = System.DateTime.Now.AddYears(-6),
                Price = 400.00,
                Type = "dog"


            };

            var pet4 = new Pet
            {

                Name = "bird",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 100.00,
                Type = "bird"


            };
            var pet5 = new Pet
            {

                Name = "penny",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 200.00,
                Type = "Horse"


            };
            var pet6 = new Pet
            {

                Name = "kim",
                Dob = System.DateTime.Now.AddYears(-7),
                Price = 300.00,
                Type = "pig"


            };




            petRepo.CreatePet(pet1);
            petRepo.CreatePet(pet2);
            petRepo.CreatePet(pet3);
            petRepo.CreatePet(pet4);
            petRepo.CreatePet(pet5);
            petRepo.CreatePet(pet6);


        }







    }
}
