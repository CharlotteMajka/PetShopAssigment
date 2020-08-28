using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServiceImple
{
   public class PetService : IPetService
    {
        private IPetRepository petRepository;

        public PetService(IPetRepository _petRepository)
        {
            petRepository = _petRepository;
        }

        public Pet AddNewPet(string name, string type,DateTime dob, string color, string previousOwner, double price)
        {
            Pet TheNewPet = new Pet()
            {
                Name = name,
                Type = type,
                Dob = dob,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return petRepository.CreatePet(TheNewPet);
        }

        public Pet DeletePet(int id)
        {
            var pet = petRepository.GetPetByID(id);
            if( pet == null)
            {
                throw new Exception();
            }
             petRepository.DeletePet(pet);
            return pet; 
        }

        public List<Pet> getPets()
        {   
            return petRepository.ReadPets();
        }
    }
}
