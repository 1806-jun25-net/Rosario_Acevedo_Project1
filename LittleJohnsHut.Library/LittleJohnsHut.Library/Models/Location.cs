using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Location : ILocation
    {
        public string address { get; set ; }
        public int ID { get ; set ; }


        private int Quantity;


        public int GetQuntity()
        {
            return Quantity;
        }

        public void SetQuntity(int value)
        {
            if (value <= 0)
            {
                Quantity = 0;
            }
            else
            {
                Quantity = value;
            }

        }

        public string NameOfProduct { get; set; }
        
    }
}
