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

            Console.Title = "Colored date";
            Console.WriteLine("Zadejte datum ve formatu dd mm rrrrr s mezerami mezi jednotlivymi cisly");
            Models.Date date = new Models.Date();
            date.ParseTheDate();

            //presetproperties
            Models.Date curentDate = new Models.Date(date.Year - 5, date.Month, date.Day);
            bool leap_year = curentDate.LeapYear;
            int DayOfMonth = curentDate.GetNumberOfDays(leap_year);
            ConsoleColor color = curentDate.GetSeason();
            //ciclus, write all dates form 5 years before to 5 years after the dates
            while (true)
            {



                //set color to color of seasn
                Console.ForegroundColor = color;
                //write a a date
                Console.WriteLine(curentDate.ToString());

                curentDate.Day++;

                //end of the month
                if (curentDate.Day >= DayOfMonth + 1)
                {
                   // generate day of month , because month changed
                    DayOfMonth = curentDate.GetNumberOfDays(leap_year);
                    curentDate.Day = 1;
                    curentDate.Month++;
                }

                //end of the year
                if (curentDate.Month >= 12 && curentDate.Day >= DayOfMonth)
                {

                    curentDate.Month = 1;
                    curentDate.Year++;
                    curentDate.Day = 1;
                    leap_year = curentDate.LeapYear;
                    //if leap year write yelow  line
                    if (leap_year)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ForegroundColor = color;
                    }
                }

                //season change to spring
                if (curentDate.Day == 20 && curentDate.Month == 3)
                    color = ConsoleColor.Green;

                //season change to summer
                if (curentDate.Day == 21 && curentDate.Month == 6)
                    color = ConsoleColor.Red;

                //season change to fall
                if (curentDate.Day == 23 && curentDate.Month == 9)
                    color = ConsoleColor.Magenta;

                //season change to winter
                if (curentDate.Day == 21 && curentDate.Month == 12)
                    color = ConsoleColor.Blue;

                //end of ciclus
                if (curentDate.Year >= date.Year + 5 && curentDate.Month == date.Month && curentDate.Day == date.Day)
                {
                    Console.WriteLine(curentDate.ToString());
                    break;
                }
            }
            Console.ReadKey();
        }




    }
}
