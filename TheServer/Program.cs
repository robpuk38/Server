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



        private static object serverLock = new object();
        private static bool showText = true;



        private class ConnectionInfo
        {
            public Socket Socket;
            public byte[] Buffer;
        }

        private static List<ConnectionInfo> connections = new List<ConnectionInfo>();


        private static void Setuplistener()
        {

            localEndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Blocking = false;

            listener.Bind(localEndPoint);
            listener.Listen((int)SocketOptionName.MaxConnections);
        }

        public static void Start()
        {
            ServerConfig();
            try
            {
                Setuplistener();
                for (int i = 0; i < 10; i++)
                {
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                }
            }
            catch (Exception e)
            {

            }

        }


        private static void AcceptCallback(IAsyncResult result)
        {

            ConnectionInfo connection = new ConnectionInfo();
            try
            {
                // Finish Accept
                Socket s = (Socket)result.AsyncState;
                connection.Socket = s.EndAccept(result);
                connection.Socket.Blocking = false;
                connection.Buffer = new byte[255];


                lock (connections)
                {
                    connections.Add(connection);
                    Clients.SetUserClientSocket(connection.Socket);
                }



                // Start Receive
                connection.Socket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connection);
                // Start new Accept
                listener.BeginAccept(new AsyncCallback(AcceptCallback), result.AsyncState);
            }
            catch (SocketException)
            {
                CloseConnection(connection);

            }
            catch (Exception)
            {
                CloseConnection(connection);

            }
        }

        private static void ReceiveCallback(IAsyncResult result)
        {
            ConnectionInfo connection = (ConnectionInfo)result.AsyncState;
            try
            {
                int bytesRead = connection.Socket.EndReceive(result);
                if (0 != bytesRead)
                {
                    lock (serverLock)
                    {
                        if (showText)
                        {
                            data = Encoding.ASCII.GetString(connection.Buffer, 0, bytesRead);

                            if (data.Contains(Construct.ONAWAKE))
                            {
                                Debug.Info("ON AWAKE: RECEIVED: " + data);

                                Network.OnAwakeSocketConnection(connection.Socket, data);

                                return;
                            }

                            if (data.Contains(Construct.ONADS))
                            {
                                //Debug.Info("ON ADS: " + data);

                                Network.OnAdsSocketConnection(connection.Socket, data);

                                return;
                            }

                            if (data.Contains(Construct.ONLOGIN))
                            {
                                //Debug.Info("ON LOGIN: " + data);

                                Network.OnLoginSocketConnection(connection.Socket, data);

                                return;
                            }

                            if (data.Contains(Construct.ONLOGOUT))
                            {
                                //Debug.Info("ON LOGOUT: " + data);

                                Network.OnLogoutSocketConnection(connection.Socket, data);

                                return;
                            }

                            if (data.Contains(Construct.ONSWITCHEDACCOUNT))
                            {
                                //Debug.Info("ON LOGOUT: " + data);

                                Network.OnLogoutSwitchedAccountsSocketConnection(connection.Socket, data);

                                return;
                            }

                            if (data.Contains(Construct.ONNEWMESSAGE))
                            {
                                //Debug.Info("ON LOGOUT: " + data);

                                Network.OnNewMessageSocketConnection(connection.Socket, data);

                                return;
                            }






                        }
                    }
                    lock (connections)
                    {
                        foreach (ConnectionInfo conn in connections)
                        {

                            conn.Socket.Send(connection.Buffer, bytesRead, SocketFlags.None);


                        }
                    }
                    connection.Socket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connection);
                }
                else
                {
                    CloseConnection(connection);
                }
            }
            catch (SocketException)
            {
                CloseConnection(connection);
            }
            catch (Exception)
            {
                CloseConnection(connection);
            }
        }

        private static void CloseConnection(ConnectionInfo ci)
        {
            ci.Socket.Close();
            lock (connections)
            {
                connections.Remove(ci);
            }
        }

        static void Main(string[] args)
        {

            bool portReady = false;

            while (true)
            {
                if (!portReady)
                {

                    Start();
                    portReady = true;

                }
                else
                {


                    Thread.Sleep(1);

                }

            }

        }









        public static void SendBroadcastData(Socket handler, string data)
        {
            try
            {
                byte[] msg = Encoding.ASCII.GetBytes(data);

                lock (connections)
                {
                    foreach (ConnectionInfo conn in connections)
                    {
                        try
                        {

                            //Debug.Error("SERVER BRAODCAST BACK: " + data);
                            conn.Socket.Send(msg);
                        }
                        catch
                        {
                            Debug.Error("Socket Has Been Destoryed");
                        }

                    }
                }
            }
            catch (ObjectDisposedException)
            {
                Debug.Error("Socket Has Been Destoryed 1");
            }
            catch (SocketException)
            {
                Debug.Error("Socket Has Been Destoryed 2");
            }

        }


        public static void SendSelfData(Socket handler, string data)
        {
            try
            {
                byte[] msg = Encoding.ASCII.GetBytes(data);

                lock (connections)
                {
                    foreach (ConnectionInfo conn in connections)
                    {
                        try
                        {
                            if (handler == conn.Socket)
                            {
                                //Debug.Error("SERVER SEND BACK: " + data);
                                conn.Socket.Send(msg);
                            }
                        }
                        catch
                        {
                            Debug.Error("Socket Has Been Destoryed");
                        }


                    }
                }
            }
            catch (ObjectDisposedException)
            {
                Debug.Error("Socket Has Been Destoryed 1");
            }
            catch (SocketException)
            {
                Debug.Error("Socket Has Been Destoryed 2");
            }

        }



        private static void ServerConfig()
        {
            Debug.Starting("Loading Deference Server....");
            Debug.Info("Build Version 0.03");
            Debug.Info("CopyRights @ What CopyRights 2017 - 2021");
            Console.Title = "Deference Server";

            // Config Server will help us get who is the app owner for the flipster report 

            Init();


        }

        private static void Init()
        {



            MySqlManager.InitializeDB();

            // MySqlManager.LoadAllMessage();
            // StartUpdate();


        }






    }
}
