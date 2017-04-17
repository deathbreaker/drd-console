using System.IO;
using System;


namespace RIN_Console.SystemHelper.characters.staticc
{
    class ArtymS
    {
        //IDictionary<string, int> zb = new Dictionary<string, int>();
        //IDictionary<string, int> teloHP = new Dictionary<string, int>();

        /// Poslední zpráva
        public bool magician = false;
        public string jmeno { get; set; }
        //public string rasa;  //0
        //public string povolani; //1
        //public string specializace; //2
        //public int uroven; //3
        //public int zk; //4

        //public int sil;  //5
        //public int obr;  //6
        //public int zruc; //7
        //public int vit; //8
        //public int roz; //9
        //public int duvt; //10
        //public int vul; //11
        //public int cha; //12

        /*
        public int bo; //13
        public int bm; //14
        public int bu; //15
        */

        //*********************bojové statistiky
        //*********************atributy hracské zbraňě
        //public string zbran;   //16
        //public int presnost; //17
        //public int vyhnuti;  //18

        public int krvaceni;   //19
        public int infekce;    //20
        public int dychani;    //21
        public int filtrace;    //22




        //public int pruraznost; //23
        //public int nicivost;   //24
        //u normálnich zbraní 50% že se jim podaří zničit brnění


        public int bodani;       //25
        public int sekani;       //26
        public int drtivost;     //27
        public int zlomenina;    //28
        public int ohen;         //29
        public int blesky;       //30
                                    //public int vydrz_zbrane; //31



        //public int hp;         //32
        //public int maxHP;      //33
        //public int mp;         //34
        //public int maxMP;      //35



        public int magenergie { get; set; }
        public int dosah { get; set; }
        public int rozsah { get; set; }
        public int vyvolavani { get; set; }
        public int trvani { get; set; }
        public int prvdKouzla { get; set; }
        public int pocetKouzel { get; set; }


        private static string character = "Artym";

        private bool x;




        public ArtymS()
        {
        
        }

        public ArtymS(bool x)
        {
            setJmeno("Artym");
            setUroven(string.Empty + 1);
            setRasa("Člověk");
            setTrade("Architekt");
            setZK("0");
            setSil("2");
            setObr("1");
            setZruc("2");
            setVit("1");
            setRoz("0");
            setDuvt("0");
            setVul("3");
            setChar("3");
            
            setBO("2");
            setBN("1");
            setBU("1");

            setPresnost("7");
            setVyhnuti("6");

            setJmenoZbrane("Dvě dýky");
            setVydrzZbrane("19");
            setPruraznost("2");
            setNicivost("0");

            setHpHlava("9");
            setHpLeveOko("0");
            setHpPraveOko("5");
            setHpLeveUcho("3");
            setHpPraveUcho("3");
            setHpUsta("5");
            setHpNos("2");
            setHpTorzo("10");
            setHpLevaRuka("10");
            setHpPravaRuka("10");
            setHpLevaDlan("5");
            setHpPravaDlan("5");
            setHpLevaNoha("10");
            setHpPravaNoha("10");
            setHpPraveChodidlo("5");
            setHpLeveChodidlo("5");

            setZbHlava("1");
            setZbNohy("1");
            setZbLevaRukavice("1");
            setZbLeveChodidlo("1");
            setZbPravaRukavice("1");
            setZbPraveChodidlo("1");
            setZbStit("0");
            setZbTorzo("1");
            setZbTvar("0");

            this.x = x;
        }

