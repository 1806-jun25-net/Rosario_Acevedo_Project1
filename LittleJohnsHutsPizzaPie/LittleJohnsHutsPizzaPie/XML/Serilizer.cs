using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LittleJohnsHutsPizzaPie.XML
{
    public class Serilizer
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
    }
}
