using System;
using System.Collections.Generic;
using Playground.String;
using Playground.Sudoku;
namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Sudoku.Sudoku game = new Sudoku.Sudoku();
            game.PrintBoard();
            Console.WriteLine("--------------");
            if (game.SolveSudoku())
            {
                game.PrintBoard();
            }
            Console.WriteLine("----------------");
            */


      


            string text = "ABBA";
            string pattern = "BA";

            KMPAlgo stringSearch = new KMPAlgo();
            Console.WriteLine("KMP algorithm-------------------");
            Console.WriteLine(stringSearch.PatternMatch(text, pattern));
            Console.WriteLine("-------------------");

            Console.WriteLine("Rabin Karp algorithm-------------------");
            RabinKarp rabinAlgo = new RabinKarp();
            Console.WriteLine(rabinAlgo.PatternSearch(text, pattern));
            Console.WriteLine("-------------------");

            Console.Read();
        }
    }
}
