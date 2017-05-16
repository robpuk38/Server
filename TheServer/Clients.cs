using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace TheServer
{
    public class Players
    {




        public String Id { get; internal set; }
        public String UserId { get; internal set; }
        public String UserName { get; internal set; }
        public String UserPic { get; internal set; }
        public String UserFirstName { get; internal set; }
        public String UserLastName { get; internal set; }
        public String UserAccessToken { get; internal set; }
        public String UserState { get; internal set; }
        public String UserAccess { get; internal set; }
        public String UserCredits { get; internal set; }
        public String UserLevel { get; internal set; }
        public String UserMana { get; internal set; }
        public String UserHealth { get; internal set; }
        public String UserExp { get; internal set; }
        public String UsersXpos { get; internal set; }
        public String UsersYpos { get; internal set; }
        public String UsersZpos { get; internal set; }
        public String UsersXrot { get; internal set; }
        public String UsersYrot { get; internal set; }
        public String UsersZrot { get; internal set; }
        public String UserGpsX { get; internal set; }
        public String UserGpsY { get; internal set; }
        public String UserGpsZ { get; internal set; }
        public String FirstTimeLogin { get; internal set; }
        public String UserDeviceId { get; internal set; }
        public String UserIpAddress { get; internal  set; }
        public String UserAcctivation { get; internal  set; }



        public Players(string _Id,
                       string _UserId,
                       string _UserName,
                       string _UserPic,
                       string _UserFirstName,
                       string _UserLastName,
                       string _UserAccessToken,
                       string _UserState,
                       string _UserAccess,
                       string _UserCredits,
                       string _UserLevel,
                       string _UserMana,
                       string _UserHealth,
                       string _UserExp,
                       string _UsersXpos,
                       string _UsersYpos,
                       string _UsersZpos,
                       string _UsersXrot,
                       string _UsersYrot,
                       string _UsersZrot,
                       string _UserGpsX,
                       string _UserGpsY,
                       string _UserGpsZ,
                       string _FirstTimeLogin, 
                       string _UserDeviceId,
                       string _UserIpAddress,
                       string _UserAcctivation)
        {
            Id = _Id;
            UserId = _UserId;
            UserName = _UserName;
            UserPic = _UserPic;
            UserFirstName = _UserFirstName;
            UserLastName = _UserLastName;
            UserAccessToken = _UserAccessToken;
            UserState = _UserState;
            UserAccess = _UserAccess;
            UserCredits = _UserCredits;
            UserLevel = _UserLevel;
            UserMana = _UserMana;
            UserHealth = _UserHealth;
            UserExp = _UserExp;
            UsersXpos = _UsersXpos;
            UsersYpos = _UsersYpos;
            UsersZpos = _UsersZpos;
            UsersXrot = _UsersXrot;
            UsersYrot = _UsersYrot;
            UsersZrot = _UsersZrot;
            UserGpsX = _UserGpsX;
            UserGpsY = _UserGpsY;
            UserGpsZ = _UserGpsZ;
            FirstTimeLogin = _FirstTimeLogin;
            UserDeviceId = _UserDeviceId;
            UserIpAddress = _UserIpAddress;
            UserAcctivation = _UserAcctivation;

        }


    }
    public class Clients
    {
        Players player;

        private Clients()
        {
            player = new Players(Id,
    UserId,
    UserName,
    UserPic,
    UserFirstName,
    UserLastName,
    UserAccessToken,
    UserState,
    UserAccess,
    UserCredits,
    UserLevel,
    UserMana,
    UserHealth,
    UserExp,
    UsersXpos,
    UsersYpos,
    UsersZpos,
    UsersXrot,
    UsersYrot,
    UsersZrot,
    UserGpsX,
    UserGpsY,
    UserGpsZ,
    FirstTimeLogin,
    UserDeviceId,
    UserIpAddress,
    UserAcctivation);
        }



        public static Clients Instance
        {
            get { return instance; }
        }

        private static Clients instance = new Clients();



        private String Id { get; set; }
        private String UserId { get; set; }
        private String UserName { get; set; }
        private String UserPic { get; set; }
        private String UserFirstName { get; set; }
        private String UserLastName { get; set; }
        private String UserAccessToken { get; set; }
        private String UserState { get; set; }
        private String UserAccess { get; set; }
        private String UserCredits { get; set; }
        private String UserLevel { get; set; }
        private String UserMana { get; set; }
        private String UserHealth { get; set; }
        private String UserExp { get; set; }
        private String UsersXpos { get; set; }
        private String UsersYpos { get; set; }
        private String UsersZpos { get; set; }
        private String UsersXrot { get; set; }
        private String UsersYrot { get; set; }
        private String UsersZrot { get; set; }
        private String UserGpsX { get; set; }
        private String UserGpsY { get; set; }
        private String UserGpsZ { get; set; }
        private String FirstTimeLogin { get; set; }
        private String UserDeviceId { get; set; }
        private String UserIpAddress { get; set; }
        private String UserAcctivation { get; set; }
        private String UserAdsMod{ get; set; }


    public static List<Players> ConnectingClients= new List<Players>();
        public static List<Players> ConnectedClients= new List<Players>();

        private string _GetUserAcctivation()
        {
            return UserAcctivation;
        }

        public static string GetUserAcctivation()
        {

            return instance._GetUserAcctivation();
        }

        private void _SetUserAcctivation(string set)
        {
            UserAcctivation = set;
        }

        public static void SetUserAcctivation(string set)
        {

            instance.UserAcctivation = set;
        }




        private string _GetUserIpAddress()
        {
            return UserIpAddress;
        }

        public static string GetUserIpAddress()
        {

            return instance._GetUserIpAddress();
        }

        private void _SetUserIpAddress(string set)
        {
            UserIpAddress = set;
        }

        public static void SetUserIpAddress(string set)
        {

            instance.UserIpAddress = set;
        }




        private string _GetUserDeviceId()
        {
            return UserDeviceId;
        }

        public static string GetUserDeviceId()
        {

            return instance._GetUserDeviceId();
        }

        private void _SetUserDeviceId(string set)
        {
            UserDeviceId = set;
        }

        public static void SetUserDeviceId(string set)
        {

            instance.UserDeviceId = set;
        }




        private string _GetFirstTimeLogin()
        {
            return FirstTimeLogin;
        }

        public static string GetFirstTimeLogin()
        {

            return instance._GetFirstTimeLogin();
        }

        private void _SetFirstTimeLogin(string set)
        {
            FirstTimeLogin = set;
        }

        public static void SetFirstTimeLogin(string set)
        {

            instance.FirstTimeLogin = set;
        }



        private string _GetUserGpsZ()
        {
            return UserGpsZ;
        }

        public static string GetUserGpsZ()
        {

            return instance._GetUserGpsZ();
        }

        private void _SetUserGpsZ(string set)
        {
            UserGpsZ = set;
        }

        public static void SetUserGpsZ(string set)
        {

            instance.UserGpsZ = set;
        }







        private string _GetUserGpsY()
        {
            return UserGpsY;
        }

        public static string GetUserGpsY()
        {

            return instance._GetUserGpsY();
        }

        private void _SetUserGpsY(string set)
        {
            UserGpsY = set;
        }

        public static void SetUserGpsY(string set)
        {

            instance.UserGpsY = set;
        }

        private string _GetUserGpsX()
        {
            return UserGpsX;
        }

        public static string GetUserGpsX()
        {

            return instance._GetUserGpsX();
        }

        private void _SetUserGpsX(string set)
        {
            UserGpsX = set;
        }

        public static void SetUserGpsX(string set)
        {

            instance.UserGpsX = set;
        }



        private string _GetUsersZrot()
        {
            return UsersZrot;
        }

        public static string GetUsersZrot()
        {

            return instance._GetUsersZrot();
        }

        private void _SetUsersZrot(string set)
        {
            UsersZrot = set;
        }

        public static void SetUsersZrot(string set)
        {

            instance.UsersZrot = set;
        }



        private string _GetUsersYrot()
        {
            return UsersYrot;
        }

        public static string GetUsersYrot()
        {

            return instance._GetUsersYrot();
        }

        private void _SetUsersYrot(string set)
        {
            UsersYrot = set;
        }

        public static void SetUsersYrot(string set)
        {

            instance.UsersYrot = set;
        }




        private string _GetUsersXrot()
        {
            return UsersXrot;
        }

        public static string GetUsersXrot()
        {

            return instance._GetUsersXrot();
        }

        private void _SetUsersXrot(string set)
        {
            UsersXrot = set;
        }

        public static void SetUsersXrot(string set)
        {

            instance.UsersXrot = set;
        }



        private string _GetUsersZpos()
        {
            return UsersZpos;
        }

        public static string GetUsersZpos()
        {

            return instance._GetUsersZpos();
        }

        private void _SetUsersZpos(string set)
        {
            UsersZpos = set;
        }

        public static void SetUsersZpos(string set)
        {

            instance.UsersZpos = set;
        }



        private string _GetUsersYpos()
        {
            return UsersYpos;
        }

        public static string GetUsersYpos()
        {

            return instance._GetUsersYpos();
        }

        private void _SetUsersYpos(string set)
        {
            UsersYpos = set;
        }

        public static void SetUsersYpos(string set)
        {

            instance.UsersYpos = set;
        }



        private string _GetUsersXpos()
        {
            return UsersXpos;
        }

        public static string GetUsersXpos()
        {

            return instance._GetUsersXpos();
        }

        private void _SetUsersXpos(string set)
        {
            UsersXpos = set;
        }

        public static void SetUsersXpos(string set)
        {

            instance.UsersXpos = set;
        }


        private string _GetUserExp()
        {
            return UserExp;
        }

        public static string GetUserExp()
        {

            return instance._GetUserExp();
        }

        private void _SetUserExp(string set)
        {
            UserExp = set;
        }

        public static void SetUserExp(string set)
        {

            instance.UserExp = set;
        }



        private string _GetUserHealth()
        {
            return UserHealth;
        }

        public static string GetUserHealth()
        {

            return instance._GetUserHealth();
        }

        private void _SetUserHealth(string set)
        {
            UserHealth = set;
        }

        public static void SetUserHealth(string set)
        {

            instance.UserHealth = set;
        }


        private string _GetUserMana()
        {
            return UserMana;
        }

        public static string GetUserMana()
        {

            return instance._GetUserMana();
        }

        private void _SetUserMana(string set)
        {
            UserMana = set;
        }

        public static void SetUserMana(string set)
        {

            instance.UserMana = set;
        }


        private string _GetUserLevel()
        {
            return UserLevel;
        }

        public static string GetUserLevel()
        {

            return instance._GetUserLevel();
        }

        private void _SetUserLevel(string set)
        {
            UserLevel = set;
        }

        public static void SetUserLevel(string set)
        {

            instance.UserLevel = set;
        }



        private string _GetUserCredits()
        {
            return UserCredits;
        }

        public static string GetUserCredits()
        {

            return instance._GetUserCredits();
        }

        private void _SetUserCredits(string set)
        {
            UserCredits = set;
        }

        public static void SetUserCredits(string set)
        {

            instance.UserCredits = set;
        }



        private string _GetUserAccess()
        {
            return UserAccess;
        }

        public static string GetUserAccess()
        {

            return instance._GetUserAccess();
        }

        private void _SetUserAccess(string set)
        {
            UserAccess = set;
        }

        public static void SetUserAccess(string set)
        {

            instance.UserAccess = set;
        }




        private string _GetUserState()
        {
            return UserState;
        }

        public static string GetUserState()
        {

            return instance._GetUserState();
        }

        private void _SetUserState(string set)
        {
            UserState = set;
        }

        public static void SetUserState(string set)
        {

            instance.UserState = set;
        }




        private string _GetUserAccessToken()
        {
            return UserAccessToken;
        }

        public static string GetUserAccessToken()
        {

            return instance._GetUserAccessToken();
        }

        private void _SetUserAccessToken(string set)
        {
            UserAccessToken = set;
        }

        public static void SetUserAccessToken(string set)
        {

            instance.UserAccessToken = set;
        }



        private string _GetUserLastName()
        {
            return UserLastName;
        }

        public static string GetUserLastName()
        {

            return instance._GetUserLastName();
        }

        private void _SetUserLastName(string set)
        {
            UserLastName = set;
        }

        public static void SetUserLastName(string set)
        {

            instance.UserLastName = set;
        }


        private string _GetUserFirstName()
        {
            return UserFirstName;
        }

        public static string GetUserFirstName()
        {

            return instance._GetUserFirstName();
        }

        private void _SetUserFirstName(string set)
        {
            UserFirstName = set;
        }

        public static void SetUserFirstName(string set)
        {

            instance.UserFirstName = set;
        }




        private string _GetUserPic()
        {
            return UserPic;
        }

        public static string GetUserPic()
        {

            return instance._GetUserPic();
        }

        private void _SetUserPic(string set)
        {
            UserPic = set;
        }

        public static void SetUserPic(string set)
        {

            instance.UserPic = set;
        }





        private string _GetId()
        {
            return Id;
        }

        public static string GetId()
        {

            return instance._GetId();
        }

        private void _SetId(string set)
        {
            Id = set;
        }

        public static void SetId(string set)
        {

            instance.Id = set;
        }




        


        private string _GetUserAdsMod()
        {
            return UserAdsMod;
        }

        public static string GetUserAdsMod()
        {

            return instance._GetUserAdsMod();
        }

        private void _SetUserAdsMod(string set)
        {
            UserAdsMod = set;
        }

        public static void SetUserAdsMod(string set)
        {

            instance.UserAdsMod = set;
        }

        private string _GetUserId()
        {
            return UserId;
        }

        public static string GetUserId()
        {

            return instance._GetUserId();
        }

        private void _SetUserId(string set)
        {
            UserId = set;
        }

        public static void SetUserId(string set)
        {

            instance.UserId = set;
        }





        private string _GetUserName()
        {
            return UserName;
        }

        public static string GetUserName()
        {

            return instance._GetUserName();
        }

        private void _SetUserName(string set)
        {
            UserName = set;
        }

        public static void SetUserName(string set)
        {

            instance.UserName = set;
        }



        private string _GetAccessToken()
        {
            return UserAccessToken;
        }

        public static string GetAccessToken()
        {

            return instance._GetAccessToken();
        }

        private void _SetAccessToken(string set)
        {
            UserAccessToken = set;
        }

        public static void SetAccessToken(string set)
        {

            instance.UserAccessToken = set;
        }

        private string _GetLoginStatus()
        {
            return UserState;
        }

        public static string GetLoginStatus()
        {

            return instance._GetLoginStatus();
        }

        private void _SetLoginStatus(string set)
        {
            UserState = set;
        }

        public static void SetLoginStatus(string set)
        {

            instance.UserState = set;
        }


        

        

        


        public static void AddPlayers(string Id,
   string UserId,
   string UserName,
   string UserPic,
    string UserFirstName,
   string UserLastName,
    string UserAccessToken,
   string UserState,
   string UserAccess,
   string UserCredits,
   string UserLevel,
   string UserMana,
    string UserHealth,
    string UserExp,
    string UsersXpos,
  string UsersYpos,
   string UsersZpos,
   string UsersXrot,
  string UsersYrot,
   string UsersZrot,
   string UserGpsX,
  string UserGpsY,
  string UserGpsZ,
  string FirstTimeLogin,
  string UserDeviceId,
  string UserIpAddress,
  string UserAcctivation)
        {


            Debug.Starting("Clients: AddPlayers()");
            Players _player = new Players(Id,
    UserId,
    UserName,
    UserPic,
    UserFirstName,
    UserLastName,
    UserAccessToken,
    UserState,
    UserAccess,
    UserCredits,
    UserLevel,
    UserMana,
    UserHealth,
    UserExp,
    UsersXpos,
    UsersYpos,
    UsersZpos,
    UsersXrot,
    UsersYrot,
    UsersZrot,
    UserGpsX,
    UserGpsY,
    UserGpsZ,
    FirstTimeLogin,
    UserDeviceId,
    UserIpAddress,
    UserAcctivation);


           

            if (ConnectedClients != null)
            {
                Debug.Info("Clients Connected: " + ConnectedClients.Count);
            }
            if (ConnectingClients != null)
            {
                Debug.Info("Clients Connecting: " + ConnectingClients.Count);
            }


            

            if ( ConnectingClients != null && _player.UserState == "3" && ConnectedClients != null)
            {
                
                bool alreadyExists = ConnectingClients.Contains(_player);

                if (ConnectedClients.Count > 0)
                {
                    for (int j = 0; j < ConnectedClients.Count; j++)
                    {

                        // so now we have a players list of all the connected clients so we can send them to all other clients.
                       


                        if (ConnectedClients[j].UserId == _player.UserId)
                        {
                            Debug.Log("I AM HERE : " + _player.UserId);

                            
                            // we are checking if the player is in the server or not if they are that is fine we do nothing


                        }
                        else if(ConnectedClients[j].UserState == "3")
                        {
                            Debug.Log("THEY ARE HERE : " + ConnectedClients[j].UserId);
                        }
                        

                        
                    }
                    if (alreadyExists == true)
                    {
                       
                        return;
                    }
                    else if (alreadyExists == false)
                    {
                      

                        if (ConnectingClients != null)
                        {
                            for (int j = 0; j < ConnectingClients.Count; j++)
                            {
                                if (ConnectingClients[j].UserId == UserId)
                                {
                                   

                                    // Ok the user is already connected the the server and is in the list we are as our self so lets return and not add our self again
                                    return;


                                }


                            }
                        }
                        if (_player.UserId != Construct._USERID && _player.UserName != Construct._USERGUEST)
                        {
                            Debug.Log("I DO NOT EXISTS : " + _player.UserId);
                            ConnectingClients.Add(_player);
                            ConnectedClients.Add(_player);
                        }
                    }
                }
                else
                {
                    
                    

                    if (alreadyExists == true)
                    {
                        
                        return;
                    }
                    else if (alreadyExists == false)
                    {
                        if (_player.UserId != Construct._USERID && _player.UserName != Construct._USERGUEST)
                        {
                            Debug.Log("I DO NOT EXISTS : " + _player.UserId);
                            ConnectingClients.Add(_player);
                            ConnectedClients.Add(_player);
                        }
                    }

                }

            }





            if (ConnectingClients != null)
            {
                for (int j = 0; j < ConnectingClients.Count; j++)
                {
                    if (ConnectingClients[j].UserId == UserId)
                    {
                        

                        // Ok the user is already connected the the server and is in the list we are as our self so lets return and not add our self again
                        return;


                    }


                }
            }







            if (ConnectingClients != null && _player.UserState == "1" || ConnectingClients != null && _player.UserState == "2" && _player.UserId != Construct._USERID && _player.UserName != Construct._USERGUEST)
            {
                ConnectingClients.Add(_player);
            }
            if (ConnectedClients != null && _player.UserState == "1" || ConnectedClients != null && _player.UserState == "2" && _player.UserId != Construct._USERID && _player.UserName != Construct._USERGUEST)
            {
                ConnectedClients.Add(_player);
            }
            

            
            Debug.Finished("Clients: AddPlayers()");
        }


    }
}
