using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;



namespace TheServer
{
  
    class Program
    {
        public static int port = 3000;
        public static String IpAddress = "10.0.0.13";
        private static IPEndPoint localEndPoint;
        private static Socket listener;
        public static string data = null;


        public static void SendData(Socket handler, string data)
        {
            byte[] msg = Encoding.ASCII.GetBytes(data);

            handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        private static void RecivedDataType(Socket handler, byte[] bytes)
        {
            data = null;


            string blowfishkey = "c2VydmVyIGNvbm5lY3Rpb24gdHlwZQ==";
            int bytesRec = handler.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);


            if (data.Contains("Awake_" + blowfishkey))
            {
                Debug.Info("AWAKE RETURNING USER");

                Network.OnSocketConnection(handler, data);
                return;
            }

            if (data.Contains("Awake_NewUser_" + blowfishkey))
            {
                Debug.Log("WE HAVE A AWAKE MESSAGE POSSIBILE NEW USER");

                Network.OnSocketConnection(handler, data);
                return;
            }


            Debug.Error("UNK "+ data);
        }
        
        private static void ServerConfig()
        {
            Debug.Starting("Loading Deference Server....");
            Debug.Info("Build Version 0.03");
            Debug.Info("CopyRights @ What CopyRights 2017 - 2021");
            localEndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Init();
            StartListening(listener, localEndPoint);
        }

        private static void Init()
        {
            

            MySqlManager.InitializeDB();

            MySqlManager.LoadAllMessage();
           // StartUpdate();


        }

        public static void StartListening(Socket listener, IPEndPoint localEndPoint)
        {
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                
                while (true)
                {
                   
                     
                    Socket handler = listener.Accept();
                    byte[] bytes = new Byte[handler.SendBufferSize];
                    RecivedDataType(handler, bytes);
                    //SendData(handler, data);
                    
                    
                }

            }
            catch (Exception e)
            {
                Debug.Error(e.ToString());
            }

            
          

        }

        public static int Main(String[] args)
        {
            ServerConfig();
            return 0;
        }


    }
}
