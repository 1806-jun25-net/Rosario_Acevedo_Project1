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
        public async Task<IEnumerable<Locations>> DesLocation(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Locations>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Locations>)serial.Deserialize(ms);
            }

        }
        public async Task<IEnumerable<Orders>> DesOrder(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Orders>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Orders>)serial.Deserialize(ms);
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
        public async Task<IEnumerable<Users>> DesUser(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Users>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Users>)serial.Deserialize(ms);
            }

        }
    }
}
