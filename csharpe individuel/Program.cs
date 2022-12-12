using System;
using System.Collections.Generic;
using System.Threading;
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

            // MAIN

            var random = new Random();
            var score = 0;


            message("Bienvenue dans le simon console !");
            message("Mémorisez l'ordre des lettres qui vont s'afficher");

            char[] colorChar = { 'W', 'X', 'C', 'V' };
            List<char> levelCharList = new List<char>();
            List<char> playerCharList = new List<char>();

            while (true)
            {
                levelCharList.Add(colorChar[random.Next(colorChar.Length)]);
                afficherLevel();
                Console.WriteLine("C'est à vous :");
                for (int n = 0; n < levelCharList.Count; n++)
                {
                    char i = char.ToUpper(Console.ReadKey().KeyChar);
                    if (i != levelCharList[n])
                    {
                        Console.Clear();
                        message($"Perdu !\nTon score est de : {score}");
                        Environment.Exit(0);
                    }

                }
                score++;

            }
            // FUNCTIONS

            void message(string msg)
            {
                Console.WriteLine(msg + "\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
                Console.Clear();
            }

            void afficherLevel()
            {
                Console.Clear();
                for (int i=0; i<levelCharList.Count;i++)
                {
                    Console.Write(" " + levelCharList[i]);
                    if (i!=levelCharList.Count-1)
                    {
                        Thread.Sleep(1000);
                    }

                }
                Thread.Sleep(2000);
                Console.Clear();
            }


        }
    }
}
