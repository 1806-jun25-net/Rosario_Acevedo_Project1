using System;
using NLog;
namespace LittleJohnsHutsPizzaPlace
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            try
            {
                DisplayClasses dis = new DisplayClasses();
                dis.FirstMenuAsync();
            }catch(ArgumentException e)
            {
                logger.Error(e, "error thrown right after startup");
            }

           
        }
    }
}
