using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    internal class FactorioModCreator : Application
    {
        List<string> optionsList = new List<string>()
        {
            "Projekt erstellen",
            "Projekt laden",
            "Projekt löschen"
        }; 
        void Print()
        {
            Console.Clear();
            Console.WriteLine("Options: ");
            foreach(var option in optionsList) { Console.WriteLine("--"+option); }
        }

        public override void Start()
        {
            Print();
        }

        public override void Update()
        {
            
        }

    }
}
