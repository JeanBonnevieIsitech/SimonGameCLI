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

            Random random = new Random();
            int score = 0;

            char[] arrowArray = { '→', '←', '↑', '↓' };

            //  Makes the correspondence between the characters of arrows and the name of the key
            Dictionary<char, ConsoleKey> ArrowDict = new Dictionary<char, ConsoleKey>();
            ArrowDict.Add('→', ConsoleKey.RightArrow);
            ArrowDict.Add('←', ConsoleKey.LeftArrow);
            ArrowDict.Add('↑', ConsoleKey.UpArrow);
            ArrowDict.Add('↓', ConsoleKey.DownArrow);


            //  List of char to memorize for each round
            List<char> levelCharList = new List<char>();

            message("Bienvenue dans le simon console !");
            message("Mémorisez l'ordre des lettres qui vont s'afficher");

            while (true)
            {
                levelCharList.Add(arrowArray[random.Next(arrowArray.Length)]);
                afficherLevel();
                Console.WriteLine("C'est à vous :");
                for (int n = 0; n < levelCharList.Count; n++)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    if (ArrowDict[levelCharList[n]] != key)
                    {
                        Console.Clear();
                        message($"Perdu !\nTon score est de : {score}");

                        Environment.Exit(0);
                    }
                    Console.Write(" " + levelCharList[n]);

                }
                score++;
                Thread.Sleep(500);

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
                for (int i = 0; i < levelCharList.Count; i++)
                {
                    Console.Write(" " + levelCharList[i]);
                    if (i != levelCharList.Count - 1)
                    {
                        Thread.Sleep(1000);
                    }

                }
                Thread.Sleep(2000);
                Console.Clear();
            }


           /* void saveToile()
            {
                var json = JsonConvert.SerializeObject            
            }*/

        }
    }
}
