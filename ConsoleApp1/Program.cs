using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;


namespace SynOS
{
    public class ProgramInit
    {
        static DataBinding TestClass = new DataBinding();
        public static Screen mainScreen = new Screen();
        
        //Test
        static Print print = new Print();
        public static string title = "SynOS";
        public void Init()
        {
            Console.Title = "SynOS";
            Console.WriteLine("Drücke ENTER");
        }
    }
    

    internal class Program
    {
        static ProgramInit programInit = new ProgramInit();
        static void Main(string[] args)
        {
            programInit.Init();
            ProgramInit.mainScreen.Start();
            Console.ReadKey(true);
        }

    }
}
