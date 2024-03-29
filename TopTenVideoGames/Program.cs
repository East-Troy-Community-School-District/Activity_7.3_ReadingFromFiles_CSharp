﻿/*
 * TopTenVideoGames
 * Pawelski
 * 11/14/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * First, run the program. What does it do? What does the program do first? 
 * What does the program do last? This pattern is very common in software. Why?
 * Why does the program store the list of videogames in an array? What is the
 * benefit of doing this? Are there any possible issues?
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenVideoGames
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILE_PATH = @"TopTenVideoGames.txt";

            FileStream file = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string[] topTenVideoGames = new string[10];
            for(int i = 0; i < topTenVideoGames.Length; i++)
            {
                topTenVideoGames[i] = reader.ReadLine();
            }
            reader.Close();
            file.Close();

            while(true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(1) Display the list of top ten video games.");
                Console.WriteLine("(2) Replace a game in the list.");
                Console.WriteLine("(3) Exit the program.");
                Console.Write("Enter choice >> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                
                if(choice == 1)
                {
                    foreach(string game in topTenVideoGames)
                    {
                        Console.WriteLine(game);
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter index of game to replace (1-10) >> ");
                    int index = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Enter replacement game >> ");
                    string game = Console.ReadLine();
                    topTenVideoGames[index] = game;
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
                Console.WriteLine();
            }

            file = new FileStream(FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            for (int i = 0; i < topTenVideoGames.Length; i++)
            {
                writer.WriteLine(topTenVideoGames[i]);
            }
            writer.Close();
            file.Close();
        }
    }
}
