using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class Menu
    {
        String[] Button;
        int CursorPosition = 1;
        public delegate void ButtonPushed ();

        public Menu(int AmountButtons)
        {
            Button = new string[AmountButtons];
        }

        public void SetButton (int Index, string text)
        {
            Button[Index] = text;
            Draw();
        }

        public void Draw()
        {
            for (int i = 1; i <= Button.Length; i++)
            {
                Console.SetCursorPosition(10, i * 5);
                Console.Write(Button[i-1]);
            }
            Console.SetCursorPosition(9, CursorPosition*5);
            Console.Write((char)62);
        }

        private void Control()
        {
            

        }
    }
}
