using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class TestObject : MoveableObject
    {
        private char mVisRep = (char)64;
        public override char VisRepresentation
        {
            get { return mVisRep; }
        }

        public override void Update()
        {
            
        }
    }
}
