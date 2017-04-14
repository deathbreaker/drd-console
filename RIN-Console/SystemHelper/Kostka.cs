using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIN_Console.SystemHelper
{
    class Kostka
    {
        private Random random;

        private int pocetSten;

        public Kostka()
        {
            this.pocetSten = 6;
            random = new Random();
        }

        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
            random = new Random();
        }


        public int VratPocetSten()
        {
            return pocetSten;
        }


        public int hod()
        {
            return random.Next(1, pocetSten + 1);
        }


        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", pocetSten);
        }
    }
}
