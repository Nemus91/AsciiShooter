using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses;
using AsciiShooter.BasicClasses.Manager;
using AsciiShooter.Entities;

namespace AsciiShooter
{
    class Shop : GameObject
    {

        Map map;

        public static bool checkedmoney;

//Fictional money ammounts
        public static int mp5value = 200;
        public static int mp5ammovalue = 20;
        public static int ak47value = 500;
        public static int ak47ammovalue = 50;
        public static int rlvalue = 1000;
        public static int rocketvalue = 100;

        public static int armorvalue = 75;

        public Shop (int Width, int Height)
        {
            map = new Map (Width, Height);
            MenuInit();
        }


//FUNKTION DAS MAN MEHRERE SACHEN AUSWHÄLEN KANN??????? bzw erneut wählen kann
        private static void MenuInit()
        {
                Player player = new Player(0, 0);


                Menu ShopMenu = new Menu(8);

                Action tempAction = new Action(BuyMP5);
                ShopMenu.SetButton(0, "MP5                  -   " + mp5value + "G", tempAction);

                tempAction = new Action(MP5Ammo);
                ShopMenu.SetButton(1, "MP5-Ammo + 10        -   " + mp5ammovalue + "G", tempAction);

                tempAction = new Action(BuyAk47);
                ShopMenu.SetButton(2, "AK47                 -   " + ak47value + "G", tempAction);

                tempAction = new Action(AKAmmo);
                ShopMenu.SetButton(3, "AK47-Ammo + 10       -   " + ak47ammovalue + "G", tempAction);

                tempAction = new Action(BuyRocketLauncher);
                ShopMenu.SetButton(4, "RocketLauncher       -   " + rlvalue + "G", tempAction);

                tempAction = new Action(RocketAmmo);
                ShopMenu.SetButton(5, "Rockets + 3          -   " + rocketvalue + "G", tempAction);

                tempAction = new Action(BuyArmor);
                ShopMenu.SetButton(6, "Armor + 5            -   " + armorvalue + "G", tempAction);

                tempAction = new Action(Exit);
                ShopMenu.SetButton(7, "Start next Level", tempAction);

        }

        private static void BuyMP5()
        {
            Player player = new Player(0, 0);

            CheckMoney(mp5value);

            if (checkedmoney == true)
            {
                player.Money -= mp5value;
                player.Weapon = "MP5";

                MP5 mp = new MP5();
                player.Weaponlist.Add(mp);
            }

        }

        private static void MP5Ammo()
        {
            Player player = new Player(0, 0);

            CheckMoney(mp5ammovalue);

            if (checkedmoney == true)
            {
                player.Money -= mp5ammovalue;
                player.Ammo += 10;
            }
        }

        private static void BuyAk47()
        {
            Player player = new Player(0, 0);

            CheckMoney(ak47value);

            if (checkedmoney == true)
            {
                player.Money -= ak47value;
                player.Weapon = "AK47";

                Ak47 ak = new Ak47();
                player.Weaponlist.Add(ak);
            }
        }

        private static void AKAmmo()
        {
            Player player = new Player(0, 0);

            CheckMoney(ak47ammovalue);

            if (checkedmoney == true)
            {
                player.Money -= ak47ammovalue;
                player.Ammo += 10;
            }
        }

        private static void BuyRocketLauncher()
        {
            Player player = new Player(0, 0);

            CheckMoney(rlvalue);

            if (checkedmoney == true)
            {
                player.Money -= rlvalue;
                player.Weapon = "RL";

                Rocketlauncher rl = new Rocketlauncher();
                player.Weaponlist.Add(rl);
            }
        }

        private static void RocketAmmo()
        {
            Player player = new Player(0, 0);

            CheckMoney(rocketvalue);

            if (checkedmoney == true)
            {
                player.Money -= rocketvalue;
                player.Ammo += 3;
            }
        }

        private static void BuyArmor()
        {
            Player player = new Player(0, 0);

            CheckMoney(armorvalue);

            if (checkedmoney == true)
            {
                player.Money -= armorvalue;
                player.Armor += 5;
            }
        }

        private static bool CheckMoney(int amount)
        {
            Player player = new Player(0, 0);

            if (player.Money >= amount)
            {
                return checkedmoney = true;
            }
                
            else
            {
               return checkedmoney = false;
            }
        }

        private static void Exit()
        {
// BITTE FÜLL MICH AUS^^
        }
    
    }
}
