using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using MEFModularDesign;
using System.ComponentModel.Composition;

namespace LoadDLL
{
    [Export(typeof(ILoader))]
    public class Load : ILoader
    {
        public List<myPerson> load()
        {
            string text = File.ReadAllText(@"C:\Users\Murat\Documents\Visual Studio 2015\Projects\Jeerjaar2\c sharp\MEFModularDesign\MyJson.json");
            List<myPerson> readPerson = JsonConvert.DeserializeObject<List<myPerson>>(text);

            return readPerson;
        }
    }
}
