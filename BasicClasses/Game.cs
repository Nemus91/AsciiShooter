using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses;

namespace AsciiShooter
{
    public class Game : GameObject
    {

        Map Map;
        List<char> SolidObjects = new List<char>(new char []{'#'});
        List<char> Collectibles = new List<char>();
        List<MoveableObject> Entities = new List<MoveableObject>();

        //Constructor
        public Game(int Width, int Height)
        {
            Map = new Map (Width, Height);
            MapInit();
            Spawn();
        }

        private void MapInit()
        {
            Console.Clear();
            Map.Load("");
            Map.Draw();
        }

        /// <summary>
        /// Initial Spawn of Game Entities (Player, Enemies, Powerups, etc.)
        /// </summary>
        private void Spawn()
        {
            Player P = new Player(10, 10);
            Entities.Add(P);
        }

        public override void Update()
        {
            Draw();
        }

        /// <summary>
        /// Redraws changes in MapArray
        /// </summary>
        //private void Draw()
        //{
        //    //Check for every Position if something changed and then rewrite it
        //    for (int y = 0; y < Map.GetLength(1); y++)
        //    {
        //        for (int x = 0; x < Map.GetLength(0); x++)
        //        {
        //            if (Map[x, y] != lastMap[x, y])
        //            {
        //                Console.SetCursorPosition(x, y);
        //                Console.Write(Map[x, y]);
        //            }
        //        }
        //    }
        //    //Copy the data from Map into lastMap
        //    for (int i = 0; i < Map.GetLength(0); i++)
        //    {
        //        Array.Copy(Map, i * Map.GetLength(1), lastMap, i * Map.GetLength(1), Map.GetLength(1));
        //    }
        //}


        /// <summary>
        /// Redraws Objects which have changed Position
        /// A moved Object will always be drawn on top
        /// For Objects that didn't moved, those who've been added first to the Entity list are drawn on top
        /// </summary>
        public void Draw()
        {
            for (int i = Entities.Count-1; i >= 0; i--)
            {
                if (Entities[i].hasChanged)
                {
                    //Check if there was an Object behind the moved Entity and draw it.
                    bool isFieldEmpty = true;
                    Console.SetCursorPosition(Entities[i].LastPosition.X, Entities[i].LastPosition.Y);
                    foreach (MoveableObject Entity in Entities)
                    {
                        if (Entity.Position == Entities[i].LastPosition)
                        {
                            Console.Write(Entity.VisRepresentation);
                            isFieldEmpty = false;
                            break;
                        }
                    }
                    //if there's no other object to draw, delete the moved Entity's Symbol
                    if (isFieldEmpty)
                    {
                        Console.Write((char)0);
                    }
                    //Draw Symbol of the moved Object at new Location
                    Console.SetCursorPosition(Entities[i].Position.X, Entities[i].Position.Y);
                    Console.Write(Entities[i].VisRepresentation);

                    Entities[i].hasChanged = false;
                }
            }
        }
    }
}
