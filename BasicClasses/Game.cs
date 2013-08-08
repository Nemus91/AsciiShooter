using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses;
using AsciiShooter.BasicClasses.Manager;
using AsciiShooter.Entities;

namespace AsciiShooter
{
    public class Game : GameObject
    {
        Map Map;

        //Constructor
        public Game(int Width, int Height)
        {
            Map = new Map (Width, Height);
            MapInit();
            Spawn();
        }

        //Initialization Method
        private void MapInit()
        {
            Console.Clear();
            Map.Load("");            
            Map.Draw();
            MoveableObjectManager.Map = Map;
        }

        /// <summary>
        /// Initial Spawn of Game Entities (Player, Enemies, Powerups, etc.)
        /// </summary>
        private void Spawn()
        {
            Player P = new Player(10, 10);
        }


        
    }
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