        public ArtymS(string jmeno, string rasa, string povolani, string specializace, int uroven, int zk, int sil, int obr, int zruc, int vit, int roz, int duvt, int vul, int cha,
                      int bo, int bn, int bu, string zbran, int presnost, int vyhnuti, int pruraznost, int nicivost, int vydrzZbrane, int hp, int maxHP, int mp, int maxMP, int HpTvar,
                      int HpNos, int HpLeveOko, int HpPraveOko, int HpUsta, int HpLeveUcho, int HpPraveUcho, int LevaNoha, int HpPravaNoha, int HpPrsa, int HpBricho, int HpLevaRuka,
                      int HpPravaRuka, int HpLevaDlan, int HpPravaDlan, int HpKrk, int HpLeveChodidlo, int HpPraveChodidlo, int HpHlava, int ZbLevaNoha, int ZbPravaNoha, int ZbTorzo,
                      int ZbLevaDlan, int ZbPravaDlan, int ZbLeveChodidlo, int ZbPraveChodidlo, int ZbHlava, int ZbNohy, int ZbTvar)
        {

            setJmeno(jmeno);
            setUroven(rasa);
            setRasa("Člověk");
            setTrade("Architekt");
            string actZk = string.Empty + zk;
            setZK(actZk);
            string actSil = string.Empty + zk;
            setSil(actSil);
            string actObr = string.Empty + zk;
            setObr(actObr);
            string actZruc = string.Empty + zk;
            setZruc(actZruc);
            string actOdl = string.Empty + zk;
            setVit(actOdl);
            string actRoz = string.Empty + zk;
            setRoz(actRoz);
            string actDuvt = string.Empty + zk;
            setDuvt(actDuvt);
            string actVul = string.Empty + zk;
            setVul(actVul);
            string actChar = string.Empty + zk;
            setChar(actChar);
            string actBO = string.Empty + zk;
            setBO(actBO);
            string actBN = string.Empty + zk;
            setBN(actBN);
            string actBU = string.Empty + zk;
            setBU(actBU);

            string actPresnost = getZruc() + 5 + string.Empty;
            setPresnost(actPresnost);
            string actVyhnuti = getObr() + 5 + string.Empty;
            setVyhnuti(actVyhnuti);

            
            setJmenoZbrane(zbran);
            string vydrZbrane = vydrzZbrane + string.Empty;
            setVydrzZbrane(vydrZbrane);
            string pruz = pruraznost + string.Empty;
            setPruraznost(pruz);
            string niciv = nicivost + string.Empty;
            setNicivost(niciv);
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






        //přehled kondice

        //zbroj a obrana

        //schopnosti hráčského povolaní a dovednosti
        private void writeDescriptionInTxts()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";

            int line1 = 1;
            string[] arrLine1 = File.ReadAllLines(fName);
            arrLine1[line1 - 1] = "Jméno charakteru";
            File.WriteAllLines(fName, arrLine1);

            int line3 = 3;
            string[] arrLine3 = File.ReadAllLines(fName);
            arrLine3[line3 - 1] = "Rasa";
            File.WriteAllLines(fName, arrLine3);

            int line6 = 6;
            string[] arrLine6 = File.ReadAllLines(fName);
            arrLine6[line6 - 1] = "Povolání";
            File.WriteAllLines(fName, arrLine6);

            int line9 = 9;
            string[] arrLine9 = File.ReadAllLines(fName);
            arrLine9[line9 - 1] = "Specializace";
            File.WriteAllLines(fName, arrLine9);

            int line12 = 12;
            string[] arrLine12 = File.ReadAllLines(fName);
            arrLine12[line12 - 1] = "Úroven";
            File.WriteAllLines(fName, arrLine12);

            int line15 = 15;
            string[] arrLine15 = File.ReadAllLines(fName);
            arrLine15[line15 - 1] = "Zkušenosti";
            File.WriteAllLines(fName, arrLine15);

            int line18 = 18;
            string[] arrLine18 = File.ReadAllLines(fName);
            arrLine18[line18 - 1] = "Síla";
            File.WriteAllLines(fName, arrLine18);

            int line21 = 21;
            string[] arrLine21 = File.ReadAllLines(fName);
            arrLine21[line21 - 1] = "Obratnost";
            File.WriteAllLines(fName, arrLine21);


            int line24 = 24;
            string[] arrLine24 = File.ReadAllLines(fName);
            arrLine24[line24- 1] = "Zručnost";
            File.WriteAllLines(fName, arrLine24);


            int line27 = 27;
            string[] arrLine27 = File.ReadAllLines(fName);
            arrLine27[line27 - 1] = "Vitalita";
            File.WriteAllLines(fName, arrLine27);

            int line30 = 30;
            string[] arrLine30 = File.ReadAllLines(fName);
            arrLine30[line30 - 1] = "Rozum";
            File.WriteAllLines(fName, arrLine30);


            int line33 = 33;
            string[] arrLine33 = File.ReadAllLines(fName);
            arrLine33[line33 - 1] = "Důmysl";
            File.WriteAllLines(fName, arrLine33);

            int line36 = 36;
            string[] arrLine36 = File.ReadAllLines(fName);
            arrLine36[line36 - 1] = "Vůle";
            File.WriteAllLines(fName, arrLine36);

            int line39 = 39;
            string[] arrLine39 = File.ReadAllLines(fName);
            arrLine39[line39 - 1] = "Charisma";
            File.WriteAllLines(fName, arrLine39);

            int line42 = 42;
            string[] arrLine42 = File.ReadAllLines(fName);
            arrLine42[line42 - 1] = "Body Osudu";
            File.WriteAllLines(fName, arrLine42);

            int line45 = 45;
            string[] arrLine45 = File.ReadAllLines(fName);
            arrLine45[line45 - 1] = "Body Nemilosti";
            File.WriteAllLines(fName, arrLine45);

            int line48 = 48;
            string[] arrLine48 = File.ReadAllLines(fName);
            arrLine48[line48 - 1] = "Body Uvědomění";
            File.WriteAllLines(fName, arrLine48);

            int line51 = 51;
            string[] arrLine51 = File.ReadAllLines(fName);
            arrLine51[line51 - 1] = "Zbraň";
            File.WriteAllLines(fName, arrLine51);

            int line54 = 54;
            string[] arrLine54 = File.ReadAllLines(fName);
            arrLine54[line54 - 1] = "Přesnost";
            File.WriteAllLines(fName, arrLine54);

            int line57 = 57;
            string[] arrLine57 = File.ReadAllLines(fName);
            arrLine57[line57 - 1] = "Vyhnuti";
            File.WriteAllLines(fName, arrLine57);

            int line60 = 60;
            string[] arrLine60 = File.ReadAllLines(fName);
            arrLine60[line60 - 1] = "Průraznost";
            File.WriteAllLines(fName, arrLine60);

            int line63 = 63;
            string[] arrLine63 = File.ReadAllLines(fName);
            arrLine63[line63 - 1] = "Výdrž zbraně";
            File.WriteAllLines(fName, arrLine63);

            int line66 = 66;
            string[] arrLine66 = File.ReadAllLines(fName);
            arrLine66[line66 - 1] = "HP Tvář";
            File.WriteAllLines(fName, arrLine66);

            int line69 = 69;
            string[] arrLine69 = File.ReadAllLines(fName);
            arrLine69[line69 - 1] = "HP Nos";
            File.WriteAllLines(fName, arrLine69);

            int line72 = 72;
            string[] arrLine72 = File.ReadAllLines(fName);
            arrLine72[line72 - 1] = "HP Levé oko";
            File.WriteAllLines(fName, arrLine72);

            int line75 = 75;
            string[] arrLine75 = File.ReadAllLines(fName);
            arrLine75[line75 - 1] = "HP Pravé oko";
            File.WriteAllLines(fName, arrLine75);

            int line78 = 78;
            string[] arrLine78 = File.ReadAllLines(fName);
            arrLine78[line78 - 1] = "HP Ústa";
            File.WriteAllLines(fName, arrLine78);

            int line81 = 81;
            string[] arrLine81 = File.ReadAllLines(fName);
            arrLine81[line81 - 1] = "HP Levé ucho";
            File.WriteAllLines(fName, arrLine81);

            int line84 = 84;
            string[] arrLine84 = File.ReadAllLines(fName);
            arrLine84[line84 - 1] = "HP Pravé ucho";
            File.WriteAllLines(fName, arrLine84);

            int line87 = 87;
            string[] arrLine87 = File.ReadAllLines(fName);
            arrLine87[line87 - 1] = "HP Levá noha";
            File.WriteAllLines(fName, arrLine87);

            int line90 = 90;
            string[] arrLine90 = File.ReadAllLines(fName);
            arrLine90[line90 - 1] = "HP Pravá noha";
            File.WriteAllLines(fName, arrLine90);





        }

