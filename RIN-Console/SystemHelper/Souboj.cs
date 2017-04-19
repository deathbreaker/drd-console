using System;
using System.Threading;

namespace RIN_Console.SystemHelper
{
    class Souboj
    {
        private Being hrac;

        private Being nepritel;

        private Kostka kostka;

        public Souboj(Being hrac, Being nepritel, Kostka kostka)
        {
            this.hrac = hrac;
            this.nepritel = nepritel;
            this.kostka = kostka;
        }

        public void Zapas()
        {
            // původní pořadí
            Being h = hrac;
            Being n = nepritel;
            Console.WriteLine("Souboj začíná !");
            Console.WriteLine("Dnes se utkají {0} s {1}! \n", hrac, nepritel);
            // prohození bojovníků
            bool zacinaBojovnik2 = (kostka.hod() <= kostka.VratPocetSten() / 2);
            if (zacinaBojovnik2)
            {
                n = hrac;
                h = nepritel;
            }
            Console.WriteLine("Začínat bude bojovník {0}! \nZápas může začít...", h);
            Console.ReadKey();
            // cyklus s bojem
            while (h.Nazivu() && n.Nazivu())
            {
                h.Utoc(n);
                Vykresli();
                VypisZpravu(n.VratPosledniZpravu()); // zpráva o využití bodů osudu
                
                VypisZpravu(h.VratPosledniZpravu()); // zpráva o útoku
                VypisZpravu(n.VratPosledniZpravu()); // zpráva o obraně                  
                if (n.Nazivu())
                {
                    n.Utoc(h);
                    Vykresli();
                    VypisZpravu(n.VratPosledniZpravu()); // zpráva o útoku
                    VypisZpravu(h.VratPosledniZpravu()); // zpráva o obraně
                }
                Console.WriteLine();
            }
        }

        private void VypisBojovnika(Being b)
        {
            Console.WriteLine(b);
            Console.Write("Zivot: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(b.GrafickyZivot());
            Console.ResetColor();
            if (b.getStateMagician())
            {
                Console.Write("Mana:  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(b.GrafickaMana());
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Vykreslí informační obrazovku
        /// </summary>
        private void Vykresli()
        {
            Console.Clear();
            Console.WriteLine("Kondice hrace a nepritele: \n");
            VypisBojovnika(hrac);
            Console.WriteLine();
            VypisBojovnika(nepritel);
            Console.WriteLine();
        }

        /// <summary>
        /// Vypíše zprávu do konzole s dramatickou pauzou
        /// </summary>
        /// <param name="zprava">Zpráva</param>
        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }

    
    }
}
