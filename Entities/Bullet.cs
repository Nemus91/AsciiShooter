using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Bullet: MoveableObject
    {
        public override char VisRepresentation
        {
            get
            {
                return (char)111; 
            }
        }

        public override void Update()
        {
            if (hasChanged)
            {
                Range --;
            }
            if (Range ==0)
            {
                Destroy();
            }
        }

        public int Damage;
        public int Range;
    }
}
