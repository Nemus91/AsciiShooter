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

            Firespeed = 3;

            Bulletspeed = 12;

            Symbol = (char) 80;

            Name = "Pistol";

        }

        public override char Symbol
        {
            get;
            set;
        }

        public override string  Name
        {
            get;
            set;
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
