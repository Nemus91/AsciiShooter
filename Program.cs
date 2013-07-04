using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsciiShooter
{
    public static class Program
    {        
        const int sizeHeight = 50;
        const int sizeWidth = 2*sizeHeight;
        const bool setBufferSizeFull = true;
        static readonly TimeSpan MinFrameLength = TimeSpan.FromMilliseconds(10);
        static List<GameObject> ObjectList = new List<GameObject>();
        public static bool CloseApplication = false;
        public static bool PauseApplication = false;


        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Initialize();

            do
                Update(DateTime.Now);
            while (!CloseApplication);                
        }

        /// <summary>
        /// calls Initialization Methods
        /// </summary>
        private static void Initialize()
        {
            Input.Init();
            ConsoleInit();
            MenuInit();
        }

        /// <summary>
        /// Sets Buffer- and WindowSize
        /// </summary>
        private static void ConsoleInit()
        {
            Console.CursorVisible = false;
            //SetBufferSize
            if (setBufferSizeFull)
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            else
                Console.SetBufferSize(sizeWidth, sizeHeight);

            //Set Window Height
            if (sizeHeight + 5 <= Console.LargestWindowHeight)
                Console.WindowHeight = sizeHeight + 5;
            else
                Console.WindowHeight = Console.LargestWindowHeight;

            //Set Window Width
            if (sizeWidth <= Console.LargestWindowWidth)
                Console.WindowWidth = sizeWidth;
            else
                Console.WindowWidth = Console.LargestWindowWidth;
        }


        private static void MenuInit()
        {
            Menu MainMenu = new Menu(3);
            Action tempAction = new Action(StartGame);
            MainMenu.SetButton(0, "Start Game", tempAction);
            tempAction = new Action(StartEditor);
            MainMenu.SetButton(1, "Start Editor", tempAction);
            tempAction = new Action(ExitGame);
            MainMenu.SetButton(2, "End Game", tempAction);
        }


        private static void StartGame()
        {
            Game Game = new Game(sizeWidth, sizeHeight);
        }

        private static void StartEditor()
        {
            Editor Editor = new Editor();
        }

        private static void ExitGame()
        {

        }
        


        /// <summary>
        /// Called at most every MinFrameLength or else when the last call is finished
        /// Calls Update-Method of every PositinedObject and updates the "Map"
        /// </summary>
        /// <param name="GameTime"></param>
        private static void Update(DateTime GameTime)
        {
            //Check for Pause
            while (PauseApplication)
                Thread.Sleep(10);

            //Update GameData
            for (int i = 0; i < ObjectList.Count; i++ )
            {
                ObjectList[i].Update();
            }
            //Check if MinframeLength is reached, else wait for it
            TimeSpan TimeDifference = DateTime.Now - GameTime;
            if (TimeDifference < MinFrameLength)
                Thread.Sleep(MinFrameLength - TimeDifference);
        }

        

        /// <summary>
        /// Add Object to program's ObjectList
        /// Update-Method of every Object in List is called every frame
        /// </summary>
        /// <param name="obj">Object to add</param>
        public static void AddObject(GameObject obj)
        {
            ObjectList.Add(obj);
        }

        /// <summary>
        /// Removing Object from program's ObjectList
        /// Update-Method of every Object in List is called every frame
        /// </summary>
        /// <param name="obj">Object to remove</param>
        public static void RemoveObject(GameObject obj)
        {
            ObjectList.Remove(obj);   
        }
    }
}
