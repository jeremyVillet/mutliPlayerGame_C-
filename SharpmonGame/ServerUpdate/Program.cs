using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DllSharpmon.dll;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerUpdate
{
    class Program
    {

        // creation socket marchant en Ipv4 ,protocole TCP
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 8192;
        private const int SERVERPORT = 5030;

        private static byte[] buffer = new byte[BUFFER_SIZE];

        private static List<string> pathFilesToUpdate = new List<string> { "FilesToSend/SharpmonInterface.pdb", "FilesToSend/SharpmonInterface.exe", "FilesToSend/DllSharpmon.dll.dll", "FilesToSend/DllSharpmon.dll.pdb", "FilesToSend/SharpmonInterface.exe.config" };
      

        // List contenant les sockets des clients connectés
        private static List<Socket> _listClientSockets = new List<Socket>();
      

        // Contient toutes les donnée de tout les fichiers a envoyer aux client pour la mise a jour 
        private static List<byte[]> filesToUpdate = new List<byte[]> {  GetFileBytes(0), GetFileBytes(1), GetFileBytes(2), GetFileBytes(3), GetFileBytes(4) };


        static void Main(string[] args)
        {
            Console.Title = "Sharpmon Server Update";
            SetUpServer();
            Console.ReadLine();
            CloseAllSockets();
            
        }

        private static void SetUpServer()
        {


            // Ip end point contient les info ( port et IP ) pour que deux services puissent se connecter )
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, SERVERPORT));
            _serverSocket.Listen(0);
            Console.Clear();
            Console.WriteLine("Server is operational...");
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private static void AcceptCallback(IAsyncResult asyncroneResult)
        {
            // acceptation connection client et creation objet socket pour gerer la connection 
            Socket socket;
            try
            {
                socket = _serverSocket.EndAccept(asyncroneResult);
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            _listClientSockets.Add(socket);
            Console.WriteLine("Client connected");


            // Reception des données du client de facon assyncrone  , appel un methode lorsque l action est terminé
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveDataCallback), socket);

            // On veut continuer d accepter les connections d autres clients
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        private static void ReceiveDataCallback(IAsyncResult asyncroneResult)
        {


            Socket currentSocket = (Socket)asyncroneResult.AsyncState;
            // On met fin a la reception  assyncrone une fois toute les données recues 
            int sizeDataReceived;
            try
            {
                sizeDataReceived = currentSocket.EndReceive(asyncroneResult);
            }
            catch (SocketException)
            {
                Console.WriteLine("Player forcefully disconnected");
                currentSocket.Close();
                _listClientSockets.Remove(currentSocket);

                return;
            }

               
            Console.WriteLine("Un client procède à une mise à jour");

            //Envoie des fichiers au client 
         
            SendFileToClient(currentSocket);
            currentSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveDataCallback, currentSocket);

        }
       

      
        private static void SendFileToClient(Socket socket)
        {
            byte[] bufferFile = getBytes(filesToUpdate);
                socket.Send(bufferFile);
                socket.BeginReceive(bufferFile, 0, bufferFile.Length, SocketFlags.None, new AsyncCallback(ReceiveDataCallback), socket);
        }


        private static void SendDataCallback(IAsyncResult asyncroneResult)
        {
            Socket socket = (Socket)asyncroneResult.AsyncState;
            // On met fin a l envoie assyncrone une fois toute les données envoyées
            socket.EndSend(asyncroneResult);
        }

        private static void CloseAllSockets()
        {
            foreach (Socket socket in _listClientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            _serverSocket.Close();
        }

        private static byte[] GetFileBytes(int index)
        {

            byte[] bufferFile;
            try
            {
                bufferFile = File.ReadAllBytes(pathFilesToUpdate[index]);
                Console.WriteLine(bufferFile.Length);
            }
            catch (IOException e)
            {
                bufferFile = new byte[0];
                Console.WriteLine("impossible d ouvrir le fichier :" + e.Message);
            }
            return bufferFile;

        }
        private static byte[] getBytes(List<byte[]> filesToUpdate)
        {
            var binFormatter = new BinaryFormatter();
            var mStream = new MemoryStream();
            binFormatter.Serialize(mStream, filesToUpdate);

        
            return mStream.ToArray();
        }



    }
}
