using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynOS
{
    //h
    public class UserInput
    {
        public ConsoleKey lastPressedKey;

        public ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey();
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public static void Init()
        {
            // Erstelle einen neuen Thread und übergebe eine anonyme Funktion als ThreadStart-Delegate
            Thread thread = new Thread(new ThreadStart(() =>
            {
                // Code der in dem neuen Thread ausgeführt wird
                Console.WriteLine("Anonyme Funktion wird in einem neuen Thread ausgeführt");
                // Füge hier weiteren Code hinzu, der im neuen Thread ausgeführt werden soll
            }));

            // Starte den neuen Thread
            thread.Start();

            // Optional: Warte, bis der Thread beendet ist (wenn notwendig)
            thread.Join();

            Console.WriteLine("Der neue Thread ist beendet");
        }
    }   


}
