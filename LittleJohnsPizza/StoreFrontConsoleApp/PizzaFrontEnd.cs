using System;
using LittleJohnsPizza.Library;
using System.Collections.Generic;
using System.Text;
using StoreFrontConsoleApp.GUI;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StoreFrontConsoleApp
{
    public class PizzaFrontEnd
    {
        public static void Main(string [] Args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSetting.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();


            Console.WriteLine(configuration.GetConnectionString("DataBaseConnection"));

            var options = new 



            Menus m = new Menus();
            m.StartingMenu();
           

        }
    }
}
