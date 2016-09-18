using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MEFModularDesign;
using System.ComponentModel.Composition;

namespace SortDLL
{
    [Export(typeof(ISorter))]
    public class Sort : ISorter
    {
        List<int> leeftijdSorted = new List<int>();

        public List<int> sort(List<myPerson> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                leeftijdSorted.Add(list[i].age);
            }

            leeftijdSorted.Sort();
            return leeftijdSorted;
        }
    }
}
