
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    public class Explorer : Application
    {
        int currentSelectionIndex;
        public string basePath = "C:\\";
        public string currentPath = string.Empty;
        public string[] directories;

        public override void Start()
        {
            Console.Title = $"{ProgramInit.title} - {displayName}";
            currentPath = basePath;
            ShowDirectories();
        }

        public override void Update()
        {

        }

        public override void OnKey(ConsoleKeyInfo consoleKey)
        {
            switch(consoleKey.Key)
            {
                case ConsoleKey.Enter:
                    NavigateSubFolder();
                    break;
            }
        }


        public void ShowDirectories()
        {
            Console.Clear();
            
            directories = Directory.GetDirectories(currentPath);
            Console.WriteLine();

            var iterationIndex = 0;
            foreach (var dir in directories)
            {
                if (iterationIndex == currentSelectionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(dir);
                iterationIndex++;
            }
            iterationIndex = 0;
        }

        public void NavigateSubFolder()
        {
            
            var dir = directories[currentSelectionIndex];
            currentPath = dir;

            currentSelectionIndex = 0;
        }
    }
}
