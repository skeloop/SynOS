using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    public class Settings : Application
    {
        ListSelection settingsListSelection = new ListSelection();

        static List<string> settings = new List<string>()
        {
            "Benutzerfarbe",
            "Speicherort",
            "Netzwerk",
            "Applications"
        };

        public override void Start()
        {
            settingsListSelection.printTexts.Clear();
            foreach (var setting in settings)
            {
                settingsListSelection.AddListElement(setting);
            }
            settingsListSelection.Render();
        }

        public override void Update()
        {
            
        }


    }
}
