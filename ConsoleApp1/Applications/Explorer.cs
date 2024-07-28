
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    public class Explorer : Application
    {
        public int currentSelectionIndex;
        public string basePath = "C:\\";
        public string currentPath = string.Empty;
        public string[] directories;
        public string[] files;

        public override void Start()
        {
            Console.WriteLine("Start");
            Console.Title = $"{ProgramInit.title} - {displayName}";
            directories = Directory.GetDirectories(basePath);
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
                case ConsoleKey.DownArrow:
                    
                    Move(Direction.Down);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.Up);
                    break;
                case ConsoleKey.Backspace:
                    MoveBack();
                    break;
                case ConsoleKey.Escape:
                    Close();
                    break;
            }
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Up)
            {
                if (currentSelectionIndex > 0)
                {
                    currentSelectionIndex--;
                }
            } else if (direction == Direction.Down)
            {
                if (currentSelectionIndex < directories.Length + files.Length - 1)
                {
                    currentSelectionIndex++;
                }
            }
            
            Console.WriteLine(currentSelectionIndex);
            ShowDirectories();
        }

        public void MoveBack()
        {
            currentPath = Directory.GetParent(currentPath).FullName;
            currentSelectionIndex = 0;
            ShowDirectories();
        }

        public void ShowDirectories()
        {
            Console.Clear();
            string[] directories = Directory.GetDirectories(currentPath);
            files = Directory.GetDirectories(currentPath);
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
            files = Directory.GetFiles(currentPath);
            foreach (var file in files)
            {
                if (iterationIndex == currentSelectionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine(file);
                iterationIndex++;
            }
            
        }

        public void NavigateSubFolder()
        {
            var dir = directories[currentSelectionIndex];
            Console.WriteLine(dir);
            Thread.Sleep(1000);
            currentPath = dir;
            currentSelectionIndex = 0;
            ShowDirectories();
        }
    }
}
