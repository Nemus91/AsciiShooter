using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiShooter
{
    public class Gear
    {
        public string actualWeapon = "Gun";
        public string nextWeapon = "Gatlingun";

        public void Upgrade()
        {
            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    if (y == 0 || y == 49)
                    {
                        //Map[x, y] = (char)45;
                        Console.SetCursorPosition(x, y);
                        Console.Write("#");
                    }
                    else
                    {
                        if (x == 0 || x == 99)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("#");
                        }
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(" ");
                        }
                    }
                }
            }

            string s = Console.ReadLine();
            int n = int.Parse(s);

            switch (n)
            {
                case 1: Console.WriteLine("Waffe");
                    Console.ReadLine();
                    break;

                case 2: Console.WriteLine("Rüstung");
                    Console.ReadLine();
                    break;

                case 3: Console.WriteLine("Leben");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe");
                    Console.ReadLine();
                    break;
            }

        }
    }
}