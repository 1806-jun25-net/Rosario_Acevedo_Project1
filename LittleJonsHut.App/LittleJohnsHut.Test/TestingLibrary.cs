using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.IO;
using Xunit;

namespace LittleJohnsHut.Test
{
    public class TestingLibrary
    {
        [Theory]
        [InlineData (2, 2)]
        public void Test1(int x, int y)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository(new LitteJohnsDBContext(optionsBuilder.Options));

           


        }
    }
}
