using System;
using System.Collections.Generic;

namespace SynOS
{
    public class ScreenObject
    {
        public Print print;
        public bool active = true;

        public virtual void Render()
        {
            Console.Clear();
            Console.WriteLine("[]--------------------[]");
            Console.WriteLine("[] Empty ScreenObject []");
            Console.WriteLine("[]--------------------[]");
        }
    }

}
