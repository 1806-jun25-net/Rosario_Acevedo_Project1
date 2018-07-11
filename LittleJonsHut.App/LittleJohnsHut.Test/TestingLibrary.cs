using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.BusinessLogic;
using LittleJohnsHut.Library.Model;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Library.XML;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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

            var or = new List<Order>();
            Serilize ser = new Serilize();
            ser.SerilizerOrder("C:/OrderByMostExpencive.XML", or );

        }
        [Fact]
        public void Test2()
        {

            var or = new List<Library.Model.Inventory>();
            Serilize ser = new Serilize();
            ser.SerilizeInventory("C:/Testing2.XML", or);

        }
        [Fact]
        public void Test3()
        {

            var or = new List<Location>();
            Serilize ser = new Serilize();
            ser.SerilizerLocation("C:/Testing3.XML", or);

        }
        [Fact]
        public void Test4()
        {

            var or = new List<User>();
            Serilize ser = new Serilize();
            ser.SerilizerUser("C:/User.XML", or);

        }
        [Fact]
        public void Test5()
        {
            var or = new List<Library.Model.Pizza>();
            Serilize ser = new Serilize();
            ser.SerilizerPizza("C:/Pizza.XML", or);
        }
        [Fact]
        public void Test6()
        {
            var or = new User();
            Serilize ser = new Serilize();
            ser.SerilizerSession("C:/Session.XML", or);
        }
        [Fact]
        public void Test7()
        {
            User u = new User();
            Validation v = new Validation();
            var t = v.UniqueUser(u);
        }








    }
}
