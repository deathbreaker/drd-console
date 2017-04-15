using System;
using System.IO;

namespace RIN_Console.SystemHelper
{
    class Monster:Being
    {
        // modifikátor override u rodiče, override u potomka

        public override void Utoc(Being souper)
        {
            int zasah = getPresnost() + kostka.hod();
            int h_pruraznost = getDrtivost();
            int h_nicivost = getNicivost();


            NastavZpravu(string.Format("{0} útočí s úderem prenosti {1} ", _jmeno_, zasah));
            souper.BranSe(zasah, h_pruraznost, h_nicivost);
        }

        /*************************************************************************************************************/
      
        public override string getJmeno()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 0;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();

                //jmeno = sr.ReadLine();

                return sr.ReadLine();
            }

        }

        protected override void setJmeno(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 0;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getUroven()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 1;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setUroven(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 1;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getRasa()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 2;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setRasa(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 2;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getProfession()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 3;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setProfession(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 3;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getZK()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 4;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setZK(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 4;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*
            Začátek základních vlastností
        */

        protected override int getSil()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 5;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setSil(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 5;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getObr()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 6;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setObr(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 6;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getZruc()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 7;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setZruc(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 7;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getOdl()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 8;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setOdl(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 8;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getRoz()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 9;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setRoz(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 9;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getDuvt()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 10;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setDuvt(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 10;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getVul()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 11;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setVul(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 11;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getChar()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 12;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setChar(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 13;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        protected override int getBO()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 14;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setBO(string newText)
        {
            int bo = int.Parse(newText);

            if (bo > 10)
            {
                bo = 10;
            }
            else
            {
                if (bo < 0)
                    bo = 0;
            }

            String boS = bo + String.Empty;

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 14;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = boS;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getBN()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 15;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setBN(string newText)
        {
            int bn = int.Parse(newText);

            if (bn > 10)
            {
                bn = 10;
            }
            else
            {
                if (bn < 0)
                    bn = 0;
            }

            String bnS = bn + String.Empty;
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 15;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getBU()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 16;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setBU(string newText)
        {
            int bu = int.Parse(newText);

            if (bu > 10)
            {
                bu = 10;
            }
            else
            {
                if (bu < 0)
                    bu = 0;
            }

            String buS = bu + String.Empty;
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 16;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /************************ Začátek atributů zbraně     ******************************/
        /*******************************   Zbraň ****************************************************/
        protected override int getDrtivost()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 17;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setDrtivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 17;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getNicivost()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 18;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setNicivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 18;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getPresnost()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 19;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setPresnost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 19;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getVyhnuti()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setVyhnuti(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************  Magická energie *********************************************/


        protected override int getMaxTotalMP()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 21;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setMaxTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 21;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getTotalMP()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 22;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 22;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public override bool getStateMagician()
        {
            verifyStateMagician();
            return magician;
        }

        protected override void verifyStateMagician()
        {
            int specMP = getMaxTotalMP();

            if (specMP > 0)
                magician = true;
        }


        /*******************************   ŽIVOTY ****************************************************/
        /*********************************************************************************************/

        protected override int getMaxTotalHP()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 23;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 23;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getTotalHP()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 24;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 24;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveOko()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 25;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpLeveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 25;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPraveOko()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 26;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 26;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpUsta()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 27;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 27;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveUcho()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 28;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 28;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPraveUcho()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 29;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 29;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpNos()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 30;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 30;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
        protected override int getHpHlava()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 31;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected override void setHpHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 31;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpTorzo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 32;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 32;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveChodilo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 33;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }
        protected override void setHpLeveChodilo(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 33;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);

        }


        protected override int getHpLevaDlan()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 34;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }
        protected override void setHpLevaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 34;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPravaDlan()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 35;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpPravaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 35;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpPravaRuka()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 36;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpPravaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 36;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpLevaRuka()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 37;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpLevaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 37;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLevaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 38;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }
        protected override void setHpLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 38;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpPravaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 39;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 39;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + get_jmeno_() + ".txt";
            int line = 40;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 40;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getHpPraveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 41;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 41;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getHpTvar()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 42;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setHpTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 42;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpKrk()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 43;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }
        protected override void setHpKrk(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 43;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************   ZBROJ  ****************************************************/
        protected override int getZbHlava()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 44;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 44;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbTorzo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 45;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 45;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbLevaChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 46;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbLevaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 46;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbPravaRukavice()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 47;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbPravaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 47;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getZbLevaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 48;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 48;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbPravaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 49;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 49;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + get_jmeno_() + ".txt";
            int line = 50;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 50;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getZbPraveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 51;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 51;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbStit()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 52;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbStit(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 52;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbTvar()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 53;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected override void setZbTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 53;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /******************************** Konec get/set metod ke zbroji *************************************/
        /******************************** Metody pro set/get jméno      *************************************/


    }
}
