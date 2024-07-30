using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Applications
{
    public class ChatServer : Application
    {
        public SynOS.Network.Network network = new SynOS.Network.Network();
        public override void Start()
        {
            Console.WriteLine("register client connect listener");
            SynOS.Network.Network.ClientConnect += ClientConnect;
            Console.WriteLine("Start network...");
            SynOS.Network.Network.Start();
            
            
        }
        public override void Update()
        {
            
        }
        public List<Socket> connectedClients = new List<Socket>();
        void ClientConnect(Socket client)
        {
            connectedClients.Add(client);
            Console.WriteLine("Client connect event activate");
        }
        
    }
}
