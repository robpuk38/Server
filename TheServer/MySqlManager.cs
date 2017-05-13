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
        public static void CheckClientsOnLoginData(Socket ClientSocket, string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ, string ClientFirstName ,string ClientUserId, string ClientAccessToken, string ClientPic, string ClientName, string ClientLastName, string ClientState, string ClientActivation)
        {

            query = "SELECT * FROM clients WHERE UserDeviceId ='" + ClientDeviceId + "' LIMIT 1";
            cmd = new MySqlCommand(query, dbConfig);

            string data = "";

            try
            {

                dbConfig.Open();

                DataReader = cmd.ExecuteReader();
                if (DataReader.Read())
                {
                    Debug.Error("The client is a full member we have all the data to send back to the client");
                    data = MyClientsTableDatatReader(DataReader);
                    AddClientToList();
                    dbConfig.Close();
                    //Debug.Error("MY ID "+ ClientUserId);
                    //Debug.Error("MY STATE " + ClientState);
                    query = string.Format("UPDATE clients SET UserState='{0}' WHERE UserId = '{1}'", ClientState, ClientUserId);
                    cmd = new MySqlCommand(query, dbConfig);
                    try
                    {
                        dbConfig.Open();
                        cmd.ExecuteNonQuery();
                        dbConfig.Close();


                    }
                    catch (MySqlException Mex)
                    {
                        //Debug.Error("Mysql Update Client Exception " + Mex.Message);
                    }
                    dbConfig.Close();
                }
                else
                {
                    // no client found lets insert the new data
                    Debug.Error("CHECKING CLIENTS ID INSERTING INTO CLIENTS : ");
                    dbConfig.Close();
                    query = "SELECT * FROM clients WHERE UserId ='" + ClientUserId + "' LIMIT 1";
                    cmd = new MySqlCommand(query, dbConfig);

                    try
                    {

                        dbConfig.Open();

                        DataReader = cmd.ExecuteReader();
                        if (DataReader.Read())
                        {
                            //The client is already a member and found in the database with a user ID thye must be uing a new device lets update the information
                            //Debug.Error("The client is already a member and found in the database with a user ID thye must be uing a new device lets update the information : ");
                            // data = MyClientsTableDatatReader(DataReader);
                            // AddClientToList();

                            Debug.Error("THE USER WAS FOUND UPDATING NEW INFORMATION : ");
                            UpdateClientDevice(ClientUserId, ClientAccessToken, ClientDeviceId, ClientIpAddress, ClientGpsX,ClientGpsY,ClientGpsZ, ClientCredits);
                            dbConfig.Close();
                        }
                        else
                        {
                            dbConfig.Close();
                            // ok this is a new client and its ok to insert the data
                            InsertNewUClient(ClientUserId,
   ClientName,
   ClientPic,
   ClientFirstName,
    ClientLastName,
   ClientAccessToken,
   ClientState,
    "0",
   ClientCredits,
    "1",
    "100",
    "100",
    "0",
    "0",
    "0",
    "0",
    "0",
    "0",
    "0",
   ClientGpsX,
   ClientGpsY,
   ClientGpsZ,
   "0",
   ClientDeviceId,
   ClientIpAddress,
   ClientActivation);
                            dbConfig.Close();
                        }
                    }
                    catch (MySqlException Mex)
                    {
                        //Debug.Error("Mysql Insert New Client Exception " + Mex.Message);
                    }




                    
                }
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Insert New Client Exception " + Mex.Message);
            }

            Program.SendData(ClientSocket, data);
            Program.Disconnected(ClientSocket);

        }

        public static void CheckClientsOnLogoutData(Socket ClientSocket, string ClientUserId, string ClientState)
        {

            dbConfig.Close();
            query = string.Format("UPDATE clients SET UserState='{0}' WHERE UserId = '{1}'", ClientState, ClientUserId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();


            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Exception " + Mex.Message);
            }
            dbConfig.Close();

           string data = Construct.USERID + ClientUserId
                       + Construct.USERSTATE + ClientState;
            Program.SendData(ClientSocket, data);
            Program.Disconnected(ClientSocket);

        }


        public static void InsertNewUClient(string _UserId,string _UserName,string _UserPic,string _UserFirstName,string _UserLastName, string _UserAccessToken, string _UserState, string _UserAccess, string _UserCredits, string _UserLevel, string _UserMana, string _UserHealth, string _UserExp, string _UsersXpos, string _UsersYpos, string _UsersZpos, string _UsersXrot, string _UsersYrot, string _UsersZrot, string _UserGpsX,string _UserGpsY, string _UserGpsZ, string _FirstTimeLogin, string _UserDeviceId,string _UserIpAddress,string _UserAcctivation)
        {

            //Debug.Starting("MySqlManager: InsertNewUClient()");

            dbConfig.Close();
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
                "UserXpos," +
                "UserYpos," +
                "UserZpos," +
                "UserXrot," +
                "UserYrot," +
                "UserZrot," +
                "UserGpsX," +
                "UserGpsY," +
                "UserGpsZ," +
                "UserFirstTimeLogin," +
                "UserDeviceId," +
                "UserIpAddress," +
                "UserActivation) VALUES ('{0}'," +
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
                "'{22}'," +
                "'{23}'," +
                "'{24}'," +
                "'{25}')", _UserId,
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
                dbConfig.Close();
                UpdatingIntoClientsTempTable(_UserDeviceId, _UserIpAddress, _UserCredits, _UserGpsX, _UserGpsY, _UserGpsZ, _UserId);

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Insert New Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: InsertNewUClient()");
        }

        private static string MyClientsTableDatatReader(MySqlDataReader DataReader)
        {


            //The client is a full member we have all the data to send back to the client
            String Id = DataReader["Id"].ToString();
            //Debug.Cleared("Id " + Id);
            Clients.SetId(Id);

            String UserId = DataReader["UserId"].ToString();
            //Debug.Cleared("UserId " + UserId);
            Clients.SetUserId(UserId);

            String UserName = DataReader["UserName"].ToString();
            //Debug.Cleared("UserName " + UserName);
            Clients.SetUserName(UserName);

            String UserPic = DataReader["UserPic"].ToString();
            //Debug.Cleared("UserPic " + UserPic);
            Clients.SetUserPic(UserPic);

            String UserFirstName = DataReader["UserFirstName"].ToString();
            //Debug.Cleared("UserFirstName " + UserFirstName);
            Clients.SetUserLastName(UserFirstName);

            String UserLastName = DataReader["UserLastName"].ToString();
            //Debug.Cleared("UserLastName " + UserLastName);
            Clients.SetUserLastName(UserLastName);

            String UserAccessToken = DataReader["UserAccessToken"].ToString();
            //Debug.Cleared("UserAccessToken " + UserAccessToken);
            Clients.SetUserAccessToken(UserAccessToken);

            String UserState = DataReader["UserState"].ToString();
            Clients.SetUserState(UserState);
            //Debug.Cleared("UserState " + UserState);

            //if (UserState == "0")
            //{
            //Debug.Cleared("UserState: CHANGE " + UserState);
            //  UserState = "1";
            // }

            String UserAccess = DataReader["UserAccess"].ToString();
            Clients.SetUserAccess(UserAccess);
            //Debug.Cleared("UserAccess " + UserAccess);

            String UserCredits = DataReader["UserCredits"].ToString();
            Clients.SetUserCredits(UserCredits);
            //Debug.Cleared("UserCredits " + UserCredits);

            String UserLevel = DataReader["UserLevel"].ToString();
            Clients.SetUserLevel(UserLevel);
            //Debug.Cleared("UserLevel " + UserLevel);

            String UserMana = DataReader["UserMana"].ToString();
            //Debug.Cleared("UserMana " + UserMana);
            Clients.SetUserMana(UserMana);

            String UserHealth = DataReader["UserHealth"].ToString();
            //Debug.Cleared("UserHealth " + UserHealth);
            Clients.SetUserHealth(UserHealth);

            String UserExp = DataReader["UserExp"].ToString();
            //Debug.Cleared("UserExp " + UserExp);
            Clients.SetUserExp(UserExp);

            String UsersXpos = DataReader["UserXpos"].ToString();
            //Debug.Cleared("UsersXpos " + UsersXpos);
            Clients.SetUsersXpos(UsersXpos);

            String UsersYpos = DataReader["UserYpos"].ToString();
            //Debug.Cleared("UsersYpos " + UsersYpos);
            Clients.SetUsersYpos(UsersYpos);

            String UsersZpos = DataReader["UserZpos"].ToString();
            //Debug.Cleared("UsersZpos " + UsersZpos);
            Clients.SetUsersZpos(UsersZpos);

            String UsersXrot = DataReader["UserXrot"].ToString();
            //Debug.Cleared("UsersXrot " + UsersXrot);
            Clients.SetUsersXrot(UsersXrot);

            String UsersYrot = DataReader["UserYrot"].ToString();
            //Debug.Cleared("UsersYrot " + UsersYrot);
            Clients.SetUsersYrot(UsersYrot);

            String UsersZrot = DataReader["UserZrot"].ToString();
            //Debug.Cleared("UsersZrot " + UsersZrot);
            Clients.SetUsersZrot(UsersZrot);

            String UserGpsX = DataReader["UserGpsX"].ToString();
            //Debug.Cleared("UserGpsX " + UserGpsX);
            Clients.SetUserGpsX(UserGpsX);

            String UserGpsY = DataReader["UserGpsY"].ToString();
            //Debug.Cleared("UserGpsY " + UserGpsY);
            Clients.SetUserGpsY(UserGpsY);

            String UserGpsZ = DataReader["UserGpsZ"].ToString();
            //Debug.Cleared("UserGpsZ " + UserGpsZ);
            Clients.SetUserGpsZ(UserGpsZ);

            String UserFirstTimeLogin = DataReader["UserFirstTimeLogin"].ToString();
            //Debug.Cleared("FirstTimeLogin " + FirstTimeLogin);
            Clients.SetFirstTimeLogin(UserFirstTimeLogin);

            String UserDeviceId = DataReader["UserDeviceId"].ToString();
            //Debug.Cleared("UserDeviceId " + UserDeviceId);
            Clients.SetUserDeviceId(UserDeviceId);

            String UserIpAddress = DataReader["UserIpAddress"].ToString();
            //Debug.Cleared("UserIpAddress " + UserIpAddress);
            Clients.SetUserIpAddress(UserIpAddress);

            String UserActivation = DataReader["UserActivation"].ToString();
            //Debug.Cleared("UserIpAddress " + UserAcctivation);
            Clients.SetUserAcctivation(UserActivation);

           string data = Construct.ID + Id
               + Construct.USERID + UserId
               + Construct.USERNAME + UserName
               + Construct.USERPIC + UserPic
               + Construct.USERFIRSTNAME + UserFirstName
               + Construct.USERLASTNAME + UserLastName
               + Construct.USERACCESSTOKEN + UserAccessToken
               + Construct.USERSTATE + "1"
               + Construct.USERACCESS + UserAccess
               + Construct.USERCREDITS + UserCredits
               + Construct.USERLEVEL + UserLevel
               + Construct.USERMANA + UserMana
               + Construct.USERHEALTH + UserHealth
               + Construct.USEREXP + UserExp
               + Construct.USERXPOS + UsersXpos
               + Construct.USERYPOS + UsersYpos
               + Construct.USERZPOS + UsersZpos
               + Construct.USERXROT + UsersXrot
               + Construct.USERYROT + UsersYrot
               + Construct.USERZROT + UsersZrot
               + Construct.USERGPSX + UserGpsX
               + Construct.USERGPSY + UserGpsY
               + Construct.USERGPSZ + UserGpsZ
               + Construct.USERFIRSTTIMELOGIN + UserFirstTimeLogin
               + Construct.USERDEVICEID + UserDeviceId
               + Construct.USERIPADDRESS + UserIpAddress
               + Construct.USERACTIVATION + UserActivation;
           
            return data;
        }

        private static void AddClientToList()
        {
            Clients.AddPlayers(
                   Clients.GetId(),
Clients.GetUserId(),
Clients.GetUserName(),
Clients.GetUserPic(),
Clients.GetUserFirstName(),
Clients.GetUserLastName(),
Clients.GetUserAccessToken(),
Clients.GetUserState(),
Clients.GetUserAccess(),
Clients.GetUserCredits(),
Clients.GetUserLevel(),
Clients.GetUserMana(),
Clients.GetUserHealth(),
Clients.GetUserExp(),
Clients.GetUsersXpos(),
Clients.GetUsersYpos(),
Clients.GetUsersZpos(),
Clients.GetUsersXrot(),
Clients.GetUsersYrot(),
Clients.GetUsersZrot(),
Clients.GetUserGpsX(),
Clients.GetUserGpsY(),
Clients.GetUserGpsZ(),
Clients.GetFirstTimeLogin(),
Clients.GetUserDeviceId(),
Clients.GetUserIpAddress(),
Clients.GetUserAcctivation()
);
        }

        public static void CheckClientsOnAdsData(Socket ClientSocket, string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ,string ClientUserId, string ClientModType, string ClientState)
        {


            query = "SELECT * FROM clients WHERE UserDeviceId ='" + ClientDeviceId + "' LIMIT 1";
            cmd = new MySqlCommand(query, dbConfig);

            string data = "";

            try
            {

                dbConfig.Open();

                DataReader = cmd.ExecuteReader();
                if (DataReader.Read())
                {

                    //The user is found in the clitns table so we want to update the clients table where users new credits are
                    String UserDeviceId = DataReader["UserDeviceId"].ToString();
                    //Debug.Cleared("UserDeviceId " + UserDeviceId);
                   

                    String UserIpAddress = DataReader["UserIpAddress"].ToString();
                    String UserCredits = DataReader["UserCredits"].ToString();
                    
                    //Debug.Info("The user is found in the clitns table so we want to update the clients table where users new credits are ");

                    if (ClientModType == "1")
                    {
                        //Debug.Info("UPDATING THE CLIENTS MODIFYED CREDITS CLIENT");


                        UpdatingIntoClientsTable(ClientDeviceId, ClientIpAddress, ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId);
                    }
                    else if (ClientModType == "0")
                    {
                        //Debug.Info("UPDATING THE CLIENTS MODIFYED CREDITS SERVER");
                        ClientDeviceId = UserDeviceId;
                        ClientIpAddress = UserIpAddress;
                        ClientCredits = UserCredits;
                    }

                    dbConfig.Close();



                }
                else
                {

                    
                    // else the user is not a full member so we want to check if they are located in the clients temp table to store the new information comming in
                    dbConfig.Close();
                    query = "SELECT * FROM clients_temp WHERE UserDeviceId ='" + ClientDeviceId + "' LIMIT 1";
                    cmd = new MySqlCommand(query, dbConfig);
                    try
                    {

                        dbConfig.Open();
                        DataReader = cmd.ExecuteReader();
                        if (DataReader.Read())
                        {
                            //the client was found so we want to update the credits table for the temp client
                            String UserDeviceId = DataReader["UserDeviceId"].ToString();
                            //Debug.Cleared("UserDeviceId " + UserDeviceId);


                            String UserIpAddress = DataReader["UserIpAddress"].ToString();
                            String UserCredits = DataReader["UserCredits"].ToString();
                            String UserId = DataReader["UserId"].ToString();

                            if(UserId != Construct._USERID)
                            {
                                //Debug.Error("THIS MEMEBR IS ALREADY A FULL MEMBER THEY MUST HAVE LOGGIN WITH SOME OTHER DEVICE");
                                dbConfig.Close();

                                query = "SELECT * FROM clients WHERE UserId ='" + UserId + "' LIMIT 1";
                                cmd = new MySqlCommand(query, dbConfig);
                                try
                                {
                                    dbConfig.Open();
                                    DataReader = cmd.ExecuteReader();
                                    if (DataReader.Read())
                                    {
                                        //Debug.Error("THIS MEMEBR IS ALREADY A FULL MEMBER THEY MUST HAVE LOGGIN WITH SOME OTHER DEVICE GETTING THE NEW DATA");
                                        UserDeviceId = DataReader["UserDeviceId"].ToString();
                                        //Debug.Cleared("UserDeviceId " + UserDeviceId);


                                        UserIpAddress = DataReader["UserIpAddress"].ToString();
                                        UserCredits = DataReader["UserCredits"].ToString();
                                    }
                                }
                                catch (MySqlException Mex)
                                {
                                    //Debug.Error("Database Configeration Error: " + Mex.Message);
                                }

                                dbConfig.Close();
                                
                            }


                            if (ClientModType == "1")
                            {
                                //Debug.Info("UPDATING THE CLIENTS MODIFYED CREDITS CLIENT TEMP");
                                UpdatingIntoClientsTempTable(ClientDeviceId, ClientIpAddress, ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId);
                            }
                            else if (ClientModType == "0")
                            {
                                //Debug.Info("UPDATING THE CLIENTS MODIFYED CREDITS SERVER TEMP");
                                ClientDeviceId = UserDeviceId;
                                ClientIpAddress = UserIpAddress;
                                ClientCredits = UserCredits;
                            }
                            
                            

                           
                            dbConfig.Close();
                        }
                        else
                        {

                            //the client has never been here with any knowen devices that we know of
                            //Debug.Error("INSERTING INTO CLIENTS TEMP : ");

                            InsertingIntoClientsTempTable(ClientDeviceId, ClientIpAddress, ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ);




                            
                            dbConfig.Close();

                        }
                    }
                    catch (MySqlException Mex)
                    {
                        //Debug.Error("Database Configeration Error: " + Mex.Message);
                    }


                }
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Database Configeration Error: " + Mex.Message);
            }
            data = Construct.USERDEVICEID + ClientDeviceId
                        + Construct.USERIPADDRESS + ClientIpAddress
                        + Construct.USERCREDITS + ClientCredits
                        + Construct.USERSTATE + ClientState;
            Program.SendData(ClientSocket, data);
            Program.Disconnected(ClientSocket);
        }

        public static void InsertingIntoClientsTempTable( string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ)
        {

            dbConfig.Close();
            query = string.Format("INSERT INTO clients_temp(UserDeviceId, " +
                "UserIpAddress, " +
                "UserCredits, " +
                "UserGpsX, " +
                "UserGpsY," +
                "UserGpsZ) VALUES ('{0}'," +
                "'{1}'," +
                "'{2}'," +
                "'{3}'," +
                "'{4}'," +
                "'{5}')", ClientDeviceId,
    ClientIpAddress,
    ClientCredits,
    ClientGpsX,
    ClientGpsY,
    ClientGpsZ);
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

            //Debug.Finished("MySqlManager: InsertClientsPreloadedData()");
            dbConfig.Close();
        }

        public static void UpdateClientDevice(string ClientUserId, string ClientAccessToken, string ClientDeviceId, string ClientIpAddress, string ClientGpsX, string ClientGpsY, string ClientGpsZ, string ClientCredits)
        {
            dbConfig.Close();
            query = string.Format("UPDATE clients SET UserAccessToken='{0}',UserGpsX='{1}',UserGpsY='{2}',UserGpsZ='{3}',UserDeviceId='{4}',UserIpAddress='{5}' WHERE UserId = '{6}'", ClientAccessToken, ClientGpsX, ClientGpsY, ClientGpsZ, ClientDeviceId, ClientIpAddress, ClientUserId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                UpdatingIntoClientsTempTable(ClientDeviceId, ClientIpAddress, ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId);
                dbConfig.Close();


            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Exception " + Mex.Message);
            }
            dbConfig.Close();
        }

        public static void UpdatingIntoClientsTable(string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ,string ClientUserId)
        {
            //Debug.Starting("MySqlManager: UpdateClientData()");
            dbConfig.Close();
            query = string.Format("UPDATE clients SET UserCredits='{0}',UserGpsX='{1}',UserGpsY='{2}',UserGpsZ='{3}',UserId='{4}' WHERE UserDeviceId = '{5}'", ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId, ClientDeviceId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();
                UpdatingIntoClientsTempTable(ClientDeviceId, ClientIpAddress, ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId);

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientData()");
        }

        public static void UpdatingIntoClientsTempTable(string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ, string ClientUserId)
        {
            //Debug.Starting("MySqlManager: UpdateClientData()");
            dbConfig.Close();
            query = string.Format("UPDATE clients_temp SET UserCredits='{0}',UserGpsX='{1}',UserGpsY='{2}',UserGpsZ='{3}',UserId='{4}' WHERE UserDeviceId = '{5}'", ClientCredits, ClientGpsX, ClientGpsY, ClientGpsZ, ClientUserId, ClientDeviceId);
            cmd = new MySqlCommand(query, dbConfig);
            try
            {
                dbConfig.Open();
                cmd.ExecuteNonQuery();
                dbConfig.Close();
                

            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Mysql Update Client Exception " + Mex.Message);
            }
            dbConfig.Close();
            //Debug.Finished("MySqlManager: UpdateClientData()");
        }

        public static void CheckClientsOnAwakeData(Socket ClientSocket, string ClientDeviceId, string ClientIpAddress, string ClientCredits, string ClientGpsX, string ClientGpsY, string ClientGpsZ)
        {


            query = "SELECT * FROM clients WHERE UserDeviceId ='" + ClientDeviceId + "' LIMIT 1";
            cmd = new MySqlCommand(query, dbConfig);

            string data = "";

            try
            {

                dbConfig.Open();

                DataReader = cmd.ExecuteReader();
                if (DataReader.Read())
                {

                  data = MyClientsTableDatatReader(DataReader);
                    //AddClientToList();
                    dbConfig.Close();
                }
                else
                {
                    dbConfig.Close();
                    query = "SELECT * FROM clients_temp WHERE UserDeviceId ='" + ClientDeviceId + "' LIMIT 1";
                    cmd = new MySqlCommand(query, dbConfig);
                    try
                    {

                        dbConfig.Open();
                        DataReader = cmd.ExecuteReader();
                        if (DataReader.Read())
                        {
                            //the client is a temp meber we do not have all the data but we have enough to know them from there device so we can send back the info we stored
                            String Id = DataReader["Id"].ToString();
                            //Debug.Cleared("Id " + Id);
                            ClientCredits = DataReader["UserCredits"].ToString();
                            //Debug.Cleared("ClientCredits " + ClientCredits);
                            data = Construct.USERDEVICEID + ClientDeviceId
                         + Construct.USERIPADDRESS + ClientIpAddress
                         + Construct.USERCREDITS + ClientCredits;
                            dbConfig.Close();
                        }
                        else
                        {

                            //the client has never been here with any knowen devices that we know of
                            //Debug.Error("INSERTING INTO CLIENTS TEMP : ");

                            InsertingIntoClientsTempTable( ClientDeviceId,  ClientIpAddress,  ClientCredits,  ClientGpsX, ClientGpsY, ClientGpsZ);

                            

                           
                             data = Construct.USERDEVICEID + ClientDeviceId
                         + Construct.USERIPADDRESS + ClientIpAddress
                         + Construct.USERCREDITS + ClientCredits;
                            dbConfig.Close();

                        }
                    }
                    catch (MySqlException Mex)
                    {
                        //Debug.Error("Database Configeration Error: " + Mex.Message);
                    }

                    
                }
            }
            catch (MySqlException Mex)
            {
                //Debug.Error("Database Configeration Error: " + Mex.Message);
            }
            
            Program.SendData(ClientSocket, data);
            Program.Disconnected(ClientSocket);
        }



        

        /*public static void LoadAllMessage()
        {
            //Debug.Starting("MySqlManager: LoadAllMessage()");
            List<MySqlManager> Messages = MySqlManager.GetMessage();

            foreach (MySqlManager Mess in Messages)
            {

                Debug.Cleared(
                    "ID: " + Mess.Id.ToString() +
                    " FromUserID: " + Mess.FromUserId.ToString() +
                    " ToUserID: " + Mess.ToUserId.ToString() +
                    " Message: " + Mess.Message.ToString() +
                    " Recieved: " + Mess.received.ToString());

        }
        Debug.Finished("MySqlManager: LoadAllMessage()");
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
         }*/


    }
}
