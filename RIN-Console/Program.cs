using System;
using System.Threading;
using System.Windows.Forms;

namespace RIN_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("╔═╗");
            //Console.WriteLine("╚═╝");
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Program Prg = new Program();
            Prg.preloader();

            SystemHelper.Being Batrachus = new SystemHelper.Being();
            SystemHelper.Being Artym = new SystemHelper.Being();
            SystemHelper.Being Jerrynek = new SystemHelper.Being();
            SystemHelper.Being Melichar = new SystemHelper.Being();
            SystemHelper.Being Teclis = new SystemHelper.Being();
            SystemHelper.Being Tomas = new SystemHelper.Being();

            if (Batrachus.get_jmeno_() == null)
                Batrachus.editatingPlayer("Batrachus", "Kouzelník", 1);


            Console.Clear();
            //progrBar();
            //Console.Clear();
            Console.WriteLine("Jméno herního charakteru je: " + Batrachus.get_jmeno_());
            //Console.WriteLine(Batrachus.getJmeno());
            //Batrachus.setJmeno("_Batrachus_");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Batrachus.getJmeno());
            Console.ResetColor();
            String[] pole = { "Jmeno", "DalsiJmeno", "ZaseJmeno" };
            Table.PrintLine();
            Table.PrintRow(pole);
            Table.PrintLine();
            Table.PrintRow(pole);
            Table.PrintRow(pole);
            Table.PrintRow(pole);
            Table.PrintLine();
            Console.ReadKey();

            String[,] pole2 = new String[200, 200];
        }

        private void preloader()
        {
            Console.CursorVisible = false;
            //Thread threadSketchIn = new Thread(new ThreadStart(runSketchInSpecLine));
            //Thread threadProgrBar = new Thread(new ThreadStart(runProgrBar));
            //Thread threadTheRestLines = new Thread(new ThreadStart(runSketchInTheRestLines));
            //Thread runSketchInDIffSpecLinee = new Thread(new ThreadStart(runSketchInDIffSpecLine));
            //Thread threadSketchTitle = new Thread(new ThreadStart(runSketchTitle));

            // n = 25
            
            for (int n = 12; n > 0; n--)
            {
                for (int i = 118; i > 0; i--)
                {
                    if (n > 0 && n != 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");


                    }
                    if (n == 1)
                    {
                        Console.Write("█");

                    }
                    if (n == 0)
                    {
                        Console.Write("██");
                    }

                }
                if (n != 1)
                    Console.Write("█\r\n");
            }
            


            //Console.Write("█");
            //Console.Write("█\r\n");
            /*
            threadSketchTitle.Priority = ThreadPriority.Highest;
            threadProgrBar.Priority = ThreadPriority.AboveNormal;
            threadSketchIn.Priority = ThreadPriority.BelowNormal;
            threadTheRestLines.Priority = ThreadPriority.Lowest;

            threadSketchTitle.Start();                          //vykreslí velký nadpis RIN CONSOLE
            threadProgrBar.Start();                             //vykreslí 'progress bar' a bude pracovat na načítání celé aplikace
            threadSketchIn.Start();                             //vykreslí zbytek řádku u 'progress bar'
            threadTheRestLines.Start();                         //vykreslí zbytek řádků pod 'progress bar'

            //AboveNormal; ThreadPriority.Lowest ThreadPriority.BelowNormal. BelowNormal Highest 
            */

            firstHalfOfScreen();
            titleOfScreen();
            secondHalfOfScreen();

            //runSketchInDIffSpecLinee.Start();
            //runSketchInSpecLine();
            //threadTheRestLines();

            Thread.Sleep(500);

            Console.ResetColor();
            Console.Clear();

            //Thread.Yield();
        }

        static void firstHalfOfScreen()
        {

        }
        
        static void secondHalfOfScreen()
        {

        }

        static void runProgrBar()
        {           
            //setCursor(22, 0);
            for (int l = 46; l > 0; l--)
            {
                //Foreground = DarkGray

                 //Background = DakrGray
                    //Foreground = DarkMagenta
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                }

                    using (var progress = new ProgressBar())
                    {
                           Console.ResetColor();
                           Console.BackgroundColor = ConsoleColor.DarkGray;
                           Console.ForegroundColor = ConsoleColor.DarkMagenta;

                           for (int i = 0; i <= 100; i++)
                           {
                                  progress.Report((double)i / 100);
                                  Thread.Sleep(20);
                           }

                          
                     }

            Console.Write("Done.");

            for (int s= 46; s>0; s--)
            {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("█");

            }

            Thread.Yield();
            Console.ResetColor();

        }

        static void writeLoadingTitle()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("RIN Console Loading...");
            Console.ResetColor();

        }

        static void runSketchInDIffSpecLine()
        {
            //setCursor(15, 0);
            //95 použitelných řádek
            for (int i = 47; i > 0; i--)
            {
                if (i > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("█");
                }

            }

            Console.ResetColor();
            writeLoadingTitle();

            for (int i = 47; i > 0; i--)
            {

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");

            }
            Console.ResetColor();
            Thread.Yield();

        }

        static void runSketchInSpecLine()
        {

            for (int c = 46; c > 0; c--)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
                Console.ResetColor();

            }


        }

        static void runSketchInTheRestLines()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int pLeft = Console.CursorLeft;
            int pTop = Console.CursorTop;
            pLeft = 0;
            pTop = 21;
            Console.SetCursorPosition(pLeft, pTop);

            // 30 - 12 = 18 => (celkový počet řádku v konzoli ve výchozí velikosti) - (mezera před prealoder nadpisem) =(zbylé volné řádky)
            // 30 - 18 =  5
            // 12 + 5 = 17
            // 12 + 5 = 17 => zapisovat se bude na 17 řádce
            for (int m = 13; m > 0; m--)
            {
                for (int q = 115; q > 0; q--)
                {
                    Console.Write("█");
                }
                Console.Write("█\r\n");
            }
            Console.ResetColor();
            Thread.Yield();


        }

        static void titleOfScreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(@"
                    ██████╗ ██╗███╗   ██╗     ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗              
                    ██╔══██╗██║████╗  ██║    ██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝              
                    ██████╔╝██║██╔██╗ ██║    ██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗                
                    ██╔══██╗██║██║╚██╗██║    ██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝                
                    ██║  ██║██║██║ ╚████║    ╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗              
                    ╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝              ");
            Console.ResetColor();
        }

        static void setCursor(int top, int left)
        {

            int pTop = Console.CursorTop;
            int pLeft = Console.CursorLeft;
            pLeft = left;
            pTop = top;
            Console.SetCursorPosition(pLeft, pTop);
        }
 }

}

