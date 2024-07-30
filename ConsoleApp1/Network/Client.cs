using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SynOS.Network
{
    public enum NetworkConnectionException { connected, blocked, failed }
    public class Client
    {
        // Connect to the server
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public int port = 11000;

        Socket localClient = null;
        public NetworkConnectionException Start()
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                // Create a TCP socket
                Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the server
                client.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                localClient = client;
                return NetworkConnectionException.connected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NetworkConnectionException.failed;
            }
        }
        /// <summary>
        /// Sendet eine Nachricht an den Server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            // Send data to the server
            byte[] msg = Encoding.ASCII.GetBytes(message);
            localClient.Send(msg);
        }
        /// <summary>
        /// Gibt die Antwort des Servers zurück
        /// </summary>
        /// <returns></returns>
        public string WaitForResponseMessage()
        {
            // Receive data from the server
            byte[] bytes = new byte[1024];
            int bytesRec = localClient.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }
        /// <summary>
        /// Schließt den Client
        /// </summary>
        public void Shutdown()
        {
            // Release the socket
            localClient.Shutdown(SocketShutdown.Both);
            localClient.Close();
        }
    }
}
