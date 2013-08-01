using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
   public class Player : MoveableObject
  
    {
       public Player (int x, int y)
       {
           Position.X = x;
           Position.Y = y;
       }

       private Vector2 View = new Vector2 (1,0);

       private List<GameObject> Weaponlist = new List<GameObject>();

       private int CurrentWeapon = 0;

       public override void Update()
       {
           Controlls();
       }
       private void Controlls()
       {
           ConsoleKeyInfo info;
           if (Console.KeyAvailable)
           {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.W:
                        Position.Y++;
                        break;

                    case ConsoleKey.S:
                        Position.Y--;
                        break;

                    case ConsoleKey.A:
                        Position.X--;
                        break;

                    case ConsoleKey.D:
                        Position.X++;
                        break;

                    case ConsoleKey.UpArrow:
                        View.X = 0;
                        View.Y = 1;
                        break;

                    case ConsoleKey.DownArrow:
                        View.X = 1;
                        View.Y = 0;
                        break;

                    case ConsoleKey.RightArrow:
                        View.X = 1;
                        View.Y = 0;
                        break;

                    case ConsoleKey.LeftArrow:
                        View.X = -1;
                        View.Y = 0;
                        break;
                }

             //  case ConsoleKey.Q:
            //       int = 

           }

      
       }
    }
}
