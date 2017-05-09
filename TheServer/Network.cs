using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TheServer
{
    class Network
    {

        public static void OnSocketNewClientConnectionLogin(Socket ClientSocket, String data)
        {
            //Debug.Starting("Network: OnSocketNewClientConnectionLogin()");

            //Debug.Log("DATA: " + data);


            string[] aData = data.Split('|');
            for (int i = 0; i < aData.Length - 1; i++)
            {
                if (aData[i] == "USERACCESSTOKEN")
                {
                    //Debug.Cleared("USERACCESSTOKEN: " + aData[i + 1]);
                    Clients.SetUserAccessToken(aData[i + 1]);
                }
                if (aData[i] == "USERID")
                {
                    //Debug.Cleared("USERID: " + aData[i + 1]);
                    Clients.SetUserId(aData[i + 1]);
                }
                if (aData[i] == "LOGINSTATUS")
                {
                    //Debug.Cleared("LOGINSTATUS: " + aData[i + 1]);
                    Clients.SetLoginStatus(aData[i + 1]);
                }

                if (aData[i] == "USERFIRSTNAME")
                {
                    //Debug.Cleared("USERFIRSTNAME: " + aData[i + 1]);
                    Clients.SetUserFirstName(aData[i + 1]);
                }

                if (aData[i] == "USERLASTNAME")
                {
                    //Debug.Cleared("USERLASTNAME: " + aData[i + 1]);
                    Clients.SetUserLastName(aData[i + 1]);
                }

                if (aData[i] == "USERNAME")
                {
                    //Debug.Cleared("USERNAME: " + aData[i + 1]);
                    Clients.SetUserName(aData[i + 1]);
                }

                if (aData[i] == "USERPIC")
                {
                    //Debug.Cleared("USERPIC: " + aData[i + 1]);
                    Clients.SetUserPic(aData[i + 1]);
                }

                if (aData[i] == "ANDROIDDEVICEID")
                {
                    //Debug.Cleared("ANDROID DEVICEID: " + aData[i + 1]);
                    Clients.SetUserDeviceId(aData[i + 1]);
                }
                if (aData[i] == "CLIENTSIPADDRESS")
                {
                    //Debug.Cleared("CLIENTS IP: " + aData[i + 1]);
                    Clients.SetUserIpAddress(aData[i + 1]);
                }
                if (aData[i] == "USERCREDITS")
                {
                    //Debug.Cleared("CLIENTS CREDITS: " + aData[i + 1]);
                    Clients.SetUserCredits(aData[i + 1]);
                }
                if (aData[i] == "USERGPSX")
                {
                    //Debug.Cleared("USERGPSX: " + aData[i + 1]);
                    Clients.SetUserGpsX(aData[i + 1]);
                }
                if (aData[i] == "USERGPSY")
                {
                    //Debug.Cleared("USERGPSY: " + aData[i + 1]);
                    Clients.SetUserGpsY(aData[i + 1]);
                }
                if (aData[i] == "USERGPSZ")
                {
                    //Debug.Cleared("USERGPSZ: " + aData[i + 1]);
                    Clients.SetUserGpsZ(aData[i + 1]);
                }
            }
            if (Clients.GetUserAccessToken() != null
                && Clients.GetUserId() != null
                 && Clients.GetLoginStatus() != null
                  && Clients.GetUserFirstName() != null
                  && Clients.GetUserLastName() != null
                   && Clients.GetUserName() != null
                && Clients.GetUserDeviceId() != null
                && Clients.GetUserIpAddress() != null
                && Clients.GetUserCredits() != null
                && Clients.GetUserGpsX() != null
                && Clients.GetUserGpsY() != null
                && Clients.GetUserGpsZ() != null)
            {

                // pre load database for new client
                MySqlManager.CheckingClientsPreloadDataLogin(ClientSocket, Clients.GetUserDeviceId(), Clients.GetUserIpAddress(), Clients.GetUserCredits(), Clients.GetUserGpsX(), Clients.GetUserGpsY(), Clients.GetUserGpsZ(), Clients.GetUserId(), Clients.GetUserFirstName(),Clients.GetUserLastName(),Clients.GetUserName(),Clients.GetUserAccessToken(),Clients.GetLoginStatus(), Clients.GetUserPic());

            }
            
            //Debug.Finished("Network: OnSocketNewClientConnectionLogin()");
        }

        public static void OnSocketNewClientConnection(Socket ClientSocket, String data)
        {
            //Debug.Starting("Network: OnSocketNewClientConnection()");

            //Debug.Log("DATALOG: " + data);

            string[] aData = data.Split('|');
            for (int i = 0; i < aData.Length - 1; i++)
            {

                if (aData[i] == "ANDROIDDEVICEID")
                {
                    //Debug.Cleared("ANDROID DEVICEID: " + aData[i + 1]);
                    Clients.SetUserDeviceId(aData[i + 1]);
                }
                if (aData[i] == "CLIENTSIPADDRESS")
                {
                    //Debug.Cleared("CLIENTS IP: " + aData[i + 1]);
                    Clients.SetUserIpAddress(aData[i + 1]);
                }
                if (aData[i] == "USERCREDITS")
                {
                    //Debug.Cleared("CLIENTS CREDITS: " + aData[i + 1]);
                    Clients.SetUserCredits(aData[i + 1]);
                }
                if (aData[i] == "USERGPSX")
                {
                    //Debug.Cleared("USERGPSX: " + aData[i + 1]);
                    Clients.SetUserGpsX(aData[i + 1]);
                }
                if (aData[i] == "USERGPSY")
                {
                    //Debug.Cleared("USERGPSY: " + aData[i + 1]);
                    Clients.SetUserGpsY(aData[i + 1]);
                }
                if (aData[i] == "USERGPSZ")
                {
                    //Debug.Cleared("USERGPSZ: " + aData[i + 1]);
                    Clients.SetUserGpsZ(aData[i + 1]);
                }
            }
            if (Clients.GetUserDeviceId() != null
                && Clients.GetUserIpAddress() != null
                && Clients.GetUserCredits() != null
                && Clients.GetUserGpsX() != null
                && Clients.GetUserGpsY() != null
                && Clients.GetUserGpsZ() != null)
            {

                // pre load database for new client
                MySqlManager.CheckClientsPreloadData(ClientSocket, Clients.GetUserDeviceId(), Clients.GetUserIpAddress(), Clients.GetUserCredits(), Clients.GetUserGpsX(), Clients.GetUserGpsY(), Clients.GetUserGpsZ());

            }


            //Debug.Finished("Network: OnSocketNewClientConnection()");
        }


        public static void OnSocketConnection(Socket ClientSocket, String data)
        {

            //Debug.Starting("Network: OnSocketConnection()");


            string[] aData = data.Split('|');
            for (int i = 0; i < aData.Length - 1; i++)
            {

                if (aData[i] == "USERACCESSTOKEN")
                {
                    Clients.SetAccessToken(aData[i + 1]);
                    //Debug.Cleared("USERACCESSTOKEN: " + aData[i + 1]);
                }
                if (aData[i] == "USERID")
                {
                    Clients.SetUserId(aData[i + 1]);
                    //Debug.Cleared("USERID: " + aData[i + 1]);
                }
                if (aData[i] == "LOGINSTATUS")
                {
                    Clients.SetLoginStatus(aData[i + 1]);
                    //Debug.Cleared("LOGINSTATUS: " + aData[i + 1]);
                }




            }
            if (Clients.GetUserId() != null && Clients.GetUserId().Length > 1)
            {
                Clients.CheckClientsData(ClientSocket, Clients.GetUserId(), Clients.GetAccessToken(), Clients.GetLoginStatus());
            }
            else
            {
                // //Debug.Info("NO USER COULD BE FOUND SENDING NEW LOGIN MESSAGE");
                //  data = "|NEWCLIENTWATINGLOGIN|";
                //  Program.SendData(ClientSocket, data);
            }




            if (Clients.ConnectedClients != null)
            {
                //Debug.Info("Clients Connected: " + Clients.ConnectedClients.Count);
            }
            if (Clients.ConnectingClients != null)
            {
                //Debug.Info("Clients Connecting: " + Clients.ConnectingClients.Count);
            }

            //Debug.Finished("Network: OnSocketConnection()");
        }
    }
}
