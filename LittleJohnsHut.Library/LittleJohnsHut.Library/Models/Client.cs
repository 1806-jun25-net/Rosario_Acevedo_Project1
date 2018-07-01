using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    class Client : IClient
    {
        public DateTime DateAndTimeOrderWasPlace { get; set ; }
        public string oreder { get ; set ; }
        public IEnumerable<string> billing_Information { get ; set ; }
        public string name { get ; set ; }
        public string address_Line1 { get; set; }
        public string address_Line2 { get ; set ; }
        public string ZipCode { get ; set ; }
    }
}
