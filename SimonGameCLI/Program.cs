using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DiscordRPC;

namespace SimonGameCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetCurrentFont("Consolas", 32);
            ConsoleHelper.Maximize();
            Console.Clear();

            discordRPC discord = new discordRPC();
            discord.gameState.State = "Dans les menus";
            discord.update();

            while (true)
            {
                Console.Clear() ;
                Console.WriteLine("bienvenue dans SimonGame CLI\n1 - Lancer SimonGame\n\n2 - Paramètres\n\n3 - Quitter : ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            SimonGame game = new SimonGame(discord);
                            game.run();
                            break;

                        case 2:
                            break;

                        case 3:
                            Console.WriteLine("à bientôt !");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                }
                catch
                {
                    continue;
                }

            }
        }
    }
}
