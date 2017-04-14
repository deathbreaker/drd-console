using System;
using System.Collections.Generic;
using System.IO;

namespace RIN_Console.SystemHelper
{
    class Being
    {
        Kostka dsS = new Kostka(26);
        protected Kostka kostka;
        string[] castTela = new string[27];
        //IDictionary<string, int> zb = new Dictionary<string, int>();
        //IDictionary<string, int> teloHP = new Dictionary<string, int>();

        /// Poslední zpráva
        private string zprava;
        protected string _jmeno_;
        //protected string rasa;
        //protected string povolani;
        //protected string specializace;
        //protected int uroven;
        //protected int zk;

        //protected int maxHP;
        //protected int maxMP;

        //protected int hp;
        //protected int mp;

        //protected int sil;
        //protected int obr;
        //protected int zruc;
        //protected int vit;
        //protected int roz;
        //protected int duvt;
        //protected int vul;
        //protected int cha;

        /*
        protected int bo;
        protected int bm;
        protected int bu;
        */

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
        protected bool magician = false;

        //přehled kondice

        //zbroj a obrana

        //schopnosti hráčského povolaní a dovednosti


        public bool Nazivu()
        {
            return (getTotalHP() > 0);
        }


        protected void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

        /// <summary>
        /// Vrátí poslední zprávu o útoku nebo obraně
        /// </summary>
        /// <returns>Poslední zpráva o útoku nebo obraně</returns>
        public string VratPosledniZpravu()
        {
            return zprava;
        }


        protected string GrafickyUkazatel(int aktualni, int maximalni)
        {

            string s = "";
            int celkem = 20;
            double pocet = Math.Round(((double)aktualni / maximalni) * celkem);
            if ((pocet == 0) && (Nazivu()))
                pocet = 1;
            for (int i = 0; i < pocet; i++)
                s += "█";
            s = s.PadRight(celkem);
            return s;
        }

        /// <summary>
        /// Vrátí grafickou reprezentaci života
        /// </summary>
        /// <returns>Řetězec s grafickou reprezentací života</returns>
        public string GrafickyZivot()
        {
            return GrafickyUkazatel(getTotalHP(), getMaxTotalHP());
        }

        public string GrafickaMana()
        {
            return GrafickyUkazatel(getTotalMP(), getMaxTotalMP());
        }

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
                        int aktHPnos = getHpTvar() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPnosS = string.Empty + aktHPnos;
                        setHpNos(aktHPnosS);
                        break;

                    case "Pravé oko":
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
                        int aktHPleveOko = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPustaS = string.Empty + aktHPleveOko;
                        setHpLeveOko(aktHPustaS);
                        break;
                    case "Ústa":
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
                        int aktHPusta = getHpUsta() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHpUstaS = string.Empty + aktHPusta;
                        setHpLeveOko(aktHpUstaS);
                        break;
                    case "Levé ucho":
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
                        int aktHPleveUcho = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPleveUchoS = string.Empty + aktHPleveUcho;
                        setHpLeveUcho(aktHPleveUchoS);
                        break;
                    case "Pravé ucho":
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
                        int aktHPPraveOko = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPraveUchoS = string.Empty + aktHPPraveOko;
                        setHpLeveOko(aktHPPraveUchoS);
                        break;
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
                        int aktHPNos = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPNosS = string.Empty + aktHPNos;
                        setHpNos(aktHPNosS);
                        break;
                    case "Levá ruka":
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

                        int aktHPLevaRuka = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPLevaRukaS = string.Empty + aktHPLevaRuka;
                        setHpLevaRuka(aktHPLevaRukaS);

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

                        int aktHPPravaRuka = getHpPravaRuka() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPravaRukaS = string.Empty + aktHPPravaRuka;
                        setHpLevaRuka(aktHPPravaRukaS);
                        break;
                    case "Levá dlaň":
                        poskZb = getZbLevaChodidlo() - zasah;
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

                        int aktHPLevaDlan = getHpLevaDlan() - (h_pruraznost / getZbLevaChodidlo()); //************* getHpTvar() - h_pruraznost
                        string aktHPLeveChodidloS = string.Empty + aktHPLevaDlan;
                        setHpLevaDlan(aktHPLeveChodidloS);
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

