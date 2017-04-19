using System;
using System.Data.SQLite;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Linq;

namespace RIN_Console.SystemHelper
{
    class Being
    {
        static public  List<Being> Player;
        
        SQLiteConnection sql_con = new SQLiteConnection("Data Source=DB_RIN-Console.sqlite;Version=3;");
        public Kostka sestiStenka;
        public Kostka dsS;
        public Kostka stoS;

        string[] castTela = new string[26];
        //IDictionary<string, int> zb = new Dictionary<string, int>();
        //IDictionary<string, int> teloHP = new Dictionary<string, int>();

        /// Poslední zpráva
        private string zprava;
        public static string character;
        public bool magician = false;
        public int ZbStit { get; set; }
        public string jmeno = "";
        public string rasa { get; set; }
        public string povolani { get; set; }
        public string specializace { get; set; }
        public int uroven { get; set; }
        public int zk { get; set; }
        public  int id;
        public int sil { get; set; }
        public int obr { get; set; }
        public int zruc { get; set; }
        public int vit { get; set; }
        public int roz { get; set; }
        public int duvt { get; set; }
        public int vul { get; set; }
        public int cha { get; set; }


        public int bo { get; set; }
        public int bn { get; set; }
        public int bu { get; set; }


        //*********************bojové statistiky
        //*********************atributy hracské zbraňě
        public string zbran { get; set; }
        public int presnost { get; set; }
        public int vyhnuti { get; set; }

        /*
        public int krvaceni { get; set; }
        public int infekce { get; set; }
        public int dychani { get; set; }
        public int filtrace { get; set; }
        */



        public int pruraznost { get; set; }
        public int nicivost { get; set; }
        //u normálnich zbraní 50% že se jim podaří zničit brnění o 1


        /* ** Zatím neimplemtováno ** */
        public int bodani { get; set; }
        public int sekani { get; set; }
        public int drtivost { get; set; }
        public int zlomenina { get; set; }
        public int ohen { get; set; }
        public int blesky { get; set; }
        /* **                         ** */

        public int vydrzZbrane { get; set; }




        /*** Specifická zbroj a HP ***/

        public int HpTvar { get; set; }
        public int HpNos { get; set; }
        public int HpLeveOko { get; set; }
        public int HpPraveOko { get; set; }
        public int HpUsta { get; set; }
        public int HpLeveUcho { get; set; }
        public int HpPraveUcho { get; set; }
        public int HpLevaNoha { get; set; }
        public int HpPravaNoha { get; set; }
        public int ZbLevaNoha { get; set; }
        public int ZbPravaNoha { get; set; }
        public int HpTorzo { get; set; }
        //public int HpPrsa { get; set; }
        //public int HpBricho { get; set; }
        public int HpLevaRuka { get; set; }
        public int HpPravaRuka { get; set; }
        public int HpLevaDlan { get; set; }
        public int HpPravaDlan { get; set; }
        public int HpKrk { get; set; }
        public int HpLeveChodidlo { get; set; }
        public int HpPraveChodidlo { get; set; }
        public int HpHlava { get; set; }

        public int ZbTorzo { get; set; }
        public int ZbLevaDlan { get; set; }
        public int ZbPravaDlan { get; set; }
        public int ZbLeveChodidlo { get; set; }
        public int ZbPraveChodidlo { get; set; }
        public int ZbHlava { get; set; }
        public int ZbNohy { get; set; }
        public int ZbTvar { get; set; }
        public int hp { get; set; }        //32
        public int maxHP { get; set; }      //33
        public int mp { get; set; }         //34
        public int maxMP { get; set; }

        public Being()
        {
            sestiStenka = new Kostka(6);            //1
            dsS = new Kostka(27);       //2
            stoS = new Kostka(100);
        }

