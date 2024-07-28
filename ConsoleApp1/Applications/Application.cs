using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    public enum ApplicationExitException { user_close, restart }
    public class Application
    {
        public string displayName;
        public string description;

        public bool running = true;

        public ApplicationExitException Run()
        {
            Start();
            while (running)
            {
                Update();
            }
            return ApplicationExitException.user_close;
        }
        public virtual void Start()
        {
            
          
        }
        public virtual void Update()
        {

        }

        public virtual void OnKey(ConsoleKey consoleKey)
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
            running = false;
        }
    }
}
