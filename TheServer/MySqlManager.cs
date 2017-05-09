using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Net.Sockets;


namespace TheServer
{
    class MySqlManager
    {
        private static String SERVER = Program.IpAddress;
        private static String DATABASE = "serverstorage";
        private static String USERID = "Robert";
        private static String PASSWORD = "MySonRocks123";
        private static MySqlConnection dbConfig;
        private static String query;
        private static MySqlCommand cmd;
        private static MySqlDataReader DataReader;

        public int Id { get; private set; }
        public String FromUserId { get; private set; }
        public String ToUserId { get; private set; }
        public String Message { get; private set; }
        public int received { get; private set; }

        private MySqlManager(int id, String FromID, String ToId, String Mess, int Rec)
        {
            Id = id;
            FromUserId = FromID;
            ToUserId = ToId;
            Message = Mess;
            received = Rec;

        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder config = new MySqlConnectionStringBuilder();

            try
            {
                config.Server = SERVER;
                config.UserID = USERID;
                config.Password = PASSWORD;
                config.Database = DATABASE;
                String Connection = config.ToString();

                config = null;

                //Debug.Starting("Initiating MySql Database:");
                //Debug.Cleared("Server: " + SERVER);
                //Debug.Cleared("Database: " + DATABASE);
                //Debug.Cleared("UserId: " + USERID);
                //Debug.Cleared("Password: " + PASSWORD);
                //Debug.Finished("MySql Database Connection Compleate:");


                dbConfig = new MySqlConnection(Connection);
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Database Configeration Error: " + Mex.Message);
            }






        }

