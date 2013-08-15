using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses;
using AsciiShooter.BasicClasses.Manager;
using AsciiShooter.Entities;
using System.Threading;

namespace AsciiShooter
{
    public class Game : GameObject
    {
        Map Map;
        Player PlayerInstance;

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
            Random tempRnd = new Random();
            Console.Clear();
            Map.Load(1);            
            Map.Draw();
            MoveableObjectManager.Map = Map;
        }

        /// <summary>
        /// Initial Spawn of Game Entities (Player, Enemies, Powerups, etc.)
        /// </summary>
        private void Spawn()
        {
            for (int y = 0; y < Map.Field.GetLength(1)-1; y++)
            {
                for (int x = 0; x < Map.Field.GetLength(0) - 1; x++)
                {
                    //Spawnpoint Player
                    if (Map.Field[x, y] == 'X')
                    {
                        Map.Field[x, y] = ' ';
                        if (PlayerInstance == null)
                            PlayerInstance = new Player(x, y);
                        else
                            PlayerInstance.Position = new Vector2(x, y);                       
                    }
                    //End of Level
                    if (Map.Field[x, y] == 'O')
                    {
                        Map.Field[x, y] = ' ';
                        EndOfLevel End = new EndOfLevel(x, y);
                        End.Game = this;   
                    }
                    //Spawn Enemies
                    if (Map.Field[x, y] == 'E')
                    {
                        Map.Field[x, y] = ' ';
                        Enemy enemy = new Enemy(x, y);
                        enemy.Player = PlayerInstance;
                        enemy.Map = Map;
                    }
                }
            }
            //bool hasSpawned = false;
            //Random tempRnd = new Random();
            //while (!hasSpawned)
            //{
            //    Vector2 Spawn = new Vector2(tempRnd.Next(Map.Field.GetLength(1)), Map.Field.GetLength(2));
            //    if (Map.Field[Spawn.X, Spawn.Y] == ' ')

            //}
           
        }

        /// <summary>
        /// Loads new Map, spawns Enemies
        /// </summary>
        public void Nextlevel()
        {
            //currently hard-coded for 9 existing maps (1-9)
            //Map 0 is kept as Editor standard map and not used in game
            Random tempRandom = new Random();
            Map.Load(tempRandom.Next(1, 10));
            Map.Draw();
            MoveableObjectManager.Map = Map;
            Spawn();
        }

        /// <summary>
        /// Unloads Map and clears entity list (except for the Player)
        /// </summary>
        public void Endlevel()
        {
            MoveableObjectManager.finish = true;
            Shop Shop = new Shop(PlayerInstance);
            Shop.game = this;
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