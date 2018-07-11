using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Library.XML;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace LittleJohnsHut.Test
{
    public class TestingLibrary
    {
        [Fact]
        public void Test1()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository(new LitteJohnsDBContext(optionsBuilder.Options));


           var Display = repo.DiplayMostExpencive();
            Serilize ser = new Serilize();
            ser.SerilizerOrder("OrderByMostExpencive.XML", Display.ToList());


        }
    }
}
