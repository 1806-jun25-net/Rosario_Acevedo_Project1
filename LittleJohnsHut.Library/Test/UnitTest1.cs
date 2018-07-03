using System;
using LittleJohnsHut.Library.Models;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            

        }
        [Theory]
        [InlineData("12345", "1234567")]
        public void TestingByName(List<User> user, string TheName)
        {
            searchByName(user, TheName);
        }
        [Fact]
        public void TesttingDisplayOrderByUSer()
        {

        }
        [Fact]
        public void TestingDisplayOrderInLocation()
        {

        }
        [Fact]
        public void testingOrderEarlest()
        {

        }
        [Fact]
        public void testingOrderLatest()
        {

        }
        [Fact]
        public void testingOrderChepest()
        {

        }
        [Fact]
        public void testtingOrderMostExpencive()
        {

        }
    }
}
