﻿using System;
using System.Runtime.InteropServices;
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
            typeLine("Jméno herního charakteru je: ");
            Console.Write(Batrachus.get_jmeno_());
            Console.WriteLine();
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

            Thread.Sleep(750);

            Console.ResetColor();
            Console.Clear();
            //Thread.Yield();
        }

        static void writeRow()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 119; i > 0; i--)
            {
                Console.Write("█");
            }
        }

        static void firstHalfOfScreen()
        {
            for (int n = 12; n > 0; n--)
            {
                for (int i = 118; i > 0; i--)
                {
                    if (n > 0 && n != 1)
                    {

                        Console.Write("█");


                    }
                    if (n == 1)
                    {
                        Console.Write("█");

                    }
                    if (n == 0)
                    {
                        Console.Write("█");
                    }

                }
                if (n != 0)
                {
                    Console.Write("█\r\n");
                }

            }

            writeRow();
        }
          
        static void secondHalfOfScreen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
           
            // 30 - 12 = 18 => (celkový počet řádku v konzoli ve výchozí velikosti) - (mezera před prealoder nadpisem) =(zbylé volné řádky)
            // 30 - 18 =  5
            // 12 + 5 = 17
            // 12 + 5 = 17 => zapisovat se bude na 17 řádce
            for (int m = 13; m > 0; m--)
            {
                for (int q = 118; q > 0; q--)
                {
                    Console.Write("█");
                }
                Console.Write("█\r\n");
            }
            Console.ResetColor();
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
            Console.WriteLine();
        }

        static void setCursor(int top, int left)
        {

            int pTop = Console.CursorTop;
            int pLeft = Console.CursorLeft;
            pLeft = left;
            pTop = top;
            Console.SetCursorPosition(pLeft, pTop);
        }

        static void typeLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(40); // Sleep for 150 milliseconds
            }
        }
        /*
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
      */
    }

}

