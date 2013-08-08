using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Grenade : Weapon
    {
        public Grenade()
        {
            Damage = 12;

            Ammunition = 1;

            Range = 9;

            Firespeed = 2;

            Bulletspeed = 7;

        }

        public override void Update()
        {
        }

        public override char VisRepresentation
        {
            get { return (char)82; }
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