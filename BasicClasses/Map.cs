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

        /// <summary>
        /// Load Map
        /// by Val Tamer
        /// </summary>
        /// <param name="place">Map Index</param>
        public void Load(int place)
        {
            String appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                String[] level = System.IO.File.ReadAllLines(appDirectory + "editorlevel" + place);
                for (int i = 0; i < level.Count(); i++)
                {
                    char[] temp = level[i].ToCharArray();
                    for (int j = 0; j < temp.GetLength(0); j++)
                    {
                        Field[j, i] = temp[j];
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read.");
            }
        }
    }
}
