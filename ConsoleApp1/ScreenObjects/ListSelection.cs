using SynOS.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace SynOS
{
    public class ListSelection : ScreenObject
    {
        public int currentSelectionIndex = 0;
        public List<PrintInformation> printTexts = new List<PrintInformation>();
        public void AddListElement(string element)
        {
            printTexts.Add(new PrintInformation()
            {
                text = element,
                color = Print.standardPrintColor,
                index = printTexts.Count
            });

        }
        public void Setup()
        {
            UserInputThread.KeyPressed += Move;
        }
        public void Move(ConsoleKey direction)
        {
            if (direction == ConsoleKey.DownArrow && currentSelectionIndex < printTexts.Count-1)
            {
                currentSelectionIndex++;
            }
            else if (direction == ConsoleKey.UpArrow && currentSelectionIndex > 0)
            {
                currentSelectionIndex--;
            }
        }
        public void Enter()
        {

        }
        public void Back()
        {

        }
        public override void Render()
        {
            Console.Clear();
            foreach (PrintInformation printInformation in printTexts)
            {
                Console.ForegroundColor = printInformation.color;
                if (currentSelectionIndex == printInformation.index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(printInformation.text);
            }
        }

        /*
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
        */
    }
}
