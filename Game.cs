using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class Game : GameObject
    {
        static char[,] Map;
        static char[,] lastMap;

        public Game(int Width, int Height)
        {
            Map = new char[Width, Height];
            lastMap = new char[Width, Height];
        }

        public override void Update()
        {
            Draw();
        }

        private static void Draw()
        {
            //Check for every Position if something changed and then rewrite it
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    if (Map[x, y] != lastMap[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(Map[x, y]);
                    }
                }
            }
            //Copy the data from Map into lastMap
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Array.Copy(Map, i * Map.GetLength(1), lastMap, i * Map.GetLength(1), Map.GetLength(1));
            }
        }



        //test methods
        static int z = 0;
        static Random a = new Random(20);
        static int v = 0;
        private static void ChangeMap()
        {
            z++;
            if (z % 4 == 0)
            {
                v++;
                int x = a.Next(Map.GetLength(0));
                int y = a.Next(Map.GetLength(1));
                int c = a.Next(20);
                if (v < 49)
                {
                    Map[v - 1, v - 1] = (char)0;
                    Map[v, v] = (char)(64);
                }
                if (v < 49)
                {
                    Map[2 * v - 2, v - 1] = (char)0;
                    Map[2 * v, v] = (char)(64);
                }
                else
                {
                    v = 0;
                }
                System.Diagnostics.Debug.WriteLine(v);
                Console.ReadKey();
            }
        }
    }
}
