using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiShooter.BasicClasses;
using AsciiShooter.BasicClasses.StaticClasses;

namespace AsciiShooter.Entities
{
    public class Enemy : MoveableObject
    {
        private int Bounty = 30;

        private int mHealth = 10;
        public int Health
        {
            get
            {
                return mHealth;
            }
            set
            {
                if (value <= 0)
                {
                    Player.Money += Bounty;
                    Destroy();
                }
                else
                    mHealth = value;
            }
        }
        private int Damage = 10;
        private int Movementspeed = 5;
        private int AcquisitionRange = 11;

        public Player Player
        {
            private get;
            set;
        }
        public Map Map
        {
            private get;
            set;
        }

        public Enemy(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public override char VisRepresentation
        {
            get { return (char)164; }
        }

        public override void Update()
        {
            KI();
        }

        public override void OnCollide(MoveableObject Other)
        {
            if (Other == Player)
                Attack(Player);
        }

        private void Attack(Player Player)
        {
            int ReducedDamage = Damage;
            ReducedDamage -= Player.Armor;
            if (ReducedDamage > 0)
                Player.Health -= ReducedDamage;
        }

        private void KI()
        {
            if (Player != null && Map != null && (Position - Player.Position).GetLength() <= AcquisitionRange)
            {
                Vector2 Direction = Player.Position - Position;
                Direction.Normalize();
                Velocity = Direction * Movementspeed;

                //Pathfinding freezes 
                //Vector2 NextField = Pathfinding.GetNextField(Position, Player.Position, Map);
                //Vector2 Direction = Position - NextField;
                //Velocity = Movementspeed * Direction;
            }
            else
                Velocity = new Vector2(0, 0);
        }

    }
}
