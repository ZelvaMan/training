using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @new.Models
{
    class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Date(int year, int month, int day )
        {
            Year = year;
            Month = month;
            Day = day;

        }

        public bool Leap_year()
        {
            return (Year % 4) == 0;
        }

        /// <summary>
        /// Parsuje datum z konzole ve formatu DD MM YYYY
        /// </summary>
        /// <returns> datum s rokem , mesicem a dnem</returns>
        public static Models.Date ParseTheDate()
        {
            // 1950 - 2050 rok
            while (true)
            {
                string text = Console.ReadLine();
                int _year = 0, _month = 0, _day = 0;
                List<string> validationMesseges = new List<string>();
                validationMesseges.Clear();
                string[] spl = text.Split(' ');
                if (int.TryParse(spl[0], out _day) && int.TryParse(spl[1], out _month) && int.TryParse(spl[2], out _year))
                {
                    if (_month < 0 || _month > 13)
                        validationMesseges.Add("Neplatny mesic, mesicu muze byt jen 12");
                    if (_day < 0 || _day > Program.GetNumberOfDays(_month, (_year % 4) == 0))
                        validationMesseges.Add($"Nelatny pocet dnu, v tomto mesici je jen {Program.GetNumberOfDays(_month, (_year % 4) == 0)} dnu");
                    if (_year < 1950 || _year > 2050)
                        validationMesseges.Add("Neplatny rok, roky muzou byt jen v rozpeti 1950 az 2050");

                }
                else validationMesseges.Add("nevalidni datum ");
                //pokud se nanaskitla zadna chyba
                if (validationMesseges.Count == 0)
                    return new Models.Date(_year, _month, _day);
                //pokud se chybz naskytli vypise
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pri validaci data nastaly nasledujici chyby");
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (string s in validationMesseges)
                {

                    Console.WriteLine(s);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("zadejte prosim znovu datum ve formatu DD MM YYYY ");






            }

        }

        public override string ToString()
        {
            return $"{Day.ToString()} {Month.ToString()} {Year.ToString()}";

        }
    }
}
