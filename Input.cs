using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace AsciiShooter
{
    public class Input
    {
        //saves whether Key has been pressed before
        static Hashtable LastTimePressed = new Hashtable();

        /// <summary>
        /// Initializes LastTimePressed-Hashtable
        /// </summary>
        public static void Init()
        {
            foreach (ConsoleKey Key in Enum.GetValues(typeof(ConsoleKey)))
            {
                LastTimePressed.Add(Key, false);
            }
        }
        
        [Flags]
        public enum AsyncKeyState : short
        {
            CurrentlyPressed = short.MinValue,
            HasNotBeenPressed = 0,
            HasBeenPressed
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern AsyncKeyState GetAsyncKeyState(ConsoleKey Key);

        /// <summary>
        /// Returns whether a specific Key has been pressed once, is still pressed or is net pressed
        /// </summary>
        /// <param name="Key">ConsoleKey to check on</param>
        /// <returns>returns element of AsyncKeyState</returns>
        public static AsyncKeyState GetKeyState (ConsoleKey Key)
        {
            if (Input.GetAsyncKeyState(Key) != Input.AsyncKeyState.HasNotBeenPressed)
            {
                if ((bool)LastTimePressed[Key])
                    return AsyncKeyState.CurrentlyPressed;
                else
                {
                    LastTimePressed[Key] = true;
                    return AsyncKeyState.HasBeenPressed;
                }
            }
            else
            {
                LastTimePressed[Key] = false;
                return AsyncKeyState.HasNotBeenPressed;
            }
        }
    }
}