                        int aktHPPravaDlan = getHpPravaDlan() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPravaDlanS = string.Empty + aktHPPravaDlan;
                        setHpPravaDlan(aktHPPravaDlanS);
                        break;
                    case "Prsty na levé dlani":
                        // dodělat tenhle 'case' a zároveň i připravit metody aktuálních životů prstů a palců
                        poskZb = getZbLevaChodidlo() - zasah;
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
                        // TO DO
                        poskZb = getZbLevaChodidlo() - zasah;
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
                        // TO DO
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
                        // TO DO
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
                        int aktHPTorzo = getHpTorzo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPTorzoS = string.Empty + aktHPTorzo;
                        setHpLevaRuka(aktHPTorzoS);
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
                        int _aktHPTorzo = getHpTorzo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string _aktHPTorzoS = string.Empty + _aktHPTorzo;
                        setHpLevaRuka(_aktHPTorzoS);
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
                        int aktHPLevaNoha = getHpLevaNoha() - (h_pruraznost / getZbLevaNoha()); //************* getHpTvar() - h_pruraznost
                        string aktHPLevaNohaS = string.Empty + aktHPLevaNoha;
                        setHpLevaRuka(aktHPLevaNohaS);
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
                        int aktHPPravaNoha = getHpPravaNoha() - (h_pruraznost / getZbPravaNoha()); //************* getHpTvar() - h_pruraznost
                        string aktHPPravaNohaS = string.Empty + aktHPPravaNoha;
                        setHpLevaRuka(aktHPPravaNohaS);
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
                        int aktHPLeveChodidlo = getHpLeveChodidlo() - (h_pruraznost / getZbLeveChodidlo()); //************* getHpTvar() - h_pruraznost
                        string _aktHPLeveChodidloS = string.Empty + aktHPLeveChodidlo;
                        setHpLevaRuka(_aktHPLeveChodidloS);
                        break;
                    case "Prsty na levé noze":
                        // TO DO
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
                        /*
                        int aktHPLeva = getHpLeveChodidlo() - (h_pruraznost / getZbLeveChodidlo()); //************* getHpTvar() - h_pruraznost
                        string __aktHPLeveChodidloS = string.Empty + aktHPLeva;
                        setHpLevaDLan(__aktHPLeveChodidloS);
                        */
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
                        /*
                        int aktHP = getHpLeveChodidlo() - (h_pruraznost / getZbLeveChodidlo()); //************* getHpTvar() - h_pruraznost
                        string __aktHPLeveChodidloS = string.Empty + getHpLeveChodidlo();
                        setHpLevaDLan(__aktHPLeveChodidloS);
                        */
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
                        int aktHPPraveChodidlo = getHpPraveChodidlo() - (h_pruraznost / getZbPraveChodidlo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPraveChodidloS = string.Empty + aktHPPraveChodidlo;
                        setHpLeveChodidlo(aktHPPraveChodidloS);

                        break;
                    case "Prsty na pravé noze":
                        // TO DO
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
                        /*
                        int aktHP = getHpLeveChodidlo() - (h_pruraznost / getZbLeveChodidlo()); //************* getHpTvar() - h_pruraznost
                        string __aktHPLeveChodidloS = string.Empty + getHpLeveChodidlo();
                        setHpLevaDLan(__aktHPLeveChodidloS);
                        */

                        break;
                    case "Palec na pravé noze":
                        // TO DO
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

        public string get_jmeno_()
        {
            return _jmeno_;
        }

        public void set_jmeno_(string _jmeno_)
        {
            this._jmeno_ = _jmeno_;
        }

        /*******************************   Zbraň ****************************************************/

        protected int getUroven()
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

        protected void setUroven(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getRasa()
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

        protected void setRasa(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getProfession()
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

        protected void setProfession(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getZK()
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

        protected void setZK(string newText)
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

        protected int getSil()
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

        protected void setSil(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getObr()
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

        protected void setObr(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getZruc()
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

        protected void setZruc(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getOdl()
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

        protected void setOdl(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getRoz()
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

        protected void setRoz(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getDuvt()
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

        protected void setDuvt(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getVul()
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

        protected void setVul(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getChar()
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

        protected void setChar(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        protected int getBO()
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

        protected void setBO(string newText)
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

        protected int getBN()
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

        protected void setBN(string newText)
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

        protected int getBU()
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

        protected void setBU(string newText)
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


        /******************** Začátek atributů zbraně     ******************************/

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


        /*******************************  Magická energie *********************************************/


        protected int getMaxTotalMP()
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

        protected void setMaxTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getTotalMP()
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

        protected void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public bool getStateMagician()
        {
            verifyStateMagician();
            return magician;
        }

        protected void verifyStateMagician()
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

        protected int getMaxTotalHP()
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

        protected void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getTotalHP()
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

        protected void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getHpLeveOko()
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

        protected void setHpLeveOko(string newText)
        {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
         }

        protected int getHpPraveOko()
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

        protected void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getHpUsta()
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

        protected void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getHpLeveUcho()
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

        protected void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected int getHpPraveUcho()
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

        protected void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected int getHpNos()
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

        protected void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
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

            protected int getHpLeveChodilo()
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


                protected int getHpLevaDlan()
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
                protected void setHpLevaDlan(string newText)
                {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
                }

                protected int getHpPravaDlan()
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

                protected void setHpPravaDlan(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected int getHpPravaRuka()
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

                protected void setHpPravaRuka(string newText)
                { 

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected int getHpLevaRuka()
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

                protected void setHpLevaRuka(string newText)
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


            protected int getZbLevaChodidlo()
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
