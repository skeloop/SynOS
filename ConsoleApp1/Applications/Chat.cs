using System;
namespace SynOS.Applications
{
    public class Chat : Application
    {


        public SynOS.Network.Client networkClient = new SynOS.Network.Client();

        public override void Start()
        {
            Network.NetworkConnectionException connectionException = networkClient.Start();
            if (connectionException == Network.NetworkConnectionException.connected)
            {
                OnConnect();
            }
            networkClient.SendMessage("Hello from the Client :D");
        }

        public override void Update()
        {
            Console.Read();
        }

        public void OnConnect()
        {
            // Als erstes muss sich der ChatClient alle Nachrichten vom Server hohlen.
            // Diese werdem einem Client direkt nach Verbindungsaufbau geschickt.
            string response = networkClient.WaitForResponseMessage();
        }
    }
}
