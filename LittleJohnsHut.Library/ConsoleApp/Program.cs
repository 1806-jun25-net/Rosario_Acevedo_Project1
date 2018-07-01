using LittleJohnsHut.Library.Models;
using System;

using System.Collections.Generic;

using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            var list = new List<Location>();
            list.Add(new Location
            {
                ID = 1,
                address = "reston VA"


            });


            Console.WriteLine("Before the method");
            foreach ( var item in list)
            {
                Console.WriteLine(item.ID +" "+item.address);
            }
            
            Serilizer("data.xml", obj:  list);
            Console.ReadLine();

        }
        
        public static void Serilizer(string fileName, List<Location> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Location
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
      
        public async Task<IEnumerable<object>> Des(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Location>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<object>)serial.Deserialize(ms);
            }

        }
    }
    
}

