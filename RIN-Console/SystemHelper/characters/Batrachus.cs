using RIN_Console.SystemHelper.trade;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIN_Console.SystemHelper.characters
{
    class Batrachus: Being, Kouzelnik
    {
        private static string character = "Batrachus";



        Kostka sestiStenka = new Kostka(6);
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

        protected int krvaceni;   //19
        protected int infekce;    //20
        protected int dychani;    //21
        protected int filtrace;    //22




        //protected int pruraznost; //23
        //protected int nicivost;   //24
        //u normálnich zbraní 50% že se jim podaří zničit brnění


        protected int bodani;       //25
        protected int sekani;       //26
        protected int drtivost;     //27
        protected int zlomenina;    //28
        protected int ohen;         //29
        protected int blesky;       //30
                                    //protected int vydrz_zbrane; //31



        //protected int hp;         //32
        //protected int maxHP;      //33
        //protected int mp;         //34
        //protected int maxMP;      //35



        //přehled kondice

        //zbroj a obrana

        //schopnosti hráčského povolaní a dovednosti

        public Batrachus() { }

        public Batrachus(string jmeno)
        {
            setJmeno(jmeno);
            setUroven("4");
            defaultInitHP(zpHP, levelHPModif);
            string actMana = string.Empty + valueManaPerLevel(getUroven(), getVul(), 0.6);
            setMaxTotalMP(actMana);
            setRasa("Člověk");
            setTrade("Architekt");
            setZK("0");
            setSil("");
            setObr("");
            setZruc("");
            setOdl("");
            setRoz("");
            setDuvt("");
            setVul("");
            setChar("");
            setBO("2");
            setBN("1");
            setBU("1");

            string presnost = getZruc() + 5 + string.Empty;
            setPresnost(presnost);
            string vyhnuti = getObr() + 5 + string.Empty;
            setVyhnuti(vyhnuti);

            setJmenoZbrane("Dvě dýky");
            setVydrzZbrane("20");
            setPruraznost("2");
            setNicivost("0");



        }

        public string getJmeno()
        {
            string fName = "../../SystemHelper/txt-char/" + character + ".txt";
            int line = 0;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();

                //jmeno = sr.ReadLine();

                return sr.ReadLine();
            }

        }

        public void setJmeno(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + character + ".txt";
            int line = 0;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public void defaultInitHP(int zpHP, int levelHPModif)
        {

            int HP = 0;

            for (int i = 1; i < getUroven() + 1; i++)
            {
                if (i == 1)
                {
                    HP = zpHP + getOdl();
                }
                else
                {
                    HP += sestiStenka.hod() + levelHPModif;
                }
            }

            string zpHPs = HP + String.Empty;
            setMaxTotalHP(zpHPs);
            setTotalHP(zpHPs);

        }

        public int valueManaPerLevel(int uroven, int domVlastnost, double magicGrowth)
        {
            // TODO   dodělat geometrickou posloupnost many

            int[][] poleMany = new int[36][];
            int specMana = 0;

            for (int u = 1; u < uroven + 1; u++)
            {

                for (int d = 1; d < domVlastnost + 1; d++)
                {

                    if (u == uroven && d == domVlastnost)
                        specMana = poleMany[u][d];
                }

            }
            return specMana;

        }

        public void levelUp(int actHP, int levelHPModif)
        {
            int HP = actHP + sestiStenka.hod() + levelHPModif;
        }

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
            castTela[8] = "Krk";
            castTela[9] = "Levá ruka";
            castTela[10] = "Pravá ruka";
            castTela[11] = "Levá dlaň";
            castTela[12] = "Pravá dlaň";
            castTela[13] = "Prsty na levé dlani";
            castTela[14] = "Palec na levé dlani";
            castTela[15] = "Prsty na pravé dlani";
            castTela[16] = "Palec na pravé dlani";
            castTela[17] = "Prsa";
            castTela[18] = "Břicho";
            castTela[19] = "Levá noha";
            castTela[20] = "Pravá noha";
            castTela[21] = "Levé chodidlo ";
            castTela[22] = "Pravé chodidlo";
            castTela[23] = "Levé chodidlo";
            castTela[24] = "Prsty na levé noze";
            castTela[25] = "Palec na levé noze";
            castTela[26] = "Prsty na pravé noze";
            castTela[27] = "Palec na pravé noze";




            if (uz < 0)
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
                        int aktHPleveOko = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPustaS = string.Empty + aktHPleveOko;
                        setHpLeveOko(aktHPustaS);
                        break;
                    case "Ústa":
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
                        int aktHPusta = getHpUsta() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHpUstaS = string.Empty + aktHPusta;
                        setHpLeveOko(aktHpUstaS);
                        break;
                    case "Levé ucho":
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
                        int aktHPleveUcho = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPleveUchoS = string.Empty + aktHPleveUcho;
                        setHpLeveUcho(aktHPleveUchoS);
                        break;
                    case "Pravé ucho":
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
                        int aktHPPraveOko = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPraveUchoS = string.Empty + aktHPPraveOko;
                        setHpLeveOko(aktHPPraveUchoS);
                        break;
                    case "Nos":
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
                        int aktHPNos = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPNosS = string.Empty + aktHPNos;
                        setHpNos(aktHPNosS);
                        break;
                    case "Tvář":
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
                        int aktHPTvar = getHpTvar() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPTvarS = string.Empty + aktHPTvar;
                        setHpNos(aktHPTvarS);
                        break;
                    case "Krk":
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;

                        poskZb = getZbHlava() - h_nicivost;

                        if (poskZb < 0)
                        {
                            string poskAZ = "0";
                            setZbHlava(poskAZ);
                        }
                        else
                        {
                            string poskZbS = string.Empty + poskZb;   // poskZbS = poškození zbroje soupeře
                            setZbHlava(poskZbS);
                        }
                        int aktHPKrk = getHpKrk() - (h_pruraznost / getZbHlava()); //************* getHpTvar() - h_pruraznost
                        string aktHPKrkS = string.Empty + aktHPKrk;
                        setHpNos(aktHPKrkS);
                        break;
                    case "Levá ruka":
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

                        int aktHPLevaRuka = getHpLeveChodilo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPLevaRukaS = string.Empty + aktHPLevaRuka;
                        setHpLevaRuka(aktHPLevaRukaS);

                        break;
                    case "Pravá ruka":
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

                        int aktHPPravaRuka = getHpPravaRuka() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPravaRukaS = string.Empty + aktHPPravaRuka;
                        setHpLevaRuka(aktHPPravaRukaS);
                        break;
                    case "Levá dlaň":
                        if (h_nicivost == 0 && zaklNiceniBr)
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

                        int aktHPPravaDlan = getHpPravaDlan() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string aktHPPravaDlanS = string.Empty + aktHPPravaDlan;
                        setHpPravaDlan(aktHPPravaDlanS);
                        break;
                    case "Prsty na levé dlani":
                        // dodělat tenhle 'case' a zároveň i připravit metody aktuálních životů prstů a palců
                        if (h_nicivost == 0 && zaklNiceniBr)
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
                        if (h_nicivost == 0 && zaklNiceniBr)
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
                        int _aktHPTorzo = getHpTorzo() - (h_pruraznost / getZbTorzo()); //************* getHpTvar() - h_pruraznost
                        string _aktHPTorzoS = string.Empty + _aktHPTorzo;
                        setHpLevaRuka(_aktHPTorzoS);
                        break;
                    case "Levá noha":
                        if (h_nicivost == 0 && zaklNiceniBr)
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
                        if (h_nicivost == 0 && zaklNiceniBr)
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
        /*
        public static string get_jmeno_(Being obj)
        {
            return obj._jmeno_;
        }

        public static void set_jmeno_(string _jmeno_, Being obj)
        {
            obj._jmeno_ = _jmeno_;
        }


        */


        protected virtual int getUroven()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 1;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setUroven(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 1;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getRasa()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 2;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setRasa(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 2;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getProfession()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 3;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setProfession(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 3;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getZK()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 4;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setZK(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 4;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*
            Začátek základních vlastností
        */

        protected virtual int getSil()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 5;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setSil(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 5;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getObr()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 6;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setObr(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 6;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getZruc()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 7;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setZruc(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 7;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getOdl()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 8;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setOdl(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 8;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getRoz()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 9;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setRoz(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 9;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getDuvt()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 10;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setDuvt(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 10;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getVul()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 11;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setVul(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 11;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getChar()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 12;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setChar(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 13;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        protected virtual int getBO()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 14;
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

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 14;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = boS;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getBN()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 15;
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
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 15;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getBU()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 16;
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
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 16;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /************************ Začátek atributů zbraně     ******************************/
        /*******************************   Zbraň ****************************************************/
        protected virtual int getDrtivost()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 17;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setDrtivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 17;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getNicivost()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 18;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setNicivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 18;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getPresnost()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 19;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setPresnost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 19;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getVyhnuti()
        {
            string row = null;
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 20;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    row = sr.ReadLine();
                return int.Parse(row);
            }
        }

        protected virtual void setVyhnuti(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************  Magická energie *********************************************/


        protected virtual int getMaxTotalMP()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 21;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setMaxTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 21;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getTotalMP()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 22;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 22;
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


        /*******************************   ŽIVOTY ****************************************************/
        /*********************************************************************************************/

        protected virtual int getMaxTotalHP()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 23;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 23;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getTotalHP()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 24;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 24;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLeveOko()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 25;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpLeveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 25;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpPraveOko()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 26;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 26;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpUsta()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 27;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 27;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLeveUcho()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 28;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 28;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpPraveUcho()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 29;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 29;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpNos()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 30;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 30;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
        protected virtual int getHpHlava()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 31;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setHpHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 31;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpTorzo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 32;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 32;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLeveChodilo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 33;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }
        protected virtual void setHpLeveChodilo(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 33;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);

        }


        protected virtual int getHpLevaDlan()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 34;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }
        protected virtual void setHpLevaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 34;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpPravaDlan()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 35;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpPravaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 35;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpPravaRuka()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 36;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpPravaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 36;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpLevaRuka()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 37;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpLevaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 37;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpLevaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 38;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }
        protected virtual void setHpLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 38;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpPravaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 39;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 39;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getHpLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + getJmeno() + ".txt";
            int line = 40;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 40;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected virtual int getHpPraveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 41;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 41;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected virtual int getHpTvar()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 42;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setHpTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 42;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getHpKrk()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 43;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }
        protected virtual void setHpKrk(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 43;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************   ZBROJ  ****************************************************/
        protected virtual int getZbHlava()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 44;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 44;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbTorzo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 45;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 45;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbLevaChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 46;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbLevaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 46;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbPravaRukavice()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 47;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbPravaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 47;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected virtual int getZbLevaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 48;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 48;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbPravaNoha()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 49;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 49;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbLeveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/ " + getJmeno() + ".txt";
            int line = 50;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 50;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        protected virtual int getZbPraveChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 51;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 51;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbStit()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 52;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbStit(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 52;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getZbTvar()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 53;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }

        }

        protected virtual void setZbTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 53;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /******************************** Konec get/set metod ke zbroji *************************************/
        /******************************** Metody pro set/get jméno      *************************************/

        /******************************** Dodatečná metoda - Povolání   *************************************/
        protected virtual int getTrade()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 54;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setTrade(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 54;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /******************************** Dodatečná metoda - Výdrž zbraně   *************************************/

        protected virtual int getVydrzZbrane()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 55;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setVydrzZbrane(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 55;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        protected virtual int getJmenoZbrane()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 56;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setJmenoZbrane(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 56;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        protected virtual int getPruraznost()
        {
            string fName = "SystemHelper/txt-char" + getJmeno() + ".txt";
            int line = 57;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        protected virtual void setPruraznost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 57;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
    }
}
