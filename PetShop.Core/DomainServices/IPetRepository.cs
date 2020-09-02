using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
   public  interface IPetRepository
    {

        public List<Pet> ReadPets();
        Pet CreatePet(Pet TheNewPet);

        void DeletePet(Pet petToDelete);
        Pet GetPetByID(int id);
        Pet UpdatePet(Pet pet);
    }
}
