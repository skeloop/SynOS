using System;
using System.Security.Cryptography.X509Certificates;

namespace SynOS.Applications
{
    public class MainPanel : Application
    {
        public int appCount;
        public int selectIndex = 0;

        public override void Update()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Willkommen zurück Nick");
            Console.WriteLine("[]===================================[]");
            
            Console.WriteLine("|| Installierte Apps: ");
            int index = 0;
            foreach(var app in Screen.applications)
            {

                if (app.disableOnDesktop)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"||  {index} » " + app.displayName + "               [Kein Zugriff]");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (index == selectIndex) Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.WriteLine($"||  {index} » " + app.displayName);
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
                    selectIndex++;
                }
            }
            if (consoleKey.Key == ConsoleKey.UpArrow)
            {
                if (selectIndex > 0)
                {
                    selectIndex--;
                }
            }
            if (consoleKey.Key == ConsoleKey.Enter)
            {
                Screen.StartApplication(selectIndex);
            }
        }
    }
}
