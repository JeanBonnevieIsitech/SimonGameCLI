using System;
using DiscordRPC;

namespace SimonGameCLI
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
                    LargeImageText = "SimonGame CLI by Jeanbon#8492"
                }
            };

            client = new DiscordRpcClient(applicationId);
            //Connect to the RPC
            client.Initialize();
        }


        public void update()
        {
            client.SetPresence(gameState);
        }

        public void disconnect()
        {
            client.Dispose();
        }
    }
}
