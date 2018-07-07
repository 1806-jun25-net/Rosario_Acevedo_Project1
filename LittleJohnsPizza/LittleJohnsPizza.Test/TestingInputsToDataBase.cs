using LittleJohnsPizza.Library;
using LittleJohnsPizza.Library.Function;
using System;
using Xunit;

namespace LittleJohnsPizza.Test
{
    public class TestingInputsToDataBase
    {
        

        [Theory]
        [InlineData("Cristian ", "Rosario", "CristianRosario", 2 )]
        public void TesttingRegisteringData(string FN, string LN, string UN, int loc)
        {
            Input i = new Input();
            i.RegisterUser(FN, LN, UN, loc); 
           
        }

        [Theory]
        [InlineData("Reston", "VA", "000-0000")]
        public void TesttingAddLocationData(string AL1, string AL2, string ZC)
        {
            Input i = new Input();
            i.AddLocation(AL1, AL2, ZC);
            
           

        }

        //[Theory]
        //[InlineData("Cristian ", "Rosario", "CristianRosario", 1)]
        //public void TesttingRegisteringData(string FN, string LN, string UN, int loc)
        //{
        //    Input i = new Input();
        //    i.RegisterUser(FN, LN, UN, loc);

        //}

        //[Theory]
        //[InlineData("Cristian ", "Rosario", "CristianRosario", 1)]
        //public void TesttingRegisteringData(string FN, string LN, string UN, int loc)
        //{
        //    Input i = new Input();
        //    i.RegisterUser(FN, LN, UN, loc);

        //}

        //[Theory]
        //[InlineData("Cristian ", "Rosario", "CristianRosario", 1)]
        //public void TesttingRegisteringData(string FN, string LN, string UN, int loc)
        //{
        //    Input i = new Input();
        //    i.RegisterUser(FN, LN, UN, loc);

        //}
    }
}
