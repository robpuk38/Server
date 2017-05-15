using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TheServer
{
    class Network
    {



        private static void ClientUpdateDataManager(string data)
        {
            string[] aData = data.Split('|');
            for (int i = 0; i < aData.Length - 1; i++)
            {

                if (aData[i] == Construct._ID)
                {

                    //Debug.Log(Construct._ID + " " + aData[i + 1]);
                    Clients.SetId(aData[i + 1]);
                }

                if (aData[i] == Construct._USERACCESS)
                {

                    //Debug.Log(Construct._USERACCESS + " " + aData[i + 1]);
                    Clients.SetUserAccess(aData[i + 1]);
                }

                if (aData[i] == Construct._USERACCESSTOKEN)
                {

                    //Debug.Log(Construct._USERACCESSTOKEN + " " + aData[i + 1]);
                    Clients.SetUserAccessToken(aData[i + 1]);
                }

                if (aData[i] == Construct._USERACTIVATION)
                {

                    //Debug.Log(Construct._USERACTIVATION + " " + aData[i + 1]);
                    Clients.SetUserAcctivation(aData[i + 1]);
                }

                if (aData[i] == Construct._USERCREDITS)
                {

                    //Debug.Log(Construct._USERCREDITS + " " + aData[i + 1]);
                    Clients.SetUserCredits(aData[i + 1]);
                }

                if (aData[i] == Construct._USERDEVICEID)
                {

                    //Debug.Log(Construct._USERDEVICEID + " " + aData[i + 1]);
                    Clients.SetUserDeviceId(aData[i + 1]);
                }

                if (aData[i] == Construct._USEREXP)
                {

                    //Debug.Log(Construct._USEREXP + " " + aData[i + 1]);
                    Clients.SetUserExp(aData[i + 1]);
                }

                if (aData[i] == Construct._USERFIRSTNAME)
                {

                    //Debug.Log(Construct._USERFIRSTNAME + " " + aData[i + 1]);
                    Clients.SetUserFirstName(aData[i + 1]);
                }

                if (aData[i] == Construct._USERFIRSTTIMELOGIN)
                {

                    //Debug.Log(Construct._USERFIRSTTIMELOGIN + " " + aData[i + 1]);
                    Clients.SetFirstTimeLogin(aData[i + 1]);
                }

                if (aData[i] == Construct._USERGPSX)
                {

                    //Debug.Log(Construct._USERGPSX + " " + aData[i + 1]);
                    Clients.SetUserGpsX(aData[i + 1]);
                }

                if (aData[i] == Construct._USERGPSY)
                {

                    //Debug.Log(Construct._USERGPSY + " " + aData[i + 1]);
                    Clients.SetUserGpsY(aData[i + 1]);
                }

                if (aData[i] == Construct._USERGPSZ)
                {

                    //Debug.Log(Construct._USERGPSZ + " " + aData[i + 1]);
                    Clients.SetUserGpsZ(aData[i + 1]);
                }

                if (aData[i] == Construct._USERHEALTH)
                {

                    //Debug.Log(Construct._USERHEALTH + " " + aData[i + 1]);
                    Clients.SetUserHealth(aData[i + 1]);
                }

                if (aData[i] == Construct._USERID)
                {

                    //Debug.Log(Construct._USERID + " " + aData[i + 1]);
                    if (aData[i + 1] != Construct._USERID && aData[i + 1] != Construct._ZERO && aData[i + 1] != Construct._USERDEVICEID && aData[i + 1] != Construct._USERADSMODTYPE && aData[i + 1] != Construct._USERSTATE && aData[i + 1] != Construct._NULL)
                    {
                        //Debug.Error(Construct._USERID + "  WE MADE IT IN EVERYTHING IS OK FOR USER ID " + aData[i + 1]);
                        Clients.SetUserId(aData[i + 1]);
                    }
                    else
                    {
                        Clients.SetUserId(Construct._USERID);
                    }
                }

                if (aData[i] == Construct._USERIPADDRESS)
                {

                    //Debug.Log(Construct._USERIPADDRESS + " " + aData[i + 1]);
                    Clients.SetUserIpAddress(aData[i + 1]);
                }

                if (aData[i] == Construct._USERLASTNAME)
                {

                    //Debug.Log(Construct._USERLASTNAME + " " + aData[i + 1]);
                    Clients.SetUserLastName(aData[i + 1]);
                }

                if (aData[i] == Construct._USERLEVEL)
                {

                    //Debug.Log(Construct._USERLEVEL + " " + aData[i + 1]);
                    Clients.SetUserLevel(aData[i + 1]);
                }

                if (aData[i] == Construct._USERMANA)
                {

                    //Debug.Log(Construct._USERMANA + " " + aData[i + 1]);
                    Clients.SetUserMana(aData[i + 1]);
                }

                if (aData[i] == Construct._USERNAME)
                {

                    //Debug.Log(Construct._USERNAME + " " + aData[i + 1]);
                    Clients.SetUserName(aData[i + 1]);
                }

                if (aData[i] == Construct._USERPIC)
                {

                    //Debug.Log(Construct._USERPIC + " " + aData[i + 1]);
                    Clients.SetUserPic(aData[i + 1]);
                }

                if (aData[i] == Construct._USERSTATE)
                {
                    if (aData[i + 1] != Construct._USERACTIVATION && aData[i + 1] != Construct._USERSTATE)
                    {
                      //  Debug.Log(Construct._USERSTATE + " " + aData[i + 1]);
                        Clients.SetUserState(aData[i + 1]);
                    }
                }

                if (aData[i] == Construct._USERXPOS)
                {

                    //Debug.Log(Construct._USERXPOS + " " + aData[i + 1]);
                    Clients.SetUsersXpos(aData[i + 1]);
                }

                if (aData[i] == Construct._USERYPOS)
                {

                    //Debug.Log(Construct._USERYPOS + " " + aData[i + 1]);
                    Clients.SetUsersYpos(aData[i + 1]);
                }

                if (aData[i] == Construct._USERZPOS)
                {

                    //Debug.Log(Construct._USERZPOS + " " + aData[i + 1]);
                    Clients.SetUsersZpos(aData[i + 1]);
                }

                if (aData[i] == Construct._USERXROT)
                {

                    //Debug.Log(Construct._USERXROT + " " + aData[i + 1]);
                    Clients.SetUsersXrot(aData[i + 1]);
                }

                if (aData[i] == Construct._USERYROT)
                {

                    //Debug.Log(Construct._USERYROT + " " + aData[i + 1]);
                    Clients.SetUsersYrot(aData[i + 1]);
                }

                if (aData[i] == Construct._USERZROT)
                {

                    //Debug.Log(Construct._USERZROT + " " + aData[i + 1]);
                    Clients.SetUsersZrot(aData[i + 1]);
                }

                if (aData[i] == Construct._USERADSMODTYPE)
                {

                    //Debug.Log(Construct._USERADSMODTYPE + " " + aData[i + 1]);
                    Clients.SetUserAdsMod(aData[i + 1]);
                }

            }
        }

        public static void OnAwakeSocketConnection(Socket ClientSocket, String data)
        {
            ClientUpdateDataManager(data);

           MySqlManager.CheckClientsOnAwakeData(ClientSocket, 
               Clients.GetUserDeviceId(), 
               Clients.GetUserIpAddress(), 
               Clients.GetUserCredits(), 
               Clients.GetUserGpsX(), 
               Clients.GetUserGpsY(), 
               Clients.GetUserGpsZ());
            
        }

        public static void OnAdsSocketConnection(Socket ClientSocket, String data)
        {
            ClientUpdateDataManager(data);
            MySqlManager.CheckClientsOnAdsData(ClientSocket,
               Clients.GetUserDeviceId(),
               Clients.GetUserIpAddress(),
               Clients.GetUserCredits(),
               Clients.GetUserGpsX(),
               Clients.GetUserGpsY(),
               Clients.GetUserGpsZ(),
               Clients.GetUserId(),
               Clients.GetUserAdsMod(),
               Clients.GetUserState());
        }

        public static void OnLoginSocketConnection(Socket ClientSocket, String data)
        {
            ClientUpdateDataManager(data);

            MySqlManager.CheckClientsOnLoginData(ClientSocket,
                Clients.GetUserDeviceId(),
                Clients.GetUserIpAddress(),
                Clients.GetUserCredits(),
                Clients.GetUserGpsX(),
                Clients.GetUserGpsY(),
                Clients.GetUserGpsZ(),
                Clients.GetUserFirstName(),
                Clients.GetUserId(),
                Clients.GetUserAccessToken(),
                Clients.GetUserPic(),
                Clients.GetUserName(),
                Clients.GetUserLastName(),
                Clients.GetUserState(),
                Clients.GetUserAcctivation());

        }

        public static void OnLogoutSocketConnection(Socket ClientSocket, String data)
        {
            ClientUpdateDataManager(data);

            MySqlManager.CheckClientsOnLogoutData(ClientSocket,
               Clients.GetUserId(),Clients.GetUserState());
        }
      
    }
}
