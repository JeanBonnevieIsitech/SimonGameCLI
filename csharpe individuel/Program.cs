using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace csharpe_individuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetCurrentFont("Consolas", 32);
            Console.Clear();

            SimonGame game = new SimonGame();
            game.run();

        }
    }
}
