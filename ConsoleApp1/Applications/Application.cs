using System;

namespace SynOS.Applications
{
    public enum ApplicationExitException { user_close, restart, shutdown }


    public class Application
    {
        public string displayName;
        public string description;
        public bool disableOnDesktop = false;
        public bool running = true;
        public bool runtimeNotification = true;

        public ApplicationExitException Run()
        {
            Start();
            Console.Title = $"{ProgramInit.title} | {displayName}";

            

            while (running)
            {
                Update();
                OnKey(Console.ReadKey());
            }
            return ApplicationExitException.user_close;
        }
        public virtual void Start()
        {
            if (runtimeNotification)
            {
                Console.Clear();
                Console.WriteLine("Empty Application Boot -> Start Method get's called.");
                Console.WriteLine("Drücke ESC um diese Application zu verlassen");
                Console.Beep();
            }
        }
        public virtual void Update()
        {
            if (runtimeNotification)
            {
                Console.Clear();
                Console.WriteLine("Empty Application -> Update Method get's called.");
                Console.WriteLine("Drücke ESC um diese Application zu verlassen");
                Console.Beep();
            }
        }

        public virtual void OnKey(ConsoleKeyInfo consoleKey)
        {
            switch (consoleKey.Key)
            {
                case ConsoleKey.Escape:
                    Close(); 
                    break;
            }
        }

        public void Close()
        {
            running = false;
        }

        public void DisableRuntimeNotification()
        {
            runtimeNotification = false;
        }
    }
}
