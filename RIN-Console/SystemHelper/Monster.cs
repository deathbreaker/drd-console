using System;
using System.IO;

namespace RIN_Console.SystemHelper
{
    class Monster:Being
    {
        // modifikátor override u rodiče, override u potomka

        public override string get_jmeno_()
        {
            return _jmeno_;
        }

        public override void set_jmeno_(string _jmeno_)
        {
            this._jmeno_ = _jmeno_;
        }


        public override string getJmeno()
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 1;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();

                jmeno = sr.ReadLine();

                return sr.ReadLine();
            }

        }

        protected override void setJmeno(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 1;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getUroven()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getRasa()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getProfession()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getZK()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
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
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getObr()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getZruc()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getOdl()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getRoz()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getDuvt()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getVul()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getChar()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        protected override int getBO()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = boS;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getBN()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getBU()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /************************ Začátek atributů zbraně     ******************************/
        /*******************************   Zbraň ****************************************************/
        protected override int getDrtivost()
        {
            string fName = "SystemHelper/txt-char" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getNicivost()
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

        protected override void setNicivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getPresnost()
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

        protected override void setPresnost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getTotalMP()
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

        protected override void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
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

        protected void haveMagicTalent()
        {


        }

        /*******************************   ŽIVOTY ****************************************************/
        /*********************************************************************************************/

        protected override int getMaxTotalHP()
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

        protected override void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getTotalHP()
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

        protected override void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveOko()
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

        protected override void setHpLeveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPraveOko()
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

        protected override void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpUsta()
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

        protected override void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveUcho()
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

        protected override void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPraveUcho()
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

        protected override void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpNos()
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

        protected override void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
        protected override int getHpHlava()
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

        protected override void setHpHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpTorzo()
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

        protected override void setHpTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLeveChodilo()
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


        protected override int getHpLevaDlan()
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
        protected override void setHpLevaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpPravaDlan()
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

        protected override void setHpPravaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpPravaRuka()
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

        protected override void setHpPravaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpLevaRuka()
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

        protected override void setHpLevaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected override int getHpLevaNoha()
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
        protected override void setHpLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpPravaNoha()
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

        protected override void setHpPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getHpLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getHpPraveChodidlo()
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

        protected override void setHpPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getHpTvar()
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

        protected override void setHpTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /*******************************   ZBROJ  ****************************************************/
        protected override int getZbHlava()
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

        protected override void setZbHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbTorzo()
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

        protected override void setZbTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbLevaChodidlo()
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

        protected override void setZbLevaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbPravaRukavice()
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

        protected override void setZbPravaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getZbLevaNoha()
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

        protected override void setZbLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbPravaNoha()
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

        protected override void setZbPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + get_jmeno_() + ".txt";
            int line = 20;
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
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected override int getZbPraveChodidlo()
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

        protected override void setZbPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbStit()
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

        protected override void setZbStit(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected override int getZbTvar()
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

        protected override void setZbTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /******************************** Konec get/set metod ke zbroji *************************************/
        /******************************** Metody pro set/get jméno      *************************************/


    }
}
