using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Data
{
    public class ListElement
    {
        public string name;
        public object value;
        public DataBinding dataBinding;
        public ListElement childListElement = null;
    }
}
