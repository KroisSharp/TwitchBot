using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;
using TwitchLib.Models.API.v5.Users;

namespace TwitchBot
{
    class Client
    {
        private readonly ConnectionCredentials credentials = new ConnectionCredentials(TwitchRescoure.BotUserName, TwitchRescoure.BotToken);
        private TwitchClient Twitchclient;

        public void Start()
        {
            Twitchclient = new TwitchClient(credentials, TwitchRescoure.ChannelName, logging: false);


            Console.WriteLine("Connting");
            Twitchclient.Connect();
            Console.WriteLine("connected");



            Twitchclient.OnMessageReceived += BotClient_OnMessageReceived;



        }



        private void BotClient_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            string Message = e.ChatMessage.Message.ToLower();
            switch (Message)
            {
                case "!hi":
                    HelloUserName(sender, e);
                    break;

                default:
                    IdidNotUnderStand(e);
                    break;

            }
            HelloUserName(sender, e);

        }



        #region Chat commands

        private void HelloUserName(object sender, OnMessageReceivedArgs e)
        {
            Twitchclient.SendMessage($"Hello {e.ChatMessage.DisplayName}");
        }

        private void IdidNotUnderStand(OnMessageReceivedArgs x)
        {
            Twitchclient.Disconnect();
        }



        #endregion


    }
}
