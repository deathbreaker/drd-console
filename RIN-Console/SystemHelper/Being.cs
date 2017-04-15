using System;
using System.Collections.Generic;
using System.IO;

namespace RIN_Console.SystemHelper
{
    class Being
    {
        Kostka dsS = new Kostka(26);
        Kostka stoS = new Kostka(100);
        protected Kostka kostka;
        string[] castTela = new string[27];
        //IDictionary<string, int> zb = new Dictionary<string, int>();
        //IDictionary<string, int> teloHP = new Dictionary<string, int>();

        /// Poslední zpráva
        private string zprava;
        protected string _jmeno_;
        protected bool magician = false;
        public string jmeno { get; set; }
        //protected string rasa;  //0
        //protected string povolani; //1
        //protected string specializace; //2
        //protected int uroven; //3
        //protected int zk; //4

        //protected int sil;  //5
        //protected int obr;  //6
        //protected int zruc; //7
        //protected int vit; //8
        //protected int roz; //9
        //protected int duvt; //10
        //protected int vul; //11
        //protected int cha; //12

        /*
        protected int bo; //13
        protected int bm; //14
        protected int bu; //15
        */

        //*********************bojové statistiky
        //*********************atributy hracské zbraňě
        //protected string zbran;   //16
        //protected int presnost; //17
        //protected int vyhnuti;  //18

        //protected int krvaceni;   //19
        //protected int infekce;    //20
        //protected int dychani;    //21
        //protected int filtrace    //22




        //protected int pruraznost; //23
        //protected int nicivost;   //24
        //u normálnich zbraní 50% že se jim podaří zničit brnění

        /*
        protected int bodani;       //25
        protected int sekani;       //26
        protected int drtivost;     //27
        protected int zlomenina;    //28
        protected int ohen;         //29
        protected int blesky;       //30
        protected int vydrz_zbrane; //31
        protected bool magician = false;
        */


        //protected int hp;         //32
        //protected int maxHP;      //33
        //protected int mp;         //34
        //protected int maxMP;      //35



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
            int zasah = getPresnost() + kostka.hod();
            int h_pruraznost = getDrtivost();
            int h_nicivost = getNicivost();


            NastavZpravu(string.Format("{0} útočí s úderem prenosti {1} ", _jmeno_, zasah));
            souper.BranSe(zasah, h_pruraznost, h_nicivost);
        }




