using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        static List<Pet> listPets = new List<Pet>();

       

        public List<Pet> ReadPets()
        {
            return (List<Pet>)listPets;
        }


        public Pet CreatePet(Pet pet1)
        {
            pet1.Id = id++;
            listPets.Add(pet1);
            return pet1;
        }

        public void DeletePet(Pet petToDelete)
        {

            listPets.Remove(petToDelete);

        }

        public Pet GetPetByID(int id)
        {
           /* Pet petFound = null;
            foreach (var item in ReadPets())
            {
                if (item.Id == id)
                {
                    petFound = item;

                }
            }

            if(petFound == null)
            {
                throw new Exception(); 
            }*/
            //var result = from s in listPets where s.Id == id select s;

            var result = listPets.Where(p => p.Id == id).FirstOrDefault();

            return result;
        }
    }
}
