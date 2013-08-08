using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.Entities;

namespace AsciiShooter
{
   public class Player : MoveableObject  
    {
       public Game Game;

       public override char VisRepresentation
       {
           get { return (char)64; }
       }

       public Player (int x, int y)
       {
           Position.X = x;
           Position.Y = y;
           Velocity = new Vector2(0, 0);
           Pistol Pistol = new Pistol();
           Weaponlist.Add(Pistol);
           ShowWeapon();
           Console.SetCursorPosition(0, 51);
           Console.Write("Armor: 0");
           Console.SetCursorPosition(0, 53);
           Console.Write("Money: 0");
       }

       public int Armor = 0;
       public int Health = 50;
       public int Money = 0;
       private int Movementspeed = 4;

       private int displayedArmor;
       private int displayedHealth;
       private int displayedMoney;

       private Vector2 mView;
       private Vector2 View
       {
           get
           {
               return mView;
           }
           set
           {
               if (!value.Equals(new Vector2(0,0)))
               {
                    mView = value;
               }
           }
       }

       private List<Weapon> Weaponlist = new List<Weapon>();

       private int CurrentWeapon = 0;

       public override void Update()
       {
           Controlls();
           Stats();
       }

       private void Stats()
       {
           if (Armor != displayedArmor)
           {
               Console.SetCursorPosition(0, 51);
               Console.Write("               ");
               Console.SetCursorPosition(0, 51);
               Console.Write("Armor: "+Armor);
               displayedArmor = Armor;
           }

           if (Health != displayedHealth)
           {
               Console.SetCursorPosition(0, 52);
               Console.Write("               ");
               Console.SetCursorPosition(0, 52);
               Console.Write("Health: " + Health);
               displayedHealth = Health;
           }

           if (Money != displayedMoney)
           {
               Console.SetCursorPosition(0, 53);
               Console.Write("               ");
               Console.SetCursorPosition(0, 53);
               Console.Write("Money: "+Money);
               displayedMoney = Money;
           }
       }

       private void ShowWeapon()
       {
           Console.SetCursorPosition(0, 54);
           Console.Write("                    ");
           Console.SetCursorPosition(0, 54);
           Console.Write(Weaponlist[CurrentWeapon].GetType());
           
       }


       private void Controlls()
       {
           if (Input.GetKeyState(ConsoleKey.S) == Input.AsyncKeyState.CurrentlyPressed)
           {
               Velocity.Y = Movementspeed;
           }
           else
           {
               if (Input.GetKeyState(ConsoleKey.W) == Input.AsyncKeyState.CurrentlyPressed)
                   Velocity.Y = -Movementspeed;
               else
                   Velocity.Y = 0;
           }

           if (Input.GetKeyState(ConsoleKey.D) == Input.AsyncKeyState.CurrentlyPressed)
           {
               Velocity.X = Movementspeed;
           }
           else
           {
               if (Input.GetKeyState(ConsoleKey.A) == Input.AsyncKeyState.CurrentlyPressed)
                   Velocity.X = -Movementspeed;
               else
                   Velocity.X = 0;
           }
           // sight
           if (Input.GetKeyState(ConsoleKey.DownArrow) == Input.AsyncKeyState.CurrentlyPressed)
           {
               View.Y = -1;
           }
           else
           {
               if (Input.GetKeyState(ConsoleKey.UpArrow) == Input.AsyncKeyState.CurrentlyPressed)
           {
               View.Y = 1;

           if (Input.GetKeyState(ConsoleKey.RightArrow) == Input.AsyncKeyState.CurrentlyPressed)
           {
               View.X = 1;
           }
           else
           {

           if (Input.GetKeyState(ConsoleKey.LeftArrow) == Input.AsyncKeyState.CurrentlyPressed)
           {
               View.X = -1;
           }

           //Weaponchange
           if (Input.GetKeyState(ConsoleKey.Q) == Input.AsyncKeyState.HasBeenPressed && CurrentWeapon > 0)
           {
               CurrentWeapon--;
               ShowWeapon();
           }

           if (Input.GetKeyState(ConsoleKey.E) == Input.AsyncKeyState.HasBeenPressed && CurrentWeapon < Weaponlist.Count -1)
           {
               CurrentWeapon++;
               ShowWeapon();
           }

           if (Input.GetKeyState(ConsoleKey.Spacebar) == Input.AsyncKeyState.CurrentlyPressed)
           {
               System.Diagnostics.Debug.Write("Shoot");
               Bullet B = new Bullet();
               Game.AddEntity(B);
               B.Position = new Vector2(Position + View);
               B.Damage = Weaponlist[CurrentWeapon].Damage;
               B.Velocity = new Vector2(Weaponlist[CurrentWeapon].Bulletspeed * View.X, Weaponlist[CurrentWeapon].Bulletspeed * View.Y);
               B.Range = Weaponlist[CurrentWeapon].Range;
           }
           //ConsoleKeyInfo info;
           //if (Console.KeyAvailable)
           //{
           //     info = Console.ReadKey();
           //     switch (info.Key)
           //     {
           //         case ConsoleKey.S:
           //             Velocity.Y = Movementspeed;
           //             break;

           //         case ConsoleKey.W:
           //             Velocity.Y =- Movementspeed;
           //             break;

           //         case ConsoleKey.A:
           //             Velocity.X =- Movementspeed;
           //             break;

           //         case ConsoleKey.D:
           //             Velocity.X = Movementspeed;
           //             break;

           //         case ConsoleKey.UpArrow:
           //             View.X = 0;
           //             View.Y = 1;
           //             break;

           //         case ConsoleKey.DownArrow:
           //             View.X = 1;
           //             View.Y = 0;
           //             break;

           //         case ConsoleKey.RightArrow:
           //             View.X = 1;
           //             View.Y = 0;
           //             break;

           //         case ConsoleKey.LeftArrow:
           //             View.X = -1;
           //             View.Y = 0;
           //             break;


           //     }

           //}

      
       }
    }
}
