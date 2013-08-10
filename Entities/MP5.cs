using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class MP5 : Weapon
    {
        public MP5()
        {
            Damage = 5;

            Ammunition = 10;

            Range = 9;

            Firespeed = 6;

            Bulletspeed = 14;

            Symbol = (char)77;

            Name = "MP5";

        }

        public override void Update()
        {
        }

        public override char Symbol
        {
            get;
            set;
        }

        public override string Name
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