        public Being( string jmeno, string rasa, string povolani, string specializace, int uroven, 
        int zk, int sil, int obr, int zruc, int vit, int roz, int duvt, int vul, int cha, int bo, 
        int bn, int bu, string zbran, int presnost, int vyhnuti, int pruraznost, int nicivost, 
        int vydrzZbrane, int HpTvar, int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta, int HpLeveUcho,
        int HpPraveUcho, int HpPravaNoha, int HpLevaNoha, int HpTorzo, int HpLevaRuka, 
        int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo,
        int HpHlava, int ZbNohy, int ZbTorzo, int ZbLevaDlan, int ZbPravaDlan, 
        int ZbLeveChodidlo, int ZbPraveChodidlo, int ZbHlava, int ZbTvar, int ZbStit)
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

            this.ZbStit = ZbStit;
        }

/*
        public List<Being> LoadPlayer()
        {
            var charList = new List<Being>();
            using (var sql_con = new SQLiteConnection("Data Source=DB_RIN-Console.sqlite;Version=3;"))
            {
                sql_con.Open();
                string sql = "SELECT * FROM characters where id like " + id + "";
                using (var command = new SQLiteCommand(sql, sql_con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Being = new Being();
                            jmeno = reader["jmeno"].ToString();
                            //rasa = reader["rasa"].ToString();
                            //povolani = reader["povolani"].ToString();

                            //Convert.ToInt32(reader["Age"])

                            charList.Add(Being);
                        }
                    }
                }
            }
            sql_con.Close();
            return charList;
          
        }
*/
        public string DBgetValueS(string typeOfValue)
        {
            string valueS = "";
            sql_con.Open();
            string sql = "SELECT "+typeOfValue+" FROM characters where id like " + id + "";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        valueS = reader["jmeno"].ToString();
                    }
                }
            sql_con.Close();
            return valueS;


        }


        public int DBgetValueI(string typeOfValue)
        {
            int valueI = 0;
            sql_con.Open();
            string sql = "SELECT " + typeOfValue + " FROM characters where id like " + id + "";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            command.ExecuteNonQuery();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    valueI = (int) reader[typeOfValue];
                }
            }
            sql_con.Close();
            return valueI;


        }

        public void DBsetValuerS(string vlastnost, string sValue)
        {
            sql_con.Open();
            string sql_ = "UPDATE characters SET "+vlastnost+" = '"+sValue+"' WHERE id ="+id+"";
            SQLiteCommand command = new SQLiteCommand(sql_, sql_con);
            command.ExecuteNonQuery();
            sql_con.Close();
        }


        public void DBsetValueI(string vlastnost, int iValue)
        {
            sql_con.Open();
            string sql_ = "UPDATE characters SET " + vlastnost + " = " + iValue + " WHERE id =" + id + "";
            SQLiteCommand command = new SQLiteCommand(sql_, sql_con);
            command.ExecuteNonQuery();
            sql_con.Close();
        }


        public void DBInit()
        {
            SQLiteConnection.CreateFile("DB_RIN-Console.sqlite");

            sql_con = new SQLiteConnection("Data Source=DB_RIN-Console.sqlite;Version=3;");
            sql_con.Open();

            string sql = "create table characters (id int, jmeno varchar(20), rasa varchar(20), povolani varchar(20), specializace varchar(20), uroven int, zk int, sil int, silOprava int, obr int, obrOprava int, zruc, zrucOprava int, vit int, vitOprava int, roz int, rozOprava int, dum int, dumOprava int, vul int, vulOprava int, cha int, chaOprava int, bo int, bm int, bu int, zbran varchar(20), presnost int, vyhnuti int, krvaceni int, infekce int, dychani int , filtrace int, pruraznost int, nicivost int, bodani int, sekani int, drtivost int, ozbrojeni int, ohen int, blesky int, mraz int, rychlost int, omraceni int, vydrzZbrane int, hp int, maxHP int, mp int, maxMP int, HpTvar int, HpNos int, HpLeveOko int, HpPraveOko int, HpUsta int, HpLeveUcho int, HpPraveUcho int, HpLevaNoha int, HpPravaNoha int, HpTorzo int, HpLevaRuka int, HpPravaRuka int, HpLevaDlan int, HpPravaDlan int, HpKrk int, HpLeveChodidlo int, HpPraveChodidlo int, HpHlava int, ZbNohy int, ZbTorzo int, ZbLevaDlan int, ZbPravaDlan int, ZbLeveChodidlo int, ZbPraveChodidlo int, ZbHlava int, ZbTvar int, HpPrstyLeveRuky int, HpPrstyPraveRuky int, HpPalecLeveRuky int, HpPalecPraveRuky int, HpPrstyLevehoChodidla int,  HpPrstyPravehoChodidla int,HpPalecLevehoChodidla int, HpPalecPravehoChodidla int, ZbStit int)";

            SQLiteCommand command = new SQLiteCommand(sql, sql_con);

            command.ExecuteNonQuery();
            //vložení do DB herní charakter Artym
            //sql = "insert into characters (jmeno , rasa , povolani , specializace , uroven , zk , sil , silOprava , obr , obrOprava , zruc, zrucOprava , vit , vitOprava , roz , rozOprava , dum , dumOprava , vul , vulOprava , cha , chaOprava, bo , bm , bu , zbran , presnost , vyhnuti , krvaceni , infekce , dychani  , filtrace , pruraznost , nicivost , bodani , sekani , drtivost , ozbrojeni , ohen , blesky , mraz ,  rychlost , omraceni , vydrzZbrane , hp , maxHP , mp , maxMP , HpTvar , HpNos , HpLeveOko , HpPraveOko , HpUsta , HpLeveUcho , HpPraveUcho , HpLevaNoha , HpPravaNoha , HpTorzo , HpLevaRuka , HpPravaRuka , HpLevaDlan , HpPravaDlan , HpKrk , HpLeveChodidlo , HpPraveChodidlo , HpHlava , ZbNohy , ZbTorzo , ZbLevaDlan , ZbPravaDlan , ZbLeveChodidlo , ZbPraveChodidlo , ZbHlava , ZbTvar, HpPrstyLeveRuky, HpPrstyPraveRuky, HpPalecLeveRuky, HpPalecPraveRuky, HpPrstyLevehoChodidla, HpPrstyPravehoChodidla, HpPalecLevehoChodidla, HpPalecPravehoChodidla) values ('Artym', 'Člověk', 'Architekt', '-', 1, 0, 16, 2, 14, 1, 15, 2, 13, 1, 11, 0, 12, 0, 17, 3, 18, 3, 2, 1, 1, 'Dvě dýky', 7, 6, 10, 10, 10, 10, 2, 0, 2, 3, 0, 2, 0, 0, 0, 3, 0, 21, 16, 16, 42, 42, 3, 2, 0, 5, 5, 3, 3, 10, 10, 10, 10, 10, 5, 5, 4, 5, 5, 10, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 1, 1, 4, 4, 1, 1)";

            //command = new SQLiteCommand(sql, sql_con);
            //command.ExecuteNonQuery();

            sql_con.Close();
        }

        public void DBdropTable()
        {
            
            sql_con = new SQLiteConnection("Data Source=DB_RIN-Console.sqlite.sqlite;Version=3;");
            sql_con.Open();

            string sql = " DROP Table 'characters'";
            //m_dbConnection.CommandText = ;
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            command.ExecuteNonQuery();
        }
        /*
        public Being(string jmeno, string rasa, string povolani, string specializace, int uroven, int zk, int sil, int obr, int zruc, int vit, int roz, int duvt, int vul, int cha, int bo, int bn, int bu, string zbran, int presnost, int vyhnuti, int pruraznost, int nicivost, int vydrzZbrane, int HpTvar, int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta, int HpLeveUcho, int HpPraveUcho, int HpPravaNoha, int HpLevaNoha, int HpTorzo, int HpLevaRuka, int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo, int HpHlava, int ZbNohy, int ZbTorzo, int ZbLevaDlan, int ZbPravaDlan, int ZbLeveChodidlo, int ZbPraveChodidlo, int ZbHlava, int ZbTvar, int zbTvar) : this(jmeno, rasa, povolani, specializace, uroven, zk, sil, obr, zruc, vit, roz, duvt, vul, cha, bo, bn, bu, zbran, presnost, vyhnuti, pruraznost, nicivost, vydrzZbrane, HpTvar, HpNos, HpLeveOko, HpPraveOko, HpUsta, HpLeveUcho, HpPraveUcho, HpPravaNoha, HpLevaNoha, HpTorzo, HpLevaRuka, HpPravaRuka, HpLevaDlan, HpPravaDlan, HpKrk, HpLeveChodidlo, HpPraveChodidlo, HpHlava, ZbNohy, ZbTorzo, ZbLevaDlan, ZbPravaDlan, ZbLeveChodidlo, ZbPraveChodidlo, ZbHlava, ZbTvar)
        {
            this.ZbTvar = zbTvar;
        }
        */
        public bool Nazivu()
        {
            return (maxHP > 0);
        }

        public void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

        public string VratPosledniZpravu()
        {
            return zprava;
        }

        public string GrafickyUkazatel(int aktualni, int maximalni)
        {

            string s = "";
            int celkem = 20;
            double pocet = Math.Round(((double)aktualni / maximalni) * celkem);
            if ((pocet == 0) && (Nazivu()))
                pocet = 1;
            for (int i = 0; i < pocet; i++)
                s += "#";
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
            int zasah = DBgetValueI("presnost") + sestiStenka.hod();
            int h_pruraznost = DBgetValueI("pruraznost");
            int h_nicivost = DBgetValueI("nicivost");

            NastavZpravu(string.Format("Charakteru {0} útočí s úderem prenosti {1} ", jmeno, zasah));
            souper.BranSe(zasah, h_pruraznost, h_nicivost);
        }

        public void BranSe(int zasah, int h_pruraznost, int h_nicivost)
        {
            // hodnota k vyhodnoceni úspěšného zásahu => uz
            int obrana = DBgetValueI("vyhnuti") + sestiStenka.hod();
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
                        poskZb = DBgetValueI("ZbTvar") - h_nicivost;
                        // pokud je poskZb->poškození celkové zbroje menší než 0, tak logicky dojde ke zranění
                        if (poskZb < 0)
                        {
                            // pokud má hráč více bodů osudu než 0, tak se může rozhodnout zranění resetovat
                            if (bo > 0)
                            {

                                zprava = string.Format("Charakteru {0} hrozí možná znatelný útok směřovaný na {1}!! Chce použít svůj osud? Odpovídejte pouze a/n.", jmeno, castTela[indexCT]);
                                NastavZpravu(zprava);
                                bool correct = false;
                                do
                                {
                                    char rozh = Console.ReadKey().KeyChar;

                                    if (rozh == 'a' || rozh == 'n' || rozh == 'A' || rozh == 'N')
                                    {
                                        if (rozh == 'a' || rozh == 'A')
                                        {
                                            zprava = string.Format("Charakteru {0} pomocí osudu se ušetřil od zranění na {1}!", jmeno, castTela[indexCT]);
                                            NastavZpravu(zprava);
                                        }
                                        else
                                        {
                                            // hráč se rozhodl nevyužít body osudu, tak dostane zranění 
                                            int befHpLeveOko = DBgetValueI("HpLeveOko");
                                            int afHpLeveOko = befHpLeveOko - (h_pruraznost / DBgetValueI("ZbTvar"));
                                            DBsetValueI("HpLeveOko", afHpLeveOko);
                                            int befHP = DBgetValueI("hp");
                                            int afHP = befHP -(h_pruraznost / DBgetValueI("ZbTvar"));
                                            DBsetValueI("hp", afHP);
                                            DBsetValueI("ZbTvar", 0);
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
                                int befHpLeveOko = DBgetValueI("HpLeveOko");
                                int afHpLeveOko = befHpLeveOko - (h_pruraznost / DBgetValueI("ZbTvar"));
                                DBsetValueI("HpLeveOko", afHpLeveOko);
                                int befHP = DBgetValueI("hp");
                                int afHP = befHP - (h_pruraznost / DBgetValueI("ZbTvar"));
                                DBsetValueI("hp", afHP);
                                DBsetValueI("ZbTvar", 0);
                            }
                        }
                        else
                        {
                            //dojde k částečnému zničení zbroje
                            int befZbTvar = DBgetValueI("ZbTvar");
                            int afZbTvar = befZbTvar - poskZb;
                            DBsetValueI("ZbTvar", afZbTvar);
                            ZbTvar -= poskZb;
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
