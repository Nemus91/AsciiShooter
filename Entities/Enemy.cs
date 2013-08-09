using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    class Enemy : MoveableObject
    {
        public override char VisRepresentation
        {
            get { throw new NotImplementedException(); }
        }

        public int Health = 10;
    }
}
