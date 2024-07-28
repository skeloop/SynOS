using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS
{
    public static class PrintHelper
    {
        public static void Directories(string path)
        {
            foreach(var dir in Directory.GetDirectories(path))
            {
                Console.WriteLine(dir);
            }
        }

        public static void Text(string text)
        {
            Console.WriteLine(text);
        }

        public static void Texts(string[] text)
        {
            Console.WriteLine(text);
        }
    }
    public struct PrintInformation
    {
        public string text;
        public ConsoleColor color;
    }
    public class Print
    {
        public List<string> texts;
        public void PrintContent()
        {
            foreach(var text in texts)
            {
                Console.WriteLine(text);
            }
        }
    }
}
