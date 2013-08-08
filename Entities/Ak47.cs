using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Ak47 : Weapon
    {
        public Ak47()
        {
            Damage = 8;

            Ammunition = 10;

            Range = 11;

            Firespeed = 6;

            Bulletspeed = 14;

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