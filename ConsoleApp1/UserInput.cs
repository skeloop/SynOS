using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynOS
{
    public class UserInput
    {
        public static ConsoleKeyInfo lastPressedKey;

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
            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    lastPressedKey = Console.ReadKey();
                }
            }));
            thread.Start();
        }
    }   


}
