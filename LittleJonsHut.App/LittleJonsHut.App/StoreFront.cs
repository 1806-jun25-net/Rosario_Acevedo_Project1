using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;

namespace LittleJohnsHut.App
{
    class StoreFront
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository(new LitteJohnsDBContext(optionsBuilder.Options));

            var Location = repo.DisplayLocation();
            foreach (var item in Location)
            {
                Console.WriteLine($"Name {item.AdressLine1}," +
                    $" genre {item.Id}");
            }
            Console.ReadLine();
        }
    }
}
