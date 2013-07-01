using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class Menu : GameObject
    {
        String[] Button;
        Action[] OnButtonPush;
        int CursorPosition = 1;

        public Menu(int AmountButtons)
        {
            Button = new string[AmountButtons];
            OnButtonPush = new Action[AmountButtons];
        }

        public void SetButton (int Index, string text, Action Callback)
        {
            Button[Index] = text;
            OnButtonPush[Index] = Callback;
            Draw();
        }

        public override void Update()
        {
            Controls();
            Draw();
        }

        private void Draw()
        {
            for (int i = 1; i <= Button.Length; i++)
            {
                Console.SetCursorPosition(10, i * 5);
                Console.Write(Button[i-1]);
            }
            Console.SetCursorPosition(9, CursorPosition*5);
            Console.Write((char)62);
        }

        private void Controls()
        {
            
        }
    }
}
