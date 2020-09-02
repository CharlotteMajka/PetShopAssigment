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



            if (name.Trim().Length < 2)
            {
                Console.WriteLine("Name must have minimum 2 letters in it");
            }
           /* if (!type.Trim().Contains(""))
            {
                upDatePet.Type = type;
            }
            if (!dob.ToString().Trim().Contains(""))
            {
                upDatePet.Dob = dob;
            }
            if (!color.Trim().Contains(""))
            {
                upDatePet.Color = color;
            }
            if (!previousOwner.Trim().Contains(""))
            {
                upDatePet.PreviousOwner = previousOwner;
            }
            if (!price.ToString().Trim().)
            {
                upDatePet.Price = price;
            }*/

            return petRepository.UpdatePet(new Pet { Id = idToupdate, Name = name, Type = type, Dob = dob, Color = color, PreviousOwner = previousOwner, Price = price });
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
