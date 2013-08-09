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

            Symbol = (char)65;

            Name = "Ak47";

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