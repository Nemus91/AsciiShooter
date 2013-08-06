using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.BasicClasses
{
    public class Map
    {
        public char[,] Field;

        public Map(int SizeX, int SizeY)
        {
            Field = new char[SizeX, SizeY];
        }

        public void Draw()
        {
            for (int y = 0; y < Field.GetLength(1); y++)
            {
                for (int x = 0; x < Field.GetLength(0); x++)
                { 
                        Console.SetCursorPosition(x, y);
                        Console.Write(Field[x, y]);
                }
            }
        }

        public void Load(string Filename)
        {
            //Test Load
            for (int y = 0; y < Field.GetLength(1); y++)
            {
                for (int x = 0; x < Field.GetLength(0); x++)
                {
                    if (y == 0 || y == Field.GetLength(1) - 1)
                        Field[x, y] = (char)45;
                    if (x == 0 || x == Field.GetLength(0) - 1)
                        Field[x, y] = (char)124;
                }
            }
        }
    }
}
