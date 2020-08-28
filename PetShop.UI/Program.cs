using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationServiceImple;
using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using System;
using System.Security.Authentication.ExtendedProtection;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            var petRepository = serviceProvider.GetRequiredService<IPetRepository>();

            var mockData = new MockData(petRepository);
            mockData.InitData();
            printer.StartUI(); 
            
        }
    }
}
