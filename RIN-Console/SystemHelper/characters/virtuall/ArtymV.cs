using RIN_Console.SystemHelper.trade;
using System;
using System.Data.SQLite;

namespace RIN_Console.SystemHelper.characters.virtuall
{
    class ArtymV: Being, Architekt
    {
        
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




        public int magenergie { get; set; }
        public int dosah { get; set; }
        public int rozsah { get; set; }
        public int vyvolavani { get; set; }
        public int trvani { get; set; }
        public int prvdKouzla { get; set; }
        public int pocetKouzel { get; set; }
      //35

        private static int zpHP = 4;          //základní počet HP u daného herního povolání

        private static int levelHPModif = -1;


        public ArtymV()
        {

        }
        /*
        public ArtymV( string jmeno, string rasa, string povolani, string specializace, int uroven, int zk, int sil, int obr, 
            int zruc, int vit, int roz, int duvt, int vul, int cha, int bo, int bn, int bu, string zbran, int presnost, int vyhnuti,
            int pruraznost, int nicivost, int vydrzZbrane, int HpTvar, int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta,
            int HpLeveUcho, int HpPraveUcho, int HpPravaNoha, int HpTorzo, int HpLevaRuka, int HpLevaNoha, 
            int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo, int HpHlava, 
            int ZbTorzo, int ZbLevaDlan, int ZbPravaDlan, int ZbLeveChodidlo, int ZbPraveChodidlo,
            int ZbHlava, int ZbNohy, int ZbTvar): base( jmeno,  rasa,  povolani,  specializace,  uroven,  zk, sil,  obr,  zruc,  
                vit,  roz, duvt, vul, cha, bo, bn, bu, zbran, presnost, vyhnuti, pruraznost, nicivost, vydrzZbrane, HpTvar,
                HpNos, HpLeveOko, HpPraveOko, HpUsta, HpLeveUcho, HpPraveUcho, HpLevaNoha, HpPravaNoha, HpTorzo, HpLevaRuka,
                HpPravaRuka,  HpLevaDlan, HpPravaDlan, HpKrk, HpLeveChodidlo, HpPraveChodidlo, HpHlava, ZbNohy,  
                ZbTorzo, ZbLevaDlan, ZbPravaDlan,  ZbLeveChodidlo,  ZbPraveChodidlo, ZbHlava, ZbNohy, ZbTvar)
        {

            defaultInitHP();
            //valueManaPerLevel();
        }
        */
        

        public void passPrideBeforeFall()
        {
            
        }
        

        public void passFocusingEgoism(){}

        public void passSenseDanger(){}

        public void passSenseTrue(){}

        public void passSenseLie(){}

        public void passSenseHalfTrue(){}
        public void passInstablesness(){}

        public void actTrickeryBlessing(){}

        public void actGreenCard(){}

        public void actFortOL(){}

        public void actStrogngoldOL(){}

        public void actCastleOL(){}

        public void actCitadelOL(){}

        public void PalaceOL(){}

        public void demolitionOC(){}

        public void portrayalOP(){}

        public void inversionOI(){}

        public void bashFG(){}

        public void fateTransfer(){}

        public void split(){}

        public void ilussionShield(){}

        public void triumphOfForce(){}

        public void adabtiableObject(){}

        public void adaptableObject(){}

        public void adaptableLObject(){}

        public void falseSight(){}

        public void painConversion(){}

