using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LauncherSharpmon.pages
{
    /// <summary>
    /// Logique d'interaction pour Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
             
        private static Socket clientSocket ;
        private const int SERVERPORT = 5030;
        private const int BUFFER_SIZE = 800000;

        private static string serverIp;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        private static List<string> pathfilesToUpdate = new List<string> { "SharpmonGame/SharpmonInterface.pdb", "SharpmonGame/SharpmonInterface.exe", "SharpmonGame/DllSharpmon.dll.dll", "SharpmonGame/DllSharpmon.dll.pdb", "SharpmonGame/SharpmonInterface.exe.config" };


        private static List<byte[]> filesToUpdate = new List<byte[]>();


        public Update(string adressIp)
        {

            InitializeComponent();
              // socket client ipv4 , protocole TCP
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIp = adressIp;
            ConnectToServer();
            if (clientSocket.Connected)
            {
                File.WriteAllText("SharpmonGame/adressIp.txt",serverIp);
                Loaded += SyncronizeWihtServer;
            }
            else
            {
                view_statutUpdate.Text = "Serveur injoignable";
                view_statutUpdate.Foreground = new SolidColorBrush(Colors.Red);
                view_progressBar.Visibility=Visibility.Hidden;
                view_buttonNewCo.Visibility = Visibility.Visible;
               
            }
           


        }

        private void click_newConnection(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ConnectionToServer());
        }
        public static void ConnectToServer()
        {

            IAsyncResult result = clientSocket.BeginConnect(serverIp, SERVERPORT, null, null);

            bool success = result.AsyncWaitHandle.WaitOne(1000, true);

            if (clientSocket.Connected)
            {
                clientSocket.EndConnect(result);
            }
            else
            {
                clientSocket.Close();
                
            }


        }
        public static void CloseConnection()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        public static void SendDataToServer(byte[] dataToSend)
        {
         
                clientSocket.Send(dataToSend, 0, dataToSend.Length, SocketFlags.None);
           
        }
        public static byte[] ReceivedDataToServer()
        {
            // Reception donnée depuis le server 
            byte[] dataReceivedBuf = new byte[BUFFER_SIZE];
            int sizeBuffer = clientSocket.Receive(dataReceivedBuf, SocketFlags.None);
            byte[] dataReceivedRaw = new byte[sizeBuffer];

            Array.Copy(dataReceivedBuf, dataReceivedRaw, sizeBuffer);


            return dataReceivedRaw;
        }
        private async void SyncronizeWihtServer(object sender, RoutedEventArgs routedEventArgs)
        {


            while (!cts.IsCancellationRequested) // while infi fait de facon non blocante
            {

                await Task.Delay(2000);
                byte[] _clientDataRaw = Encoding.ASCII.GetBytes("ask files");


                view_statutUpdate.Text = "Mise a jour en cours de téléchargement ..";
                SendDataToServer(_clientDataRaw);
                byte[] dataRawsFromServer = ReceivedDataToServer();
                filesToUpdate = fromBytes(dataRawsFromServer);


                break;
            }


            for (int i = 0; i < filesToUpdate.Count(); i++)
            {
                try
                {
                    File.WriteAllBytes(pathfilesToUpdate[i], filesToUpdate[i]);

                }
                catch (IOException e)
                {
                    view_statutUpdate.Text = ($"impossible de recuperer le fichier : {pathfilesToUpdate[i]} ");
                }
            }

            try
            {
                view_statutUpdate.Text = "Lancement du jeu ..";
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "SharpmonGame\\SharpmonInterface.exe";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.Start();
                Environment.Exit(0);

            }
            catch (Exception e)
            {
                view_statutUpdate.Text = "Impossible de lancer Sharpmon";
            }


        }
       
        private static List<byte[]> fromBytes(byte[] objectBytes)
        {
            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();

            // Where 'objectBytes' is your byte array.
            mStream.Write(objectBytes, 0, objectBytes.Length);
            mStream.Position = 0;

            return binFormatter.Deserialize(mStream) as List<byte[]>;
        }

     
    }
    

}
