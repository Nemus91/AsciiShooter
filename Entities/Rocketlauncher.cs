using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Rocketlauncher : Weapon
    {
        public Rocketlauncher()
        {
            Damage = 11;

            Ammunition = 3;

            Range = 14;

            Firespeed = 2;

            Bulletspeed = 16;

            Symbol = (char)82;

            Name = "Rocketlauncher";

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