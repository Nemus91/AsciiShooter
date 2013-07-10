using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses.Manager;

namespace AsciiShooter
{
    public class Game : GameObject
    {
        char[,] Map;
        char[,] lastMap;
        List<char> MassiveObjects = new List<char>();
        List<char> Collectibles = new List<char>();
        List<MoveableObject> Entities = new List<MoveableObject>();


        //Constructor
        public Game(int Width, int Height)
        {
            Map = new char[Width, Height];
            lastMap = new char[Width, Height];
            MapInit();
            Spawn();
        }

        private void MapInit()
        {
            Console.Clear();
            //Load Map here
            //Test Initialize
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    if (y == 0 || y == Map.GetLength(1)-1)
                        Map[x, y] = (char)45;
                    if (x == 0 || x == Map.GetLength(0)-1)
                        Map[x, y] = (char)124;
                }
            }
        }

        /// <summary>
        /// Initial Spawn of Game Entities (Player, Enemies, Powerups, etc.)
        /// </summary>
        private void Spawn()
        {
            TestObject Test = new TestObject();
            Test.Position = new Vector2(10, 10);
            Test.Velocity = new Vector2(2, 2);
            Entities.Add(Test);
            TestObject Test2 = new TestObject();
            Test2.Position = new Vector2(10, 5);
            Test2.Velocity = new Vector2(2, 0);
            Entities.Add(Test2);
            TestObject Test3 = new TestObject();
            Test3.Position = new Vector2(10, 13);
            Test3.Velocity = new Vector2(0, 7);
            Entities.Add(Test3);
            Entities.Remove(Test3);
            Test3.Destroy();
        }

        public override void Update()
        {
            ChangeMap();
            Draw();
        }

        /// <summary>
        /// Redraws changes in MapArray
        /// </summary>
        private void Draw()
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


        /// <summary>
        /// Applies Entity-Position changes to MapArray
        /// </summary>
        public void ChangeMap()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].hasChanged)
                {
                    Map[Entities[i].LastPosition.X, Entities[i].LastPosition.Y] = (char)0;
                    Map[Entities[i].Position.X, Entities[i].Position.Y] = Entities[i].VisRepresentation;
                    Entities[i].hasChanged = false;
                }
            }
        }
    }
}
