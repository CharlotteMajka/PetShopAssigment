using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {

        public List<Pet> getPets();

        Pet AddNewPet(string name, string type, DateTime dob, string color, string previousOwner, double price);

        Pet DeletePet(int id);

        Pet UpdatePet(int idToupdate, string name, string type, DateTime dob, string color, string previousOwner, double price);

        IEnumerable<Pet> SortPetsByPrice();

        IEnumerable<Pet> Get5ChepestPets();


    }
}
