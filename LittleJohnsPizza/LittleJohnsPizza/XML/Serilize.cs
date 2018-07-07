using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LittleJohnsPizza.Library.XML
{
    public class Serilize
    {
        public void SerilizeInventory(string fileName, List<Inventory> obj)
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
        public void SerilizerOrder(string fileName, List<Orders> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Orders
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
        public void SerilizerUser(string fileName, List<Users> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Users
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
        public void SerilizerLocation(string fileName, List<Locations> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Locations
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
    }
}
