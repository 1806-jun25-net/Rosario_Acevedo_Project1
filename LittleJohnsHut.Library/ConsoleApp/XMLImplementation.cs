using LittleJohnsHut.Library.Models;
using System;

using System.Collections.Generic;

using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp
{
    class XMLIMplementation
    {
      
        public void SerilizerOrder(string fileName, List<Order> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Order
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
        public void SerilizerUser(string fileName, List<User> obj)
        {
            var Serial = new XmlSerializer(typeof(List<User
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
        public void SerilizerInv(string fileName, List<Inventory> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Inventory
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
        public void SerilizerPizza(string fileName, List<Pizza> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Pizza
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
        public void SerilizerLocation(string fileName, List<Location> obj)
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
      
        public async Task<IEnumerable<Location>> DesLocation(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Location>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Location>)serial.Deserialize(ms);
            }

        }
        public async Task<IEnumerable<Order>> DesOrder(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Order>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Order>)serial.Deserialize(ms);
            }

        }
        public async Task<IEnumerable<Pizza>> DesPizza(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Pizza>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Pizza>)serial.Deserialize(ms);
            }

        }
        public async Task<IEnumerable<User>> DesUser(string fn)
        {
            var serial = new XmlSerializer(typeof(List<User>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<User>)serial.Deserialize(ms);
            }

        }
        public async Task<IEnumerable<Inventory>> DesInv(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Inventory>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Inventory>)serial.Deserialize(ms);
            }

        }
    }
    
}

