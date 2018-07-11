
using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LittleJohnsPizza.Library.XML
{
    public class DeSerilize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        public async Task<User> DesSession(string fn)
        {
            var serial = new XmlSerializer(typeof(User));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (User)serial.Deserialize(ms);
            }

        }
    }
}
