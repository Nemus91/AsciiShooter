using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
   public class Player : MoveableObject
  
    {
       public override char VisRepresentation
       {
           get { return (char)64; }
       }

       public Player (int x, int y)
       {
           Position.X = x;
           Position.Y = y;
           Velocity = new Vector2(0, 0);
       }

       public int Armor = 0;
       public int Health = 50;
       public int Money = 0;
       private int Movementspeed = 4;

       private Vector2 View = new Vector2 (1,0);

       private List<GameObject> Weaponlist = new List<GameObject>();

       private int CurrentWeapon = 0;

       public override void Update()
       {
           Controlls();
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
