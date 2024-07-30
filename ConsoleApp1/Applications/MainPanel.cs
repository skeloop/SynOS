using System;
using System.Security.Cryptography.X509Certificates;

namespace SynOS.Applications
{
    public class MainPanel : Application
    {
        public int appCount;
        public int selectIndex = 0;
        public override void Start()
        {
            UserInputThread.KeyPressed += InputListener;
            Render();
        }
        public override void Update()
        {

            
        }

        void InputListener(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.DownArrow)
            {
                if (selectIndex < Screen.applications.Count - 1)
                {

                    if (selectIndex + 1 < Screen.applications.Count - 1 && Screen.applications[selectIndex + 1].disableOnDesktop)
                    {
                        selectIndex++;
                    }
                    selectIndex++;
                    Render();
                }
            }
            if (consoleKey == ConsoleKey.UpArrow)
            {
                if (selectIndex > 0)
                {
                    if (selectIndex - 1 > 0 && Screen.applications[selectIndex - 1].disableOnDesktop)
                    {
                        selectIndex--;
                    }
                    selectIndex--;
                    Render();
                }
            }
            if (consoleKey == ConsoleKey.Enter)
            {
                Screen.StartApplication(selectIndex);
            }
        }

        void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Willkommen zurück Nick");
            Console.WriteLine("[]===================================[]");

            Console.WriteLine("|| Installierte Apps: \n||");
            int index = 0;
            foreach (var app in Screen.applications)
            {

                if (app.disableOnDesktop)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"|| » " + app.displayName + " | [Kein Zugriff]");
                    Console.WriteLine($"|| └──» " + app.description);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (index == selectIndex) Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"|| » " + app.displayName);
                    Console.WriteLine($"|| └──» " + app.description);
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;

                index++;
            }

            Console.WriteLine("[]===================================[]");
        }
    }
}
