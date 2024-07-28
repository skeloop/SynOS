using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;


namespace SynOS
{


    public class ProgramInit
    {
        public static string title = "SynOS";
        public static void Init()
        {
            UserInput.Init();
            Console.Title = "SynOS";
            Console.WriteLine("Drücke ENTER");
        }
    }
    

    internal class Program
    {

        static DataBinding TestClass = new DataBinding();
        static Screen mainScreen = new Screen();

        static Print print = new Print();

        static void Main(string[] args)
        {
            ProgramInit.Init();
            mainScreen.Start();
            Console.ReadKey(true);
        }

    }
}
