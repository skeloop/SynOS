using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace SynOS.Network
{
    public class Network
    {
        public delegate void OnClientConnect(Socket client);
        public static event OnClientConnect ClientConnect;

        private static ConcurrentDictionary<Socket, Task> clients = new ConcurrentDictionary<Socket, Task>();

        public static void Start()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 11000;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            Thread listenerThread = new Thread(() =>
            {
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(100);

                    Console.WriteLine("Waiting for a connection...");

                    while (true)
                    {
                        Socket handler = listener.Accept();
                        Console.WriteLine("Client connecting...");
                        if (ClientConnect != null)
                        {
                            Console.WriteLine("Fire event");
                            ClientConnect(handler);
                            Console.WriteLine("ClientConnect event triggerd");
                        }
                        Console.WriteLine("Handle client in new Thread");
                        Task clientTask = Task.Run(() => HandleClient(handler));
                        clients.TryAdd(handler, clientTask);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            });
            listenerThread.Start();

        }

        private static void HandleClient(Socket client)
        {
            Console.WriteLine("Try Handle Client in new Thread");
            try
            {
                while (true)
                {
                    string response = WaitForResponse(client);
                    Console.WriteLine("new iteration");
                    Console.WriteLine("Received: {0}", response);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Sendet eine Nachricht an alle Clients
        /// </summary>
        /// <param name="message"></param>
        public static void Broadcast(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            foreach (var client in clients.Keys)
            {
                client.Send(msg);
            }
        }
        /// <summary>
        /// Sendet eine Nachricht an einen bestimmten Client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        public static void SendToClient(Socket client, string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            client.Send(msg);
        }
        /// <summary>
        /// Gibt die antwort eines Clients zurück
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string WaitForResponse(Socket client)
        {
            byte[] bytes = new byte[1024];
            int bytesRec = client.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }
    }




}



