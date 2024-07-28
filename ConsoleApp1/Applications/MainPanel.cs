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
            Render();
        }
        public override void Update()
        {

            
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
        public override void OnKey(ConsoleKeyInfo consoleKey)
        {
            if (consoleKey.Key == ConsoleKey.DownArrow)
            {
                if (selectIndex < Screen.applications.Count - 1)
                {
                    
                    if (selectIndex+1 < Screen.applications.Count -1 && Screen.applications[selectIndex + 1].disableOnDesktop)
                    {
                        selectIndex++;
                    }
                    selectIndex++;
                }
            }
            if (consoleKey.Key == ConsoleKey.UpArrow)
            {
                if (selectIndex > 0)
                {
                    if (selectIndex - 1 > 0 && Screen.applications[selectIndex - 1].disableOnDesktop)
                    {
                        selectIndex--;
                    }
                    selectIndex--;
                }
            }
            if (consoleKey.Key == ConsoleKey.Enter)
            {
                Screen.StartApplication(selectIndex);
            }
            Render();
        }
    }
}
