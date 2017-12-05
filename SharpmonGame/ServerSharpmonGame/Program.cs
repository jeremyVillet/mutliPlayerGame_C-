using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DllSharpmon.dll;

namespace ServerSharpmonGame
{
    class Program
    {
        
        // creation socket marchant en Ipv4 ,protocole TCP
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 8192;
        private const int SERVERPORT = 5035;

        private static byte[] buffer = new byte[BUFFER_SIZE];

        // List contenant les sockets des clients connectés
        private static List<Socket> _listClientSockets = new List<Socket>();

        private static List<ClientData> playersConnected = new List<ClientData>();

        

        static void Main(string[] args)
        {
            Console.Title="Server Game Sharpmon";
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
            catch(ObjectDisposedException)
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
            
            // formatage des données recues 
            byte[] dataBuf = new byte[sizeDataReceived];

            Array.Copy(buffer, dataBuf, sizeDataReceived);

     
             ClientData clientData = (ClientData)Utils.ConvertByteToObj(dataBuf);
            Console.WriteLine("Player {0} :: {1} has synchronized with the server" ,clientData.IdPlayer,clientData.NamePlayer);

            //Actualisation et Renvoie de données vers le client 
            clientData=ManageDataClient(clientData);

            
            SendDataToClient(currentSocket, clientData);


        }
        private static void SendDataToClient(Socket socket, ClientData clientData)
        {
            byte[] dataToSendRaw = Utils.ConvertObjToByte(clientData);
            socket.Send(dataToSendRaw);

            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveDataCallback), socket);
        }

        // Gestion des données

        private static ClientData ManageDataClient(ClientData clientData)
        {
            // syncro donnée client server
            int actionPlayer = clientData.ActionPlayer;

            foreach (ClientData _player in playersConnected.Where(_player=>_player.IdPlayer == clientData.IdPlayer))
            {       
                    clientData = _player;
            }
            clientData.ActionPlayer = actionPlayer;

            switch (clientData.StatutPlayer)
            {
                case "entre dans le salon": // Le client vient de se connecter dans la room et est placé dans la file d attente
                    playersConnected.Add(clientData);
                    clientData.StatutPlayer = "attente d un joueur";
                    break;

                case "attente d un joueur": // On attend la connection d'un autre joueur 
                    clientData.ManageQueue(playersConnected);
                    break;

                case "la partie commence": // On determine qui commence et qui joue en second 
                    clientData.InitializeGame(playersConnected);
                    break;

                case "joue durant ce tour": // Traitement de l action du joueur 
                    clientData.IsPlaying(playersConnected);
                    break;
               
            }

            // Syncronisation donnée client avec celles du client opposé
            if (clientData.Opponent != null)
            {
                foreach(ClientData _opponnant in playersConnected.Where(_opponnant => _opponnant.IdPlayer == clientData.Opponent.IdPlayer))
                {
                   
                    clientData.Opponent = (ClientData)_opponnant.Clone();
                }
               
            }

            // Le joueur va se deconnecter , on supprime ses données de la liste des joueurs connectés
            if(clientData.CurrentSharpmon.CurrentHP<0 || clientData.Opponent!=null && clientData.Opponent.CurrentSharpmon.CurrentHP < 0)
            {
                playersConnected.RemoveAll(playerToDelete => playerToDelete.IdPlayer.Contains(clientData.IdPlayer));
            }


            clientData.PlayersConnected = playersConnected.Count();

            return clientData;
        }


        private static void SendDataCallback(IAsyncResult asyncroneResult)
        {
            Socket socket = (Socket)asyncroneResult.AsyncState;
            // On met fin a l envoie assyncrone une fois toute les données envoyées
            socket.EndSend(asyncroneResult);
        }

        private static void CloseAllSockets()
        {
            foreach( Socket socket in _listClientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            _serverSocket.Close();
        }


        
        
        
    }
}
