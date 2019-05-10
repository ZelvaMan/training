using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models
{
    class Guess
    {
        /// <summary>
        /// how much bigger, smaller number is 
        /// </summary>
        public enum GuessSucess
        {
            /// <summary>
            /// the difference is less than  20
            /// </summary>
            litleBitMore,
            /// <summary>
            /// the difference is less than  20
            /// </summary>
            littleBitLess,
            /// <summary>
            /// the diferent is less than 40
            /// </summary>
            FarMore,
            /// <summary>
            /// the diferent is less that 40
            /// </summary>
            FarLess,
            /// <summary>
            /// the diferent is bigger that 40
            /// </summary>
            NotInRange,
            /// <summary>
            /// the numbers match
            /// </summary>
            Match
        }
        /// <summary>
        /// based on diferent between numbers returns GuessSucess
        /// </summary>
        /// <param name="value">number that user quess</param>
        /// <returns></returns>
        public static GuessSucess Range(int value, int randomNumber)
        {
            //diferenc betveen value and random number in absolut value
            int diference = Math.Abs(randomNumber - value);

            if (diference < 20)
                return value > randomNumber ? GuessSucess.littleBitLess : GuessSucess.litleBitMore;

            if (diference < 40)
                return value > randomNumber ? GuessSucess.FarLess : GuessSucess.FarMore;

            if ( value == randomNumber)
                return GuessSucess.Match;
            return GuessSucess.NotInRange;
        }

    }
}
