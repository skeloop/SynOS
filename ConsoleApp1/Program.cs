using System;
using System.Linq;
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

        public static string editingModPath = "E:\\Arbeitsplatz\\FCM\\FCM_Console";

        static void Main(string[] args)
        {
            ProgramInit.Init();
            mainScreen.Start();
            Console.ReadKey(true);
        }
        public void ShowClassInformation()
        {
            var classes = GetClassesInNamespace("ConsoleApp1");
            Console.WriteLine("■ Klassen > ConsoleApp1");
            foreach (var cls in classes)
            {
                PrintColoredText("└─» " + cls.Name, cls.Name, ConsoleColor.Blue);
            }

            Console.WriteLine(DataBinding.GetInstanceName(TestClass));

            Console.WriteLine("===============================================");
            Console.WriteLine("■ Variablen");
            foreach (string arg in DataBinding.GetVariableNames(TestClass))
            {

                PrintColoredText("└─» " + arg + " = 'value'", arg, ConsoleColor.Blue);
            }
        }
        public static Type[] GetClassesInNamespace(string namespaceName)
        {
            // Ermitteln des aktuellen Assemblies
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Ermitteln aller Typen im aktuellen Assembly
            Type[] types = assembly.GetTypes();

            // Filtern der Typen, um nur die Klassen im angegebenen Namespace zu erhalten
            var classTypes = types.Where(t => t.IsClass && t.Namespace == namespaceName).ToArray();

            return classTypes;
        }
        public static void PrintColoredText(string fullText, string textToColor, ConsoleColor color)
        {
            int startIndex = fullText.IndexOf(textToColor);
            if (startIndex == -1)
            {
                Console.WriteLine(fullText);
                return;
            }

            // Teile vor dem zu färbenden Text ausgeben
            Console.Write(fullText.Substring(0, startIndex));

            // Farbe ändern und den zu färbenden Text ausgeben
            Console.ForegroundColor = color;
            Console.Write(textToColor);

            // Farbe zurücksetzen und den Rest des Textes ausgeben
            Console.ResetColor();
            Console.WriteLine(fullText.Substring(startIndex + textToColor.Length));
        }
    }
}