        public void DBdropTable()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = " DROP Table 'characters'";
            //m_dbConnection.CommandText = ;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        public void DBInit()
        {
            SQLiteConnection.CreateFile("DB_RIN-Console.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "create table characters (jmeno varchar(20), rasa varchar(20), povolani varchar(20), specializace varchar(20), uroven int, zk int, sil int, silOprava int, obr int, obrOprava int, zruc, zrucOprava int, vit int, vitOprava int, roz int, rozOprava int, dum int, dumOprava int, vul int, vulOprava int, cha int, chaOprava int, bo int, bm int, bu int, zbran varchar(20), presnost int, vyhnuti int, krvaceni int, infekce int, dychani int , filtrace int, pruraznost int, nicivost int, bodani int, sekani int, drtivost int, ozbrojeni int, ohen int, blesky int, mraz int, rychlost int, omraceni int, vydrzZbrane int, hp int, maxHP int, mp int, maxMP int, HpTvar int, HpNos int, HpLeveOko int, HpPraveOko int, HpUsta int, HpLeveUcho int, HpPraveUcho int, HpLevaNoha int, HpPravaNoha int, HpTorzo int, HpLevaRuka int, HpPravaRuka int, HpLevaDlan int, HpPravaDlan int, HpKrk int, HpLeveChodidlo int, HpPraveChodidlo int, HpHlava int, ZbNohy int, ZbTorzo int, ZbLevaDlan int, ZbPravaDlan int, ZbLeveChodidlo int, ZbPraveChodidlo int, ZbHlava int, ZbTvar int, HpPrstyLeveRuky int, HpPrstyPraveRuky int, HpPalecLeveRuky int, HpPalecPraveRuky int, HpPrstyLevehoChodidla int,  HpPrstyPravehoChodidla int,HpPalecLevehoChodidla int, HpPalecPravehoChodidla int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.ExecuteNonQuery();
            //vložení do DB herní charakter Artym
            sql = "insert into characters (jmeno , rasa , povolani , specializace , uroven , zk , sil , silOprava , obr , obrOprava , zruc, zrucOprava , vit , vitOprava , roz , rozOprava , dum , dumOprava , vul , vulOprava , cha , chaOprava, bo , bm , bu , zbran , presnost , vyhnuti , krvaceni , infekce , dychani  , filtrace , pruraznost , nicivost , bodani , sekani , drtivost , ozbrojeni , ohen , blesky , mraz ,  rychlost , omraceni , vydrzZbrane , hp , maxHP , mp , maxMP , HpTvar , HpNos , HpLeveOko , HpPraveOko , HpUsta , HpLeveUcho , HpPraveUcho , HpLevaNoha , HpPravaNoha , HpTorzo , HpLevaRuka , HpPravaRuka , HpLevaDlan , HpPravaDlan , HpKrk , HpLeveChodidlo , HpPraveChodidlo , HpHlava , ZbNohy , ZbTorzo , ZbLevaDlan , ZbPravaDlan , ZbLeveChodidlo , ZbPraveChodidlo , ZbHlava , ZbTvar, HpPrstyLeveRuky, HpPrstyPraveRuky, HpPalecLeveRuky, HpPalecPraveRuky, HpPrstyLevehoChodidla, HpPrstyPravehoChodidla, HpPalecLevehoChodidla, HpPalecPravehoChodidla) values ('Artym', 'Člověk', 'Architekt', '-', 1, 0, 16, 2, 14, 1, 15, 2, 13, 1, 11, 0, 12, 0, 17, 3, 18, 3, 2, 1, 1, 'Dvě dýky', 7, 6, 10, 10, 10, 10, 2, 0, 2, 3, 0, 2, 0, 0, 0, 3, 0, 21, 16, 16, 42, 42, 3, 2, 0, 5, 5, 3, 3, 10, 10, 10, 10, 10, 5, 5, 4, 5, 5, 10, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 1, 1, 4, 4, 1, 1)";


            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public void DBbringDataToTerm()
        {
        //SQLiteConnection  = new SQLiteConnection("Data Source=c:\\Dev\\MYApp.sqlite;Version=3;New=False;Compress=True;");
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            sql_con.Open();
            string sql = "select * from characters";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Jméno: " + reader["jmeno"] + "\tRasa: " + reader["rasa"]);

            Console.ReadKey();
        }


        public void defaultInitHP()
        {
            int HP = 0;

            for (int i = 1; i < uroven + 1; i++)
            {
                if (i == 1)
                {
                    HP = zpHP + vit;
                }
                else
                {
                    int narust = sestiStenka.hod() + levelHPModif + vit;
                    if (narust < 0)
                        narust = 0;

                    HP += narust;
                    
                }
            }

            hp = HP;
            maxHP = HP;

        }

        public void valueManaPerLevel(int uroven, int domVlastnost, double magicGrowth)
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
            mp = specMana;
            maxMP = specMana;
        }

        public void levelUp(int actHP, int levelHPModif)
        {
            int HP = actHP + sestiStenka.hod() + levelHPModif;
        }





    }
}
