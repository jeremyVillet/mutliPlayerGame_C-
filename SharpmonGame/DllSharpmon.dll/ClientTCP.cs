using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DllSharpmon.dll
{

    public class ClientTCP
    {
        // socket client ipv4 , protocole TCP
        private static Socket _clientSocket;
        private const int SERVERPORT = 5035;
     
        private const int BUFFER_SIZE = 8192;

        public static void ConnectToServer(string serverIp)
        {
            _clientSocket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("tring to connect .. ");
            int attempsToConnect = 0;
            while (! _clientSocket.Connected && attempsToConnect!=3 )
            {
                try
                {
                    attempsToConnect++;
                    
                    _clientSocket.Connect(serverIp, SERVERPORT);
                }
                catch (SocketException)
                {
                  
                }
               
            }
           
            
        }
        public static void CloseConnection()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }
        public static void SendDataToServer(byte[] dataToSend)
        {

            // Envoie donnée vers server
            try 
            {
                _clientSocket.Send(dataToSend, 0, dataToSend.Length,SocketFlags.None);
                
            }
            catch(SocketException)
            {
                       
            }
          

        }
        public static ClientData ReceivedDataToServer( ClientData dataReceived)
        {
            
            try
            {
                // Reception donnée depuis le server 
                byte[] dataReceivedBuf = new byte[BUFFER_SIZE];
                int sizeBuffer = _clientSocket.Receive(dataReceivedBuf, SocketFlags.None);
                byte[] dataReceivedRaw = new byte[sizeBuffer];

                Array.Copy(dataReceivedBuf, dataReceivedRaw, sizeBuffer);
                dataReceived = (ClientData)Utils.ConvertByteToObj(dataReceivedRaw);
            }
           catch(SocketException)
            {
                CloseConnection();
                dataReceived.StatutPlayer = "erreur connection ";
            }
           
            return dataReceived;
        }
    }
    
}
