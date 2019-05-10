using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models
{
    public struct MinMaxStructure
    {
        public int Min;
        public int Max;

        public override string ToString()
        {
            return Min + " " + Max;
        }
    }
}
