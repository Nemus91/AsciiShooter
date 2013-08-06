using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
   
    public abstract class Weapon : MoveableObject
    {
        public Weapon()
        {
            hasCollision = false;
        }

        public abstract int Damage
        {
            get;
            set;
        }

        public abstract int Ammunition
        {
            get;
            set;
        }

        public abstract int Range
        {
            get;
            set;
        }

        public abstract int Firespeed
        {
            get;
            set;
        }

        public abstract int Bulletspeed
        {
            get;
            set;
        }
    }
}
