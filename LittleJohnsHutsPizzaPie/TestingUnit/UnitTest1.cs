using LittleJohnsHutsPizzaPie.Models;
using LittleJohnsHutsPizzaPie.Functions;

using LittleJohnsHutsPizzaPie.XML;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using LittleJohnsHutsPizzaPlace;

namespace TestingUnit
{
    public class UnitTest1
    {
        //[Fact]
        //public void Test1()
        //{
        //    Searching Search = new Searching();
        //    List<User> order = new List<User>();
        //    string found =  Search.SearchingByName(order, "John");

        //}
       
        [Fact]
        public async System.Threading.Tasks.Task testOrderMostExpenciveAsync()
        {
            DeSerilizer deSerilizer = new DeSerilizer();
            await deSerilizer.DesUser("UserDate.XML");

        }
        [Fact]
        public void TestOrderCheapest()
        {
            DisplayClasses dis = new DisplayClasses();
            dis.FirstMenuAsync();
        }
        [Fact]
        public void TestOrderLatest()
        {

        }
        [Fact]
        public void TestOrderEarliest()
        {

        }
        [Fact]
        public void TestSerilization()
        {

        }
        [Fact]
        public void TestDeSerilization()
        {

        }
    }
}