        public  int getUroven()
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

        public  void setUroven(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 1;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getRasa()
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

        public  void setRasa(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 2;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getProfession()
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

        public  void setProfession(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 3;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getZK()
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

        public  void setZK(string newText)
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

        public  int getSil()
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

        public  void setSil(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 5;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getObr()
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

        public  void setObr(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 6;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getZruc()
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

        public  void setZruc(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 7;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getVit()
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

        public  void setVit(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 8;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getRoz()
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

        public  void setRoz(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 9;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getDuvt()
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

        public  void setDuvt(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 10;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getVul()
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

        public  void setVul(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 11;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getChar()
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

        public  void setChar(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 13;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        /******************** Konec základních vlastnosti ******************************/


        public  int getBO()
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

        public  void setBO(string newText)
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

        public  int getBN()
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

        public  void setBN(string newText)
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

        public  int getBU()
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

        public  void setBU(string newText)
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
        public  int getDrtivost()
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

        public  void setDrtivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 17;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getNicivost()
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

        public  void setNicivost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 18;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getPresnost()
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

        public  void setPresnost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 19;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getVyhnuti()
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

        public  void setVyhnuti(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 20;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************  Magická energie *********************************************/


        public  int getMaxTotalMP()
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

        public  void setMaxTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 21;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getTotalMP()
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

        public  void setTotalMP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 22;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
 
        /*******************************   ŽIVOTY ****************************************************/
        /*********************************************************************************************/

        public  int getMaxTotalHP()
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

        public  void setMaxTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 23;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getTotalHP()
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

        public  void setTotalHP(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 24;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpLeveOko()
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

        public  void setHpLeveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 25;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpPraveOko()
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

        public  void setHpPraveOko(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 26;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpUsta()
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

        public  void setHpUsta(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 27;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpLeveUcho()
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

        public  void setHpLeveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 28;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpPraveUcho()
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

        public  void setHpPraveUcho(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 29;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpNos()
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

        public  void setHpNos(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 30;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /****** */
        public  int getHpHlava()
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

        public  void setHpHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 31;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpTorzo()
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

        public  void setHpTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 32;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpLevaDlan()
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
        public  void setHpLevaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 34;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpPravaDlan()
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

        public  void setHpPravaDlan(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 35;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpPravaRuka()
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

        public  void setHpPravaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 36;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpLevaRuka()
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

        public  void setHpLevaRuka(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 37;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpLevaNoha()
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
        public  void setHpLevaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 38;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpPravaNoha()
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

        public  void setHpPravaNoha(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 39;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getHpLeveChodidlo()
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

        public  void setHpLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 40;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        public  int getHpPraveChodidlo()
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

        public  void setHpPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 41;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        public  int getHpTvar()
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

        public  void setHpTvar(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 42;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getHpKrk()
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
        public  void setHpKrk(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 43;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        /*******************************   ZBROJ  ****************************************************/
        public  int getZbHlava()
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

        public  void setZbHlava(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 44;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getZbTorzo()
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

        public  void setZbTorzo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 45;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getZbLevaChodidlo()
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 60;
            using (var sr = new StreamReader(fName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return int.Parse(sr.ReadLine());
            }
        }

        public  void setZbLevaChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 60;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);

        }



        public  int getZbLevaRukavice()
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
        public  void setZbLevaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 46;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        public  int getZbPravaRukavice()
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
        public  void setZbPravaRukavice(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 47;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        public  int getZbNohy()
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

        public  void setZbNohy(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 48;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getZbLeveChodidlo()
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

        public  void setZbLeveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 50;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }



        public  int getZbPraveChodidlo()
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

        public  void setZbPraveChodidlo(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 51;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getZbStit()
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

        public  void setZbStit(string newText)
        {

            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 52;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getZbTvar()
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

        public  void setZbTvar(string newText)
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
        public  int getTrade()
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

        public  void setTrade(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 54;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        /******************************** Dodatečná metoda - Výdrž zbraně   *************************************/

        public  int getVydrzZbrane()
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

        public  void setVydrzZbrane(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 55;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }

        public  int getJmenoZbrane()
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

        public  void setJmenoZbrane(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 56;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public  int getPruraznost()
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

        public  void setPruraznost(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 57;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public int getJmenoZbrane2()
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

        public void setJmenoZbrane2(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 56;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }


        public int getPruraznost2()
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

        public void setPruraznost2(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 57;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
        public int getNicivost2()
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

        public void setNicivost2(string newText)
        {
            string fName = "../../SystemHelper/txt-char/" + getJmeno() + ".txt";
            int line = 18;
            string[] arrLine = File.ReadAllLines(fName);
            arrLine[line - 1] = newText;
            File.WriteAllLines(fName, arrLine);
        }
    }
}
