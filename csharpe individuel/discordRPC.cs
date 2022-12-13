using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace csharpe_individuel
{
    internal class discordRPC
    {
        private DiscordRpcClient client;
        private String applicationId;
        public RichPresence gameState;
        
        //  Constructor
        public discordRPC() 
        {
            applicationId = "1052148422662172745";
            gameState = new RichPresence()
            {

                Assets = new Assets()
                {
                    LargeImageKey = "game",
                    LargeImageText = "SimonGame CLI"
                }
            };

            initialize();

        }
        private void initialize()
        {
            /*
Create a Discord client
NOTE: 	If you are using Unity3D, you must use the full constructor and define
         the pipe connection.
*/
            client = new DiscordRpcClient(applicationId);

            //Set the logger
            //client.Logger = new ConsoleLogger() { Level = LogLevel.None };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                //Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                //Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                //Details = "Example Project",
                //State = "csharp example",

            });
        }

        public void update()
        {
            client.SetPresence(gameState);
        }
    }
}
