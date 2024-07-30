using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynOS
{
    public class UserInputThread
    {
        public delegate void OnKeyPress(ConsoleKey consoleKey);
        public static event OnKeyPress KeyPressed;

        public static ConsoleKeyInfo lastPressedKey;

        public void Init()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    lastPressedKey = Console.ReadKey();
                    if (KeyPressed != null)
                    {
                        KeyPressed.Invoke(lastPressedKey.Key);
                    }
                    
                }
            }));
            thread.Start();
        }

        public static ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey();
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }   


}
