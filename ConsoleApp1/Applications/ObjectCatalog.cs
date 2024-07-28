using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    internal class ObjectCatalog : Application
    {
        public override void Start()
        {
            Console.Title = $"{ProgramInit.title} - {displayName}";
        }

        
    }
}
