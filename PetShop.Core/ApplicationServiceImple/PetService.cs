using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        

        public Pet UpdatePet(int idToupdate, string name, string type, DateTime dob, string color, string previousOwner, double price)
        {
            Pet upDatePet = petRepository.GetPetByID(idToupdate);

            upDatePet.Name = name;
            upDatePet.Type = type;
            upDatePet.Dob = dob;
            upDatePet.Color = color;
            upDatePet.PreviousOwner = previousOwner;
            upDatePet.Price = price;

            return upDatePet;
        }

        public IEnumerable<Pet> SortPetsByPrice()
        {
           var SortPetsByPrice = petRepository.ReadPets().OrderByDescending(s => s.Price);

            return SortPetsByPrice;


        }


        public IEnumerable<Pet> Get5ChepestPets()
        {
            var Get5ChepestPets = petRepository.ReadPets().OrderBy(s => s.Price);

            return Get5ChepestPets;


        }

        public IEnumerable<Pet> SearchPetByType(string stringToLookFore)
        {

            return petRepository.ReadPets().FindAll(s => s.Type.ToLower().Contains(stringToLookFore.ToLower()));//.Equals(stringToLookFore.Trim()));


        }
    }
}
