using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter.Entities
{
    public class Collectable : MoveableObject
    {
        Weapon Item;

        public override char VisRepresentation
        {
            get { return Item.Symbol; }
        }

        public Collectable(Weapon Item, int X, int Y)
        {
            this.Item = Item;
            Position.X = X;
            Position.Y = Y;
            hasCollision = false;
        }

        public override void OnCollide(MoveableObject Other)
        {
            if (Other.GetType()==typeof(Player))
            {
                ((Player)Other).Weaponlist.Add(Item);
                Destroy();

            }

        }


    }
}
