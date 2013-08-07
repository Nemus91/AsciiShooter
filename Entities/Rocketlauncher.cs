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
            Damage = 11;

            Ammunition = 3;

            Range = 14;

            Firespeed = 2;

            Bulletspeed = 16;

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