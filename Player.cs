using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
   public class Player : MoveableObject
    {
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
           }
           switch (info.Key)
           {
               case ConsoleKey.W:
                   Position.X++;
                   break;
           }
       }
    }
}
