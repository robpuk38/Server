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

                Debug.Starting("Initiating MySql Database:");
                Debug.Cleared("Server: " + SERVER);
                Debug.Cleared("Database: " + DATABASE);
                Debug.Cleared("UserId: " + USERID);
                Debug.Cleared("Password: " + PASSWORD);
                Debug.Finished("MySql Database Connection Compleate:");


                dbConfig = new MySqlConnection(Connection);
            }
            catch (MySqlException Mex)
            {
                Debug.Error("Database Configeration Error: " + Mex.Message);
            }






        }

        public static void LoadPlayersData(Socket ClientSocket,string _UserId, string _AccessToken, string _LoginStatus)
        {

            if (_LoginStatus == "0")
            {

                // We only want to prep the database and store the information in memory for when they do log back in.
                // so if loginstatus is 1 do nothing but the system is still in here trying to access something
                Debug.Starting("MySqlManager: LoadPlayersData()");
                String query = "SELECT * FROM clients WHERE UserId ='" + _UserId + "' AND UserAccessToken ='" + _AccessToken + "' LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, dbConfig);



                try
                {

                    dbConfig.Open();

                    MySqlDataReader DataReader = cmd.ExecuteReader();


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
                        Debug.Cleared("Id " + Id);

                        String UserId = DataReader["UserId"].ToString();
                        Debug.Cleared("UserId " + UserId);

                        String UserName = DataReader["UserName"].ToString();
                        Debug.Cleared("UserName " + UserName);

                        String UserPic = DataReader["UserPic"].ToString();
                        Debug.Cleared("UserPic " + UserPic);

                        String UserFirstName = DataReader["UserFirstName"].ToString();
                        Debug.Cleared("UserFirstName " + UserFirstName);

                        String UserLastName = DataReader["UserLastName"].ToString();
                        Debug.Cleared("UserLastName " + UserLastName);

                        String UserAccessToken = DataReader["UserAccessToken"].ToString();
                        Debug.Cleared("UserAccessToken " + UserAccessToken);

                        String UserState = DataReader["UserState"].ToString();
                        Debug.Cleared("UserState " + UserState);

                        String UserAccess = DataReader["UserAccess"].ToString();
                        Debug.Cleared("UserAccess " + UserAccess);

                        String UserCredits = DataReader["UserCredits"].ToString();
                        Debug.Cleared("UserCredits " + UserCredits);

                        String UserLevel = DataReader["UserLevel"].ToString();
                        Debug.Cleared("UserLevel " + UserLevel);

                        String UserMana = DataReader["UserMana"].ToString();
                        Debug.Cleared("UserMana " + UserMana);

                        String UserHealth = DataReader["UserHealth"].ToString();
                        Debug.Cleared("UserHealth " + UserHealth);

                        String UserExp = DataReader["UserExp"].ToString();
                        Debug.Cleared("UserExp " + UserExp);

                        String UsersXpos = DataReader["UsersXpos"].ToString();
                        Debug.Cleared("UsersXpos " + UsersXpos);

                        String UsersYpos = DataReader["UsersYpos"].ToString();
                        Debug.Cleared("UsersYpos " + UsersYpos);

                        String UsersZpos = DataReader["UsersZpos"].ToString();
                        Debug.Cleared("UsersZpos " + UsersZpos);

                        String UsersXrot = DataReader["UsersXrot"].ToString();
                        Debug.Cleared("UsersXrot " + UsersXrot);

                        String UsersYrot = DataReader["UsersYrot"].ToString();
                        Debug.Cleared("UsersYrot " + UsersYrot);

                        String UsersZrot = DataReader["UsersZrot"].ToString();
                        Debug.Cleared("UsersZrot " + UsersZrot);

                        String UserGpsX = DataReader["UserGpsX"].ToString();
                        Debug.Cleared("UserGpsX " + UserGpsX);

                        String UserGpsY = DataReader["UserGpsY"].ToString();
                        Debug.Cleared("UserGpsY " + UserGpsY);

                        String UserGpsZ = DataReader["UserGpsZ"].ToString();
                        Debug.Cleared("UserGpsZ " + UserGpsZ);

                        String FirstTimeLogin = DataReader["FirstTimeLogin"].ToString();
                        Debug.Cleared("FirstTimeLogin " + FirstTimeLogin);
                        string data = "|ID|"+ Id 
                            + "|USERID|" + UserId
                            + "|USERNAME|" + UserName
                            + "|USERPIC|" + UserPic
                            + "|USERFIRSTNAME|" + UserFirstName
                            + "|USERLASTNAME|" + UserLastName
                            + "|USERACCESSTOKEN|" + UserAccessToken
                            + "|USERSTATE|" + UserState
                            + "|USERACCESS|" + UserAccess
                            + "|USERCREDITS|" + UserCredits
                            + "|USERLEVEL|" + UserLevel
                            + "|USERMANA|" + UserMana
                            + "|USERHEALTH|" + UserHealth
                            + "|USEREXP|" + UserExp
                            + "|USERXPOS|" + UsersXpos
                            + "|USERYPOS|" + UsersYpos
                            + "|USERZPOS|" + UsersZpos
                            + "|USERXROT|" + UsersXrot
                            + "|USERYROT|" + UsersYrot
                            + "|USERZROT|" + UsersZrot
                            + "|USERGPSX|" + UserGpsX
                            + "|USERGPSY|" + UserGpsY
                            + "|USERGPSZ|" + UserGpsZ
                            + "|USERFIRSTTIMELOGIN|" + FirstTimeLogin;
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
    FirstTimeLogin
 );

                        Program.SendData(ClientSocket, data);

                    }
                    else
                    {
                        Debug.Error("No USER COULD BE FOUND");
                    }

                    dbConfig.Close();
                }
                catch (MySqlException Mex)
                {
                    Debug.Error("Database Configeration Error: " + Mex.Message);
                }
               

                Debug.Finished("MySqlManager: LoadPlayersData()");
            }






        }


        public static void LoadAllMessage()
        {
            Debug.Starting("MySqlManager: LoadAllMessage()");
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
            Debug.Starting("MySqlManager: GetMessage()");
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
                Debug.Error("Database Configeration Error: " + Mex.Message);
            }

            Debug.Finished("MySqlManager: GetMessage()");

            return Messages;
        }


    }
}
