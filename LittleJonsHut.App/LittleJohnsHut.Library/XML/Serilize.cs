using LittleJohnsHut.Library.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LittleJohnsHut.Library.XML
{
    public class Serilize
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
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
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
        public void SerilizerSession(string fileName, User obj)
        {
            var Serial = new XmlSerializer(typeof(User
                ));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
                logger.Error(e, "File not found");
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e, "File not found");
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
