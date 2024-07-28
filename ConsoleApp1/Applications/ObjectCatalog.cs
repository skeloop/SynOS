using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    internal class ObjectCatalog : Application
    {
        public override void Start()
        {
            DisableRuntimeNotification();
            Console.Title = $"{ProgramInit.title} - {displayName}";
            Console.Clear();
            Console.WriteLine("■ Namespace < SynOS");
            ShowClassInformation();
        }

        public void ShowClassInformation()
        {
            var classes = GetClassesInNamespace("SynOS");
            foreach (var cls in classes)
            {
                PrintColoredText("└─» " + cls.Name, cls.Name, ConsoleColor.Blue);
                Console.WriteLine(cls.FullName);

                Console.WriteLine("■ Variablen");

                object instance = null;
                try
                {
                    // Create an instance using the parameterless constructor
                    instance = Activator.CreateInstance(cls);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not create instance of {cls.Name}: {ex.Message}");
                }

                foreach (FieldInfo field in cls.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                {
                    object value = null;
                    try
                    {
                        // Handle static fields separately
                        if (field.IsStatic)
                        {
                            value = field.GetValue(null);
                        }
                        else
                        {
                            value = field.GetValue(instance);
                        }
                    }
                    catch (Exception ex)
                    {
                        value = $"Error: {ex.Message}";
                    }
                    PrintColoredText("└─» " + field.Name + " = " + value, field.Name, ConsoleColor.Blue);
                }
            }
            Console.WriteLine("===============================================");
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
