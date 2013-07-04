using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AsciiShooter
{
    public class Editor : GameObject
    {
        public Editor()
        {
            Init();
        }

        private void Init()
        {
           char[,] editormap = new char[100,50];

            Random random = new Random();

            //for (int i = 0; i < editormap.GetLength(1); i++)
            //{
            //    for (int j = 0; j < editormap.GetLength(0); j++)
            //    {
            //        editormap[j, i] = (random.Next(1, 3) == 1) ? '*' : '-';
            //    }
            //}


            Console.Clear();
            Console.WriteLine("EDITOR");
            Console.WriteLine("Arrows: Move");
            Console.WriteLine("#: Place Wall");
            Console.WriteLine("-: Place Floor");
            Console.WriteLine("L/S: Load/Save");

            String appDirectory = AppDomain.CurrentDomain.BaseDirectory;
           using (StreamWriter sw = new StreamWriter("editorlevel"))


           try{
                using (StreamReader sr = new StreamReader(appDirectory + "editorlevel.txt"))
	      {
              String line;
              while((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
	     }
            

        } catch (Exception e){
            Console.WriteLine("File could not be read.");
        }
}

        public override void Update()
        {
            
        }
    }
}
