using LittleJohnsHutsPizzaPie.Models;
using LittleJohnsHutsPizzaPie.Functions;
using LittleJohnsHutsPizzaPie.XML;
using System;
using System.Collections.Generic;
using Xunit;


namespace TestingUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            List<User> order = new List<User>();
            string found = Searching.SearchingByName(order, "John");

        }
        [Fact]
        public void testDisplayByUser()
        {

        }
        [Fact]
        public void testDisplayInLocation()
        {

        }
        [Fact]
        public void testOrderMostExpencive()
        {

        }
        [Fact]
        public void TestOrderCheapest()
        {

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
