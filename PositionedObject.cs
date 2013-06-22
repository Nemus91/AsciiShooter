using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class PositionedObject
    {
        //The Position of the Object
        public Vector2 Position
        {
            get;
            protected set;
        }

        //Constructor (Initialize Object)
        PositionedObject()
        {
            Program.AddObject(this);
            Position = new Vector2(0, 0);
        }

        //"Destructor" (Removes Object from Program's ObjectList)
        public virtual void Destroy()
        {
            Program.RemoveObject(this);
        }

        /// <summary>
        /// The Update Method is called every frame
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
