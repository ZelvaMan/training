using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace @new
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Konecne funkcni";
            Console.WriteLine("Zadejte datum ve formatu dd mm rrrrr s mezerami mezi jednotlivymi cisly");
            Models.Date date = Models.Date.ParseTheDate();

            Models.Date curentDate = new Models.Date(date.Year - 5, date.Month, date.Day);
            bool leap_year = curentDate.Leap_year();
            int DayOfMonth = GetNumberOfDays(curentDate.Year, leap_year);
            ConsoleColor color = GetSeason(date.Day, date.Month);
            while (true)
            {




                Console.ForegroundColor = color;
                Console.WriteLine(curentDate.ToString());

                curentDate.Day++;

                if (curentDate.Day >= DayOfMonth + 1)
                {
                    DayOfMonth = GetNumberOfDays(curentDate.Month, leap_year);
                    curentDate.Day = 1;
                    curentDate.Month++;
                }

                //konec roku
                if (curentDate.Month >= 12 && curentDate.Day >= DayOfMonth)
                {
                    curentDate.Month = 1;
                    curentDate.Year++;
                    curentDate.Day = 1;
                    leap_year = curentDate.Leap_year();
                    if (leap_year) 
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //jaro
                if (curentDate.Day == 20 && curentDate.Month == 3)
                    color = ConsoleColor.Green;

                //leto
                if (curentDate.Day == 21 && curentDate.Month == 6)
                    color = ConsoleColor.Red;

                //podzim
                if (curentDate.Day == 23 && curentDate.Month == 9)
                    color = ConsoleColor.Magenta;

                //zima
                if (curentDate.Day == 21 && curentDate.Month == 12)
                    color = ConsoleColor.Blue;


                if (curentDate.Year >= date.Year + 5 && curentDate.Month == date.Month && curentDate.Day == date.Day)
                {
                    Console.WriteLine(curentDate.ToString());
                    break;
                }
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="leapYear"></param>
        /// <returns></returns>
        public static int GetNumberOfDays(int month, bool leapYear)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:

                    return 31;
                    break;
                case 2:
                    return leapYear ? 29 : 28;
                    break;

            }
            return 30;
        }

        
        /// <summary>
        /// Vrati rocni obdobi na zaklade data
        /// </summary>
        /// <param name="day">den </param>
        /// <param name="month">mesic </param>
        /// <returns> barvu zastupujici rocni obdobi</returns>
        public static ConsoleColor GetSeason(int day, int month)
        {
            //winter 
            if (month == 1 && month == 2 &&
                (month == 12 && day > 22) &&
                (month == 3 && day <= 20))
                return ConsoleColor.Blue;
            //spring 
            if (month == 4 && month == 5 &&
                (month == 3 && day >= 22) &&
                (month == 6 && day < 21))
                return ConsoleColor.Green;
            //summer 
            if (month == 7 && month == 8 &&
                (month == 6 && day >= 21) &&
                (month == 9 && day < 23))
                return ConsoleColor.Red;
            //fall
            return ConsoleColor.Magenta;
        }
    }
}
