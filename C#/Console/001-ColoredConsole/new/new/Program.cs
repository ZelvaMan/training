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
            Models.Date date = ParseTheDate();
            
            
            int CurDay = date.Day;

            int curMonth = date.Month;

            int curYear = date.Year - 5;

            bool leap_year = (curYear % 4) == 0 ? true : false;
            int DayOfMonth = GetNumberOfDays(date.Year, leap_year);
            ConsoleColor color = GetSeason(date.Day, date.Month);
            while (true)
            {
                
                
                

                Console.ForegroundColor = color;
                Console.WriteLine($"{CurDay} {curMonth} {curYear}");

                CurDay++;

                if (CurDay >= DayOfMonth + 1)
                {
                    DayOfMonth = GetNumberOfDays(curMonth, leap_year);
                    CurDay = 1;
                    curMonth++;
                }

                //konec roku
                if (curMonth >= 12 && CurDay >= DayOfMonth)
                {
                    curMonth = 1;
                    curYear++;
                    CurDay = 1;
                    leap_year = (date.Year % 4) == 0 ? true : false;
                    if (leap_year)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //jaro
                if (CurDay == 20 && curMonth == 3)
                    color = ConsoleColor.Green;

                //leto
                if (CurDay == 21 && curMonth == 6)
                    color = ConsoleColor.Red;

                //podzim
                if (CurDay == 23 && curMonth == 9)
                    color = ConsoleColor.Magenta;

                //zima
                if (CurDay == 21 && curMonth == 12)
                    color = ConsoleColor.Blue;

                
                if(curYear >= date.Year + 5 && curMonth == date.Month && CurDay == date.Day)
                {
                    Console.WriteLine($"{CurDay} {curMonth} {curYear}");
                    break;
                }
            }
            Console.ReadKey();
        }

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
        /// 
        /// </summary>
        /// <param name="text"> if null everythink is OK</param>
        /// <returns></returns>
        public static Models.Date ParseTheDate()
        {
            // 1950 - 2050 rok
            while (true)
            {
                string text = Console.ReadLine();
                int _year, _month, _day;
                List<string> validationMesseges = new List<string>();
                string[] spl = text.Split(' ');
                if (int.TryParse(spl[0], out _day) && int.TryParse(spl[1], out _month) && int.TryParse(spl[2], out _year))

                    


                            
                            return new Models.Date(_year, _month, _day);
                       

            }
            
        }
        public static ConsoleColor GetSeason(int day, int month)
        {
            //winter 
            if (month == 1 && month == 2 &&
                (month == 12 && day > 22) && 
                (month == 3 && day <= 20))
                return ConsoleColor.Blue;
            //spring 
            if (month == 4 && month == 5 &&
                (month == 3 && day >= 22 ) && 
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
