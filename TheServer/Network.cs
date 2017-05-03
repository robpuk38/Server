using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TheServer
{
    class Network
    {

        public static void OnSocketConnection(Socket ClientSocket, String data)
        {

            Debug.Starting("Network: OnSocketConnection()");


            string[] aData = data.Split('|');
            for (int i = 0; i < aData.Length - 1; i++)
            {
               
                if (aData[i] == "USERACCESSTOKEN")
                {
                    Clients.SetAccessToken(aData[i + 1]);
                    Debug.Cleared("USERACCESSTOKEN: " + aData[i + 1]);
                }
                if (aData[i] == "USERID")
                {
                    Clients.SetUserId(aData[i + 1]);
                    Debug.Cleared("USERID: " + aData[i + 1]);
                }
                if (aData[i] == "LOGINSTATUS")
                {
                    Clients.SetLoginStatus(aData[i + 1]);
                    Debug.Cleared("LOGINSTATUS: " + aData[i + 1]);
                }
                



            }
            if (Clients.GetUserId() != null && Clients.GetUserId().Length > 1 )
            {
                Clients.CheckClientsData(ClientSocket,Clients.GetUserId(),Clients.GetAccessToken(),Clients.GetLoginStatus());
            }
            Debug.Log(Clients.GetUserId());

            //todo a mysql insert of new message
            //ClientSocket.Send(Encoding.ASCII.GetBytes(data));
            
            if (Clients.ConnectedClients != null)
            {
                Debug.Info("Clients Connected: " + Clients.ConnectedClients.Count);
            }
            if (Clients.ConnectingClients != null)
            {
                Debug.Info("Clients Connecting: " + Clients.ConnectingClients.Count);
            }

            Debug.Finished("Network: OnSocketConnection()");
        }
    }
}
