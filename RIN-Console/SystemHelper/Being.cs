using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIN_Console.SystemHelper
{
    class Being
    {
        protected Kostka sestiStenka;
        protected Kostka dsS;
        protected Kostka stoS;

        string[] castTela = new string[26];
        //IDictionary<string, int> zb = new Dictionary<string, int>();
        //IDictionary<string, int> teloHP = new Dictionary<string, int>();

        /// Poslední zpráva
        private string zprava;

        protected bool magician = false;
        protected string jmeno { get; set; }
        protected string rasa { get; set; }
        protected string povolani { get; set; }
        protected string specializace { get; set; }
        protected int uroven { get; set; }
        protected int zk { get; set; }

        protected int sil { get; set; }
        protected int obr { get; set; }
        protected int zruc { get; set; }
        protected int vit { get; set; }
        protected int roz { get; set; }
        protected int duvt { get; set; }
        protected int vul { get; set; }
        protected int cha { get; set; }


        protected int bo { get; set; }
        protected int bn { get; set; }
        protected int bu { get; set; }


        //*********************bojové statistiky
        //*********************atributy hracské zbraňě
        protected string zbran { get; set; }
        protected int presnost { get; set; }
        protected int vyhnuti { get; set; }

        /*
        protected int krvaceni { get; set; }
        protected int infekce { get; set; }
        protected int dychani { get; set; }
        protected int filtrace { get; set; }
        */



        protected int pruraznost { get; set; }
        protected int nicivost { get; set; }
        //u normálnich zbraní 50% že se jim podaří zničit brnění o 1


        /* ** Zatím neimplemtováno ** */
        protected int bodani { get; set; }
        protected int sekani { get; set; }
        protected int drtivost { get; set; }
        protected int zlomenina { get; set; }
        protected int ohen { get; set; }
        protected int blesky { get; set; }
        /* **                         ** */

        protected int vydrzZbrane { get; set; }




        /*** Specifická zbroj a HP ***/

        protected int HpTvar { get; set; }
        protected int HpNos { get; set; }
        protected int HpLeveOko { get; set; }
        protected int HpPraveOko { get; set; }
        protected int HpUsta { get; set; }
        protected int HpLeveUcho { get; set; }
        protected int HpPraveUcho { get; set; }
        protected int HpLevaNoha { get; set; }
        protected int HpPravaNoha { get; set; }
        protected int ZbLevaNoha { get; set; }
        protected int ZbPravaNoha { get; set; }
        protected int HpTorzo { get; set; }
        //protected int HpPrsa { get; set; }
        //protected int HpBricho { get; set; }
        protected int HpLevaRuka { get; set; }
        protected int HpPravaRuka { get; set; }
        protected int HpLevaDlan { get; set; }
        protected int HpPravaDlan { get; set; }
        protected int HpKrk { get; set; }
        protected int HpLeveChodidlo { get; set; }
        protected int HpPraveChodidlo { get; set; }
        protected int HpHlava { get; set; }

        protected int ZbTorzo { get; set; }
        protected int ZbLevaDlan { get; set; }
        protected int ZbPravaDlan { get; set; }
        protected int ZbLeveChodidlo { get; set; }
        protected int ZbPraveChodidlo { get; set; }
        protected int ZbHlava { get; set; }
        protected int ZbNohy { get; set; }
        protected int ZbTvar { get; set; }
        protected int hp { get; set; }        //32
        protected int maxHP { get; set; }      //33
        protected int mp { get; set; }         //34
        protected int maxMP { get; set; }

        public Being()
        {

        }

        public Being( string jmeno, string rasa, string povolani, string specializace, int uroven, 
        int zk, int sil, int obr, int zruc, int vit, int roz, int duvt, int vul, int cha, int bo, 
        int bn, int bu, string zbran, int presnost, int vyhnuti, int pruraznost, int nicivost, 
        int vydrzZbrane, int HpTvar, int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta, int HpLeveUcho,
        int HpPraveUcho, int HpPravaNoha, int HpLevaNoha, int HpTorzo, int HpLevaRuka, 
        int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo,
        int HpHlava, int ZbNohy, int ZbTorzo, int ZbLevaDlan, int ZbPravaDlan, 
        int ZbLeveChodidlo, int ZbPraveChodidlo, int ZbHlava, int ZbTvar)
        {
            sestiStenka = new Kostka(6);            //1
            dsS = new Kostka(27);       //2
            stoS = new Kostka(100); //3


            this.jmeno = jmeno;     //4
            this.rasa = rasa;           //5
            this.povolani = povolani;   //6
            this.specializace = specializace;   //7
            this.uroven = uroven;   //8
            this.zk = zk;       //9

            this.sil = sil;     //10
            this.obr = obr;     //11
            this.zruc = zruc;   //12
            this.vit = vit;     //13
            this.roz = roz;     //14
            this.duvt = duvt;   //15
            this.vul = vul;     //16
            this.cha = cha;     //17


            this.bo = bo;       //18
            this.bn = bn;       //19
            this.bu = bu;       //20
                
            this.zbran = zbran; //21
            this.presnost = presnost;   //22
            this.vyhnuti = vyhnuti;     //23

            

            this.pruraznost = pruraznost; //24
            this.nicivost = nicivost;   //25

            this.vydrzZbrane = vydrzZbrane; //26

            this.HpTvar = HpTvar;    //31
            this.HpNos = HpNos;     //32
            this.HpLeveOko = HpLeveOko; //33
            this.HpPraveOko = HpPraveOko;   //34
            this.HpLeveOko = HpLeveOko; //35
            this.HpUsta = HpUsta;
            this.HpLeveUcho = HpLeveUcho;   //36
            this.HpPraveUcho = HpPraveUcho; //37
            this.HpLevaNoha = HpLevaNoha;   //38
            this.HpPravaNoha = HpPravaNoha; //37
            //this.HpPrsa = HpPrsa;
            //this.HpBricho = HpBricho;   //38
            this.HpTorzo = HpTorzo;
            this.HpLevaRuka = HpLevaRuka;   //39
            this.HpPravaRuka = HpPravaRuka; //40
            this.HpLevaDlan = HpLevaDlan;   //41
            this.HpPravaDlan = HpPravaDlan; //42
            this.HpKrk = HpKrk;             //43
            this.HpLeveChodidlo = HpLeveChodidlo;   //44
            this.HpPraveChodidlo = HpPraveChodidlo; //45
            this.HpHlava = HpHlava;                 //46



            this.ZbNohy = ZbNohy;       //47
            //this.ZbPravaNoha = ZbPravaNoha;     //48
            this.ZbTorzo = ZbTorzo;             //49
            this.ZbLevaDlan = ZbLevaDlan;       //50
            this.ZbPravaDlan = ZbPravaDlan;     //51
            this.ZbLeveChodidlo = ZbLeveChodidlo;   //52
            this.ZbPraveChodidlo = ZbPraveChodidlo; //53
            this.ZbHlava = ZbHlava;                 //54
            this.ZbNohy = ZbNohy;                   //55
            this.ZbTvar = ZbTvar;                   //56
        }

        public Being(string jmeno, string rasa, string povolani, string specializace, int uroven, int zk, int sil, int obr, int zruc, int vit, int roz, int duvt, int vul, int cha, int bo, int bn, int bu, string zbran, int presnost, int vyhnuti, int pruraznost, int nicivost, int vydrzZbrane, int HpTvar, int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta, int HpLeveUcho, int HpPraveUcho, int HpPravaNoha, int HpLevaNoha, int HpTorzo, int HpLevaRuka, int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo, int HpHlava, int ZbNohy, int ZbTorzo, int ZbLevaDlan, int ZbPravaDlan, int ZbLeveChodidlo, int ZbPraveChodidlo, int ZbHlava, int ZbTvar, int zbTvar) : this(jmeno, rasa, povolani, specializace, uroven, zk, sil, obr, zruc, vit, roz, duvt, vul, cha, bo, bn, bu, zbran, presnost, vyhnuti, pruraznost, nicivost, vydrzZbrane, HpTvar, HpNos, HpLeveOko, HpPraveOko, HpUsta, HpLeveUcho, HpPraveUcho, HpPravaNoha, HpLevaNoha, HpTorzo, HpLevaRuka, HpPravaRuka, HpLevaDlan, HpPravaDlan, HpKrk, HpLeveChodidlo, HpPraveChodidlo, HpHlava, ZbNohy, ZbTorzo, ZbLevaDlan, ZbPravaDlan, ZbLeveChodidlo, ZbPraveChodidlo, ZbHlava, ZbTvar)
        {
            this.ZbTvar = zbTvar;
        }

        public bool Nazivu()
        {
            return (maxHP > 0);
        }

        protected void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

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


        public virtual bool getStateMagician()
        {
            verifyStateMagician();
            return magician;
        }

        public virtual void verifyStateMagician()
        {
            if (maxMP > 0)
                magician = true;
        }

        public string GrafickyZivot()
        {
            return GrafickyUkazatel(hp, maxHP);
        }

        public string GrafickaMana()
        {
            return GrafickyUkazatel(hp, maxHP);
        }


        public virtual void Utoc(Being souper)
        {
            int zasah = presnost + kostka.hod();
            int h_pruraznost = drtivost;
            int h_nicivost = nicivost;

            NastavZpravu(string.Format("Charakteru {0} útočí s úderem prenosti {1} ", jmeno, zasah));
            souper.BranSe(zasah, h_pruraznost, h_nicivost);
        }

        public void BranSe(int zasah, int h_pruraznost, int h_nicivost)
        {
            // hodnota k vyhodnoceni úspěšného zásahu => uz
            int obrana = vyhnuti + kostka.hod();
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
            castTela[21] = "Pravé chodidlo";
            castTela[22] = "Levé chodidlo";
            castTela[23] = "Prsty na levé noze";
            castTela[24] = "Palec na levé noze";
            castTela[25] = "Prsty na pravé noze";
            castTela[26] = "Palec na pravé noze";
            castTela[27] = "Hlava";



            if (uz < 0)
            {
                int indexCT = dsS.hod();  //index zasažené části těla
                int poskZb = 0;

                switch (castTela[indexCT])
                {
                    case "Levé oko":

                        // Vzorový case
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLeveOko -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }
                                    correct = true;
                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLeveOko -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar =0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar-= poskZb;
                        }
                        break;
                    /*************************************************************************************************************************/
                    case "Pravé oko":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPraveOko -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }
                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPraveOko -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Ústa":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpUsta -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }
                                    correct = true;
                                }
                                while (!correct);

                            }
                            else
                            {
                                HpUsta -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Levé ucho":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLeveUcho -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }
                                    correct = true;
                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLeveUcho -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Pravé ucho":


                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPraveUcho -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPraveUcho -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Nos":

                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpNos -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpNos -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Tvář":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTvar - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpTvar -= (h_pruraznost / ZbTvar);
                                            hp -= (h_pruraznost / ZbTvar);
                                            ZbTvar = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpTvar -= (h_pruraznost / ZbTvar);
                                hp -= (h_pruraznost / ZbTvar);
                                ZbTvar = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTvar -= poskZb;
                        }
                        break;
                    case "Krk":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = (ZbTorzo+ZbHlava/2) - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpKrk -= (h_pruraznost / (ZbTorzo + ZbHlava / 2));
                                            hp -= (h_pruraznost / (ZbTorzo + ZbHlava / 2));
                                            ZbTorzo = 0;
                                            ZbHlava = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpKrk -= (h_pruraznost / (ZbTorzo + ZbHlava / 2));
                                hp -= (h_pruraznost / (ZbTorzo + ZbHlava / 2));
                                ZbTorzo = 0;
                                ZbHlava = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTorzo -= poskZb;
                            ZbHlava -= poskZb;
                        }
                        break;
                    case "Levá ruka":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTorzo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLevaRuka -= (h_pruraznost / ZbTorzo);
                                            hp -= (h_pruraznost / ZbTorzo);
                                            ZbTorzo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLevaRuka -= (h_pruraznost / ZbTorzo);
                                hp -= (h_pruraznost / ZbTorzo);
                                ZbTorzo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTorzo -= poskZb;
                        }
                        break;
                    case "Pravá ruka":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTorzo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPravaRuka -= (h_pruraznost / ZbTorzo);
                                            hp -= (h_pruraznost / ZbTorzo);
                                            ZbTorzo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPravaRuka -= (h_pruraznost / ZbTorzo);
                                hp -= (h_pruraznost / ZbTorzo);
                                ZbTorzo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTorzo -= poskZb;
                        }
                        break;
                    case "Levá dlaň":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbLevaDlan - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLevaDlan -= (h_pruraznost / ZbLevaDlan);
                                            hp -= (h_pruraznost / ZbLevaDlan);
                                            ZbLevaDlan = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLevaDlan -= (h_pruraznost / ZbLevaDlan);
                                hp -= (h_pruraznost / ZbLevaDlan);
                                ZbTorzo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbLevaDlan -= poskZb;
                        }
                        break;
                    case "Pravá dlaň":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbPravaDlan - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPravaDlan -= (h_pruraznost / ZbPravaDlan);
                                            hp -= (h_pruraznost / ZbPravaDlan);
                                            ZbPravaDlan = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPravaDlan -= (h_pruraznost / ZbPravaDlan);
                                hp -= (h_pruraznost / ZbPravaDlan);
                                ZbPravaDlan = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbPravaDlan -= poskZb;
                        }
                        break;
                    case "Prsty na levé dlani":
                        //TO DO

                        break;
                    case "Palec na levé dlani":
                        // TO DO

                        break;
                    case "Prsty na pravé dlani":
                        // TO DO

                        break;
                    case "Palec na pravé dlani":
                        // TO DO
                     
                        break;
                    case "Prsa":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTorzo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpTorzo -= (h_pruraznost / ZbTorzo);
                                            hp -= (h_pruraznost / ZbTorzo);
                                            ZbTorzo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpTorzo -= (h_pruraznost / ZbTorzo);
                                hp -= (h_pruraznost / ZbTorzo);
                                ZbTorzo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTorzo -= poskZb;
                        }
                        break;
                    case "Břicho":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbTorzo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpTorzo -= (h_pruraznost / ZbTorzo);
                                            hp -= (h_pruraznost / ZbTorzo);
                                            ZbTorzo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpTorzo -= (h_pruraznost / ZbTorzo);
                                hp -= (h_pruraznost / ZbTorzo);
                                ZbTorzo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbTorzo -= poskZb;
                        }
                        break;
                    case "Levá noha":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbLevaNoha - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLevaNoha -= (h_pruraznost / ZbLevaNoha);
                                            hp -= (h_pruraznost / ZbLevaNoha);
                                            ZbLevaNoha = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLevaNoha -= (h_pruraznost / ZbLevaNoha);
                                hp -= (h_pruraznost / ZbLevaNoha);
                                ZbLevaNoha = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbLevaNoha -= poskZb;
                        }
                        break;
                    case "Pravá noha":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbPravaNoha - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPravaNoha -= (h_pruraznost / ZbPravaNoha);
                                            hp -= (h_pruraznost / ZbPravaNoha);
                                            ZbPravaNoha = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPravaNoha -= (h_pruraznost / ZbPravaNoha);
                                hp -= (h_pruraznost / ZbPravaNoha);
                                ZbPravaNoha = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbPravaNoha -= poskZb;
                        }
                        break;
                    case "Levé chodidlo":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbLeveChodidlo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpLeveChodidlo -= (h_pruraznost / ZbLeveChodidlo);
                                            hp -= (h_pruraznost / ZbLeveChodidlo);
                                            ZbLeveChodidlo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpLeveChodidlo -= (h_pruraznost / ZbLeveChodidlo);
                                hp -= (h_pruraznost / ZbLeveChodidlo);
                                ZbLeveChodidlo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbLeveChodidlo -= poskZb;
                        }

                        break;
                    case "Prsty na levé noze":
                        // TO DO
                        
                        break;
                    case "Palec na levé noze":
                        // TO DO
                        break;
                    case "Pravé chodidlo":
                        // pokud je hráčská ničivost hodnot 0 a bool hodnota zaklNiceniBr říká true, tak hráčská ničivost je 1
                        if (h_nicivost == 0 && zaklNiceniBr)
                            h_nicivost = 1;
                        // načtění hodnoty celkové poskožení zbroje k dalším operacím programu 
                        poskZb = ZbPraveChodidlo - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {
                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/N.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'N')
                                    {
                                        if (rozh == 'a')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            HpPraveChodidlo -= (h_pruraznost / ZbPraveChodidlo);
                                            hp -= (h_pruraznost / ZbPraveChodidlo);
                                            ZbPraveChodidlo = 0;
                                        }

                                        correct = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zadejte prosím platnou klávesu !!");
                                    }

                                }
                                while (!correct);

                            }
                            else
                            {
                                HpPraveChodidlo -= (h_pruraznost / ZbPraveChodidlo);
                                hp -= (h_pruraznost / ZbPraveChodidlo);
                                ZbPraveChodidlo = 0;
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            ZbPraveChodidlo -= poskZb;
                        }


                        break;
                    case "Prsty na pravé noze":
                        // TO DO                     

                        break;
                    case "Palec na pravé noze":
                        // TO DO
                       
                        break;

                }
            }
            else
            {
                if (uz == obrana)
                {
                    int indexCT = dsS.hod();
                    zprava = string.Format("Charakteru {0} se podařilo těsně odrazit útok směřovaný na {1}!!", jmeno, castTela[indexCT]);
                    NastavZpravu(zprava);
                }
                else
                {
                    // uv => úspěšné vyhnutí 
                    int uv = obrana - uz;
                    zprava = string.Format("Charakteru {0} se podařilo těsně odrazit útok o hodnotu {1}", jmeno, uv);
                    NastavZpravu(zprava);
                }


            }

        }

    }
}
