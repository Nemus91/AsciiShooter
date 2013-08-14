using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;

namespace AsciiShooter
{
    public class Editor : GameObject
    {

        static char[,] Map;
        static char[,] lastMap;
        static bool first= true;
        static bool endpointset = false;
        static bool startpointset = false;


        public Editor(int Width, int Height)
        {
            Map = new char[Width, Height];
            lastMap = new char[Width, Height];
            Init();
        }

        private void Init()
        {
            char[,] editormap = new char[100, 50];

            Random random = new Random();

            Console.Clear();
            Console.CursorVisible = true;
            load(0);

            Console.WriteLine("EDITOR");
            Console.WriteLine("Arrows: Move, Enter: Place Wall/Place Floor");
            Console.WriteLine("X: Set End Point/Remove End Point, O: Set Start Point/Remove Start Point, E: Add Enemy Spawnpoint/Remove Enemy Spawnpoint");
            Console.WriteLine("L/S + 1-9: Load/Save Slot 1-9");
            
        }

        
  public override void Update()
        {
            Draw();
            Controls();
        }


  private void Controls()
  {
      if (Input.GetKeyState(ConsoleKey.DownArrow) == Input.AsyncKeyState.HasBeenPressed && Console.CursorTop < Map.GetLength(1)+3)
      {
        
              Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop += 1);
      }



      if (Input.GetKeyState(ConsoleKey.UpArrow) == Input.AsyncKeyState.HasBeenPressed && Console.CursorTop >6)
      {
          Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop -= 1);
      }

      if (Input.GetKeyState(ConsoleKey.LeftArrow) == Input.AsyncKeyState.HasBeenPressed && Console.CursorLeft >1)
          
      {
     
          Console.SetCursorPosition(Console.CursorLeft -= 1, Console.CursorTop);
      }

      if (Input.GetKeyState(ConsoleKey.RightArrow) == Input.AsyncKeyState.HasBeenPressed && Console.CursorLeft < Map.GetLength(0)-2)
      {
        
          Console.SetCursorPosition(Console.CursorLeft += 1, Console.CursorTop);
      }


      if (Input.GetKeyState(ConsoleKey.Enter) == Input.AsyncKeyState.HasBeenPressed)
      {

          if (!(Console.CursorTop > Map.GetLength(1)+6 || Console.CursorLeft > Map.GetLength(0)))
          {
              if (Map[Console.CursorLeft, Console.CursorTop - 5] == '#')
              {
                  Map[Console.CursorLeft, Console.CursorTop - 5] = ' ';
              }
              else if (Map[Console.CursorLeft, Console.CursorTop - 5] == ' ')
              {
                  Map[Console.CursorLeft, Console.CursorTop - 5] = '#';
              }
          }
      }
      if (Input.GetKeyState(ConsoleKey.X) == Input.AsyncKeyState.HasBeenPressed)
      {

          if (endpointset == false)
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = 'X';
              endpointset = true;
          }
          else if (Map[Console.CursorLeft, Console.CursorTop - 5] == 'X')
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = ' ';
              endpointset = false;
          }
      }

      if (Input.GetKeyState(ConsoleKey.O) == Input.AsyncKeyState.HasBeenPressed)
      {

          if (startpointset == false)
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = 'O';
              startpointset = true;
          }
          else if (Map[Console.CursorLeft, Console.CursorTop - 5] == 'O')
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = ' ';
              startpointset = false;
          }
      }

      if (Input.GetKeyState(ConsoleKey.E) == Input.AsyncKeyState.HasBeenPressed)
      {

          if (Map[Console.CursorLeft, Console.CursorTop - 5] == ' ')
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = 'E';
          }
          else if (Map[Console.CursorLeft, Console.CursorTop - 5] == 'E')
          {
              Map[Console.CursorLeft, Console.CursorTop - 5] = ' ';
          }
      }

          if ((Input.GetKeyState(ConsoleKey.S) == Input.AsyncKeyState.CurrentlyPressed))
          {
              if (Input.GetKeyState(ConsoleKey.D1) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(1);
              }

              if (Input.GetKeyState(ConsoleKey.D2) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(2);
              }

              if (Input.GetKeyState(ConsoleKey.D3) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(3);
              }

              if (Input.GetKeyState(ConsoleKey.D4) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(4);
              }

              if (Input.GetKeyState(ConsoleKey.D5) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(5);
              }

              if (Input.GetKeyState(ConsoleKey.D6) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(6);
              }

              if (Input.GetKeyState(ConsoleKey.D7) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(7);
              }

              if (Input.GetKeyState(ConsoleKey.D8) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(8);
              }

              if (Input.GetKeyState(ConsoleKey.D9) == Input.AsyncKeyState.HasBeenPressed)
              {
                  save(9);
              }

          }





          if (Input.GetKeyState(ConsoleKey.L) == Input.AsyncKeyState.CurrentlyPressed)
          {
              if (Input.GetKeyState(ConsoleKey.D1) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(1);
              }

              if (Input.GetKeyState(ConsoleKey.D2) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(2);
              }

              if (Input.GetKeyState(ConsoleKey.D3) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(3);
              }

              if (Input.GetKeyState(ConsoleKey.D4) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(4);
              }

              if (Input.GetKeyState(ConsoleKey.D5) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(5);
              }

              if (Input.GetKeyState(ConsoleKey.D6) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(6);
              }

              if (Input.GetKeyState(ConsoleKey.D7) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(7);
              }

              if (Input.GetKeyState(ConsoleKey.D8) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(8);
              }

              if (Input.GetKeyState(ConsoleKey.D9) == Input.AsyncKeyState.HasBeenPressed)
              {
                  load(9);
              }

          }
      }
  
           

          private void Draw()
        {
            
            //Check for every Position if something changed and then rewrite it
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    if (Map[x, y] != lastMap[x, y])
                    {
                        Console.SetCursorPosition(x, y+5);
                        Console.Write(Map[x, y]);
                    }
                }
            }
            //Copy the data from Map into lastMap
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Array.Copy(Map, i * Map.GetLength(1), lastMap, i * Map.GetLength(1), Map.GetLength(1));
            }

            if (first)
            {
                Console.SetCursorPosition(1, 6);
                first = false;
            }
        }


        private void save(int place){
             String appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            String [] level = new string [Map.GetLength(1)];

            for(int i=0; i< Map.GetLength(1); i++){
                for(int j=0; j<Map.GetLength(0); j++){
            level[i] += Map[j,i];
                }
            }

                System.IO.File.WriteAllLines(@appDirectory + "editorlevel"+ place, level);
        }



        private void load(int place){
            String appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                try
                {
                        String[] level = System.IO.File.ReadAllLines(appDirectory + "editorlevel"+ place);
                        for (int i = 0; i < level.Count(); i++)
                        {
                            char[] temp = level[i].ToCharArray();
                            for (int j = 0; j < temp.GetLength(0); j++)
                            {
                                Map[j, i] = temp[j];
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
