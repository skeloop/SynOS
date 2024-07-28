using SynOS.Applications;
using SynOS.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SynOS
{
    public enum Direction { Left, Right, Up, Down }
    public enum InputInfo { down, up, left, right }
    public enum ScreenExitException { close, force_close, developer }
    public class Screen : IScreen
    {
        public static List<Application> applications = new List<Application>()
        {
            new Explorer()
            {
                displayName = "Explorer",
                description = "Explorer um Daten zu durchsuchen",
                running = true,
            },
            new MainPanel()
            {
                displayName = "Panel",
                description = "Hier ist der Arbeitsbereich",
                running = true,
                disableOnDesktop = true,
            },
            new ObjectCatalog()
            {
                displayName = "C# Objektkatalog",
                description = "Analysiere C# Objekte/Elemente visuell",
                running = true,
            }
        };

        public List<ScreenObject> screenObjects = new List<ScreenObject>();
        public bool active = true;
        // ScreenObjects...
        // Hier sind alle ScreenObjects. Sowas wie Listenansicht, UserInput, ...
        public ListSelection listSelection = new ListSelection();
        //...
        static ApplicationExitException applicationExitException = new ApplicationExitException();
        static Application currentApplication = null;
        public int mainApplication = 1; //Main Panel
        public virtual void Start()
        {
            while (active)
            {
                Console.WriteLine("Screen wurde detached");
                Console.WriteLine("Screen neu starten...");
                Console.WriteLine("Lade...");
                Thread.Sleep(50);
                Console.Title = $"{ProgramInit.title} | Hauptmenü";
                Console.WriteLine(StartApplication(mainApplication));
                
            }
        }
        public virtual void Update()
        {
        }

        public static ApplicationExitException StartApplication(int applicationID)
        {
            if (currentApplication != null)
            {
                currentApplication.Close();
            }
            currentApplication = applications[applicationID];
            currentApplication.running = true;
            applicationExitException = currentApplication.Run();
            return applicationExitException;
        }

        public void Handle()
        {



            //ShowDirectory(Program.editingModPath);
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    listSelection.Move(Direction.Down);
                    break;
                case ConsoleKey.UpArrow:
                    listSelection.Move(Direction.Up);
                    break;
                case ConsoleKey.LeftArrow:
                    listSelection.Back();
                    break;
                case ConsoleKey.RightArrow:
                    listSelection.Enter();
                    break;
            }
        }

        public static string GetTitleString(string title)
        {
            return $"└─» {title}";
        }

        public static void ShowDirectory(string path)
        {
            Console.WriteLine(GetTitleString(path));
            var directories = Directory.GetDirectories(path);
            for(int i = 0; i < directories.Length; i++)
            {
                var printString = $" └─■ " + directories[i].Replace(path, "");
                Console.WriteLine(printString);
            }
            var files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                var printString = $" └─■ " + files[i].Replace(path, "");
                Console.WriteLine(printString);
            }
        }


    }


}
