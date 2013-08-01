using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses.Manager;

namespace AsciiShooter
{
    public abstract class MoveableObject : GameObject
    {
        //for Recognizing Position changes
        public bool hasChanged = false;

        //visibleRepresentation
        abstract public char VisRepresentation
        {
            get;
        }

        //Last Position of the Object
        public Vector2 LastPosition
        {
            get;
            private set;
        }

        //Current Position of the Object
        private Vector2 mPosition;
        public Vector2 Position
        {
            get { return mPosition; }
            set
            {
                if (value != mPosition)
                {
                    hasChanged = true;
                    LastPosition = mPosition;
                    mPosition = value;
                }
            }
        }

        //Velocity of Object in Units per Second
        public Vector2 Velocity
        {
            get;
            set;
        }

        //Constructor (Initialize Object)
        public MoveableObject()
        {
            Position = new Vector2(0, 0);
            MoveableObjectManager.Add(this);
        }

        public override void Destroy()
        {
            MoveableObjectManager.Remove(this);
            base.Destroy();
        }
    }
}
