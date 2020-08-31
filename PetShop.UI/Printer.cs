using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI
{
    public class Printer: IPrinter
    {
        private IPetService PetService; 

        public Printer(IPetService _PetService)
        {
            PetService = _PetService;
        }

        public void StartUI()
        {
            string[] menuItems = {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "5 Cheapest Pets",
                "Search Pets by type",
                "Sort Pets by Price",
                "Exit"

            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ListAllPets(PetService.getPets());
                        break;
                    case 2:
                        // addPEt
                        CreateNewPet(); 

                        break;
                    case 3:
                        //DeletePet;
                        DeletePet();
                        break;
                    case 4:
                        //Console.WriteLine("Update Car");
                        UpdatePet();
                        break;
                    case 5:
                        //ShowCheapestPets();
                        Get5ChepestPets(); 
                        break;
                    case 6:
                        //Search Pets by type 
                        SearchPetByType();
                        break;
                    case 7:
                        //Sort Pets by Price
                        SortPetsByPrice();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private void SearchPetByType()
        {
            
            String stringToLookFore = AskQuestion("Enter which type of pet your are looking for:\n ");

            List<Pet> pets = (List<Pet>)PetService.SearchPetByType(stringToLookFore.Trim());

            foreach (var item in pets)
            {
                WriteLine($" ID: {item.Id}\n Name: {item.Name}\n DoB: {item.Dob.ToShortDateString()}\n Price: {item.Price}\n Type: {item.Type}\n ");

            }


        }

        private void DeletePet()
        {

            //int IdToDelete;
            WriteLine("Please type the ID for the Pet you whant to Delete:");

           int IdToDelete =  GetID();

            /*while( !int.TryParse(Console.ReadLine(), out IdToDelete))
            {
                WriteLine("Please insert a Valid ID number");
            }*/
            /*Pet PetFound = null;

            foreach (var item in PetService.getPets())
            {
                if (item.Id == IdToDelete)
                {
                    PetFound = item;
                  
                }
            }

            if(PetFound != null)
            {
                PetService.DeletePet(PetFound);
                 WriteLine( $" ID: {PetFound.Id}  Name:{PetFound.Name} was Deleted ");
            }*/
            var tempPet = PetService.DeletePet(IdToDelete);
            WriteLine($"\n ID: {tempPet.Id}  Name:{tempPet.Name} was deleted\n ");

        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (var i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }


        void WriteLine(String textToWitre)
        {
            Console.WriteLine(textToWitre);
        }

        string AskQuestion(string question)
        {
            WriteLine(question);
            return Console.ReadLine(); 

        }


        public void ListAllPets(List<Pet> pets) 
        {
            WriteLine("\nList of Pets :");
            if (pets.Count > 0)
            {
                foreach (var item in pets)
                {
                    WriteLine($" ID: {item.Id}\n Name: {item.Name}\n DoB: {item.Dob.ToShortDateString()}\n Price: {item.Price}\n Type: {item.Type}\n ");

                }
            }
            else
            {
                WriteLine("ther is no Pets in List");
            }

        }

        public void CreateNewPet()
        {
            var name = AskQuestion("\nWrite The name of the new Pet:");
            var type = AskQuestion("Write The Type of the new Pet:");
            DateTime Dob;
            var Color = AskQuestion("Write The color of the new Pet:");
            var previousOwner = AskQuestion("Write The previus owner of the new Pet:");
           
            double price;

            DateTime.TryParse(AskQuestion("Write The date of birth(DoB) of the new Pet:"), out Dob);

            Double.TryParse(AskQuestion("Enter the Price for the Pet: "), out price);

            var theNewPet = PetService.AddNewPet(name, type, Dob,  Color, previousOwner, price);

            Console.WriteLine($" \nnew Pet Added!! :\nID:{theNewPet.Id} \nName: {theNewPet.Name}\n");


        }

        public void UpdatePet()
        {

            
            WriteLine("Please type the ID for the Pet you want to Update:");

            /*while (!int.TryParse(Console.ReadLine(), out IdToDelete))
            {
                WriteLine("Please insert a Valid ID number");
            }*/

            int IdToupdate = GetID();

            var name = AskQuestion("\nWrite The new name of the Pet:");
            var type = AskQuestion("Write The new Type of the Pet:");
            DateTime Dob;
            var Color = AskQuestion("Write The new color of the Pet:");
            var previousOwner = AskQuestion("Write The previus owner of the Pet:");

            double price;

            DateTime.TryParse(AskQuestion("Write The date of birth(DoB) of the Pet:"), out Dob);

            Double.TryParse(AskQuestion("Enter the Price for the Pet: "), out price);

            var thePetUpdate = PetService.UpdatePet(IdToupdate, name, type, Dob, Color, previousOwner, price);

            Console.WriteLine($" \nnew Pet Updatet :\nID:{thePetUpdate.Id} \nName: {thePetUpdate.Name}\n");



        }

        public int GetID()
        {

            int IdToGet;
           
            while (!int.TryParse(Console.ReadLine(), out IdToGet))
            {
                WriteLine("Please insert a Valid ID number");
            }
            return IdToGet;
        }


        public void SortPetsByPrice()
        {
            WriteLine("List af Pets Sorted by Price Desc\n");
            foreach (var item in PetService.SortPetsByPrice())
            {
                WriteLine($" ID: {item.Id}\n Name: {item.Name}\n DoB: {item.Dob.ToShortDateString()}\n Price: {item.Price}\n ");
            }


        }

        public void Get5ChepestPets()
        {
            WriteLine("Here is the 5 Chepest pets:\n");

            int count = 0;
    
                foreach (var item in PetService.Get5ChepestPets())
                {   WriteLine($" ID: {item.Id}\n Name: {item.Name}\n DoB: {item.Dob.ToShortDateString()}\n Price: {item.Price}\n ");
                    count++;
                     if (count > 4)
                    {
                    break;
                    }
                
                } 
            

        }


    }
}
