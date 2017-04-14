using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RIN_Console.SystemHelper
{
    class Being
    {
            Kostka dsS = new Kostka(26);
            protected Kostka kostka;
            string[] castTela = new string[27];
            IDictionary<string, int> zb = new Dictionary<string, int>();
            IDictionary<string, int> teloHP = new Dictionary<string, int>();

            /// Poslední zpráva
            private string zprava;
            protected string _jmeno_;
            protected string rasa;
            protected string povolani;
            protected string specializace;
            protected int uroven;
            protected int zk;

            protected int maxHP;
            protected int maxMP;

            protected int hp;
            protected int mp;

            protected int sil;
            protected int obr;
            protected int zruc;
            protected int vit;
            protected int roz;
            protected int duvt;
            protected int vul;
            protected int cha;

            protected int bo; // Body osudu
            protected int bm; // Body nemilosti
            protected int bu; // Body uvědomění

            protected int presnost;
            protected int vyhnuti;

            protected int krvaceni;
            protected int infekce;
            protected int dychani;
            protected int filtrace;

            //bojové statistiky
            // atributy hracské zbraňě
            protected string zbran;
            protected int pruraznost;
            protected int nicivost;
            protected int bodani;
            protected int sekani;
            protected int drtivost;
            protected int zlomenina;
            protected int ohen;
            protected int blesky;
            protected int vydrz_zbrane;

            //přehled kondice

            //zbroj a obrana

            //schopnosti hráčského povolaní a dovednosti


            public virtual void Utoc(Being souper)
            {
                int zasah = presnost + kostka.hod();
                int h_pruraznost = getDrtivost();
                int h_nicivost = getNicivost();


                NastavZpravu(string.Format("{0} útočí s úderem prenosti {1} ", _jmeno_, zasah));
                souper.BranSe(zasah, h_pruraznost, h_nicivost);
            }




            public void BranSe(int zasah, int h_pruraznost, int h_nicivost)
            {
                int uz = zasah - vyhnuti;                         // hodnota k vyhodnoceni úspěšného zásahu
                int obrana = vyhnuti + kostka.hod();

                castTela[1] = "Levé oko";
                castTela[2] = "Pravé oko";
                castTela[3] = "Ústa";
                castTela[4] = "Levé ucho";
                castTela[5] = "Pravé ucho";
                castTela[6] = "Nos";
                castTela[7] = "Tvář";
                castTela[8] = "Levá ruka";
                castTela[9] = "Pravá ruka";
                castTela[10] = "Levá dlaň";
                castTela[11] = "Pravá dlaň";
                castTela[12] = "Prsty na levé dlani";
                castTela[13] = "Palec na levé dlani";
                castTela[14] = "Prsty na pravé dlani";
                castTela[15] = "Palec na pravé dlani";
                castTela[16] = "Prsa";
                castTela[17] = "Břicho";
                castTela[18] = "Levá noha";
                castTela[19] = "Pravá noha";
                castTela[20] = "Levé chodidlo ";
                castTela[21] = "Pravé chodidlo";
                castTela[22] = "Levé chodidlo";
                castTela[23] = "Prsty na levé noze";
                castTela[24] = "Palec na levé noze";
                castTela[25] = "Prsty na pravé noze";
                castTela[26] = "Palec na pravé noze";



                if (uz > obrana)
                {
                    int indexCT = dsS.hod();  //index zasažené části těla
                    int poskZb = 0;
                    switch (castTela[indexCT])
                    {
                        case "Levé oko":
                        case "Pravé oko":
                        case "Ústa":
                        case "Levé ucho":
                        case "Pravé ucho":
                        case "Nos":
                            poskZb = getZbTvar() - h_nicivost;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbTvar(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;   // poskZbS = poškození zbroje soupeře
                                setZbTvar(poskZbS);
                            }
                            int aktHPNos = h_pruraznost;   //************* getHpTvar() - h_pruraznost;
                            break;
                        case "Levá ruka":
                            poskZb = getZbTorzo() - zasah;
                            poskZb = getZbTorzo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbTorzo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbTorzo(poskZbS);
                            }
                            break;
                        case "Pravá ruka":
                            poskZb = getZbTorzo() - zasah;
                            poskZb = getZbTorzo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbTorzo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbTorzo(poskZbS);
                            }
                            break;
                        case "Levá dlaň":
                            poskZb = getZbLevaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLevaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLevaRukavice(poskZbS);
                            }
                            break;
                        case "Pravá dlaň":
                            poskZb = getZbPravaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPravaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPravaRukavice(poskZbS);
                            }
                            break;
                        case "Prsty na levé dlani":
                            poskZb = getZbLevaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLevaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLevaRukavice(poskZbS);
                            }
                            break;
                        case "Palec na levé dlani":
                            poskZb = getZbLevaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLevaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLevaRukavice(poskZbS);
                            }
                            break;
                        case "Prsty na pravé dlani":
                            poskZb = getZbPravaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPravaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPravaRukavice(poskZbS);
                            }
                            break;
                        case "Palec na pravé dlani":
                            poskZb = getZbPravaRukavice() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPravaRukavice(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPravaRukavice(poskZbS);
                            }
                            break;
                        case "Prsa":
                            poskZb = getZbTorzo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbTorzo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbTorzo(poskZbS);
                            }
                            break;
                        case "Břicho":
                            poskZb = getZbTorzo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbTorzo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbTorzo(poskZbS);
                            }
                            break;
                        case "Levá noha":
                            poskZb = getZbLevaNoha() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLevaNoha(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLevaNoha(poskZbS);
                            }
                            break;
                        case "Pravá noha":
                            poskZb = getZbPravaNoha() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPravaNoha(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPravaNoha(poskZbS);
                            }
                            break;
                        case "Levé chodidlo":
                            poskZb = getZbLeveChodidlo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLeveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLeveChodidlo(poskZbS);
                            }
                            break;
                        case "Prsty na levé noze":
                            poskZb = getZbLeveChodidlo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLeveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLeveChodidlo(poskZbS);
                            }
                            break;
                        case "Palec na levé noze":
                            poskZb = getZbLeveChodidlo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbLeveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbLeveChodidlo(poskZbS);
                            }
                            break;
                        case "Pravé chodidlo":
                            poskZb = getZbPraveChodidlo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPraveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPraveChodidlo(poskZbS);
                            }
                            break;
                        case "Prsty na pravé noze":
                            poskZb = getZbPraveChodidlo() - zasah;
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPraveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPraveChodidlo(poskZbS);
                            }
                            break;
                        case "Palec na pravé noze":
                            poskZb = getZbPraveChodidlo() - zasah;   //současný stav zbroje, může nabývat i záporných hodnot
                            if (poskZb < 0)
                            {
                                string poskAZ = "0";
                                setZbPraveChodidlo(poskAZ);
                            }
                            else
                            {
                                string poskZbS = string.Empty + poskZb;
                                setZbPraveChodidlo(poskZbS);
                            }
                            break;

                    }
                }
                else
                {
                    if (uz == obrana)
                    {
                        int indexCT = dsS.hod();
                        zprava = string.Format("{0} těsně odrazil útok směřovanou na {1}!!", _jmeno_, castTela[indexCT]);
                        NastavZpravu(zprava);
                    }
                    else
                    {
                        int uv = obrana - uz;
                        zprava = string.Format("{0} odrazil útok o hodnotu {1}", _jmeno_, uv);
                        NastavZpravu(zprava);
                    }


                }

            }
            protected void NastavZpravu(string zprava)
            {
                this.zprava = zprava;
            }


            public string get_jmeno_()
            {
                return _jmeno_;
            }

            protected void set_jmeno_(string _jmeno_)
            {
                this._jmeno_ = _jmeno_;
            }

            public void editatingPlayer(string jmenoHrace, string povolani, int uroven)
            {
                this._jmeno_ = jmenoHrace;
                this.povolani = povolani;
                //this.specializace = specializace;
                this.uroven = uroven;
            }
            /*******************************   Zbraň ****************************************************/

            protected int getDrtivost()
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

            protected void setDrtivost(string newText)
            {
                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getNicivost()
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

            protected void setNicivost(string newText)
            {
                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
        }

            /*******************************   ŽIVOTY ****************************************************/
            /*********************************************************************************************/
            protected int getHpHlava()       
            {
                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    using (var sr = new StreamReader(fName))
                    {
                        for (int i = 1; i<line; i++)
                            sr.ReadLine();
                        return int.Parse(sr.ReadLine());
                    }
            }

            protected void setHpHlava(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getHpTorzo()
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

            protected void setHpTorzo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getHpLevaDlane()
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

            protected void setHpPravaDlane(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getHpPravaDlane()
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

            protected void setHpLevaDlane(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected int getHpLevaNoha()
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

            protected void setHpLevaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getHpPravaNoha()
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

            protected void setHpPravaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getHpLeveChodidlo()
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

            protected void setHpLeveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected int getHpPraveChodidlo()
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

            protected void setHpPraveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected int getHpTvar()
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

            protected void setHpTvar(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }

/*******************************   ZBROJ  ****************************************************/
                protected int getZbHlava()
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

            protected void setZbHlava(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbTorzo()
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

            protected void setZbTorzo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbLevaRukavice()
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

            protected void setZbLevaRukavice(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbPravaRukavice()
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

            protected void setZbPravaRukavice(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected int getZbLevaNoha()
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

            protected void setZbLevaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbPravaNoha()
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

            protected void setZbPravaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbLeveChodidlo()
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

            protected void setZbLeveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected int getZbPraveChodidlo()
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

            protected void setZbPraveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbStit()
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

            protected void setZbStit(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected int getZbTvar()
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

            protected void setZbTvar(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }

            /******************************** Konec get/set metod ke zbroji *************************************/
            /******************************** Metody pro set/get jméno      *************************************/

            public void setJmeno(string newText)
            {
                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 1;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }

            public string getJmeno()
            {
                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 1;
                using (var sr = new StreamReader(fName))
                {
                    for (int i = 1; i < line; i++)
                        sr.ReadLine();
                    return sr.ReadLine();
                }
            }
        }
}
