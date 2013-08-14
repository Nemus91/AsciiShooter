using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class EndOfLevel : MoveableObject
    {
        public Game Game;

        public EndOfLevel(int x, int y)
        {
            Position = new Vector2(x, y);
            hasCollision = false;
        }

        public override char VisRepresentation
        {
            get { return 'X'; }
        }

        public override void OnCollide(MoveableObject Other)
        {
            if (Other.GetType() == typeof (Player))
            {
                Game.Endlevel();
            }
        }
    }
}
