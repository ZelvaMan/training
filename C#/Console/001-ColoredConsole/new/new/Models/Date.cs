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
        public bool LeapYear
        {
            get
            {
                return (Year % 4) == 0;
            }
        }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public Date() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="leapYear"></param>
        /// <returns></returns>
        public int GetNumberOfDays(bool leapYear)
        {
            switch (Month)
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
        /// Parsuje datum z konzole ve formatu DD MM YYYY
        /// </summary>
        /// <returns> datum s rokem , mesicem a dnem</returns>
        public void ParseTheDate()
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
                    if (_year < 1950 || _year > 2050)
                        validationMesseges.Add("Neplatny rok, roky muzou byt jen v rozpeti 1950 az 2050");

                    if (_month < 0 || _month > 13)
                        validationMesseges.Add("Neplatny mesic, mesicu muze byt jen 12");

                    if (_day < 0 || _day > GetNumberOfDays((_year % 4) == 0))
                        validationMesseges.Add($"Nelatny pocet dnu, v tomto mesici je jen {GetNumberOfDays(LeapYear)} dnu");

                    Year = _year;
                    Month = _month;
                    Day = _day;
                }
                else validationMesseges.Add("nevalidni datum ");
                //pokud se nanaskitla zadna chyba
                if (validationMesseges.Count == 0)
                    return;
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

        /// <summary>
        /// Vrati rocni obdobi na zaklade data
        /// </summary>
        /// <param name="Day">den </param>
        /// <param name="Month">mesic </param>
        /// <returns> barvu zastupujici rocni obdobi</returns>
        public ConsoleColor GetSeason()
        {
            //winter 
            if (Month == 1 && Month == 2 &&
                (Month == 12 && Day > 22) &&
                (Month == 3 && Day <= 20))
                return ConsoleColor.Blue;
            //spring 
            if (Month == 4 && Month == 5 &&
                (Month == 3 && Day >= 22) &&
                (Month == 6 && Day < 21))
                return ConsoleColor.Green;
            //summer 
            if (Month == 7 && Month == 8 &&
                (Month == 6 && Day >= 21) &&
                (Month == 9 && Day < 23))
                return ConsoleColor.Red;
            //fall
            return ConsoleColor.Magenta;
        } 
        public override string ToString()
        {
            return $"{Day.ToString()} {Month.ToString()} {Year.ToString()}";

        }
    }
}
