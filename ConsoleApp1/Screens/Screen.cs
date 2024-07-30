using SynOS.Applications;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SynOS
{
    public enum Direction { Left, Right, Up, Down }
    public enum InputInfo { down, up, left, right }
    public enum ScreenExitException { close, force_close, developer }
    public class Screen : IScreen
    {
        public static List<Application> applications = new List<Application>()
        {
            new Explorer()
            {
                displayName = "Explorer",
                description = "Explorer um Daten zu durchsuchen.\n||",
                running = true,
            },
            new MainPanel()
            {
                displayName = "Panel",
                description = "Hier ist der Arbeitsbereich.\n||",
                running = true,
                disableOnDesktop = true,
            },
            new ObjectCatalog()
            {
                displayName = "C# Objektkatalog",
                description = "Analysiere C# Objekte/Elemente visuell.\n||",
                running = true,
            },
            new ProjectManager()
            {
                displayName = "Projektmanager",
                description = "Bietet funktionalitäten für fortgeschrittene Datei bearbeitung.\n||",
                running = true,
            },
            new FactorioModCreator()
            {
                displayName = "FMC - Factorio Mod Creator",
                description = "Bietet eine Visuelle möglichkeit Mods für Factorio zu erstellen.\n||      Untersucht Struktur des Spiels und stellt diese bereit.\n||"
            },
            new LinuxBride()
            {
                displayName = "LinuxBridge",
                description = "Remote Server/Desktop steuerung. Dateiübertragung. Gruppenmanagment.\n||"
            },
            new PiConnector()
            {
                displayName = "Pi-Connector",
                description = "Rasperry-Pi GPIO Pins über .NET(C#) steuern.\n||"
            },
            new Settings()
            {
                displayName = "Einstellungen",
                description = "Verwalte globale Einstellungen.\n||"
            },
            new ChatServer()
            {
                displayName = "Chat - Server",
                description = "(server-side)"
            },
            new Chat()
            {
                displayName = "Chat - Client",
                description = "Verbindet dich mit dem Globalen Chat"
            }
        };

        public bool active = true;

        static ApplicationExitException applicationExitException = new ApplicationExitException();
        static Application currentApplication = null;
        public int mainApplication = 1; //Main Panel

        public virtual void Start()
        {
            Console.WriteLine("First Screen start...");
            Thread.Sleep(1000);
            Console.WriteLine("Load Main Application");
            Thread.Sleep(1000);
            StartApplication(mainApplication);
        }

        public virtual void Exit()
        {
            active = false;
            WriteShutDownMessage();
        }

        void WriteShutDownMessage()
        {
            Console.WriteLine("Der Screen wird beendet.");
            Thread.Sleep(550);
            Console.WriteLine("Aufräumen...");
            Thread.Sleep(100);
            Console.WriteLine("Bis bald :)");
            Thread.Sleep(1000);
        }

        public virtual void Update()
        {
        }

        public static ApplicationExitException StartApplication(int applicationID)
        {
            if (currentApplication != null)
            {
                Console.WriteLine("Closing current application...");
                Thread.Sleep(2500);
                currentApplication.Close();
            }
            Console.WriteLine($"Application boot: {applicationID}");
            Console.WriteLine($"Application name: {applications[applicationID]}");
            Thread.Sleep(5000);
            currentApplication = applications[applicationID];
            currentApplication.running = true;
            applicationExitException = currentApplication.Run();
            return applicationExitException;
        }
    }
}
