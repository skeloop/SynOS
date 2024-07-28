using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS
{
    public struct PrintInformation
    {
        public string text;
        public ConsoleColor color;
        public int startSpacing, endSpacing;
        public int index;
    }
    public class Print
    {
        public List<PrintInformation> printInformation = new List<PrintInformation>()
        {
            new PrintInformation()
            {
                text = "Test1",
                color = ConsoleColor.Green,
                startSpacing = 10,
                endSpacing = 0,
                index = 0
            },
            new PrintInformation()
            {
                text = "Test2",
                color = ConsoleColor.Red,
                startSpacing = 20,
                endSpacing = 15,
                index = 0
            },
        };
        /// <summary>
        /// Gibt den Inhalt (PrintInformation) der Klasse in der Konsole aus
        /// </summary>
        public void PrintContent()
        {
            foreach (var info in printInformation)
            {
                string spaceString = "";
                string text = "Empty Text";
                Console.ForegroundColor = info.color;
                for(int i = 0; i < info.startSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{spaceString}{text}";
                spaceString = "";
                for (int i = 0; i < info.endSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{text}{spaceString}";
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }
    }
}
