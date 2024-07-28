using SynOS.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace SynOS
{
    public class ListSelection : ScreenObject
    {
        public string currentPath = "E:\\Arbeitsplatz\\FCM\\FCM_Console";

        public List<ListElement> listElements = new List<ListElement>();

        public int currentSelectionIndex = 0;
        public int minIndex = 0;
        public int maxIndex = 20;

        public List<PrintInformation> printTexts = new List<PrintInformation>();

        public void AddListElement(string objectNames)
        {
            ListElement listElement = new ListElement()
            {
                name = objectNames.ToString().Replace(currentPath + "\\", "» "),
                value = currentPath
            };
            listElements.Add(listElement);

        }

        

        public void Move(Direction direction)
        {
            if (direction == Direction.Down && currentSelectionIndex < listElements.Count-1)
            {
                currentSelectionIndex++;
            }
            else if (direction == Direction.Up && currentSelectionIndex > minIndex)
            {
                currentSelectionIndex--;
            }
            PrintList();
        }
        public void Enter()
        {
            string enteredPath = listElements[currentSelectionIndex].value as string;
            var dirs = Directory.GetDirectories(enteredPath);
            foreach (var dir in dirs)
            {
                Print("└─ " + dir);
            }
            currentPath = enteredPath;
            PrintList();

        }
        public void Back()
        {
            PrintList();
        }

        /// <summary>
        /// Gibt keine Nachricht in der Konsole aus. Fügt nur eine Nachricht zu einer Liste hinzu die zu einem späteren Zeitpunkt angezeigt wird.
        /// </summary>
        public void Print(string message)
        {
            printTexts.Add(new PrintInformation()
            {
                text = message,
                color = ConsoleColor.Gray,
            });
        }

        public void PrintList()
        {
            Console.Clear();
            printTexts.Clear();
            // output
            ConsoleColor outputLineColor = ConsoleColor.White;
            Console.WriteLine("Path: "+currentPath);
            var itIndex = 0;
            foreach (var element in listElements)
            {
                if (itIndex == currentSelectionIndex)
                {
                    outputLineColor = ConsoleColor.Green;
                } else
                {
                    outputLineColor = ConsoleColor.DarkGray;
                }
                Console.ForegroundColor = outputLineColor;
                printTexts.Add(new PrintInformation()
                {
                    color = outputLineColor,
                    text = element.name + ": " + element.value,
                });

                itIndex++;
            }
            foreach (var printTextInformation in printTexts)
            {
                Console.ForegroundColor = printTextInformation.color;
                Console.WriteLine("> "+printTextInformation.text);
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
