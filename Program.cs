using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsciiShooter
{
    public static class Program
    {
        static TimeSpan MinFrameLength = TimeSpan.FromMilliseconds(10);
        static List<PositionedObject> ObjectList = new List<PositionedObject>();
        static int sizeHeight = 50;
        static int sizeWidth = 2*sizeHeight;
        static char[,] Map = new char[sizeWidth, sizeHeight];
        static char[,] lastMap = new char[sizeWidth, sizeHeight];
        public static bool CloseApplication = false;
        public static bool PauseApplication = false;
        
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Initialize();
            while (!CloseApplication)
                Update(DateTime.Now);
        }

        /// <summary>
        /// Initialization Method setting the Windows Size and filling the "Map" with empty Spaces
        /// </summary>
        private static void Initialize()
        {
            //Set Window Height
            Console.SetBufferSize(sizeWidth, sizeHeight);
            if (sizeHeight+5 <= Console.LargestWindowHeight)
                Console.WindowHeight = sizeHeight+5;
            else
                Console.WindowHeight = Console.LargestWindowHeight;

            //Set Window Width
            Console.BufferWidth = Console.LargestWindowWidth;
            if (sizeWidth <= Console.LargestWindowWidth)
                Console.WindowWidth = sizeWidth;
            else
                Console.WindowWidth = Console.LargestWindowWidth;

            //Fill Array with empty spaces
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Map[x, y] = (char)0;
                    Console.Write(Map[x, y]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Called at most every MinFrameLength or else when the last call is finished
        /// Calls Update-Method of every PositinedObject and Updates the "Map"
        /// </summary>
        /// <param name="GameTime"></param>
        private static void Update(DateTime GameTime)
        {
            //Check for Pause
            while (PauseApplication)
                Thread.Sleep(10);

            //Update GameData
            foreach (PositionedObject Obj in ObjectList)
                Obj.Update();
            UpdateMap();

            //Draw Output
            Draw();

            //Check if MinframeLength is reached, else wait for it
            TimeSpan TimeDifference = DateTime.Now - GameTime;
            if (TimeDifference < MinFrameLength)
                Thread.Sleep(MinFrameLength - TimeDifference);
        }

        /// <summary>
        /// Updates graphical Output
        /// </summary>
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
                Array.Copy(Map, i*Map.GetLength(1), lastMap, i*Map.GetLength(1), Map.GetLength(1));
            }
        }

        /// <summary>
        /// Add Object to program's ObjectList
        /// Update-Method of every Object in List is called every frame
        /// </summary>
        /// <param name="obj">Object to add</param>
        public static void AddObject(PositionedObject obj)
        {
            ObjectList.Add(obj);
        }

        /// <summary>
        /// Removing Object from program's ObjectList
        /// Update-Method of every Object in List is called every frame
        /// </summary>
        /// <param name="obj">Object to remove</param>
        public static void RemoveObject(PositionedObject obj)
        {
            
        }

        /// <summary>
        /// Updates the Map-Array
        /// </summary>
        private static void UpdateMap()
        {
            ChangeMap();

            //TEST GEAR
            // Gear g1 = new Gear();
            // g1.Upgrade();
        }


        //test methods
        static int z = 0;
        static Random a = new Random(20);
        private static void ChangeMap()
        {
            z++;
            if (z % 2 == 0)
            {

                int x = a.Next(sizeWidth);
                int y = a.Next(sizeHeight);
                int c = a.Next(20);
                Map[x, y] = (char)(64+c);
                System.Diagnostics.Debug.WriteLine(x + " " + y);
            }
        }
    }
}
