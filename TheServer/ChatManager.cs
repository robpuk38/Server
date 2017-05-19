using System;
using System.Collections.Generic;
using System.Net.Sockets;


namespace TheServer
{

   

   public class ChatManager
    {
        ChatManager chatManager;
        public static List<ChatManager> Messages = new List<ChatManager>();
        public String FromUserId { get; internal set; }
        public String Message { get; internal set; }
        public String ToUserId { get; internal set; }
        public String FromUserPic { get; internal set; }
        public String FromUserName { get; internal set; }
        public ChatManager(string _FromUserId,string _Message,string _ToUserId,string _FromUserPic, string _FromUserName)
        {
           FromUserId = _FromUserId;
            Message = _Message;
            ToUserId = _ToUserId;
            FromUserPic = _FromUserPic;
            FromUserName = _FromUserName;

        }

        private ChatManager()
        {
            chatManager = new ChatManager(FromUserId, Message, ToUserId, FromUserPic, FromUserName);
        }
        public static ChatManager Instance
        {
            get { return instance; }
        }

        private static ChatManager instance = new ChatManager();


        public static string GetChatFromUserId()
        {

            return instance.FromUserId;
        }

        public static void SetChatFromUserId(string set)
        {

            instance.FromUserId = set;
        }



        public static string GetChatMessage()
        {

            return instance.Message;
        }

        public static void SetChatMessage(string set)
        {

            instance.Message = set;
        }


        public static string GetChatToUserId()
        {

            return instance.ToUserId;
        }

        public static void SetChatToUserId(string set)
        {

            instance.ToUserId = set;
        }



        public static string GetChatFromUserPic()
        {

            return instance.FromUserPic;
        }

        public static void SetChatFromUserPic(string set)
        {

            instance.FromUserPic = set;
        }


        public static string GetChatFromUserName()
        {

            return instance.FromUserName;
        }

        public static void SetChatFromUserName(string set)
        {

            instance.FromUserName = set;
        }

        public static void AddMessage(Socket ClientSocket ,string _FromUserId, string _Message, string _ToUserId, string _FromUserPic, string _FromUserName)
        {
            ChatManager chatManager = new ChatManager(_FromUserId, _Message, _ToUserId, _FromUserPic, _FromUserName);
            Messages.Add(chatManager);

           string data = Construct.FROMUSERID + _FromUserId
                      + Construct.THEMESSAGE + _Message
                      + Construct.TOUSERID + _ToUserId
                      + Construct.FROMUSERPIC + _FromUserPic
                      + Construct.FROMUSERNAME + _FromUserName;

            Program.SendBroadcastData(ClientSocket,data);

            

        }

        

    }
}
