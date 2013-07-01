using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class MoveableObject : GameObject
    {
        //The Position of the Object
        public Vector2 Position
        {
            get;
            protected set;
        }

        //Constructor (Initialize Object)
        public MoveableObject()
        {
            Position = new Vector2(0, 0);
        }

        public MoveableObject(Vector2 Position)
        {
            this.Position = Position;
        }

        /// <summary>
        /// The Update Method is called every frame
        /// </summary>
        public override void Update()
        {

        }
    }
}
