using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharpe_individuel
{
    internal class SimonGame
    {
        private Random random = new Random();
        private int score;
        private int delay;
        private string savePath;
        private string saveFilename;

        private char[] arrowArray;
        private Dictionary<char, ConsoleKey> ArrowDict;

        //  List of char to memorize for each round
        private List<char> levelCharList = new List<char>();

        // constructeur
        public SimonGame()
        {
            // Games variable intialisation
            score = 0;
            delay = 2000;
            arrowArray = new char[] { '→', '←', '↑', '↓' };

            //  Makes the correspondence between the characters of arrows and the name of the key
            ArrowDict = new Dictionary<char, ConsoleKey>();
            ArrowDict.Add('→', ConsoleKey.RightArrow);
            ArrowDict.Add('←', ConsoleKey.LeftArrow);
            ArrowDict.Add('↑', ConsoleKey.UpArrow);
            ArrowDict.Add('↓', ConsoleKey.DownArrow);

            // Other variables
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\SimonGame";
            //savePath = "data";
            saveFilename = "save.json"; 
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
                    Thread.Sleep(delay / 2);
                }

            }
            Thread.Sleep(delay);
            Console.Clear();
        }

        void iniSaveFile()
        {
            Directory.CreateDirectory(@savePath);
            if (!File.Exists(@savePath))
            {
                Dictionary<string, int> scoreDict = new Dictionary<string, int>();
                scoreDict["highscore"] = -1;
                File.Create($"{savePath}\\{saveFilename}").Close();
                File.WriteAllText($"{ savePath}\\{saveFilename}", JsonConvert.SerializeObject(scoreDict));
            }
        }

        void saveScoreTofile(int score)
        {

            var scoreDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText($"{savePath}\\{saveFilename}"));
            if (score > scoreDict["highscore"])
            {
                scoreDict["highscore"] = score;
                message("Et c'est un nouveau record !");

            }

            File.WriteAllText($"{savePath}\\{saveFilename}", JsonConvert.SerializeObject(scoreDict));
        }



        public void run()
        {
            // MAIN

            iniSaveFile();

            message("Bienvenue dans le simon console !");
            // afficher meilleur score si y'a
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
                        saveScoreTofile(score);
                        Environment.Exit(0);
                    }
                    Console.Write(" " + levelCharList[n]);

                }
                score++;
                Thread.Sleep(delay / 2);

            }

        }
    }
}
