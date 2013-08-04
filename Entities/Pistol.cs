using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Pistol : Weapon
    {
        public Pistol()
        {
            Damage = 5;
            
            Ammunition = -1;

            Range = 9;

            Firespeed = 2;

            Bulletspeed = 12;

        }

        public override char VisRepresentation
        {
            get { return (char)80; }
        }

        public override int Ammunition
        {
            get;
            set;
        }

        public override int Damage
        {
            get;
            set;

        }

        public override int Range
        {
            get;
            set;

        }

        public override int Firespeed
        {
            get;
            set;

        }

        public override int Bulletspeed
        {
            get;
            set;

        }
    }
}
