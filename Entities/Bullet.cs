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
                return (char)11; 
            }
        }

        public override void Update()
        {
            if (Position != (LastPosition))
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
