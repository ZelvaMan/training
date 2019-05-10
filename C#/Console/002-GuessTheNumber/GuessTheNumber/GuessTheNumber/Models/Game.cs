using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models
{
    public class Game
    {
        private Generator generator;

        public Game(MinMaxStructure minMax)
        {
            generator = new Generator(minMax);
        }

        public void Play()
        {
            generator.GenerateNumber();
            // Console.WriteLine("Myslim si cislo a vasim ukolem je to uhadnout.");
            // Console.WriteLine($"Vy zadate cislo v rozsahu od {generator.MinMax.Min} do {generator.MinMax.Max} ");
            Console.WriteLine($"I think number from {generator.MinMax.Min} to {generator.MinMax.Max} try to guess it");
            int tries = 0;
            while (true)
            {
                //increse tries
                tries++;
                //parse number from console
                int UserNumber = Parse();
                Models.Guess.GuessSucess range = Models.Guess.Range(UserNumber, generator.RandomNumber);
                if(UserNumber == generator.RandomNumber)
                {
                    //congratulate you 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"CONGRATULATION you guess it, It was number {generator.RandomNumber}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("you only need: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(tries.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("tries");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    //dont gues it, wrote if was that number hier, or smaler
                    Console.Write("Number, that i think is ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(range.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
               
            }
        }
        /// <summary>
        /// parse the number from console
        /// </summary>
        /// <returns></returns>
        public int Parse()
        {
            while (true)
            {
                int UserNumber = 0;
                //try to pard
                if (int.TryParse(Console.ReadLine(), out UserNumber))
                {
                    //number must be in range
                    if(UserNumber >= generator.MinMax.Min &&  generator.MinMax.Max  >= UserNumber )
                        //sucesfully parsed
                        return UserNumber;
                    Console.WriteLine("numbers have to be in range");
                }
                else
                    //parse fail ask user to do it again
                    Console.WriteLine("Please assign the NUMBER from {generator.MinMax.Min} to {generator.MinMax.Max} ");
            }
        }

    }
}
