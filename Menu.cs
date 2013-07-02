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

        /// <summary>
        /// Creates a new Menu with specific a Amount of Buttons
        /// </summary>
        /// <param name="AmountButtons">Amount of Menu Buttons</param>
        public Menu(int AmountButtons)
        {
            Button = new string[AmountButtons];
            OnButtonPush = new Action[AmountButtons];
        }

        /// <summary>
        /// Sets a Buttons text and Method to call when clicked
        /// </summary>
        /// <param name="Index">Index of Button to change (starting at 0)</param>
        /// <param name="text">Text to display</param>
        /// <param name="Callback">OnButtonPush Method</param>
        public void SetButton (int Index, string text, Action Callback)
        {
            Button[Index] = text;
            OnButtonPush[Index] = Callback;
            Console.Clear();
            Draw();
        }

        /// <summary>
        /// Update Method, called by Main Program
        /// Should not be called manually
        /// </summary>
        public override void Update()
        {
            Controls();
            Draw();
        }

        private void Draw()
        {
            for (int i = 1; i <= Button.Length; i++)
            {
                Console.SetCursorPosition(9, i * 5);
                if (i != CursorPosition)
                    Console.Write((char)0);
                else
                    Console.Write((char)62);

                Console.Write(Button[i-1]);
            }
        }

        private void Controls()
        {
            if (Input.GetKeyState(ConsoleKey.DownArrow) == Input.AsyncKeyState.HasBeenPressed)
            {
                if (CursorPosition < Button.Length)
                {
                    CursorPosition++;
                }
            }

            if (Input.GetKeyState(ConsoleKey.UpArrow) == Input.AsyncKeyState.HasBeenPressed)
            {
                if (CursorPosition > 1)
                {
                    CursorPosition--;
                }
            }

            if (Input.GetKeyState(ConsoleKey.Enter) == Input.AsyncKeyState.HasBeenPressed)
            {
                OnButtonPush[CursorPosition - 1]();
                base.Destroy();
            }
        }
    }
}