        public static void LoadPlayersData(Socket ClientSocket, string _UserId, string _AccessToken, string _LoginStatus)
        {

            if (_LoginStatus == "0")
            {

                // We only want to prep the database and store the information in memory for when they do log back in.
                // so if loginstatus is 1 do nothing but the system is still in here trying to access something
                //Debug.Starting("MySqlManager: LoadPlayersData()");
                query = "SELECT * FROM clients WHERE UserId ='" + _UserId + "' AND UserAccessToken ='" + _AccessToken + "' LIMIT 1";
                cmd = new MySqlCommand(query, dbConfig);



                try
                {

                    dbConfig.Open();

                    DataReader = cmd.ExecuteReader();


                    /*
                     Id
    UserId
    UserName
    UserPic
    UserFirstName
    UserLastName
    UserAccessToken
    UserState
    UserAccess
    UserCredits
    UserLevel
    UserMana
    UserHealth
    UserExp
    UsersXpos
    UsersYpos
    UsersZpos
    UsersXrot
    UsersYrot
    UsersZrot
    UserGpsX
    UserGpsY
    UserGpsZ
    FirstTimeLogin

                     */

                    if (DataReader.Read())
                    {

                        String Id = DataReader["Id"].ToString();
                        //Debug.Cleared("Id " + Id);

                        String UserId = DataReader["UserId"].ToString();
                        //Debug.Cleared("UserId " + UserId);

                        String UserName = DataReader["UserName"].ToString();
                        //Debug.Cleared("UserName " + UserName);

                        String UserPic = DataReader["UserPic"].ToString();
                        //Debug.Cleared("UserPic " + UserPic);

                        String UserFirstName = DataReader["UserFirstName"].ToString();
                        //Debug.Cleared("UserFirstName " + UserFirstName);

                        String UserLastName = DataReader["UserLastName"].ToString();
                        //Debug.Cleared("UserLastName " + UserLastName);

                        String UserAccessToken = DataReader["UserAccessToken"].ToString();
                        //Debug.Cleared("UserAccessToken " + UserAccessToken);

                        String UserState = DataReader["UserState"].ToString();
                        //Debug.Cleared("UserState " + UserState);

                        //if (UserState == "0")
                        //{
                            //Debug.Cleared("UserState: CHANGE " + UserState);
                          //  UserState = "1";
                       // }

                        String UserAccess = DataReader["UserAccess"].ToString();
                        //Debug.Cleared("UserAccess " + UserAccess);

                        String UserCredits = DataReader["UserCredits"].ToString();
                        //Debug.Cleared("UserCredits " + UserCredits);

                        String UserLevel = DataReader["UserLevel"].ToString();
                        //Debug.Cleared("UserLevel " + UserLevel);

                        String UserMana = DataReader["UserMana"].ToString();
                        //Debug.Cleared("UserMana " + UserMana);

                        String UserHealth = DataReader["UserHealth"].ToString();
                        //Debug.Cleared("UserHealth " + UserHealth);

                        String UserExp = DataReader["UserExp"].ToString();
                        //Debug.Cleared("UserExp " + UserExp);

                        String UsersXpos = DataReader["UsersXpos"].ToString();
                        //Debug.Cleared("UsersXpos " + UsersXpos);

                        String UsersYpos = DataReader["UsersYpos"].ToString();
                        //Debug.Cleared("UsersYpos " + UsersYpos);

                        String UsersZpos = DataReader["UsersZpos"].ToString();
                        //Debug.Cleared("UsersZpos " + UsersZpos);

                        String UsersXrot = DataReader["UsersXrot"].ToString();
                        //Debug.Cleared("UsersXrot " + UsersXrot);

                        String UsersYrot = DataReader["UsersYrot"].ToString();
                        //Debug.Cleared("UsersYrot " + UsersYrot);

                        String UsersZrot = DataReader["UsersZrot"].ToString();
                        //Debug.Cleared("UsersZrot " + UsersZrot);

                        String UserGpsX = DataReader["UserGpsX"].ToString();
                        //Debug.Cleared("UserGpsX " + UserGpsX);

                        String UserGpsY = DataReader["UserGpsY"].ToString();
                        //Debug.Cleared("UserGpsY " + UserGpsY);

                        String UserGpsZ = DataReader["UserGpsZ"].ToString();
                        //Debug.Cleared("UserGpsZ " + UserGpsZ);

                        String FirstTimeLogin = DataReader["FirstTimeLogin"].ToString();
                        //Debug.Cleared("FirstTimeLogin " + FirstTimeLogin);

                        String UserDeviceId = DataReader["UserDeviceId"].ToString();
                        //Debug.Cleared("UserDeviceId " + UserDeviceId);

                        String UserIpAddress = DataReader["UserIpAddress"].ToString();
                        //Debug.Cleared("UserIpAddress " + UserIpAddress);

                        String UserAcctivation = DataReader["UserAcctivation"].ToString();
                        //Debug.Cleared("UserIpAddress " + UserAcctivation);

                        string data = Contruct.ID + Id
                            + Contruct.USERID + UserId
                            + Contruct.USERNAME + UserName
                            + Contruct.USERPIC  + UserPic
                            + Contruct.USERFIRSTNAME  + UserFirstName
                            + Contruct.USERLASTNAME  + UserLastName
                            + Contruct.USERACCESSTOKEN  + UserAccessToken
                            + Contruct.USERSTATE +"1"
                            + Contruct.USERACCESS  + UserAccess
                            + Contruct.USERCREDITS  + UserCredits
                            + Contruct.USERLEVEL  + UserLevel
                            + Contruct.USERMANA  + UserMana
                            + Contruct.USERHEALTH  + UserHealth
                            + Contruct.USEREXP  + UserExp
                            + Contruct.USERXPOS  + UsersXpos
                            + Contruct.USERYPOS  + UsersYpos
                            + Contruct.USERZPOS  + UsersZpos
                            + Contruct.USERXROT  + UsersXrot
                            + Contruct.USERYROT  + UsersYrot
                            + Contruct.USERZROT  + UsersZrot
                            + Contruct.USERGPSX  + UserGpsX
                            + Contruct.USERGPSY  + UserGpsY
                            + Contruct.USERGPSZ  + UserGpsZ
                            + Contruct.USERFIRSTTIMELOGIN  + FirstTimeLogin
                            + Contruct.USERDEVICEID  + UserDeviceId
                            + Contruct.USERIPADDRESS  + UserIpAddress
                            + Contruct.USERACCTIVATION  + UserAcctivation;
                        Clients.AddPlayers(
                             Id,
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
    UserAcctivation
 );

                        Program.SendData(ClientSocket, data);

                    }
                    else
                    {
                        dbConfig.Close();
                        //Debug.Info("NO USER COULD BE FOUND CHECKING WITH OUT ACCESSTOKEN");


                        query = "SELECT * FROM clients WHERE UserId ='" + _UserId + "' LIMIT 1";
                        cmd = new MySqlCommand(query, dbConfig);
                        try
                        {
                            dbConfig.Open();
                            DataReader = cmd.ExecuteReader();
                            if (DataReader.Read())
                            {
                                //Debug.Info("USER FOUND UPDATING ACCESS TOKEN ");
                                dbConfig.Close();
                                UpdateClientAccessToekn(ClientSocket, _UserId, _AccessToken, _LoginStatus);
                                /*InsertNewUClient("1",
                                    "uername", 
                                    "pic",
                                    "firstname", 
                                    "lastname", 
                                    "accesstocken", 
                                    "userstate", 
                                    "useraccess", 
                                    "credits",
                                    "level",
                                    "mana",
                                    "health",
                                    "exp",
                                    "xpos",
                                    "ypos",
                                    "zpos",
                                    "xrot",
                                    "yrot",
                                    "zrot",
                                    "gpsx",
                                    "gpsy",
                                    "gpsz",
                                    "0",
                                    "deviceid",
                                    "ipaddress",
                                    "0"
                                    );*/
                            }
                            else
                            {
                                //Debug.Info("NO USER COULD BE FOUND SENDING NEW LOGIN MESSAGE");
                                string data = "|NEWCLIENTWATINGLOGIN|";
                                Program.SendData(ClientSocket, data);


                            }

                        }
                        catch (MySqlException Mex)
                        {
                            //Debug.Error("Database Configeration Error: " + Mex.Message);
                        }



                    }
                    dbConfig.Close();

                }
                catch (MySqlException Mex)
                {
                    //Debug.Error("Database Configeration Error: " + Mex.Message);
                }


                //Debug.Finished("MySqlManager: LoadPlayersData()");
            }






        }


