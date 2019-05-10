using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GuessTheNumber.Models;

namespace GuessTheNumber
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game(LoadFromConfig());
            game.Play();
            Console.ReadKey();
        }

        //get min and max values from app.config
        private static MinMaxStructure LoadFromConfig()
        {
            int minValue = int.Parse(ConfigurationManager.AppSettings["MinValue"]);
            int maxValue = int.Parse(ConfigurationManager.AppSettings["MaxValue"]);
            return new MinMaxStructure { Min = minValue, Max = maxValue };
        }
    }
}