        public void BranSe(int zasah, int h_pruraznost, int h_nicivost)
        {
            // hodnota k vyhodnoceni úspěšného zásahu => uz
            int obrana = getVyhnuti() + kostka.hod();
            int uz = obrana - zasah;
            int hod100Kostkou = stoS.hod();
            bool zaklNiceniBr = (hod100Kostkou >= 50);

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



            if (uz<0)
            {
                int indexCT = dsS.hod();  //index zasažené části těla
                int poskZb = 0;
                switch (castTela[indexCT])
                {
                    case "Levé oko":


                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

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

                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;
                        

                            poskZb = getZbTorzo() - h_nicivost;

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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;
                        

                        poskZb = getZbTorzo() - h_nicivost;


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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbLevaChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbPravaRukavice() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbLevaChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbLevaChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbPravaRukavice() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbPravaRukavice() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbTorzo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbTorzo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbLevaNoha() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbPravaNoha() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr )
                            h_nicivost = 1;

                        poskZb = getZbLeveChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbLeveChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbLeveChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbPraveChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbPraveChodidlo() - h_nicivost;
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
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbPraveChodidlo() - h_nicivost;   //současný stav zbroje, může nabývat i záporných hodnot
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
                    // uv => úspěšné vyhnutí 
                    int uv = obrana - uz;
                    zprava = string.Format("{0} odrazil útok o hodnotu {1}", _jmeno_, uv);
                    NastavZpravu(zprava);
                }


            }

        }

        public virtual string get_jmeno_()
        {
            return _jmeno_;
        }

        public virtual void set_jmeno_(string _jmeno_)
        {
            this._jmeno_ = _jmeno_;
        }


        public virtual string getJmeno()
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

        protected virtual void setJmeno(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 0;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getUroven()
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

        protected virtual void setUroven(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getRasa()
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

        protected virtual void setRasa(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getProfession()
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

        protected virtual void setProfession(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getZK()
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

        protected virtual void setZK(string newText)
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

        protected virtual int getSil()
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

        protected virtual void setSil(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getObr()
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

        protected virtual void setObr(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getZruc()
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

        protected virtual void setZruc(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getOdl()
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

        protected virtual void setOdl(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getRoz()
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

        protected virtual void setRoz(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getDuvt()
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

        protected virtual void setDuvt(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getVul()
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

        protected virtual void setVul(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getChar()
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

        protected virtual void setChar(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        protected virtual int getBO()
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

        protected virtual void setBO(string newText)
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

        protected virtual int getBN()
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

        protected virtual void setBN(string newText)
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

        protected virtual int getBU()
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

        protected virtual void setBU(string newText)
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
        protected virtual int getDrtivost()
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

        protected virtual void setDrtivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getNicivost()
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

        protected virtual void setNicivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getPresnost()
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

        protected virtual void setPresnost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getVyhnuti()
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

        protected virtual void setVyhnuti(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************  Magická energie *********************************************/


        protected virtual int getMaxTotalMP()
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

        protected virtual void setMaxTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getTotalMP()
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

        protected virtual void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public virtual bool getStateMagician()
        {
            verifyStateMagician();
            return magician;
        }

        protected virtual void verifyStateMagician()
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

        protected virtual int getMaxTotalHP()
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

        protected virtual void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getTotalHP()
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

        protected virtual void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLeveOko()
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

        protected virtual void setHpLeveOko(string newText)
        {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
         }

        protected virtual int getHpPraveOko()
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

        protected virtual void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpUsta()
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

        protected virtual void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLeveUcho()
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

        protected virtual void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpPraveUcho()
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

        protected virtual void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpNos()
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

        protected virtual void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
            protected virtual int getHpHlava()       
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

            protected virtual void setHpHlava(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getHpTorzo()
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

            protected virtual void setHpTorzo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }

            protected virtual int getHpLeveChodilo()
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


                protected virtual int getHpLevaDlan()
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
                protected virtual void setHpLevaDlan(string newText)
                {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
                }

                protected virtual int getHpPravaDlan()
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

                protected virtual void setHpPravaDlan(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected virtual int getHpPravaRuka()
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

                protected virtual void setHpPravaRuka(string newText)
                { 

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected virtual int getHpLevaRuka()
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

                protected virtual void setHpLevaRuka(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }

                protected virtual int getHpLevaNoha()
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
                protected virtual void setHpLevaNoha(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected virtual int getHpPravaNoha()
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

                protected virtual void setHpPravaNoha(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }


                protected virtual int getHpLeveChodidlo()
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

                protected virtual void setHpLeveChodidlo(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }



                protected virtual int getHpPraveChodidlo()
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

                protected virtual void setHpPraveChodidlo(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }



                protected virtual int getHpTvar()
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

                protected virtual void setHpTvar(string newText)
                {

                    string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                    int line = 20;
                    string[] arrLine = File.ReadAllLines(fName);
                    arrLine[line - 1] = newText;
                    File.WriteAllLines(fName, arrLine);
                }

/*******************************   ZBROJ  ****************************************************/
                protected virtual int getZbHlava()
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

            protected virtual void setZbHlava(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbTorzo()
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

            protected virtual void setZbTorzo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbLevaChodidlo()
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

            protected virtual void setZbLevaRukavice(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbPravaRukavice()
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

            protected virtual void setZbPravaRukavice(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected virtual int getZbLevaNoha()
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

            protected virtual void setZbLevaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbPravaNoha()
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

            protected virtual void setZbPravaNoha(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbLeveChodidlo()
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

            protected virtual void setZbLeveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }



            protected virtual int getZbPraveChodidlo()
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

            protected virtual void setZbPraveChodidlo(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbStit()
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

            protected virtual void setZbStit(string newText)
            {

                string fName = "../../SystemHelper/txt-char/" + get_jmeno_() + ".txt";
                int line = 20;
                string[] arrLine = File.ReadAllLines(fName);
                arrLine[line - 1] = newText;
                File.WriteAllLines(fName, arrLine);
            }


            protected virtual int getZbTvar()
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

            protected virtual void setZbTvar(string newText)
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
