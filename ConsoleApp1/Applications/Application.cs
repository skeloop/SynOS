using System;

namespace SynOS.Applications
{
    public enum ApplicationExitException { user_close, restart, shutdown }


    public class Application
    {
        public delegate void ApplicationCloseEvent();
        public event ApplicationCloseEvent ApplicationClose;

        public UserInputThread userInputThread = new UserInputThread();

        public string displayName;
        public string description;
        public bool disableOnDesktop = false;
        public bool running = true;
        public bool runtimeNotification = true;

        public ApplicationExitException Run()
        {
            userInputThread.Init();
            UserInputThread.KeyPressed += OnKey;
            UserInputThread.KeyPressed += KeyPressed;
            Start();
            Console.Title = $"{ProgramInit.title} | {displayName}";
            while (running)
            {
                Update();
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

        void OnKey(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Escape:
                    Close(); 
                    break;
            }
        }

        public void Close()
        {
            // ApplicationClose => Globales Event
            if (ApplicationClose != null)
            {
                Console.WriteLine("Applicatrion Close triggered");
                Console.ReadKey();
                ApplicationClose();
            }
            
            running = false;
        }

        public void DisableRuntimeNotification()
        {
            runtimeNotification = false;
        }

        public virtual void KeyPressed(ConsoleKey consoleKey)
        {
            Console.WriteLine($"({displayName}) | Empty virtual KeyPresssed: " + consoleKey.ToString());
        }

        public virtual void Render()
        {
            Console.WriteLine("[]--------------------------[]");
            Console.WriteLine("[] Empty Application Window []");
            Console.WriteLine("[]--------------------------[]");
        }
    }
}