        public static void UpdateClientAccessToekn(Socket ClientSocket, string _UserId, string _UserAccessToken, string _LoginStatus)
        {
            //Debug.Starting("MySqlManager: UpdateClientData()");
            query = string.Format("UPDATE clients SET UserAccessToken='{0}' WHERE UserId = '{1}'", _UserAccessToken, _UserId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();
                LoadPlayersData(ClientSocket, _UserId, _UserAccessToken, _LoginStatus);

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientData()");
        }

        public static void UpdateClientsPreloadData(Socket ClientSocket, string _DeviceId, string _ClientIp, string _ClientsCredits, string _ClientsGpsX, string _ClientsGpsY, string _ClientsGpsZ)
        {
            dbConfig.Close();
            //Debug.Starting("MySqlManager: UpdateClientsPreloadData()");
           
            query = string.Format("UPDATE clients SET UserCredits='{0}',UserIpAddress='{1}',UserGpsX='{2}',UserGpsY='{3}',UserGpsZ='{4}' WHERE UserDeviceId = '{5}'", _ClientsCredits, _ClientIp, _ClientsGpsX, _ClientsGpsY, _ClientsGpsZ, _DeviceId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();
                

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Preloaded Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientsPreloadData()");
        }



        public static void UpdateClientsPreloadLoginData(Socket ClientSocket, string _DeviceId, string _ClientIp, string _ClientsCredits, string _ClientsGpsX, string _ClientsGpsY, string _ClientsGpsZ, string _ClientUserId, string _ClientFirstName, string _ClientLastName, string _ClientUserName, string _ClientAccessToken, string _ClientLoginStatus, string _ClientsPic)
        {
            dbConfig.Close();
            //Debug.Starting("MySqlManager: UpdateClientsPreloadData()");

            query = string.Format("UPDATE clients SET UserCredits='{0}'," +
                "UserIpAddress='{1}'," +
                "UserGpsX='{2}'," +
                "UserGpsY='{3}'," +
                "UserGpsZ='{4}'," +
                "UserId='{5}'," +
                "UserName='{6}'," +
                "UserPic='{7}'," +
                "UserFirstName= '{8}'," +
                "UserLastName = '{9}'," +
                "UserAccessToken = '{10}' WHERE UserDeviceId = '{11}'", _ClientsCredits, _ClientIp, _ClientsGpsX, _ClientsGpsY, _ClientsGpsZ, _ClientUserId, _ClientUserName, _ClientsPic, _ClientFirstName, _ClientLastName, _ClientAccessToken, _DeviceId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();
                

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Preloaded Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientsPreloadData()");
        }


        public static void CheckingClientsPreloadDataLogin(Socket ClientSocket, string _DeviceId, string _ClientIp, string _ClientsCredits, string _ClientsGpsX, string _ClientsGpsY, string _ClientsGpsZ ,string _ClientUserId , string _ClientFirstName ,string _ClientLastName , string _ClientUserName , string _ClientAccessToken, string _ClientLoginStatus, string _ClientsPic)
        {
            //Debug.Starting("MySqlManager: UpdateClientsPreloadDataLogin()");
            dbConfig.Close();
            string data = "";
            query = "SELECT * FROM clients WHERE UserDeviceId ='" + _DeviceId + "' LIMIT 1";
            cmd = new MySqlCommand(query, dbConfig);
            try
            {

                dbConfig.Open();
                DataReader = cmd.ExecuteReader();
                if (DataReader.Read())
                {

                     //UPDATING THE DATA
                  
                    String Id = DataReader["Id"].ToString();
                    //Debug.Cleared("Id " + Id);

                    String UserId = DataReader["UserId"].ToString();
                    //Debug.Cleared("UserId " + UserId);

                    String UserName = DataReader["UserName"].ToString();
                    //Debug.Cleared("UserName " + UserName);

                    String UserPic = DataReader["UserPic"].ToString();
                    //Debug.Cleared("UserPic " + UserPic);

                    String UserFirstName = DataReader["UserFirstName"].ToString();
                    //Debug.Cleared("UserFirstName " + UserFirstName);

                    String UserLastName = DataReader["UserLastName"].ToString();
                    //Debug.Cleared("UserLastName " + UserLastName);

                    String UserAccessToken = DataReader["UserAccessToken"].ToString();
                    //Debug.Cleared("UserAccessToken " + UserAccessToken);

                    String UserState = DataReader["UserState"].ToString();
                    //Debug.Cleared("UserState " + UserState);

                  //  if (_ClientLoginStatus == "1")
                   // {
                        //Debug.Cleared("UserState: CHANGE " + UserState);
                    //    UserState = "2";
                   // }

                    String UserAccess = DataReader["UserAccess"].ToString();
                    //Debug.Cleared("UserAccess " + UserAccess);

                    String UserCredits = DataReader["UserCredits"].ToString();
                    //Debug.Cleared("UserCredits " + UserCredits);

                    String UserLevel = DataReader["UserLevel"].ToString();
                    //Debug.Cleared("UserLevel " + UserLevel);

                    String UserMana = DataReader["UserMana"].ToString();
                    //Debug.Cleared("UserMana " + UserMana);

                    String UserHealth = DataReader["UserHealth"].ToString();
                    //Debug.Cleared("UserHealth " + UserHealth);

                    String UserExp = DataReader["UserExp"].ToString();
                    //Debug.Cleared("UserExp " + UserExp);

                    String UsersXpos = DataReader["UsersXpos"].ToString();
                    //Debug.Cleared("UsersXpos " + UsersXpos);

                    String UsersYpos = DataReader["UsersYpos"].ToString();
                    //Debug.Cleared("UsersYpos " + UsersYpos);

                    String UsersZpos = DataReader["UsersZpos"].ToString();
                    //Debug.Cleared("UsersZpos " + UsersZpos);

                    String UsersXrot = DataReader["UsersXrot"].ToString();
                    //Debug.Cleared("UsersXrot " + UsersXrot);

                    String UsersYrot = DataReader["UsersYrot"].ToString();
                    //Debug.Cleared("UsersYrot " + UsersYrot);

                    String UsersZrot = DataReader["UsersZrot"].ToString();
                    //Debug.Cleared("UsersZrot " + UsersZrot);

                    String UserGpsX = DataReader["UserGpsX"].ToString();
                    //Debug.Cleared("UserGpsX " + UserGpsX);

                    String UserGpsY = DataReader["UserGpsY"].ToString();
                    //Debug.Cleared("UserGpsY " + UserGpsY);

                    String UserGpsZ = DataReader["UserGpsZ"].ToString();
                    //Debug.Cleared("UserGpsZ " + UserGpsZ);

                    String FirstTimeLogin = DataReader["FirstTimeLogin"].ToString();
                    //Debug.Cleared("FirstTimeLogin " + FirstTimeLogin);

                    String UserDeviceId = DataReader["UserDeviceId"].ToString();
                    //Debug.Cleared("UserDeviceId " + UserDeviceId);

                    String UserIpAddress = DataReader["UserIpAddress"].ToString();
                    //Debug.Cleared("UserIpAddress " + UserIpAddress);

                    String UserAcctivation = DataReader["UserAcctivation"].ToString();
                    //Debug.Cleared("UserIpAddress " + UserAcctivation);
                    data = "|NEWCLIENTWATINGLOGIN|2" 
                        + "|ANDROIDDEVICEID|" + _DeviceId
                        + "|CLIENTSIPADDRESS|" + _ClientIp
                        + "|USERCREDITS|" + UserCredits
                        + "|USERGPSX|" + _ClientsGpsX
                        + "|USERGPSY|" + _ClientsGpsY
                        + "|USERGPSZ|" + _ClientsGpsZ
                        + "|ID|" + Id
                        + "|USERID|" + _ClientUserId
                        + "|USERNAME|" + _ClientUserName
                        + "|USERPIC|" + _ClientsPic
                        + "|USERFIRSTNAME|" + _ClientFirstName
                        + "|USERLASTNAME|" + _ClientLastName
                        + "|USERACCESSTOKEN|" + _ClientAccessToken
                        + "|USERSTATE|2";

                    Program.SendData(ClientSocket, data);
                    dbConfig.Close();
                    Clients.AddPlayers(
                            Id,
   UserId,
   UserName,
   UserPic,
   UserFirstName,
   UserLastName,
   UserAccessToken,
   _ClientLoginStatus,
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
   UserAcctivation
);
                    int incredits = 0;
                    bool InClientsCredits = int.TryParse(_ClientsCredits, out incredits);
                    int outcredits = 0;
                    bool OutClientsCredits = int.TryParse(UserCredits, out outcredits);
                    if (incredits > outcredits)
                    {
                        //Debug.Error("CREDITS ARE BIG UPDATE NOW");
                        UpdateClientsPreloadLoginData(ClientSocket, _DeviceId, _ClientIp, _ClientsCredits, _ClientsGpsX, _ClientsGpsY, _ClientsGpsZ, _ClientUserId, _ClientFirstName, _ClientLastName, _ClientUserName, _ClientAccessToken, _ClientLoginStatus, _ClientsPic);

                    }
                    else
                    {
                        UpdateClientsPreloadLoginData(ClientSocket, _DeviceId, _ClientIp, UserCredits, _ClientsGpsX, _ClientsGpsY, _ClientsGpsZ, _ClientUserId, _ClientFirstName, _ClientLastName, _ClientUserName, _ClientAccessToken, _ClientLoginStatus, _ClientsPic);
                    }
                }
                else
                {
                    //Debug.Error("NOTHING WAS FOUND");
                }
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Check Client Preload Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientsPreloadDataLogin()");
        }

        public static void CheckClientsPreloadData(Socket ClientSocket, string _DeviceId, string _ClientIp, string _ClientsCredits, string _ClientsGpsX, string _ClientsGpsY, string _ClientsGpsZ)
        {
            //Debug.Starting("MySqlManager: CheckClientsPreloadData()");
            dbConfig.Close();
            //Debug.Info("PRELOADING CLIENTS DATA CHECKING");

            string data = "";
            query = "SELECT * FROM clients WHERE UserDeviceId ='" + _DeviceId + "' LIMIT 1";
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
               
                dbConfig.Open();
                DataReader = cmd.ExecuteReader();
                if (DataReader.Read())
                {
                    //Debug.Info("USER FOUND SENDING THE DATA WE HAVE ");
                    String Id = DataReader["Id"].ToString();
                    String UserDeviceId = DataReader["UserDeviceId"].ToString();
                    String UserIpAddress = DataReader["UserIpAddress"].ToString();
                    String UserGpsX = DataReader["UserGpsX"].ToString();
                    String UserGpsY = DataReader["UserGpsY"].ToString();
                    String UserGpsZ = DataReader["UserGpsZ"].ToString();
                    String UserCredits = DataReader["UserCredits"].ToString();
                    
                    data = "|NEWCLIENTWATINGLOGIN|2" + "|ANDROIDDEVICEID|" + UserDeviceId + "|CLIENTSIPADDRESS|" + UserIpAddress + "|USERCREDITS|" + UserCredits + "|USERGPSX|" + UserGpsX + "|USERGPSY|" + UserGpsY + "|USERGPSZ|" + UserGpsZ+"|ID|"+ Id;
                    Program.SendData(ClientSocket, data);
                    // UPDATING THE DATA COMMING IN

                    // do not update yet
                    int incredits = 0 ;
                    bool InClientsCredits = int.TryParse(_ClientsCredits, out incredits);
                    int outcredits = 0;
                    bool OutClientsCredits = int.TryParse(UserCredits, out outcredits);
                    if (incredits > outcredits)
                    {
                        //Debug.Error("CREDITS ARE BIG UPDATE NOW");
                        UpdateClientsPreloadData(ClientSocket, _DeviceId, _ClientIp, _ClientsCredits, _ClientsGpsX, _ClientsGpsY, _ClientsGpsZ);
                    }
                    

                    dbConfig.Close();
                }
                else
                {
                    //Debug.Info("NO DATA FOUND INSERTING PRELOADED DATA ");
                    InsertClientsPreloadedData( ClientSocket,  _DeviceId,  _ClientIp,  _ClientsCredits,  _ClientsGpsX,  _ClientsGpsY,  _ClientsGpsZ);
                    
                }
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Check Client Preload Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: CheckClientsPreloadData()");
        }

        public static void InsertClientsPreloadedData(Socket ClientSocket, string _DeviceId, string _ClientIp, string _ClientsCredits, string _ClientsGpsX, string _ClientsGpsY, string _ClientsGpsZ)
        {

            //Debug.Starting("MySqlManager: InsertClientsPreloadedData()");
            string data = "";
            dbConfig.Close();
            query = string.Format("INSERT INTO clients(UserDeviceId, " +
                "UserIpAddress, " +
                "UserCredits, " +
                "UserGpsX, " +
                "UserGpsY," +
                "UserGpsZ) VALUES ('{0}'," +
                "'{1}'," +
                "'{2}'," +
                "'{3}'," +
                "'{4}'," +
                "'{5}')", _DeviceId,
    _ClientIp,
    _ClientsCredits,
    _ClientsGpsX,
    _ClientsGpsY,
    _ClientsGpsZ);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                data = "|NEWCLIENTWATINGLOGIN|1"+"|ANDROIDDEVICEID|"+ _DeviceId+ "|CLIENTSIPADDRESS|"+ _ClientIp+ "|USERCREDITS|"+ _ClientsCredits+ "|USERGPSX|"+ _ClientsGpsX+ "|USERGPSY|" + _ClientsGpsY+ "|USERGPSZ|"+ _ClientsGpsZ;
                Program.SendData(ClientSocket, data);
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Insert New Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: InsertClientsPreloadedData()");

        }

        public static void InsertNewUClient(string _UserId,
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
    string _UserAcctivation


            )
        {
            /*
              UserId
    UserName
    UserPic
    UserFirstName
    UserLastName
    UserAccessToken
    UserState
    UserAccess
    UserCredits
    UserLevel
    UserMana
    UserHealth
    UserExp
    UsersXpos
    UsersYpos
    UsersZpos
    UsersXrot
    UsersYrot
    UsersZrot
    UserGpsX
    UserGpsY
    UserGpsZ
    FirstTimeLogin
             */
            //Debug.Starting("MySqlManager: InsertNewUClient()");


            query = string.Format("INSERT INTO clients(UserId, " +
                "UserName, " +
                "UserPic, " +
                "UserFirstName, " +
                "UserLastName," +
                "UserAccessToken," +
                "UserState," +
                "UserAccess," +
                "UserCredits," +
                "UserLevel," +
                "UserMana," +
                "UserHealth," +
                "UserExp," +
                "UsersXpos," +
                "UsersYpos," +
                "UsersZpos," +
                "UsersXrot," +
                "UsersYrot," +
                "UsersZrot," +
                "UserGpsX," +
                "UserGpsY," +
                "UserGpsZ," +
                "FirstTimeLogin," +
                "UserDeviceId," +
                "UserIpAddress," +
                "UserAcctivation) VALUES ('{0}'," +
                "'{1}'," +
                "'{2}'," +
                "'{3}'," +
                "'{4}'," +
                "'{5}'," +
                "'{6}'," +
                "'{7}'," +
                "'{8}'," +
                "'{9}'," +
                "'{10}'," +
                "'{11}'," +
                "'{12}'," +
                "'{13}'," +
                "'{14}'," +
                "'{15}'," +
                "'{16}'," +
                "'{17}'," +
                "'{18}'," +
                "'{19}'," +
                "'{20}'," +
                "'{21}'," +
                "'(22)'," +
                "'(23)'," +
                "'(24)'," +
                "'(25)')", _UserId,
    _UserName,
    _UserPic,
    _UserFirstName,
    _UserLastName,
    _UserAccessToken,
    _UserState,
    _UserAccess,
    _UserCredits,
    _UserLevel,
    _UserMana,
    _UserHealth,
    _UserExp,
    _UsersXpos,
    _UsersYpos,
    _UsersZpos,
    _UsersXrot,
    _UsersYrot,
    _UsersZrot,
    _UserGpsX,
    _UserGpsY,
    _UserGpsZ,
    _FirstTimeLogin,
    _UserDeviceId,
    _UserIpAddress,
    _UserAcctivation);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Insert New Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: InsertNewUClient()");
        }


        public static void LoadAllMessage()
        {
            //Debug.Starting("MySqlManager: LoadAllMessage()");
            List<MySqlManager> Messages = MySqlManager.GetMessage();

            foreach (MySqlManager Mess in Messages)
            {

                /*Debug.Cleared(
                    "ID: " + Mess.Id.ToString() +
                    " FromUserID: " + Mess.FromUserId.ToString() +
                    " ToUserID: " + Mess.ToUserId.ToString() +
                    " Message: " + Mess.Message.ToString() +
                    " Recieved: " + Mess.received.ToString());*/

            }
            //Debug.Finished("MySqlManager: LoadAllMessage()");
        }

        public static List<MySqlManager> GetMessage()
        {
            //Debug.Starting("MySqlManager: GetMessage()");
            List<MySqlManager> Messages = new List<MySqlManager>();

            String query = "SELECT * FROM clients_message";
            MySqlCommand cmd = new MySqlCommand(query, dbConfig);
            try
            {

                dbConfig.Open();

                MySqlDataReader DataReader = cmd.ExecuteReader();


                while (DataReader.Read())
                {
                    int id = (int)DataReader["id"];
                    String fromUserId = DataReader["fromUserId"].ToString();
                    String toUserId = DataReader["toUserId"].ToString();
                    String message = DataReader["message"].ToString();
                    int received = (int)DataReader["received"];

                    MySqlManager Mess = new MySqlManager(id, fromUserId, toUserId, message, received);
                    Messages.Add(Mess);

                }

                dbConfig.Close();
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Database Configeration Error: " + Mex.Message);
            }

            //Debug.Finished("MySqlManager: GetMessage()");

            return Messages;
        }


    }
}
